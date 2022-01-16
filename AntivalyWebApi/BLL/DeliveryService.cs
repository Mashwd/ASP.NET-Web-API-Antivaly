using AutoMapper;
using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DeliveryService
    {
        static DeliveryService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Delivery, DeliveryModel>();
                cfg.CreateMap<DeliveryModel, Delivery>();
            });
        }

        public static void Create(DeliveryModel b)
        {
            var data = Mapper.Map<Delivery>(b);
            DataSupplier.DeliveryDataAccess().Add(data);
        }

        public static void Edit(DeliveryModel b)
        {
            var data = Mapper.Map<Delivery>(b);
            DataSupplier.DeliveryDataAccess().Edit(data);
        }

        public static void Delete(string id)
        {
            DataSupplier.DeliveryDataAccess().Delete(id);
        }

        public static List<DeliveryModel> Get()
        {
            var data = Mapper.Map<List<DeliveryModel>>(DataSupplier.DeliveryDataAccess().Get());
            return data;
        }
        public static DeliveryModel Get(string id)
        {
            var data = Mapper.Map<DeliveryModel>(DataSupplier.DeliveryDataAccess().Get(id));
            return data;
        }
    }
}
