using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VehicleQuote.Api;
using VehicleQuote.Api.Models;

namespace VehicleQuote.Controllers
{
    /// <summary>
    /// Provides vehicle information
    /// </summary>
    [RoutePrefix("Vehicle")]
	public class VehicleController : Controller 
    {
        private string _path;
        private List<VehicleMake> _makes;
        private List<VehicleModel> _models;

        public VehicleController()
        {
        }

        public List<VehicleMake> GetVehicleMakes()
        {
            _makes = MakesModels.GetVehicleMakes(_path + @"/makes.xml");
            return _makes;
        }

        public List<VehicleModel> GetVehicleModelByMakeID(int makeID)
        {
            if (makeID > 0)
            {
                _models = MakesModels.GetVehicleModels(_path + @"/modelsbymake.xml");
                return _models.Where(m => m.MakeID == makeID).ToList();
            }

            return new List<VehicleModel>();
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
	}
}