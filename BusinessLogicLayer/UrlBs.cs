using BussinessObjectsLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UrlBs
    {
        private URLdb objDb;

        public UrlBs()
        {
            objDb = new URLdb();
        }

        public IEnumerable<Url_Table> GetAll()
        {
            return objDb.GetALL();
        }

        public Url_Table GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }

        public void Insert(Url_Table url)
        {
            objDb.Insert(url);
        }

        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }

        public void Update(Url_Table url)
        {
            objDb.Update(url);
        }
    }
}
