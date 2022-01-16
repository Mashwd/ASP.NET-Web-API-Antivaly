using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserIdService
    {
        public static void Create(UserID b)
        {
            DataSupplier.UserIdDataAccess().Add(b);
        }

        public static void Edit(UserID b)
        {
            DataSupplier.UserIdDataAccess().Edit(b);
        }

        public static void Delete(int id)
        {
            DataSupplier.UserIdDataAccess().Delete(id);
        }

        public static List<UserID> Get()
        {
            return DataSupplier.UserIdDataAccess().Get(); ;
        }
        public static UserID Get(int id)
        {
            return DataSupplier.UserIdDataAccess().Get(id);
        }
    }
}
