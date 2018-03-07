﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using TyresStore.Repository;
using TyresStore.Repository.Models;

namespace TyresStore.Controllers
{
    public class HomeController : Controller
    {
        VehiclesRepository vehiclesRepo = new VehiclesRepository();
        TyresRepository tyresRepo = new TyresRepository();
        BasketRepository BasketRepo = new BasketRepository();

        public ActionResult Index()
        {
            List<Vehicle> vehicles = vehiclesRepo.GetVehicles();

            return View(vehicles);
        }

        public string GetTyres(int vehicleId)
        {
            List<Tyre> tyres = tyresRepo.GetTyresByVehicleId(vehicleId);

            string ret = RenderPartialViewToString("~/Views/Home/TyresView.cshtml", tyres);

            return ret;
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

       public ActionResult AddTyreToBasket(int tyreId, string description)
        {
            bool tyreAdded = BasketRepo.TyreAlreadyAdded(tyreId);

            if (!tyreAdded)
                BasketRepo.StoreTyre(tyreId, description);

            return Json(new { exists = tyreAdded });
        }

        public ActionResult GetBasketItems()
        {
            return Json(BasketRepo.GetItems(), JsonRequestBehavior.AllowGet);
        }

        public string GetBasketHtml()
        {
            List<Basket> basket = BasketRepo.GetItems();

            string ret = RenderPartialViewToString("~/Views/Home/Basket.cshtml", basket);

            return ret;
        }

        public string RemoveItemFromBasket(int itemId)
        {
            BasketRepo.RemoveItem(itemId);

            List<Basket> basket = BasketRepo.GetItems();

            string ret = RenderPartialViewToString("~/Views/Home/Basket.cshtml", basket);

            return ret;

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}