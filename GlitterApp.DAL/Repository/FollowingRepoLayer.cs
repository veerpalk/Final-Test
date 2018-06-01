using GlitterApp.DAL.DatabaseDAL;
using GlitterApp.SharedLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GlitterApp.DAL.Repository
{
    public class FollowingRepoLayer
    {

        /// <summary>
        /// get the Users that are being followed by the Current user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="searchvalue"></param>
        /// <returns></returns>
        public List<UserModel> getFollowingById(int id,string searchvalue)
        {
            //searchstring is used
            //to consume the same service 
            //and methods for the Search Results
            MicoBloggingEntities db = new MicoBloggingEntities();
            List<UserModel> followerList = new List<UserModel>();
            if(searchvalue==null)
            {
                searchvalue = "";
            }

            User dbuser = new User();
            //kind of self join on user table
            try
            {
                var followingids = from f in db.UserFollowers
                                   where f.FollowerId == id
                                   select f.UserId;

                var following = db.Users.Where(t => followingids.Contains(t.Uid) & (t.FName.Contains(searchvalue) || t.LName.Contains(searchvalue) || t.Email.Contains(searchvalue)));
                //assigns data to usermodel or DTO
                foreach (var followingusr in following)
                {
                    UserModel usermodel = new UserModel();
                    usermodel.FName = followingusr.FName;
                    usermodel.LName = followingusr.LName;
                    usermodel.Uid = followingusr.Uid;
                    usermodel.ImageUrl = followingusr.ImageUrl;
                    usermodel.Uid = followingusr.Uid;
                    //usermodel.Contact = follower.Contact;
                    //usermodel.Country = follower.Country;
                    followerList.Add(usermodel);

                }
            }
            catch(Exception)
            {
                Console.WriteLine("Sorry Some Error Occured");
            }

            return followerList;
        }
        /// <summary>
        /// User can unfollow another user that he was following
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idToUnfollow"></param>
        public void unFollowById(int id,int idToUnfollow)
        {
            MicoBloggingEntities db = new MicoBloggingEntities();
            //get the of following user by kind of self join
            //if records exit he can unfollow else not
            
            var followingdata = from ftable in db.UserFollowers
                               where ftable.FollowerId == id & ftable.UserId == idToUnfollow
                               select ftable;
            if(followingdata!=null)
            {
                foreach (var item in followingdata)
                {
                    db.UserFollowers.Remove(item);
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {  // Provide for exceptions.
                    Console.WriteLine(e);
                  
                }

            }

        }

        //User can follow another user
        public bool FollowById(UserFollowerModel followerdata)
        {
            MicoBloggingEntities db = new MicoBloggingEntities();
            try
            {
                var data = from userfollow in db.UserFollowers
                           where userfollow.FollowerId == followerdata.UserId & userfollow.UserId == followerdata.FollowerId
                           select userfollow;
                Console.WriteLine(data);
                Console.WriteLine(data.Count());
                if (data.Count() == 0)
                {
                    UserFollower dbusrfoll = new UserFollower();
                    dbusrfoll.UserId = followerdata.FollowerId;
                    dbusrfoll.FollowerId = followerdata.UserId;
                    db.UserFollowers.Add(dbusrfoll);
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Sorry Some Error Occured");
            }

            return false;

        }
    }
}
