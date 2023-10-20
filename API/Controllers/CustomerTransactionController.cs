using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CustomerTransactionController : ApiController
    {
        Entities context = new Entities();

        [Route("api/CustomerTransaction/Get90CustomerTransactions")]
        [HttpGet]
        public IEnumerable<Models.CustomerTransaction> Get90CustomerTransactions(string username)
        {
            var last90DaysTransactions = context.CustomerTransactions.Where(t => t.TrasnactionDate >= DateTime.Now.AddDays(-90) && t.CreatedBy == username).ToList();
            return last90DaysTransactions.ToList();
        }

        [Route("api/CustomerTransaction/GetAllCustomerTransactions")]
        [HttpGet]
        public IEnumerable<Models.CustomerTransaction> GetAllCustomerTransactions(string username)
        {
            return context.CustomerTransactions.Where(x => x.CreatedBy == username).ToList();
        }

        [Route("api/CustomerTransaction/TransReport")]
        [HttpGet]
        public IEnumerable<Models.CustomerTransaction> TransReport()
        {
            return context.CustomerTransactions.ToList();
        }

        [HttpPost]
        public bool InsertTransaction(Models.CustomerTransaction c)
        {
            Shared.CustomerTransaction customer = new Shared.CustomerTransaction();
            try
            {
                context.CustomerTransactions.Add(c);
                context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
