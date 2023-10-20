using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string ReferenceNo { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers are allowed.")]
        public string CellNo { get; set; }
        [Required]
        public string Agent { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        public string DeletedOn { get; set; }
    }
}
