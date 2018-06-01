using GlitterApp.BusinessLayer.BusinessLayerLogic;
using GlitterApp.SharedLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace GlitterApp.Controllers
{
    /// <summary>
    /// Gets the Following
    /// Business Layer  functions are called
    /// to perform some logic on data
    /// </summary>
    public class FollowingController : ApiController
    {
        //get those users whome the user is following
        //GET:/api/Following/getFollowingById/1
        [HttpGet]
        public List<UserModel> getFollowingById(int id, string searchvalue)
        {
            FollowingBusinessLogic FollowingBL = new FollowingBusinessLogic();
            return (FollowingBL.getFollowingById(id, searchvalue));
        }

        //asks for user to follow i.e sends follow request
        // POST: api/Following/FollowById
        [HttpPost]
        public bool FollowById(UserFollowerModel followerdata)
        {
            FollowingBusinessLogic FollowingBL = new FollowingBusinessLogic();
            return (FollowingBL.FollowById(followerdata));

        }

        //sends delete request to unfollow the user
        // DELETE: api/Following/unFollowById/5/4
        [HttpDelete]
        public void unFollowById(int id, int idToUnfollow)
        {
            FollowingBusinessLogic FollowingBL = new FollowingBusinessLogic();
            FollowingBL.unFollowById(id, idToUnfollow);
        }
    }
}
