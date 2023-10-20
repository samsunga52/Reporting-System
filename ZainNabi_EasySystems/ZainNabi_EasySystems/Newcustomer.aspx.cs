using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZainNabi_EasySystems.Models;

namespace ZainNabi_EasySystems
{
    public partial class Newcustomer : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            string customername = ddlTitle.SelectedValue + " " + txtFirstName.Text + " " + txtLastName.Text;
            var customer = new Shared.Customers()
            {
                ReferenceNo = txtReferenceNumber.Text,
                CustomerName = customername,
                AddedDate = DateTime.Now,
                Email = txtEmail.Text,
                CellNo = txtCellNumber.Text,
                Agent = User.Identity.Name,
                Address = txtAddress.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Title = ddlTitle.SelectedValue,
                DeletedOn = null
            };

            var result = await CustomerService.InsertCustomer(customer).ConfigureAwait(false);

            if(result.CustomerID != 0)
            {
                btnCaptureTrans.Visible = true;
                btnViewTrans.Visible = true;

                var customerTransactions = await CustomerService.Get90CustomerTransactions(User.Identity.Name).ConfigureAwait(false);

                if (customerTransactions == null)
                {
                    Label1.Visible = true;
                }
                else
                {
                    customerTransactions = customerTransactions.Select(x => new CustomerTransaction()
                    {
                        CustomerTransID = x.CustomerTransID,
                        TrasnactionDate = x.TrasnactionDate,
                        TransactionDescription = x.TransactionDescription,
                        TransactionAmount = x.TransactionAmount

                    }).ToList();
                    GridView1.DataSource = customerTransactions;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }
            }
        }
        protected  void btnCaptureTrans_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customertransaction.aspx", false);
        }
        protected async void btnViewTrans_Click(object sender, EventArgs e)
        {
            var customerTransactions = await CustomerService.GetAllCustomerTransactions(User.Identity.Name).ConfigureAwait(false);

            if (customerTransactions == null)
            {
                Label1.Visible = true;
            }
            else
            {
                customerTransactions = customerTransactions.Select(x => new CustomerTransaction()
                {
                    CustomerTransID = x.CustomerTransID,
                    TrasnactionDate = x.TrasnactionDate,
                    TransactionDescription = x.TransactionDescription,
                    TransactionAmount = x.TransactionAmount

                }).ToList();
                GridView1.DataSource = customerTransactions;
                GridView1.DataBind();
                GridView1.Visible = true;
                Label1.Visible = false;
            }
        }
    }
}