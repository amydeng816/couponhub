using BussinessObjectsLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDB
    {
        private CouponHubDBEntities db;

        public UserDB()
        {
            db = new CouponHubDBEntities();
        }

        public IEnumerable<User_Table> GetALL()
        {
            return db.User_Table.ToList();
        }

        public User_Table GetByID(int Id)
        {
            return db.User_Table.Find(Id);
        }

        public void Insert(User_Table user)
        {
            db.User_Table.Add(user);
            Save();
        }

        public void Delete(int Id)
        {
            User_Table user = db.User_Table.Find(Id);
            db.User_Table.Remove(user);
            Save();
        }

        public void Update(User_Table user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
