using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZainNabi_EasySystems.Models;

namespace ZainNabi_EasySystems
{
    public partial class Customerammendments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    RegisterAsyncTask(new PageAsyncTask(() => LoadData(id)));
                }
            }
        }

        private async Task LoadData(int id)
        {
            var customers = await CustomerService.GetAllCustomers().ConfigureAwait(false);
            var customer = customers.FirstOrDefault(x => x.CustomerID == id);

            txtFirstName.Text = customer.FirstName.ToString();
            txtLastName.Text = customer.LastName.ToString();
            txtReferenceNumber.Text = customer.ReferenceNo.ToString();
            txtEmail.Text = customer.Email.ToString();
            txtCellNumber.Text = customer.CellNo.ToString();
            ddlTitle.SelectedValue = customer.Title.ToString();
            txtAddress.Text = customer.Address.ToString();
            txtCustomerID.Text = customer.CustomerID.ToString();
            txtDateAdded.Text = customer.AddedDate.ToString();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string customername = ddlTitle.SelectedValue + " " + txtFirstName.Text + " " + txtLastName.Text;
            var customer = new Shared.Customers()
            {
                CustomerID = Convert.ToInt32(txtCustomerID.Text),
                ReferenceNo = txtReferenceNumber.Text,
                CustomerName = customername,
                AddedDate = Convert.ToDateTime(txtDateAdded.Text),
                Email = txtEmail.Text,
                CellNo = txtCellNumber.Text,
                Agent = User.Identity.Name,
                Address = txtAddress.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Title = ddlTitle.SelectedValue,
                DeletedOn = null
            };

            CustomerService.UpdateCustomer(customer).ConfigureAwait(false);
            Response.Redirect("Customers.aspx");
        }
    }
}