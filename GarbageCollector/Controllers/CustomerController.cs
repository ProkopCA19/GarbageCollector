using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarbageCollector.Models;
using Microsoft.AspNet.Identity;

namespace GarbageCollector.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customerList = db.Customer.Include(m => m.Zipcode).Include(p=>p.Pickup).ToList();
            return View(customerList);
        }
           




            // GET: Customers/Details/5
            public ActionResult Details(int? id)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customer customer = db.Customer.Include(m => m.Zipcode).Include(p => p.Pickup).Where(c=>c.CustomerID==id).FirstOrDefault();
                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View(customer);
            }

            // GET: Customers/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Customers/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Address,City,State,TrashBalance,ZipId,UserId,PickupID,Zipcode,PickupDay,Areacode,DayOfWeek")] CustomerViewModel cvm)
            {
                string currentUserId = User.Identity.GetUserId();
                var customer = new Customer();
                customer.UserId = currentUserId;
                customer.PickupId = db.Pickup.Where(p => p.DayOfWeek == cvm.PickupDay).FirstOrDefault().PickupID;
                customer.FirstName = cvm.FirstName;
                customer.LastName = cvm.LastName;
                customer.Address = cvm.Address;
                customer.City = cvm.City;
                customer.State = cvm.State;
                customer.Trashbalance = cvm.Trashbalance;
                customer.ZipId = db.Zipcode.Where(z => z.Areacode == cvm.Zipcode).FirstOrDefault().ZipId;

            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

                return View(customer);
            }

            // GET: Customers/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                    Customer customer = db.Customer.Find(id);
                    CustomerViewModel cvm = new CustomerViewModel();
                    cvm.customer = customer;
                    cvm.CustomerID = cvm.customer.CustomerID;
                    cvm.FirstName = cvm.customer.FirstName;
                    cvm.LastName = cvm.customer.LastName;
                    cvm.Address = cvm.customer.Address;
                    cvm.City = cvm.customer.City;
                    cvm.State = cvm.customer.State;
                    cvm.Trashbalance = cvm.customer.Trashbalance;
                    cvm.PickupDay = db.Pickup.Where(p => p.PickupID == cvm.customer.PickupId).FirstOrDefault().DayOfWeek;
                    cvm.Zipcode = db.Zipcode.Where(z => z.ZipId == cvm.customer.ZipId).FirstOrDefault().Areacode;

            if (customer == null)
                {
                   return HttpNotFound();
                }
                   return View(cvm);
            }

            // POST: Customers/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Address,City,State,TrashBalance,ZipId,UserId,PickupID,DayOfWeek,Zipcode,PickupDay")] CustomerViewModel cvm)
            {
            if (ModelState.IsValid)
            {
                var customerToEdit = db.Customer.Where(s => s.CustomerID == cvm.CustomerID).FirstOrDefault();
                customerToEdit.FirstName = cvm.FirstName;
                customerToEdit.LastName = cvm.LastName;
                customerToEdit.Address = cvm.Address;
                customerToEdit.City = cvm.City;
                customerToEdit.State = cvm.State;
                customerToEdit.Trashbalance = cvm.Trashbalance;
                customerToEdit.ZipId = db.Zipcode.Where(z => z.Areacode == cvm.Zipcode).FirstOrDefault().ZipId;
                customerToEdit.PickupId = db.Pickup.Where(p => p.DayOfWeek == cvm.PickupDay).FirstOrDefault().PickupID;

                db.SaveChanges();


            }

                return RedirectToAction("Index");
            }
    
                
            

            // GET: Customers/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customer customer = db.Customer.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View(customer);
            }

            // POST: Customers/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Customer customer = db.Customer.Find(id);
                db.Customer.Remove(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }


        public ActionResult Dailypickups()
        {
            var userId = User.Identity.GetUserId();
            var employeeZipCode = db.Employee.Where(c => c.UserId == userId).Select(c => c.Zipcode.Areacode).FirstOrDefault();

            var dailyPickUps = db.Customer.Include(m => m.Zipcode).Include(p => p.Pickup).Where(p => p.Zipcode.Areacode == employeeZipCode).Select(p => p).ToList();

            return View(dailyPickUps);
        }
    }
}