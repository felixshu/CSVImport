using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian.Entity
{
    [Table("Customers")]
    public class Customer
    {
        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }

        [Key]
        public Guid CustomerId { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Birthday")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:{dd/MM/yyy}")]
        [DataType(DataType.Date)]
        public DateTime? Dob { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "You must proivde a proper phone number")]
        public string Mobile { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "You must proivde a proper phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNum { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
