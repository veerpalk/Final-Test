using System.ComponentModel.DataAnnotations;

namespace GlitterApp.SharedLayer
{
    /// <summary>
    /// DTO or model for Tweet Table
    /// </summary>
    public class TweetModel
    {
        public int Tid { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public System.DateTime CreationTime { get; set; }
        public int CountLike { get; set; }

    }
}
