using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ZainNabi_EasySystems.Models;

namespace ZainNabi_EasySystems
{
    public partial class Transactiondata : System.Web.UI.Page
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime firstDayOfPreviousMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
                DateTime lastDayOfPreviousMonth = firstDayOfPreviousMonth.AddMonths(1).AddDays(-1);

                txtFromDate.Text = firstDayOfPreviousMonth.ToString("yyyy/mm/dd");
                txtToDate.Text = lastDayOfPreviousMonth.ToString("yyyy/mm/dd");
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected async void btnLoadReport_Click(object sender, EventArgs e)
        {


            DateTime fromDate = DateTime.Parse(txtFromDate.Text);
            DateTime toDate = DateTime.Parse(txtToDate.Text);


            var trans = await CustomerService.TransReport().ConfigureAwait(false);


            List<Shared.CustomerTransaction> transactions = trans.Where(x => x.TrasnactionDate.Value >= fromDate && x.TrasnactionDate.Value <= toDate).ToList();
            var customers = await CustomerService.GetAllCustomers().ConfigureAwait(false);
            // Filter out removed customers
            var result = (from item1 in customers
                                        join item2 in transactions on item1.Agent equals item2.CreatedBy
                                        select new
                                        {
                                            item1.ReferenceNo,
                                            CustomerName = item1 != null ? item1.CustomerName : null,
                                            TransnactionDate = item2 != null ? item2.TrasnactionDate : null,
                                            TransactionAmount = item2 != null ? item2.TransactionAmount : null,
                                            TransactionDescription = item2 != null ? item2.TransactionDescription : null
                                        }).ToList();

            GridView1.DataSource = result;
            GridView1.DataBind();
            GridView1.Visible = true;
        }

        protected async void btnExportXML_Click(object sender, EventArgs e)
        {
            DateTime fromDate = DateTime.Parse(txtFromDate.Text);
            DateTime toDate = DateTime.Parse(txtToDate.Text);

            if (fromDate > toDate)
            {
                // Show error message
                return;
            }

            // Get transactions from database

            var trans = await CustomerService.TransReport().ConfigureAwait(false);


            List<Shared.CustomerTransaction> transactions = trans.Where(x => x.TrasnactionDate >= fromDate && x.TrasnactionDate <= toDate).ToList();
            var customers = await CustomerService.GetAllCustomers().ConfigureAwait(false);
            // Filter out removed customers
            var result = from item1 in customers
                         join item2 in trans on item1.Agent equals item2.CreatedBy
                         select new { item1.ReferenceNo, item1.LastName, item2.TrasnactionDate, item2.TransactionAmount, item2.TransactionDescription };

            // Create XML document
            XDocument xml = new XDocument(new XElement("Transactions",
                from t in result
                orderby t.TrasnactionDate
                select new XElement("Transaction",
                    new XElement("ReferenceNo", t.ReferenceNo),
                    new XElement("LastName", t.LastName),
                    new XElement("TransactionDate", t.TrasnactionDate),
                    new XElement("TransactionAmount", t.TransactionAmount)
                )
            ));

            // Export XML file
            Response.Clear();
            Response.ContentType = "text/xml";
            Response.AddHeader("Content-Disposition", "attachment; filename=transactions.xml");
            xml.Save(Response.Output);
            Response.End();
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Export GridView to Excel file
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=transactions.xls");
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

    }
}