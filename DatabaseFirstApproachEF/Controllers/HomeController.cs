using DatabaseFirstApproachEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseFirstApproachEF.Controllers
{
    public class HomeController : Controller
    {
        DataBaseFirstApproachEFEntities db = new DataBaseFirstApproachEFEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid == true)
            {
                //db.Students.Add(s);
                db.Entry(s).State = EntityState.Added;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Not Inserted !!')</script>";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Updated !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Not Updated !!')</script>";
                }
            }
            return View();
        }

        [HttpGet] //Case 1 (Are you sure you want to delete this?)
        public ActionResult Delete(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Deleted !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["DeleteMessage"] = "<script>alert('Not Deleted !!')</script>";
                }
            }
            return View();
        }

        /*
        [HttpGet] //Case 2
        public ActionResult NewDelete(int id)
        {
            if (id > 0)
            {
                var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = System.Data.Entity.EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Deleted !!')</script>";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Not Deleted !!')</script>";
                    }
                }
            }
            return View();
        }
        */

        [HttpGet]
        public ActionResult Details(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
    }
}