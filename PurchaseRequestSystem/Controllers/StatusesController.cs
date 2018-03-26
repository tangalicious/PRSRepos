using PurchaseRequestSystem.Models;
using PurchaseRequestSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PurchaseRequestSystem.Controllers
{
    public class StatusesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // /Statuses/List

        public ActionResult ActiveProducts()
        {
            List<Status> status = db.Statuses.Where(e => e.Active == true).ToList();
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Statuses.ToList() };
        }
        // /Statuses/Get/3
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            Status status = db.Statuses.Find(id);
            if (status == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return new JsonNetResult { Data = status };
        }
        // /Statuses/Create [POST]
        public ActionResult Create([FromBody] Status status)
        {
            status.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.Statuses.Add(status);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Status was created."));
        }
        // /Statuses/Change [POST]
        public ActionResult Change([FromBody] Status status)
        {
            Status status2 = db.Statuses.Find(status.ID);
            status2.Description = status.Description;
            status2.Active = status.Active;
           
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Status was changed."));
        }
        // /Statuses/Remove
        public ActionResult Remove([FromBody] Status status)
        {
            Status status2 = db.Statuses.Find(status.ID);
            db.Statuses.Remove(status2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Status was deleted."));
        }
    }
}