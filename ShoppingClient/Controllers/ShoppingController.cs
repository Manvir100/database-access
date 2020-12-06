using ShoppingClient.Models;
using ShoppingClient.ShoppingServiceReference;
using System.Diagnostics;
using System.Web.Mvc;

namespace ShoppingClient.Controllers
{
    public class ShoppingController : Controller
    {
        ShoppingServiceClient client = new ShoppingServiceClient();
        Hash hash = new Hash();

        public ActionResult Login()
        {
            if(isLoggedIn())
            {
                ViewBag.success = true;
            }
            return View();
        }

        [HttpPost]
        public ActionResult LoginSubmit(Userlogin login)
        {
            tryLogin(login);
            if(isLoggedIn())
            {
                ViewBag.name = getUserName();
                return View("Home");
            }
            else
            {
                ViewBag.fail = true;
                return View("Login");
            }
        }
        public ActionResult Home()
        {
            if(isLoggedIn())
            {
                ViewBag.name = getUserName();
                return View();
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult Products()
        {
            if(isLoggedIn())
            {
                return View(client.GetAllProducts());
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }

        // GET: Shopping/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shopping/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shopping/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shopping/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shopping/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shopping/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shopping/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void tryLogin(Userlogin login)
        {
            User user = client.GetUserByUsername(login.Username);
            if (user == null)
            {
                return;
            }
            if (user.Password == hash.HashPassword(login.Password))
            {
                HttpContext.Application["logged_in"] = true;
                HttpContext.Application["user_name"] = login.Username;
            }
        }

        public string getUserName()
        {
            return (string)HttpContext.Application["user_name"];
        }

        public bool isLoggedIn()
        {
            return (bool)HttpContext.Application["logged_in"];
        }

    }
}
