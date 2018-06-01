using GlitterApp.DAL.DatabaseDAL;
using GlitterApp.SharedLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlitterApp.DAL.Repository
{
  
    public class FollowerRepoLayer
    {
        /// <summary>
        /// gets the Followe of the User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UserModel> getFollowerById(int id)
        {
            MicoBloggingEntities db = new MicoBloggingEntities();
            List<UserModel> followerList = new List<UserModel>();

            User dbuser = new User();
            //finds the follower of the user
            try
            {
                var followrids = from f in db.UserFollowers
                                 where f.UserId.Equals(id)
                                 select f.FollowerId;

                var followers = db.Users.Where(t => followrids.Contains(t.Uid));
                //Assign the data to the usermodel
                foreach (var follower in followers)
                {
                    //Model class or DTO is used
                    UserModel usermodel = new UserModel();
                    usermodel.FName = follower.FName;
                    usermodel.LName = follower.LName;
                    //  usermodel.Email = follower.Email;
                    usermodel.ImageUrl = follower.ImageUrl;
                    usermodel.Uid = follower.Uid;
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
    }
}
