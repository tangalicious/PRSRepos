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
    public class VendorsController : Controller
    {
        // Vendors/List

        private AppDbContext db = new AppDbContext();

        public ActionResult ActiveVendors()
        {
            List<Vendor> vendor = db.Vendors.Where(e => e.Active == true).ToList();
            return Json(vendor, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Vendors.ToList() };
        }
        // /Vendors/Get/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return new JsonNetResult { Data = vendor };
        }
        // /Vendors/Create [POST]
        public ActionResult Create([FromBody] Vendor vendor)
        {

            vendor.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.Vendors.Add(vendor);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Vendor was created."));
        }

        // /Vendors/Change [POST]
        public ActionResult Change([FromBody] Vendor vendor)
        {
            if (vendor.Code == null) return new EmptyResult();
            Vendor vendor2 = db.Vendors.Find(vendor.ID);
            vendor2.Code = vendor.Code;
            vendor2.Name = vendor.Name;
            vendor2.Address = vendor.Address;
            vendor2.City = vendor.City;
            vendor2.State = vendor.State;
            vendor2.Zip = vendor.Zip;
            vendor2.Phone = vendor.Phone;
            vendor2.Email = vendor.Email;
            vendor2.IsPreApproved = vendor.IsPreApproved;
            vendor2.Active = vendor.Active;
             try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Vendor was changed."));
        }
        // /Vendors/Remove
        public ActionResult Remove([FromBody] Vendor vendor)
        {
            if (vendor.Code == null) return new EmptyResult();
            Vendor vendor2 = db.Vendors.Find(vendor.ID);
            db.Vendors.Remove(vendor2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Vendor was deleted."));
        }
    }
}