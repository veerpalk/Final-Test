using System.ComponentModel.DataAnnotations;

namespace GlitterApp.DAL.DatabaseDAL
{
    /// <summary>
    /// Meta class concept 
    /// to apply the backend validations
    /// on the data
    /// </summary>
    [MetadataType(typeof(UserMetaData))]
        public partial class User 
        {
        }
   
    public class UserMetaData
    {
        public int Uid { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid."), Required(ErrorMessage = "Please enter Email")]
        //E-Mail must be unique and valid as per standard format
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Email"), RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$")]
        //Password minimum length is 8 and it must have at-least 1 special character, 1 number and 1 alphabet each
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter FirstName"), RegularExpression(@"^[a-zA-Z\s]+$")]
        //First Name (Alphabets and spaces only)
        public string FName { get; set; }
        [Required(ErrorMessage = "Please enter LastName"), RegularExpression(@"^[a-zA-Z\s]+$")]
        //Last Name(Alphabets and spaces only)
        public string LName { get; set; }
        [Required(ErrorMessage = "Please enter ContactNumber"), RegularExpression(@"^((\+91-?)|0)?[0-9]{10}$", ErrorMessage = "Entered phone format is not valid.")]
        //Contact number (10 digits, numeric only)
        public string Contact { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
    }

}
