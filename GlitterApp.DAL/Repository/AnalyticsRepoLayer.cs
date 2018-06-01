using GlitterApp.DAL.DatabaseDAL;
using GlitterApp.SharedLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlitterApp.DAL.Repository
{
    public class AnalyticsRepoLayer
    {
        /// <summary>
        /// Get the analytics for the website
        /// </summary>
        /// <returns></returns>
        public AnalyticsViewModel GetAnalytics()
        {
            AnalyticsViewModel analyticsVM = new AnalyticsViewModel();
            MicoBloggingEntities db = new MicoBloggingEntities();

            //Query selects the total tweets
            var tweetData = db.Tweets.Select(t => t).ToList();
            //tweets are filtered by Today's date
            int totalTweetsToday = tweetData.Where(t => DateTime.Compare(t.CreationTime.Date, DateTime.Now.Date) == 0).Count();
            //Adds Data to Analytics View Model
            analyticsVM.TotalTweetsToday = totalTweetsToday;

            //selects the tweet  
            //group by userid
            //finds count in descending order
            Queue<int> list = new Queue<int>();
            try
            {
                foreach (var line in tweetData.GroupBy(tweet => tweet.UserId)
                            .Select(group => new
                            {
                                UserId = group.Key,
                                Count = group.Count()
                            }).OrderByDescending(x => x.Count))
                {
                    int UserId = line.UserId;
                    list.Enqueue(UserId);
                }
                //Selects the user firstname
                //that have most tweets till date
                if (list.Count() > 0)
                {
                    int userId = list.Dequeue();
                    string mostTweetsBy = (from userD in db.Users
                                           where userD.Uid == userId
                                           select userD.FName).Single();

                    //puts the data in the Viewmodel
                    analyticsVM.MostTweetsBy = mostTweetsBy;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry Some Error Occured");
            }

              /* Query to select the Most Liked tweets
             *grouping by tweet id
             *where twiteliek is true
             * order by descending
             */
            var tweetLikeDislike = db.TweetLikeDislikes.Select(t => t).ToList();

            Queue<int> listLD = new Queue<int>();
            var Like = db.TweetLikeDislikes.Select(t => t.LikeDislike).ToList();
            try
            {
                foreach (var tweetLData in tweetLikeDislike.Where(x => x.LikeDislike == "true      ").GroupBy(tweet => tweet.TweetId)
                            .Select(group => new
                            {
                                tweetId = group.Key,
                                count = group.Count(),
                            }).OrderByDescending(x => x.tweetId)
                           )
                {
                    int tweetid = Convert.ToInt32(tweetLData.tweetId);
                    listLD.Enqueue(tweetid);
                    break;
                }
                /*
                 finds the Tweet Body in database
                 that has maximum Likes*/

                int tweetId = listLD.Dequeue();
                string mostLikedTweet = (from tweet in db.Tweets
                                         where tweet.Tid == tweetId
                                         select tweet.Body).Single();
                //Inserts into Analytics
                analyticsVM.MostLikedTweets = mostLikedTweet;
            }
            catch(Exception)
            {
                Console.WriteLine("Sorry Some Error Occured");
            }

           
            return analyticsVM;
        }
    }
}
