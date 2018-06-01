using System;

namespace GlitterApp.SharedLayer
{
    /// <summary>
    /// DTO or model for Tweet LikeDislike Table
    /// </summary>

    public class TweetLikeDislikeModel
    {
        public int LDid { get; set; }
        public Nullable<int> TweetId { get; set; }
        public Nullable<int> LikedDislikedBy { get; set; }
        public string LikeDislike { get; set; }
        public Nullable<int> Count { get; set; }


    }
}
