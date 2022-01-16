using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserIdRepo : IRepository<UserID, int>
    {
        AntivalyEntities db;

        public UserIdRepo(AntivalyEntities db)
        {
            this.db = db;
        }

        public void Add(UserID e)
        {
            this.db.UserIDs.Add(e);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var userId = db.UserIDs.FirstOrDefault(c => c.ID == id);
            db.UserIDs.Remove(userId);
            db.SaveChanges();
        }

        public void Edit(UserID e)
        {
            var u = db.UserIDs.FirstOrDefault(en => en.ID == e.ID);
            db.Entry(u).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<UserID> Get()
        {
            return db.UserIDs.ToList();
        }

        public UserID Get(int id)
        {
            return db.UserIDs.FirstOrDefault(c => c.ID == id);
        }
    }
}
