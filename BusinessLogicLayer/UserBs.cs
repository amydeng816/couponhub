using BussinessObjectsLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserBs
    {
        private UserDB objDb;

        public UserBs()
        {
            objDb = new UserDB();
        }

        public IEnumerable<User_Table> GetAll()
        {
            return objDb.GetALL();
        }

        public User_Table GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }

        public void Insert(User_Table user)
        {
            objDb.Insert(user);
        }

        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }

        public void Update(User_Table user)
        {
            objDb.Update(user);
        }
    }
}
