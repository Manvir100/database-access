using ShoppingClient.Models;
using ShoppingClient.ShoppingServiceReference;
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
                ViewBag.name = getUserName();
                return View("Home");
            }
            return View();
        }
        public ActionResult Logout()
        {
            tryLogout();
            ViewBag.success = true;
            return View("Login");
        }

        [HttpPost]
        public ActionResult LoginSubmit(Userlogin login = null)
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
        [HttpPost]
        public ActionResult ProductSubmit(Product product)
        {
            if (isLoggedIn())
            {
                client.AddProduct(product);
                return View("Products", client.GetAllProducts());
            }
            else
            {
                ViewBag.fail = true;
                return View("Login");
            }
        }
        [HttpPost]
        public ActionResult UserSubmit(User user)
        {
            if (isLoggedIn())
            {
                client.AddUser(user);
                return View("Users", client.GetAllUsers());
            }
            else
            {
                ViewBag.fail = true;
                return View("Login");
            }
        }
        [HttpPost]
        public ActionResult UserInfosSubmit(UserInfo userInfo)
        {
            if (isLoggedIn())
            {
                client.AddUserInfos(userInfo);
                return View("UserInfos", client.GetAllUserInfos());
            }
            else
            {
                ViewBag.fail = true;
                return View("Login");
            }
        }
        [HttpPost]
        public ActionResult ProductEditSubmit(Product product)
        {
            if (isLoggedIn())
            {
                client.EditProduct(product);
                return View("Products", client.GetAllProducts());
            }
            else
            {
                ViewBag.fail = true;
                return View("Login");
            }
        }
        [HttpPost]
        public ActionResult UserEditSubmit(User user)
        {
            if (isLoggedIn())
            {
                client.EditUser(user);
                return View("Users", client.GetAllUsers());
            }
            else
            {
                ViewBag.fail = true;
                return View("Login");
            }
        }
        [HttpPost]
        public ActionResult UserInfosEditSubmit(UserInfo userInfo)
        {
            if (isLoggedIn())
            {
                client.EditUserInfos(userInfo);
                return View("UserInfos", client.GetAllUserInfos());
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
        public ActionResult EditProduct(int id = 1)
        {
            if (isLoggedIn())
            {
                return View(client.GetAProduct(id));
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult EditUser(int id = 1)
        {
            if (isLoggedIn())
            {
                return View(client.GetAUser(id));
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult EditUserInfos(int id = 1)
        {
            if (isLoggedIn())
            {
                return View(client.GetAUserInfos(id));
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult CreateProduct()
        {
            if (isLoggedIn())
            {
                return View();
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult CreateUser()
        {
            if (isLoggedIn())
            {
                return View();
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult CreateUserInfos()
        {
            if (isLoggedIn())
            {
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
        public ActionResult ProductsDetails(int id = 1)
        {
            if (isLoggedIn())
            {
                return View(client.GetAProduct(id));
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult DeleteUser(int id = 1)
        {
            if (isLoggedIn())
            {
                client.DeleteUser(id);
                return View("Users", client.GetAllUsers());
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult DeleteUserInfos(int id = 1)
        {
            if (isLoggedIn())
            {
                client.DeleteUserInfos(id);
                return View("UserInfos", client.GetAllUserInfos());
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult DeleteProduct(int id = 1)
        {
            if (isLoggedIn())
            {
                client.DeleteProduct(id);
                return View("Products", client.GetAllProducts());
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult Users()
        {
            if (isLoggedIn())
            {
                return View(client.GetAllUsers());
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult UsersDetails(int id = 1)
        {
            if (isLoggedIn())
            {
                return View(client.GetAUser(id));
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult UserInfosDetails(int id = 1)
        {
            if (isLoggedIn())
            {
                return View(client.GetAUserInfos(id));
            }
            else
            {
                ViewBag.error = true;
                return View("Login");
            }
        }
        public ActionResult UserInfos()
        {
            if (isLoggedIn())
            {
                return View(client.GetAllUserInfos());
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

        public ActionResult GetProductsByPrice(double productPrice)
        {
            return View(client.GetProductsGreaterThanOrEqualToPrice(productPrice));
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
                HttpContext.Application["user_name"] = user.Username;
            }
        }
        public void tryLogout()
        {
            HttpContext.Application["logged_in"] = false;
            HttpContext.Application["user_name"] = "";
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
