using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class CustomerTransaction
    {
        public int CustomerTransID { get; set; }
        public Nullable<System.DateTime> TrasnactionDate { get; set; }
        public string ReferenceNo { get; set; }
        public string CustomerName { get; set; }
        public string TransactionDescription { get; set; }
        public Nullable<decimal> TransactionAmount { get; set; }
        public string CreatedBy { get; set; }
    }
}
