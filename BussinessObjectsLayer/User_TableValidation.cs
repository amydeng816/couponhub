using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjectsLayer
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CouponHubDBEntities db = new CouponHubDBEntities();
            if (value == null)
            {
                return new ValidationResult("Email Address is required");
            }

            String UserEmailValue = value.ToString();
            int count = db.User_Table.Where(x => x.UserEmail == UserEmailValue).ToList().Count();
            if (count != 0)
            {
                return new ValidationResult("User Already Exists With This Email ID");
            }
            return ValidationResult.Success;
        }
    }

    public class User_TableValidation
    {
        [Required]
        [EmailAddress]
        [UniqueEmail]
        public String UserEmail { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    [MetadataType(typeof(User_TableValidation))]
    public partial class User_Table 
    {
        public string ConfirmPassword { get; set; }
    }
}
