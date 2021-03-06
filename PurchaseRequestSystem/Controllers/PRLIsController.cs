﻿using PurchaseRequestSystem.Models;
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
    public class PRLIsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        private void CalculateTotal(int PurchaseRequestID) {
            db = new AppDbContext();
            var purchaseRequest = db.PurchaseRequests.Find(PurchaseRequestID);
            purchaseRequest.Total = purchaseRequest.PRLIs
                .Sum(prli => prli.Quantity * prli.Product.Price);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        // PRLIs/List
        public ActionResult ActivePRLIs()
        {
            List<PRLI> prli = db.PRLIs.Where(e => e.Active == true).ToList();
            return Json(prli, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List()
        {
             return new JsonNetResult { Data = db.PRLIs.ToList() };
        }
        // /PRLIs/Get/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            PRLI prli = db.PRLIs.Find(id);
            if (prli == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return new JsonNetResult { Data = prli };
        }
        // /PRLIs/Create [POST]
        public ActionResult Create([FromBody] PRLI prli)
        {
            prli.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.PRLIs.Add(prli);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            //CalculateTotal(prli)
            //db.SaveChanges();
            return Json(new JsonMessage("Success", "PRLI was created."));
        }

        // /PRLIs/Change [POST]
        public ActionResult Change([FromBody] PRLI prli)
        {
            PRLI prli2 = db.PRLIs.Find(prli.ID);
            prli2.PurchaseRequestID = prli.PurchaseRequestID;
            prli2.ProductID = prli.ProductID;
            prli2.Quantity = prli.Quantity;
            prli2.Active = prli.Active;
            prli2.DateCreated = prli.DateCreated;
            
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "PRLI was changed."));
        }
        // /PRLIs/Remove
        public ActionResult Remove([FromBody] PRLI prli)
        {
            PRLI prli2 = db.PRLIs.Find(prli.ID);
            db.PRLIs.Remove(prli2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "PRLI was deleted."));
        }
        // /PurchaseRequests/List
        //public ActionResult Change([FromBody] PurchaseRequest purchaserequest)
        //
        // PR Total
        //-> Read PR
        //-> Loop through the associated PRLI
        //-> For each, tally up by Quantity * Product.Price
        //-> Create variable for running total 
        //-> Update PurchaseRequest.Total
    }
}


