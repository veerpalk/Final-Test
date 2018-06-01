using GlitterApp.DAL.DatabaseDAL;
using GlitterApp.SharedLayer;
using GlitterApp.SharedLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlitterApp.DAL.Repository
{
    public class TweetRepoLayer
    {

        MicoBloggingEntities db = new MicoBloggingEntities();

        Tweet dbtweet = new Tweet();

        /// <summary>
        /// Add new Tweet to the Database
        /// </summary>
        /// <param name="tweetmodel"></param>
        /// <returns></returns>
        public bool postTweet(TweetModel tweetmodel)
        {

            try
            {
                dbtweet.Body = tweetmodel.Body;
                dbtweet.UserId = Convert.ToInt32(tweetmodel.UserId);
                dbtweet.CreationTime = tweetmodel.CreationTime;
                db.Tweets.Add(dbtweet);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry Some Error Occurred");
                return false;
            }

              }

        /// <summary>
        /// get the tweets by the current User
        /// and of the user whom he is following
        /// </summary>
        /// <param name="id"></param>
        /// <param name="searchvalue"></param>
        /// <returns></returns>
        public List<TweetViewModel> getTweetById(int id, string searchvalue)
        {
            List<TweetViewModel> tweetmodelList = new List<TweetViewModel>();
            if (searchvalue == null)
            {
                searchvalue = "";
            }
            else
            {
                searchvalue = "#" + searchvalue;
            }
            try
            {
                var followingids = from f in db.UserFollowers
                                   where f.FollowerId == id
                                   select f.UserId;

                var tweetList = from tweet in db.Tweets
                                where (tweet.UserId == id
                                || followingids.Contains(tweet.UserId))
                                & tweet.Body.Contains(searchvalue)
                                orderby tweet.CreationTime descending
                                select tweet;
                foreach (var tweetitem in tweetList)
                {
                    TweetViewModel tweetmodel = new TweetViewModel();
                    tweetmodel.Tid = tweetitem.Tid;
                    tweetmodel.Body = tweetitem.Body;
                    tweetmodel.CreationTime = tweetitem.CreationTime;
                    tweetmodel.UserId = tweetitem.UserId;
                    tweetmodel.ImageUrl = tweetitem.User.ImageUrl;
                    tweetmodel.FName = tweetitem.User.FName;
                    tweetmodel.LName = tweetitem.User.LName;
                    tweetmodel.Email = tweetitem.User.Email;





                    //Query to fetch data from the data abt that tweet and its userid
                    bool tweetLikeDislike = Convert.ToBoolean((from tweetld in db.TweetLikeDislikes
                                                               where tweetld.TweetId == tweetitem.Tid
                                                               & tweetld.LikedDislikedBy == id
                                                               select tweetld.LikeDislike).FirstOrDefault());


                    tweetmodel.LikeDislike = tweetLikeDislike;
                    tweetmodelList.Add(tweetmodel);


                }

            }catch(Exception)
            {
                Console.WriteLine("Sorry Some Error Occured");
            }
            return tweetmodelList;

        }

        /// <summary>
        /// Deletes the tweet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tweetId"></param>

        public void deleteTweet(int id, int tweetId)
        {
            MicoBloggingEntities db = new MicoBloggingEntities();
            try
            {
                var tweetdata = from tweet in db.Tweets
                            where tweet.UserId == id & tweet.Tid == tweetId
                            select tweet;
            //First delete from the foriegn key tABLE
            var tweetInAnother = from tweetAnother in db.TweetLikeDislikes
                                 where tweetAnother.TweetId == tweetId
                                 select tweetAnother;
            if (tweetdata != null)
            {

                if (tweetInAnother.Count() == 0)
                {
                    foreach (var itemdata in tweetdata)
                        db.Tweets.Remove(itemdata);
                }
                else
                {
                    foreach (var tweetdataanother in tweetInAnother)
                        db.TweetLikeDislikes.Remove(tweetdataanother);
                    db.SaveChanges();
                    foreach (var itemdata in tweetdata)
                        db.Tweets.Remove(itemdata);
                }
            }


           
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }

        }

        /// <summary>
        /// edits the tweets
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tweetdata"></param>
        /// <returns></returns>
        public bool editTweet(int id, TweetModel tweetdata)
        {
            MicoBloggingEntities db = new MicoBloggingEntities();


            try
            {
                Tweet tweetToEdit = (from tweet in db.Tweets
                                     where tweet.Tid == id & tweet.UserId == tweetdata.UserId
                                     select tweet).FirstOrDefault();
                tweetToEdit.Body = tweetdata.Body;
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            return true;

        }




        //Update the Tweet Like dislike table when user Clicks the Like Button
        public bool tweetLikeClicked(TweetLikeDislikeModel data)
        {
            MicoBloggingEntities db = new MicoBloggingEntities();
            TweetLikeDislike dbtweetlikedislike = new TweetLikeDislike();

            try
            {
                //finds the Previous record of that tweet
                var findPrevData = (from tweetLD in db.TweetLikeDislikes
                                    where tweetLD.TweetId == data.TweetId
                                    & tweetLD.LikedDislikedBy == data.LikedDislikedBy
                                    select tweetLD).FirstOrDefault();
                //if there is no Record it will create the tweetrecord
                if (findPrevData != null)
                {
                    Console.WriteLine(findPrevData);
                    findPrevData.LikeDislike = "true";

                    db.SaveChanges();

                    return true;

                }
                //if record exists the data is updated
                else
                {
                    dbtweetlikedislike.TweetId = data.TweetId;
                    dbtweetlikedislike.LikedDislikedBy = data.LikedDislikedBy;
                    dbtweetlikedislike.LikeDislike = data.LikeDislike;

                    db.TweetLikeDislikes.Add(dbtweetlikedislike);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry some Error ocuured" + ex);
                return false;
            }

        }

        /// <summary>
        /// adds data if no record exist of that tweet 
        /// else updates the like or dislike value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool tweetDisLikeClicked(TweetLikeDislikeModel data)
        {
            MicoBloggingEntities db = new MicoBloggingEntities();
            TweetLikeDislike dbtweetlikedislike = new TweetLikeDislike();

            try
            {
                var findPrevData = (from tweetLD in db.TweetLikeDislikes
                                    where tweetLD.TweetId == data.TweetId
                                    & tweetLD.LikedDislikedBy == data.LikedDislikedBy
                                    select tweetLD).FirstOrDefault();
                if (findPrevData != null)
                {
                    Console.WriteLine(findPrevData);
                    findPrevData.LikeDislike = "false";

                    db.SaveChanges();

                    return true;

                }
                else
                {
                    dbtweetlikedislike.TweetId = data.TweetId;
                    dbtweetlikedislike.LikedDislikedBy = data.LikedDislikedBy;
                    dbtweetlikedislike.LikeDislike = data.LikeDislike;
                    db.TweetLikeDislikes.Add(dbtweetlikedislike);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry some Error ocuured" + ex);
                return false;
            }

        }





    }
}
