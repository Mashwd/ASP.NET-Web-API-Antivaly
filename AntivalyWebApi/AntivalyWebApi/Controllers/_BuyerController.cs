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
using System.Web.Script.Serialization;


namespace AntivalyWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class _BuyerController : ApiController
    {
        [Route("api/buyer/home")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var d = ProductService.Get();
            /*var c = CouponService.GetAvailableCoupons();

            *//*var d = new bindhome();
            d.Coupons = c;
            d.Products = p;*/
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [Route("api/buyer/home/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var d = ProductService.Get(id);
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [Route("api/buyer/home/category/{s}")]
        [HttpGet]
        public HttpResponseMessage GetProductByCategory(string s)
        {
            var d = ProductService.GetProductByCategory(s);
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [Route("api/buyer/home/product/{s}")]
        [HttpGet]
        public HttpResponseMessage GetProductByProduct(string s)
        {
            var d = ProductService.GetProductByProduct(s);
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [CustomAuth]
        [Route("api/buyer/placeOrder/{id}")]
        [HttpPost]
        public HttpResponseMessage PlaceOrder(string id, List<ProductModel> p)
        {
            TransactionService.PlaceOrder(id, p);
            if (p != null)
                return Request.CreateResponse(HttpStatusCode.OK, "Order placed.");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty cart!");
        }

        [CustomAuth]
        [Route("api/buyer/cancelOrder/{id}")]
        [HttpPost]
        public HttpResponseMessage CancelOrder(int id)
        {
            var d = TransactionService.CancelOrder(id);
            if (d)
                return Request.CreateResponse(HttpStatusCode.OK, "Order canceled.");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "No in-processing orders exist!");
        }


        [Route("api/buyer/home/coupon")]
        [HttpGet]
        public HttpResponseMessage GetCoupon()
        {
            var l = CouponService.GetAvailableCoupons();
            if (l != null)
                return Request.CreateResponse(HttpStatusCode.OK, l);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty!");
        }

        [CustomAuth]
        [Route("api/buyer/home/get/category")]
        [HttpGet]
        public HttpResponseMessage GetAllcategory()
        {
            var l = CategoryService.Get();
            if (l != null)
                return Request.CreateResponse(HttpStatusCode.OK, l);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty!");
        }

        [CustomAuth]
        [Route("api/buyer/profile/{id}")]
        [HttpGet]
        public HttpResponseMessage GetUser(string id)
        {
            var l = UserService.Get(id);
            if (l != null)
                return Request.CreateResponse(HttpStatusCode.OK, l);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty!");
        }

        [CustomAuth]
        [Route("api/buyer/profile/edit")]
        [HttpGet]
        public HttpResponseMessage Edit(UserModel user)
        {
            UserService.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated.");
        }

        
        [Route("api/buyer/NumOrder/{id}")]
        [HttpGet]
        public HttpResponseMessage NumOrder(string id)
        {
            var d = TransactionService.NumOfSuccessfulOrder(id);
            if (d > 0)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            return Request.CreateResponse(HttpStatusCode.NotFound, "No orders. =>" + d);
        }

        
        [Route("api/buyer/rank/{id}")]
        [HttpGet]
        public HttpResponseMessage GetRank(string id)
        {
            var d = TransactionService.SuccessfulOrders(id);
            double total = 0;
            string rank = "";
            foreach (var i in d)
            {
                total += i.TAmount;
            }
            if (total < 1000)
                rank = "Bronze";
            else if (total > 1000 && total < 3000)
                rank = "Silver";
            else if (total > 3000 && total < 6000)
                rank = "Gold";
            else if (total > 6000 && total < 10000)
                rank = "Platinum";

            return Request.CreateResponse(HttpStatusCode.OK, rank);
        }

        
        [Route("api/buyer/reward/{id}")]
        [HttpGet]
        public HttpResponseMessage RewardPoints(string id)
        {
            var d = TransactionService.SuccessfulOrders(id);
            double total = 0;
            foreach (var i in d)
            {
                total += i.TAmount;
            }


            return Request.CreateResponse(HttpStatusCode.OK, (total / 100) * 10);
        }

        [CustomAuth]
        [Route("api/buyer/transaction/{id}")]
        [HttpGet]
        public HttpResponseMessage Transactions(string id)
        {
            var d = TransactionService.GetAll(id);

            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty.");

        }

        [Route("api/coupon")]
        [HttpGet]
        public HttpResponseMessage Coupons()
        {
            var d = CouponService.GetAvailableCoupons();

            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty.");

        }

        [CustomAuth]
        [Route("api/coupon/discount/{coupon}")]
        [HttpGet]
        public HttpResponseMessage Coupons(string coupon)
        {
            var d = CouponService.Get(coupon);
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d.Discount);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid Coupon.");
        }
    }
}
