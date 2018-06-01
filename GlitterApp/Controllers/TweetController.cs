using GlitterApp.BusinessLayer.BusinessLayerLogic;
using GlitterApp.SharedLayer;
using GlitterApp.SharedLayer.ViewModel;
using System.Collections.Generic;
using System.Web.Http;

namespace GlitterApp.Controllers
{
    /// <summary>
    /// gets the tweet requests to perform some action
    /// calls the bussiness layer function to perform some logic
    /// </summary>
    public class TweetController : ApiController
    {
        //get the tweets by user
        // GET: api/Tweet/getTweetById/5
        [HttpGet]
        public List<TweetViewModel> getTweetById(int id, string searchvalue)
        {
            TweetBusinessLogic TweetBL = new TweetBusinessLogic();
            return (TweetBL.getTweetById(id, searchvalue));

        }
       
        //Add new tweet
        // POST: api/Tweet/postTweet
        [HttpPost]
        public bool postTweet(TweetModel tweetmodel)
        {
            TweetBusinessLogic TweetBL = new TweetBusinessLogic();

            return (TweetBL.postTweet(tweetmodel));
        }

        
        //Post: api/Tweet/tweetLikeClicked
        [HttpPost]
        public bool tweetLikeClicked(TweetLikeDislikeModel data)
        {

            TweetBusinessLogic TweetBL = new TweetBusinessLogic();
            return (TweetBL.tweetLikeClicked(data));



        }
        //Post: api/Tweet/tweetdisLikeClicked
        [HttpPost]
        public bool tweetDisLikeClicked(TweetLikeDislikeModel data)
        {

            TweetBusinessLogic TweetBL = new TweetBusinessLogic();
            return (TweetBL.tweetDisLikeClicked(data));


        }

        //Edit tweet
        // PUT: api/Tweet/editTweet/id
        [HttpPut]
        public bool editTweet(int id, TweetModel tweetdata)
        {
            TweetBusinessLogic TweetBL = new TweetBusinessLogic();
            return (TweetBL.editTweet(id, tweetdata));
        }

        //asks for tweet to deleted by only particular User
        // DELETE: api/Tweet/deleteTweet/5
        [HttpDelete]
        public void deleteTweet(int id, int tweetId)
        {
            TweetBusinessLogic TweetBL = new TweetBusinessLogic();
            TweetBL.deleteTweet(id, tweetId);
        }
    }
}
