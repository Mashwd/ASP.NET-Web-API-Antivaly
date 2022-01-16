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
    public class BuyerService
    {
        static BuyerService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Buyer, BuyerModel>();
                cfg.CreateMap<BuyerModel, Buyer>();
            });
        }
        public static void Create(BuyerModel b)
        {
            var data = Mapper.Map<Buyer>(b);
            DataSupplier.BuyerDataAccess().Add(data);
        }

        public static void Edit(BuyerModel b)
        {
            var data = Mapper.Map<Buyer>(b);
            DataSupplier.BuyerDataAccess().Edit(data);
        }

        public static void Delete(string id)
        {
            DataSupplier.BuyerDataAccess().Delete(id);
        }

        public static List<BuyerModel> Get()
        {
            var data = Mapper.Map<List<BuyerModel>>(DataSupplier.BuyerDataAccess().Get());
            return data;
        }
        public static BuyerModel Get(string id)
        {

            var data = Mapper.Map<BuyerModel>(DataSupplier.BuyerDataAccess().Get(id));
            return data;
        }
    }
}
