using GlitterApp.DAL.Repository;
using GlitterApp.SharedLayer;
using System.Collections.Generic;

namespace GlitterApp.BusinessLayer.BusinessLayerLogic
{
    /// <summary>
    /// Sends the request to the database
    /// perfroms some logic if Required
    /// </summary>
    public class FollowerBusinessLogic
    {

        public List<UserModel> getFollowerById(int id)
        {
            FollowerRepoLayer obj = new FollowerRepoLayer();
            return (obj.getFollowerById(id));
        }


       

    }
}
