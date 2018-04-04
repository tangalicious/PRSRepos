using PurchaseRequestSystem.Models;
using PurchaseRequestSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Utility;


namespace PurchaseRequestSystem.Controllers
{
    public class UsersController : Controller
    {
        // Users/Log-in

        // GET: Users/Login/username/password
        public ActionResult Login(string username, string password)
        {
            if (username == null || password == null)
            {
                return new JsonNetResult { Data = new Msg { Result = "Failed", Message = "Invalid username/password." } };
            }
            var user = db.Users.SingleOrDefault(u => u.UserName == username && u.Password == password);
            if (user == null)
            {
                return new JsonNetResult { Data = new Msg { Result = "Failed", Message = "Invalid username/password." } };
            }
            return new JsonNetResult { Data = new Msg { Result = "Success", Message = "Login successful.", Data = user } };
        }
        

        // Users/List

        private AppDbContext db = new AppDbContext();

        public ActionResult ActiveUsers()
        {
            List<User> user = db.Users.Where(e => e.Active == true).ToList();
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Users.ToList() };
        }
        // /Users/Get/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return new JsonNetResult { Data = user };
        }
        // /Users/Create [POST]
        public ActionResult Create([FromBody] User user)
        {
            if (user.UserName == null) return new EmptyResult();
            user.DateCreated = DateTime.Now; 
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.Users.Add(user);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "User was created."));
        }

        // /Users/Change [POST]
        public ActionResult Change([FromBody] User user)
        {
            if (user.UserName == null) return new EmptyResult();
            User user2 = db.Users.Find(user.ID);
            user2.UserName = user.UserName;
            user2.Password = user.Password;
            user2.FirstName = user.FirstName;
            user2.LastName = user.LastName;
            user2.Phone = user.Phone;
            user2.Email = user.Email;
            user2.IsReviewer = user.IsReviewer;
            user2.IsAdmin = user.IsAdmin;
            user2.Active = user.Active;
            
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "User was changed."));
        }
        // /Users/Remove
        public ActionResult Remove([FromBody] User user)
        {
            if (user.UserName == null) return new EmptyResult();
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            
            User user2 = db.Users.Find(user.ID);
            db.Users.Remove(user2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "User was deleted."));
        }
    }
}