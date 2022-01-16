using BEL;
using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CouponService
    {
        static CouponService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Coupon, CouponModel>();
                cfg.CreateMap<CouponModel, Coupon>();
            });
        }

        public static void Create(CouponModel b)
        {
            var data = Mapper.Map<Coupon>(b);
            DataSupplier.CouponDataAccess().Add(data);
        }

        public static void Edit(CouponModel b)
        {
            var data = Mapper.Map<Coupon>(b);
            DataSupplier.CouponDataAccess().Edit(data);
        }

        public static void Delete(string id)
        {
            DataSupplier.CouponDataAccess().Delete(id);
        }

        public static List<CouponModel> Get()
        {
            var data = Mapper.Map<List<CouponModel>>(DataSupplier.CouponDataAccess().Get());
            return data;
        }
        public static CouponModel Get(string id)
        {
            var data = Mapper.Map<CouponModel>(DataSupplier.CouponDataAccess().Get(id));
            return data;
        }

        public static List<CouponModel> GetAvailableCoupons()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Coupon, CouponModel>();
            });
            var data = Mapper.Map<List<CouponModel>>(DataSupplier.CouponDataAccess().Get());
            return data;
        }
    }
}
