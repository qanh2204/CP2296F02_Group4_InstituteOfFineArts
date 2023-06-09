using InstituteOfFineArts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InstituteOfFineArts.Controllers
{
    public class LoginController : Controller
    {
        private InstituteOfFineArtsDBEntities db = new InstituteOfFineArtsDBEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Login(string username, string password)
        {
            string redirectPage = "";
            if (ModelState.IsValid)
            {
                //var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).SingleOrDefault();
                if (data != null)
                {
                    //add session
                    Session["FullName"] = data.FullName;
                    Session["UserType"] = data.UserType;
                    Session["UserId"] = data.UserId;
                    
                    if (data.UserType == 0)
                    {
                        redirectPage = "/Admin/Users";
                    }
                    else if (data.UserType == 1)
                    {
                        redirectPage = "/Manager/Users";
                    }
                    else if (data.UserType == 2)
                    {
                        redirectPage = "/Teacher/Competitions";
                    }
                    else
                    {
                        redirectPage = "/Student/Desigins";
                    }
                    
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return Redirect("Index");
                }
            }
            return Redirect(redirectPage);
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index", "Home");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}

