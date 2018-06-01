using GlitterApp.BusinessLayer.BusinessLayerLogic;
using GlitterApp.SharedLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace GlitterApp.Controllers
{
    /// <summary>
    /// Get the Followers 
    /// </summary>
    public class FollowerController : ApiController
    {
        // GET: api/Follower/getFollowerById/5
        [HttpGet]
        public List<UserModel> getFollowerById(int id)
        {
            FollowerBusinessLogic FollowerBL = new FollowerBusinessLogic();
          return (FollowerBL.getFollowerById(id));
        }

       
    }
}
