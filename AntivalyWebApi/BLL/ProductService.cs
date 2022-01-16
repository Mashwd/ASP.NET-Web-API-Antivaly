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
    public class ProductService
    {
        static ProductService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<ProductModel, Product>();
            });
        }

        public static void Create(ProductModel b)
        {
            var data = Mapper.Map<Product>(b);
            DataSupplier.ProductDataAccess().Add(data);
        }

        public static void Edit(ProductModel b)
        {
            var data = Mapper.Map<Product>(b);
            DataSupplier.ProductDataAccess().Edit(data);
        }

        public static void Delete(int id)
        {
            DataSupplier.ProductDataAccess().Delete(id);
        }

        public static List<ProductModel> Get()
        {
            Mapper.Initialize(cfg =>{cfg.CreateMap<Product, ProductModel>();});
            var data = Mapper.Map<List<ProductModel>>(DataSupplier.ProductDataAccess().Get());
            return data;
        }
        public static ProductModel Get(int id)
        {
            var data = Mapper.Map<ProductModel>(DataSupplier.ProductDataAccess().Get(id));
            return data;
        }

        public static List<ProductModel> GetProductByCategory(string s)
        {
            var data = Mapper.Map<List<ProductModel>>(DataSupplier.ProductDataAccess().GetProductByCategory(s));
            return data;
        }

        public static List<ProductModel> GetProductByProduct(string s)
        {
            var data = Mapper.Map<List<ProductModel>>(DataSupplier.ProductDataAccess().GetProductByProduct(s));
            return data;
        }

        public static List<ProductModel> GetAllHiddenProducts()
        {
            var data = Mapper.Map<List<ProductModel>>(DataSupplier.ProductDataAccess().GetAllHiddenProducts());
            return data;
        }

        public static void HideProduct(int id)
        {
            DataSupplier.ProductDataAccess().HideProduct(id);
        }

        public static void ExhibitProduct(int id)
        {
            DataSupplier.ProductDataAccess().ExhibitProduct(id);
        }
    }
}
