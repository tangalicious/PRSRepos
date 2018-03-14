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
    public class ProductsController : Controller
    {
        private AppDbContext db = new AppDbContext();
        
        // /Products/List

        public ActionResult ActiveProducts()
        {
            List<Product> product = db.Products.Where(e => e.Active == true).ToList();
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List()
        {
            return Json(db.Products.ToList(), JsonRequestBehavior.AllowGet);
        }
        // /Products/Get/5
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        // /Products/Create [POST]
        public ActionResult Create([FromBody] Product product)
        {
            product.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.Products.Add(product);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Product was created."));
        }
        // /Products/Change [POST]
        public ActionResult Change([FromBody] Product product)
        {
            Product product2 = db.Products.Find(product.ID);
            product2.VendorID = product.VendorID;
            product2.Name = product.Name;
            product2.Price = product.Price;
            product2.Unit = product.Unit;
            product2.PhotoPath = product.PhotoPath;
            product2.Active = product.Active;
            product2.UpdatedByUser = product.UpdatedByUser;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Product was changed."));
        }
        // /Products/Remove
        public ActionResult Remove([FromBody] Product product)
        {
            Product product2 = db.Products.Find(product.ID);
            db.Products.Remove(product2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Product was deleted."));
        }
    }
}