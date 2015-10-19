using BussinessObjectsLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CategoryBs
    {
        private CategoryDB objDb;

        public CategoryBs()
        {
            objDb = new CategoryDB();
        }

        public IEnumerable<Category_Table> GetAll()
        {
            return objDb.GetALL();
        }

        public Category_Table GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }

        public void Insert(Category_Table category)
        {
            objDb.Insert(category);
        }

        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }

        public void Update(Category_Table category)
        {
            objDb.Update(category);
        }
    }
}
