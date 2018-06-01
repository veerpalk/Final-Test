using System.ComponentModel.DataAnnotations;

namespace GlitterApp.SharedLayer
{
    /// <summary>
    /// DTO or model for User Table
    /// </summary>

    public class UserModel
    {
        public int Uid { get; set; }
        
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Country { get; set; }
        public string ImageUrl { get; set; }


    }
}
