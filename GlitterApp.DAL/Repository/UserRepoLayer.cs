
using GlitterApp.DAL.DatabaseDAL;
using GlitterApp.SharedLayer;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Mvc;
//using System.Web.Security;


namespace GlitterApp.DAL
{
    public class UserRepoLayer
    {
       /// <summary>
       /// Adds the User to the Database
       /// </summary>
       /// <param name="usermodel"></param>
       /// <returns></returns>
        public bool Signup(UserModel usermodel)
        {
            UserModel userDetails = new UserModel();

            User dbusr = new User();
            MicoBloggingEntities db = new MicoBloggingEntities();

             try
             {
            if (usermodel.Email == null)
                return false;
            if (db == null) throw new Exception("The dbContext has not been set");
            var userobj = (from prevuser in db.Users
                           where prevuser.Email == usermodel.Email
                           select prevuser).SingleOrDefault();

           
                if (userobj!=null)
                {
                    return false;
                }
            
                else
                {
                    dbusr.Email = usermodel.Email;
                    dbusr.Password = usermodel.Password;
                    dbusr.FName = usermodel.FName;
                    dbusr.LName = usermodel.LName;
                    dbusr.Contact = usermodel.Contact;
                    dbusr.Country = usermodel.Country;
                    dbusr.ImageUrl = usermodel.ImageUrl;
                    // Console.WriteLine(dbusr);
                    db.Users.Add(dbusr);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return false;
                    }
                }
           }
           catch(Exception )
            {
                Console.WriteLine("Sorry some  error occured" );
            }

            return true;

        }
        /// <summary>
        /// checks if the user exists in the tbale or not
        /// </summary>
        /// <param name="usermodel"></param>
        /// <returns></returns>
        public UserModel  CheckLogin(UserModel usermodel)
        {
            MicoBloggingEntities db = new MicoBloggingEntities();
            try
            {

                var obj = db.Users.Where(a => a.Email.Equals(usermodel.Email) && a.Password.Equals(usermodel.Password)).FirstOrDefault();
                if (obj != null)
                {
                    usermodel.Uid = obj.Uid;
                    usermodel.FName = obj.FName;
                    usermodel.LName = obj.LName;
                    usermodel.Contact = obj.Contact;
                    usermodel.Country = obj.Country;
                    usermodel.ImageUrl = obj.ImageUrl;


                }
                else
                {

                    usermodel.Email = null;
                    usermodel.Password = null;
                    usermodel.FName = null;
                    usermodel.LName = null;
                    usermodel.Contact = null;
                    usermodel.Country = null;
                    usermodel.ImageUrl = null;


                }
            }
            catch(Exception)
            {
                Console.WriteLine("Sorry error in database while fetching User");
            }
            return usermodel;

        }



        /// <summary>
        /// returns the list of all users
        /// </summary>
        /// <param name="id"></param>
        /// <param name="searchvalue"></param>
        /// <returns></returns>
        public List<UserModel> getAllUsers(int id,string searchvalue)
        {
            if(searchvalue==null)
            {
                searchvalue = "";
            }

            MicoBloggingEntities db = new MicoBloggingEntities();
            List<UserModel> userList = new List<UserModel>();
            try
            {

                User dbuser = new User();



                var followingids = from f in db.UserFollowers
                                   where f.FollowerId == id
                                   select f.UserId;


                var userslist = from u in db.Users
                                where
                            (followingids.Contains(u.Uid) == false & u.Uid != id)
                            & (u.FName.Contains(searchvalue) || u.LName.Contains(searchvalue) || u.Email.Contains(searchvalue))
                                select u;


                foreach (var usr in userslist)
                {
                    UserModel usermodel = new UserModel();
                    usermodel.FName = usr.FName;
                    usermodel.LName = usr.LName;
                    usermodel.Uid = usr.Uid;
                    usermodel.ImageUrl = usr.ImageUrl;
                    usermodel.Contact = usr.Contact;
                    usermodel.Country = usr.Country;
                    usermodel.Email = usr.Email;
                    //  usermodel.Password = usr.Password;
                    userList.Add(usermodel);

                }
            }catch(Exception)
            {
                Console.WriteLine("Sorry Error in dataBase While Fetching Users");
            }
            return userList;



        }

    }

    }
