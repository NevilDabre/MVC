//<!-- Neville Dabre & Moonsun Choi-->
using ShoppingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingMall.Controllers
{
    public class ShoppingController : Controller
    {
        double shirtPrice = 70.0;
        double cameraPrice = 95.0;
        double watchPrice = 200.0;
        double tax = 0, total = 0,finalCost = 0;
        DateTime today = DateTime.Today.Date;
        DateTime deliveryDate;
        Double deliveryCost;
        int shirtQ, cameraQ ,watchQ, phone;
        string name , email , address, postalCode,provience;

        Dictionary<string, double> proviences = new Dictionary<string,double>();

        
        // GET: Shopping
        public ActionResult Index()
        {
            return View();
        }

        // GET: Shopping/Details/5
        public ActionResult Details(FormCollection form)
        {
            shirtQ = int.Parse(form["shirtQuantity"]);
            cameraQ = int.Parse(form["cameraQuantity"]);
            watchQ = int.Parse(form["watchQuantity"]);
            name = form["name"].ToString();
            email = form["email"].ToString();
            phone = Int32.Parse(form["phone"]);
            address = form["address"].ToString();
            postalCode = form["postalCode"].ToString();
            provience = form["provience"].ToString();

/*            if (shirtQ > 0 || cameraQ > 0 || watchQ > 0)
            {
*/

                proviences.Add("AB", 0.05);
                proviences.Add("BC", 0.12);
                proviences.Add("MB", 0.13);
                proviences.Add("NB", 0.15);
                proviences.Add("NL", 0.13);
                proviences.Add("NS", 0.05);
                proviences.Add("NT", 0.15);
                proviences.Add("NU", 0.05);
                proviences.Add("ON", 0.13);
                proviences.Add("PE", 0.14);
                proviences.Add("QC", 0.14975);
                proviences.Add("SK", 0.10);
                proviences.Add("YT", 0.05);

            total = shirtQ * shirtPrice + cameraQ * cameraPrice + watchQ * watchPrice;

            if (total==0)
            {
                deliveryCost = 0;
                deliveryDate = DateTime.Now;
            }
                else if (total > 0 && total < 25 )
            {
                deliveryDate = today.AddDays(1);
                deliveryCost = 3;
            }
                else if(total > 25 && total < 50)
            {
                deliveryDate = today.AddDays(2);
                deliveryCost = 4;
            }
                else if (total > 50 && total < 75)
            {
                deliveryDate = today.AddDays(3);
                deliveryCost = 5;
            }
                else if (total > 75)
            {
                deliveryDate = today.AddDays(4);
                deliveryCost = 6;
            }


                double rate = proviences.FirstOrDefault(t => t.Key == provience).Value;

                tax = total * rate;

                finalCost = total + tax + deliveryCost;

                var shopping = new ShoppingCart { shirt = shirtQ, watch = watchQ, camera = cameraQ, name = name, email = email, phoneNumber = phone, address = address, postalCode = postalCode, provience = provience, total = total, tax = tax, finalCost = finalCost, deliveryCost = deliveryCost, deliveryDate = deliveryDate };

                return View(shopping);
         /*   }
            else
            {
                var error = new ErrorMessage { errorMsg = "Buy Some Items!" };
                return View(error);
            }*/
        

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
        
    }
}
