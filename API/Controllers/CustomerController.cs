using API.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CustomerController : ApiController
    {
        Entities context = new Entities();
        // GET api/<controller>
        [HttpGet]
        public List<Models.Customer> GetAllCustomers()
        {
            return context.Customers.Where(x => x.DeletedOn == null).ToList();
        }


        [HttpPost]
        public Shared.Customers InsertCustomer(Models.Customer c)
        {
            Shared.Customers customer = new Shared.Customers();
            try
            {
                context.Customers.Add(c);
                context.SaveChanges();
                var id = c.CustomerID;
                customer.CustomerID = id;
                return customer;

            }
            catch (Exception e)
            {
                return customer;
            }
        }

        [HttpPut]
        public bool UpdateCustomer(Models.Customer c)
        {
            try
            {
                context.Entry(c).State = EntityState.Modified;
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