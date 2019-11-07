using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VehicleQuote.Api.Models;
using VehicleQuote.Models;

namespace VehicleQuote.Controllers
{
    /// <summary>
    /// Controller that serves the quoting portion of the website
    /// </summary>
    [RoutePrefix("Quote")]
	[Route("{action}")]
	public class QuoteController : Controller 
    {
        private VehicleController _vehicleController;

        public QuoteController()
        {
            _vehicleController = new VehicleController();
            _vehicleController.Path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        }

		/// <summary>
		/// Index action / landing page
		/// </summary>
		/// <returns>A ViewResult</returns>
		[Route]
		[Route("~/")]
		[Route("Index")]
		[HttpGet]
		public ViewResult Index() 
        {
            var quote = new QuoteViewModel();

            quote.Post = false;
            quote.Makes = _vehicleController.GetVehicleMakes();
            quote.Models = new List<VehicleModel>();

			return View(quote);
		}

        [HttpGet]
        public JsonResult GetVehicleModelsByMakeID(int makeID)
        {
            var models = _vehicleController.GetVehicleModelByMakeID(makeID);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Post(QuoteViewModel model)
        {
            model.Makes = _vehicleController.GetVehicleMakes();
            if (model.SelectedVehicleMakeID != 0)
            {
                model.Models = _vehicleController.GetVehicleModelByMakeID(model.SelectedVehicleMakeID);
            }
            else
            {
                model.Models = new List<VehicleModel>();
            }

            if (ModelState.IsValid)
            {
                model.Post = true;
            }

            return View("Index", model);
        }



    }
}