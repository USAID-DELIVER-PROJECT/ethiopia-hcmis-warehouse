using HCMIS.Concrete.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMIS.Concrete.Models;

namespace HCMIS.Core.Distribution.Services
{
    public class OrderService
    { 
        RepositoryFactory repos = new RepositoryFactory();
        public Concrete.Models.Order GetOrder(int id)
        {
            return repos.Orders.First(o => o.ID == id);
        }

        public IEnumerable<Concrete.Models.Order> GetDraftOrder()
        {
           
            IEnumerable<Concrete.Models.Order> vals =  repos.Orders.Find(o => o.OrderStatusID == 1);
            Console.WriteLine(vals.Count());
            foreach (var v in vals)
            {
                Console.WriteLine(v.ID);
            }
            return vals;
        }

        public void ListUsers(){
            var users = repos.Users.GetAll();
            foreach (var user in users)
            {
                Console.WriteLine(user.FullName);
            }
        }

        public void ShowSU()
        {
            var user = repos.Users.Find(u => u.FullName == "su").FirstOrDefault();
            Console.WriteLine(user.ToString());
        }

    }
}
