using GlitterApp.DAL.Repository;
using GlitterApp.SharedLayer;
using System.Collections.Generic;

namespace GlitterApp.BusinessLayer.BusinessLayerLogic
{
    /// <summary>
    /// Sends the request to the database
    /// perfroms some logic if Required
    /// </summary>
    public class FollowingBusinessLogic
    {
        //function that communicated with DAL give the list of users 
        //that are followed by the user 
        public List<UserModel> getFollowingById(int id,string searchvalue)
        {
            FollowingRepoLayer obj = new FollowingRepoLayer();
            return (obj.getFollowingById(id, searchvalue));
        }
        //function that communicated with DAL to unfollow user
        public void unFollowById(int id,int idToUnfollow)
        {
            FollowingRepoLayer obj = new FollowingRepoLayer();
            obj.unFollowById(id,idToUnfollow);
        }
         //function that communicated with DAL to follow user
        public bool FollowById(UserFollowerModel followerdata)
        {
            FollowingRepoLayer obj = new FollowingRepoLayer();
            return (obj.FollowById(followerdata));

        }

    }
    }
