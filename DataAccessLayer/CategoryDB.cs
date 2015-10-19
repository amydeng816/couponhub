using BussinessObjectsLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDB
    {
        private CouponHubDBEntities db;

        public CategoryDB()
        {
            db = new CouponHubDBEntities();
        }

        public IEnumerable<Category_Table> GetALL()
        {
            return db.Category_Table.ToList();
        }

        public Category_Table GetByID(int Id)
        {
            return db.Category_Table.Find(Id);
        }

        public void Insert(Category_Table category)
        {
            db.Category_Table.Add(category);
            Save();
        }

        public void Delete(int Id)
        {
            Category_Table category = db.Category_Table.Find(Id);
            db.Category_Table.Remove(category);
            Save();
        }

        public void Update(Category_Table category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
