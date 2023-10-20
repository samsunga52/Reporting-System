using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ZainNabi_EasySystems.Models
{
    public class CustomerService
    {
        public static async Task<Shared.Customers> InsertCustomer(Shared.Customers model)
        {
            try
            {
                return await RestApiHelper.PostAsync(new Uri(UrlHelper.Api.CustomerApi, $"{UrlHelper.Controller.Customer}InsertCustomer/"), model);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static async Task<Shared.CustomerTransaction> InsertCustomerTrans(Shared.CustomerTransaction model)
        {
            try
            {
                return await RestApiHelper.PostAsync(new Uri(UrlHelper.Api.CustomerApi, $"{UrlHelper.Controller.CustomerTransaction}InsertTransaction/"), model);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static async Task<List<Shared.Customers>> GetAllCustomers()
        {
            return await RestApiHelper.GetAsync<List<Shared.Customers>>(new Uri(UrlHelper.Api.CustomerApi, $"{UrlHelper.Controller.Customer}GetAllCustomers"));
        }

        public static async Task<bool> UpdateCustomer(Shared.Customers model)
        {
            try
            {
                return await RestApiHelper.PutAsync(new Uri(UrlHelper.Api.CustomerApi, $"{UrlHelper.Controller.Customer}UpdateCustomer/"), model);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static async Task<List<Shared.CustomerTransaction>> Get90CustomerTransactions(string username)
        {
            return await RestApiHelper.GetAsync<List<Shared.CustomerTransaction>>(new Uri(UrlHelper.Api.CustomerApi, $"{UrlHelper.Controller.CustomerTransaction}Get90CustomerTransactions?username={username}"));
        }

        public static async Task<List<Shared.CustomerTransaction>> GetAllCustomerTransactions(string username)
        {
            return await RestApiHelper.GetAsync<List<Shared.CustomerTransaction>>(new Uri(UrlHelper.Api.CustomerApi, $"{UrlHelper.Controller.CustomerTransaction}GetAllCustomerTransactions?username={username}"));
        }

        public static async Task<List<Shared.CustomerTransaction>> TransReport()
        {
            return await RestApiHelper.GetAsync<List<Shared.CustomerTransaction>>(new Uri(UrlHelper.Api.CustomerApi, $"{UrlHelper.Controller.CustomerTransaction}TransReport"));
        }
    }
}