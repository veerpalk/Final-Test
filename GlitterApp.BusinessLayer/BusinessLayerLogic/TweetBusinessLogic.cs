using GlitterApp.DAL.Repository;
using GlitterApp.SharedLayer;
using GlitterApp.SharedLayer.ViewModel;
using System.Collections.Generic;


namespace GlitterApp.BusinessLayer.BusinessLayerLogic
{
    /// <summary>
    /// Sends the request to the database
    /// performs some logic if Required
    /// </summary>
    public class TweetBusinessLogic
    {
        //function that communicated with DAL to add a new twet by the user
        public bool postTweet(TweetModel tweetmodel)
        {
            TweetRepoLayer obj = new TweetRepoLayer();
            return (obj.postTweet(tweetmodel));
        }

        //function that communicated with DAL give the tweets
        public List<TweetViewModel> getTweetById(int id, string searchvalue)
        {
            TweetRepoLayer obj = new TweetRepoLayer();
            return (obj.getTweetById(id, searchvalue));


        }
        //function that communicated with DAL to delete the tweet
        public void deleteTweet(int id, int tweetId)
        {
            TweetRepoLayer obj = new TweetRepoLayer();

            obj.deleteTweet(id, tweetId);
        }

        //function that communicated with DAL to edit the tweet
        public bool editTweet(int id, TweetModel tweetdata)
        {
            TweetRepoLayer obj = new TweetRepoLayer();
            return (obj.editTweet(id, tweetdata));
        }


        //function that communicated with DAL if like button is clicked
        public bool tweetLikeClicked(TweetLikeDislikeModel data)
        {

            TweetRepoLayer obj = new TweetRepoLayer();
            return (obj.tweetLikeClicked(data));


        }
        //function that communicated with DAL if dislike button is clicked
        public bool tweetDisLikeClicked(TweetLikeDislikeModel data)
        {

            TweetRepoLayer obj = new TweetRepoLayer();
            return (obj.tweetDisLikeClicked(data));


        }


    }
}
