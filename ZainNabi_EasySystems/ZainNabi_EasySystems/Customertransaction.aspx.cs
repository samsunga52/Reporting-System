using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZainNabi_EasySystems.Models;

namespace ZainNabi_EasySystems
{
    public partial class Customertransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var model = new Shared.CustomerTransaction();
            model.TrasnactionDate = Convert.ToDateTime(txtTransDate.Text);
            model.TransactionDescription = txtTransDescr.Text;
            model.TransactionAmount = Convert.ToDecimal(txtAmount.Text);
            model.CreatedBy = User.Identity.Name;

            CustomerService.InsertCustomerTrans(model).ConfigureAwait(false);
            Response.Redirect("Newcustomer.aspx");

        }
    }
}