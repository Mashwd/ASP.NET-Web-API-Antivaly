using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class bindhome
    {
        public virtual List<ProductModel> Products { get; set; }
        public virtual List<CouponModel> Coupons { get; set; }
    }
}
