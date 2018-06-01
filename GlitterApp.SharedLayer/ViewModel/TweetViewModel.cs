namespace GlitterApp.SharedLayer.ViewModel
{
    /// <summary>
    /// to show the tweets
    /// by fetching records from various tables
    /// </summary>
    public class TweetViewModel
    {
        public int Tid { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreationTime { get; set; }
   
        public string Email { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string ImageUrl { get; set; }
        public bool LikeDislike { get; set; }
        public int CountLike { get; set; }

    }
}
