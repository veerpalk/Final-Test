using System.ComponentModel.DataAnnotations;

namespace GlitterApp.SharedLayer
{

    /// <summary>
    /// DTO or model for Tweet UserFollower Table
    /// </summary>
    public class UserFollowerModel
    {
        public int Fid { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public  int FollowerId { get; set; }


    }
}
