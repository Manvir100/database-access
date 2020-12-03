using ShoppingClient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ShoppingClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult LoginForm()
        {
            if(isLoggedIn())
            {
                ViewBag.success = true;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Home(Login login)
        {
            tryLogin(login);
            if(isLoggedIn()) 
            {
                ViewBag.name = login.Username;
                return View();
            }
            else
            {
                ViewBag.fail = true;
                return View("LoginForm");
            }
           
        }
        public ActionResult Index()
        {
            if(isLoggedIn())
            {
                return View();
            }
            else
            {
                ViewBag.error = true;
                return View("LoginForm");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            if(isLoggedIn())
            {
                return View();
            }
            else
            {
                ViewBag.error = true;
                return View("LoginForm");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            if(isLoggedIn())
            {
                return View();
            }
            else
            {
                ViewBag.error = true;
                return View("LoginForm");
            }
        }

        public void tryLogin(Login login)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString);
            conn.Open();

            string insertCmd = "select Password from Users where Username=@username";
            SqlCommand cmd = new SqlCommand(insertCmd, conn);

            cmd.Parameters.AddWithValue("@username", login.Username);

            string password = (string) cmd.ExecuteScalar();
            conn.Close();

            if (password == hash(login.Password))
            {
                HttpContext.Application["logged_in"] = true;
            }
            Debug.WriteLine(hash(login.Password));
        }

        public bool isLoggedIn()
        {
            return (bool) HttpContext.Application["logged_in"];
        }

        public string hash(string password)
        {
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}