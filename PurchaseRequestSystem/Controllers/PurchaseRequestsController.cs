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
    public class PurchaseRequestsController : Controller
    {
        // PurchaseRequests/List

        private AppDbContext db = new AppDbContext();

        public ActionResult ActivePurchaseRequests()
        {
            List<PurchaseRequest> purchaserequest = db.PurchaseRequests.Where(e => e.Active == true).ToList();
            return Json(purchaserequest, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List()
        {
            return Json(db.PurchaseRequests.ToList(), JsonRequestBehavior.AllowGet);
        }

        // /PurchaseRequests/Get/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            PurchaseRequest purchaserequest = db.PurchaseRequests.Find(id);
            if (purchaserequest == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return Json(purchaserequest, JsonRequestBehavior.AllowGet);
        }
        // /PurchaseRequests/Create [POST]
        public ActionResult Create([FromBody] PurchaseRequest purchaserequest)
        {
            purchaserequest.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.PurchaseRequests.Add(purchaserequest);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "PurchaseRequest was created."));
        }

        // /PurchaseRequests/Change [POST]
        public ActionResult Change([FromBody] PurchaseRequest purchaserequest)
        {
            PurchaseRequest purchaserequest2 = db.PurchaseRequests.Find(purchaserequest.ID);
            purchaserequest2.UserID = purchaserequest.UserID;
            purchaserequest2.Description = purchaserequest.Description;
            purchaserequest2.Justification = purchaserequest.Justification;
            purchaserequest2.DeliveryMode = purchaserequest.DeliveryMode;
            purchaserequest2.StatusID = purchaserequest.StatusID;
            purchaserequest2.Total = purchaserequest.Total;
            purchaserequest2.Active = purchaserequest.Active;
            purchaserequest2.ReasonForRejection = purchaserequest.ReasonForRejection;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "PurchaseRequest was changed."));
        }
        // /PurchaseRequests/Remove
        public ActionResult Remove([FromBody] PurchaseRequest purchaserequest)
        {
            PurchaseRequest purchaserequest2 = db.PurchaseRequests.Find(purchaserequest.ID);
            db.PurchaseRequests.Remove(purchaserequest2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "PurchaseRequest was deleted."));
        }
    }
}

      

    
