using AntivalyWebApi.Auth;
using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AntivalyWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    [CustomAuth]
    public class DeliveryManController : ApiController
    {
        [Route("api/delivery/orderRequest")]
        [HttpGet]
        public HttpResponseMessage GetProcessing()
        {
            var d = TransactionService.GetProcessing();
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [Route("api/delivery/delivered/{id}")]
        [HttpGet]
        public HttpResponseMessage GetDelivered(string id)
        {
            var d = TransactionService.GetAllDelivered(id);
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [Route("api/delivery/accept/{id}/{tid}")]
        [HttpGet]
        public HttpResponseMessage AcceptOrder(string id, int tid)
        {
            var d = TransactionService.Get(tid);
            d.DMID = id;
            TransactionService.Edit(d);
            var dm = DeliveryService.Get(id);
            dm.Status = "Busy";
            DeliveryService.Edit(dm);
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, "Order Activated.");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [Route("api/delivery/cancel/{id}/{tid}")]
        [HttpGet]
        public HttpResponseMessage CancelDelivery(string id, int tid)
        {
            var d = TransactionService.Get(tid);
            d.DMID = null;
            TransactionService.Edit(d);
            var dm = DeliveryService.Get(id);
            dm.Status = "Free";
            DeliveryService.Edit(dm);
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, "Order canceled.");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [Route("api/delivery/active/order/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAllActive(string id)
        {
            var d = TransactionService.GetAllActive(id);
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [Route("api/delivery/balance/{id}")]
        [HttpGet]
        public HttpResponseMessage GetBalance(string id)
        {
            var d = DeliveryService.Get(id);
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d.Balance);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [CustomAuth]
        [Route("api/delivery/profile/edit")]
        [HttpGet]
        public HttpResponseMessage Edit(UserModel user)
        {
            UserService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated.");
        }
    }
}
