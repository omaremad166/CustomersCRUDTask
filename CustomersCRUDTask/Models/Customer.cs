using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersCRUDTask.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Gender")]
        public char CustomerGender { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime CustomerDOB { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

    }
}
