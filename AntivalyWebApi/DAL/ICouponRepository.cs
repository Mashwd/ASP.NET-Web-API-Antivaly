using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICouponRepository<T, ID>: IRepository<T, ID>
    {
        List<T> GetAvailableCoupons();
    }
}
