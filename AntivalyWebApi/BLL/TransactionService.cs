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
    public class TransactionService
    {
        static TransactionService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionModel>();
                cfg.CreateMap<TransactionModel, Transaction>();
            });
        }

        public static void Create(TransactionModel b)
        {
            var data = Mapper.Map<Transaction>(b);
            DataSupplier.TransactionDataAccess().Add(data);
        }

        public static void Edit(TransactionModel b)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TransactionModel, Transaction>();
            });

            var data = Mapper.Map<Transaction>(b);
            DataSupplier.TransactionDataAccess().Edit(data);
        }

        public static void Delete(int id)
        {
            DataSupplier.TransactionDataAccess().Delete(id);
        }

        public static List<TransactionModel> Get()
        {
            var data = Mapper.Map<List<TransactionModel>>(DataSupplier.TransactionDataAccess().Get());
            return data;
        }
        public static TransactionModel Get(int id)
        {
            var data = Mapper.Map<TransactionModel>(DataSupplier.TransactionDataAccess().Get(id));
            return data;
        }

        public static void PlaceOrder(string id, List<ProductModel> p)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductModel, Product>();
            });
            DataSupplier.TransactionDataAccess().PlaceOrder(id, Mapper.Map<List<Product>>(p));
        }

        public static bool CancelOrder(int id)
        {
            return DataSupplier.TransactionDataAccess().CancelOrder(id);
        }

        public static int NumOfSuccessfulOrder(string id)
        {
            return DataSupplier.TransactionDataAccess().NumOfSuccessfulOrder(id);
        }

        public static List<TransactionModel> SuccessfulOrders(string id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionModel>();
            });
            return Mapper.Map<List<TransactionModel>>(DataSupplier.TransactionDataAccess().SuccessfulOrders(id));
        }

        public static List<TransactionModel> GetAll(string id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionModel>();
            });
            return Mapper.Map<List<TransactionModel>>(DataSupplier.TransactionDataAccess().GetAll(id));
        }
        public static List<TransactionModel> GetProcessing()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionModel>();
            });
            return Mapper.Map<List<TransactionModel>>(DataSupplier.TransactionDataAccess().GetProcessing());
        }

        public static List<TransactionModel> GetAllDelivered(string id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionModel>();
            });
            return Mapper.Map<List<TransactionModel>>(DataSupplier.TransactionDataAccess().GetAllDelivered(id));

        }

        public static List<TransactionModel> GetAllActive(string id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionModel>();
            });
            return Mapper.Map<List<TransactionModel>>(DataSupplier.TransactionDataAccess().GetAllActive(id));

        }
    }
}
