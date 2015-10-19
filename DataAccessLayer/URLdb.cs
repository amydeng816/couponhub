using BussinessObjectsLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class URLdb
    {
        private CouponHubDBEntities db;

        public URLdb()
        {
            db = new CouponHubDBEntities();
        }

        public IEnumerable<Url_Table> GetALL()
        {
            return db.Url_Table.ToList();
        }

        public Url_Table GetByID(int Id)
        {
            return db.Url_Table.Find(Id);
        }

        public void Insert(Url_Table url)
        {
            db.Url_Table.Add(url);
            Save();
        }

        public void Delete(int Id)
        {
            Url_Table url = db.Url_Table.Find(Id);
            db.Url_Table.Remove(url);
            Save();
        }

        public void Update(Url_Table url)
        {
            db.Entry(url).State = EntityState.Modified;
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
