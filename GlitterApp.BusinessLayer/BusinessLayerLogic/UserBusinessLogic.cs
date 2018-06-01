using GlitterApp.DAL;
using GlitterApp.SharedLayer;
using System.Collections.Generic;

namespace GlitterApp.BusinessLayer
{
    /// <summary>
    /// Sends the request to the database
    /// perfroms some logic if Required
    /// </summary>
    public class UserBusinessLogic
    {
        //function that communicated with DAL to add new user 
        public bool Signup(UserModel userObj)
        {
                UserRepoLayer obj = new UserRepoLayer();
                        return ( obj.Signup(userObj));
        }
        //function that communicated with DAL to check the User Credentials
        public UserModel CheckLogin(UserModel usermodel)
        {
            UserRepoLayer obj = new UserRepoLayer();
            return (obj.CheckLogin(usermodel));

        }
        //function that communicated with DAL give the list of users 
         public List<UserModel> getAllUsers(int id,string searchvalue)
        {
            UserRepoLayer obj = new UserRepoLayer();
            return (obj.getAllUsers(id, searchvalue));

           
        }
    }
}
