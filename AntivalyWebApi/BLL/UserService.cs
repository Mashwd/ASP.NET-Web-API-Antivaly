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
    public class UserService
    {
        static UserService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
            });
        }

        public static void Create(UserModel b)
        {
            var data = Mapper.Map<User>(b);
            DataSupplier.UserDataAccess().Add(data);
        }

        public static void Edit(UserModel b)
        {
            var data = Mapper.Map<User>(b);
            DataSupplier.UserDataAccess().Edit(data);
        }

        public static void Delete(string id)
        {
            DataSupplier.UserDataAccess().Delete(id);
        }

        public static List<UserModel> Get()
        {
            var data = Mapper.Map<List<UserModel>>(DataSupplier.UserDataAccess().Get());
            return data;
        }
        public static UserModel Get(string id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
            });
            var data = Mapper.Map<UserModel>(DataSupplier.UserDataAccess().Get(id));
            return data;
        }
    }
}
