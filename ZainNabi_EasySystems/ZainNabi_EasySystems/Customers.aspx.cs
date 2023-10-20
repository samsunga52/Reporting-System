using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZainNabi_EasySystems
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("Customerammendments.aspx?id=" + id);
        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Newcustomer.aspx");
        }

        protected void chkRemoved_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox box = (CheckBox)sender;
            //GridViewRow row = (GridViewRow)box.NamingContainer;
            //string customerId = ((CheckBox)row.FindControl("chkRemoved")).Text;

            CheckBox checkBox = (CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
            string customerId = GridView1.DataKeys[gridViewRow.RowIndex].Value.ToString();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Customers SET DeletedOn = @IsRemoved WHERE CustomerId = @CustomerId", conn);
                cmd.Parameters.AddWithValue("@IsRemoved", DateTime.Now);
                cmd.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(customerId));
                cmd.ExecuteNonQuery();
            }

            // Update the GridView using AJAX and jQuery
            GridView1.DataBind();
        }
    }
}