using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL
{
    public class TransactionRepo: ITransactionRepository<Transaction, int>
    {
        AntivalyEntities db;

        public TransactionRepo(AntivalyEntities db)
        {
            this.db = db;
        }

        public void Add(Transaction e)
        {
            this.db.Transactions.Add(e);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var transaction = db.Transactions.FirstOrDefault(c => c.TID == id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
        }

        public void Edit(Transaction e)
        {
            var t = db.Transactions.FirstOrDefault(en => en.TID == e.TID);
            db.Entry(t).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Transaction> Get()
        {
            return db.Transactions.ToList();
        }

        public Transaction Get(int id)
        {
            return db.Transactions.FirstOrDefault(c => c.TID == id);
        }

        public void PlaceOrder(string id, List<Product> p )
        {

            var d = new List<Product>();
            d = p;

            foreach (var c in d)
            {
                var data = db.Products.FirstOrDefault(e => e.PID == c.PID);
                var cp = data;
                cp.Qty -= c.Qty;
                db.Entry(data).CurrentValues.SetValues(cp);
                db.SaveChanges();
            }



            var transaction = new Transaction()
            {
                UID = id,
                TAmount = d.Select(i => i.Price).Sum(),
                TDetials = "",
                Status = "In Processing",
                TDate = DateTime.Now.ToString()
            };

            db.Transactions.Add(transaction);

            /*var b = SuccessfulOrders(id);

            double total = 0;
            string rank = "";
            foreach (var i in b)
            {
                total += i.TAmount;
            }

            if (total < 1000)
                rank = "Bronze";
            else if (total > 1000 && total < 3000)
                rank = "Silver";
            else if (total > 3000 && total < 6000)
                rank = "Gold";
            else if (total > 6000 && total < 10000)
                rank = "Platinum";

            var buyer = new Buyer()
            {
                BuyerId = id,
                Rank = rank,
                RewardPoint = (total/100)*10
            };
*/
            db.SaveChanges();
        }

        public bool CancelOrder(int id)
        {
            var d = db.Transactions.FirstOrDefault(e => e.TID == id);

            var temp = Convert.ToDateTime(d.TDate);

            if (temp.AddDays(1) < DateTime.Now)
            {
                var cp = d;
                cp.Status = "Canceled";

                var p = new List<Product>();
                p = new JavaScriptSerializer().Deserialize<List<Product>>(cp.TDetials);

                foreach(var i in p)
                {
                    var data = db.Products.FirstOrDefault(e => e.PID == i.PID);
                    var c = data;
                    c.Qty += i.Qty;
                    db.Entry(data).CurrentValues.SetValues(c);
                    db.SaveChanges();
                }

                db.Entry(d).CurrentValues.SetValues(cp);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public int NumOfSuccessfulOrder(string id)
        {
            return db.Transactions.Where(e=> e.Status == "Delivered" && e.UID == id).ToList().Count;
        }

        public List<Transaction> SuccessfulOrders(string id)
        {
            return db.Transactions.Where(e => e.Status == "Delivered" && e.UID == id).ToList();
        }

        public List<Transaction> GetAll(string id)
        {
            return db.Transactions.Where(e => e.UID == id).ToList();
        }

        public List<Transaction> GetProcessing()
        {
            return db.Transactions.Where(e => e.Status == "In Processing").ToList();
        }

        public List<Transaction> GetAllDelivered(string id)
        {
            return db.Transactions.Where(e => e.Status == "Delivered" && e.DMID == id).ToList();
        }

        public List<Transaction> GetAllActive(string id)
        {
            return db.Transactions.Where(e => e.DMID != null && e.DMID == id && e.Status == "In Processing").ToList();
        }
    }
}
