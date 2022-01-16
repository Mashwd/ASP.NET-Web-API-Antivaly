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
    public class AuthService
    {
        static AuthService()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<Token, TokenModel>();
                cfg.CreateMap<TokenModel, Token>();
            });
        }
        public static TokenModel Auth(UserModel user)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<Token, TokenModel>();
            });
            var db_user = Mapper.Map<User>(user);
            var token = DataSupplier.AuthDataAccess().Authenticate(db_user);
            var tokenModel = Mapper.Map<TokenModel>(token);
            return tokenModel;
        }
        public static bool CheckValidityToken(string token)
        {
            var rs = DataSupplier.AuthDataAccess().IsAuthenticated(token);
            return rs;
        }

        public static Token IsExist(string id)
        {
            var rs = DataSupplier.AuthDataAccess().IsExist(id);
            return rs;
        }

        public static bool Logout(string t)
        {
            return DataSupplier.AuthDataAccess().Logout(t);
        }
    }
}
