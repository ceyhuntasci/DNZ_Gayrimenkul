using DNZ_Gayrimenkul.DAL;
using DNZ_Gayrimenkul.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity;

namespace DNZ_Gayrimenkul.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private DNZContext db = new DNZContext();

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                User login = db.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

                if (login != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.Email));
                    claims.Add(new Claim(ClaimTypes.GivenName, login.FullName));
                    claims.Add(new Claim(ClaimTypes.Sid, login.ID.ToString()));
                    var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
 
                    var authenticationManager = Request.GetOwinContext().Authentication;
                    authenticationManager.SignIn(id);


                    authenticationManager.User.AddIdentity(id);


                    return RedirectToAction("Index", "Main");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }

            }
            return View();
        }

        public ActionResult LogOut()
        {
            Request.GetOwinContext().Authentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}