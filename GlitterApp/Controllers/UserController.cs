using GlitterApp.BusinessLayer;
using GlitterApp.SharedLayer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace GlitterApp.Controllers
{
    /// <summary>
    /// this controller is responsible
    /// for the user SignUp and Login
    /// </summary>
    public class UserController : ApiController
    {

        //gets the total people or users
        // GET: api/User/getAllusers/2
        [HttpGet]
        public List<UserModel> getAllUsers(int id, string searchvalue)
        {
            UserBusinessLogic UserBL = new UserBusinessLogic();

            return (UserBL.getAllUsers(id, searchvalue));
        }

        //SignUp or Register User
        // POST: api/User/Signup
        [HttpPost]
        public bool Signup(UserModel userObject)
        {
            UserBusinessLogic UserBL = new UserBusinessLogic();

            return (UserBL.Signup(userObject));
        }




        // POST: api/User/Login
        [HttpPost]
        public UserModel Login(UserModel usermodel)
        {
            UserBusinessLogic UserBL = new UserBusinessLogic();

            return (UserBL.CheckLogin(usermodel));
        }




        /// <summary>
        /// this method uploads image file to the server it creates the virtual 
        /// path and saves image at servers PostedFile folder
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string UploadJsonFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            HttpPostedFile postedFile;
            if (httpRequest.Files.Count > 0)
            {

                postedFile = httpRequest.Files[0];
                Console.WriteLine(postedFile.FileName);
                var filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + postedFile.FileName);
                postedFile.SaveAs(filePath);
                return postedFile.FileName;

            }
            return null;

        }






    }
}
