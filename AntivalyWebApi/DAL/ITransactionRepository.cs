using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ITransactionRepository<T, ID>: IRepository<T, ID>
    {
        void PlaceOrder(string id, List<Product> p);
        bool CancelOrder(ID id);
        int NumOfSuccessfulOrder(string id);
        List<T> SuccessfulOrders(string id);
        List<T> GetAll(string id);
        List<T> GetProcessing();
        List<T> GetAllDelivered(string id);
        List<T> GetAllActive(string id);
    }
}
