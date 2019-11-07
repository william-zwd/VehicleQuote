using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using VehicleQuote.Api.Models;

namespace VehicleQuote.Models
{
    public class QuoteViewModel
    {
        public bool Post { get; set; }

        private List<VehicleMake> _makes;
        private List<VehicleModel> _models;

        [Display(Name="Make")]
        [Required(ErrorMessage = "Please select a vehicle make")]
        public int SelectedVehicleMakeID { get; set; }
        public IEnumerable<SelectListItem> VehicleMakes 
        { 
            get             
            {
                return new SelectList(_makes, "ID", "Description");
            }
        }

        public string SelectedVehicleMake 
        { 
            get
            {
                if (SelectedVehicleMakeID != 0)
                {
                    return Makes.First(v => v.ID == SelectedVehicleMakeID).Description;
                }

                return "";
            }
        }

        public List<VehicleMake> Makes 
        {
            get 
            { 
                return _makes; 
            } 
            set 
            { 
                _makes = value; 
            } 
        }

        [Display(Name ="Model")]
        [Required(ErrorMessage = "Please select a vehicle model")]
        public int SelectedVehicleModelID { get; set; }
        public IEnumerable<SelectListItem> VehicleModels
        {
            get
            {
                return new SelectList(_models, "ID", "Description");
            }
        }

        public string SelectedVehicleModel
        {
            get
            {
                if (SelectedVehicleMakeID != 0 && SelectedVehicleModelID != 0)
                {
                    return Models.First(v => v.MakeID == SelectedVehicleMakeID && v.ID == SelectedVehicleModelID).Description;
                }

                return "";
            }
        }

        public List<VehicleModel> Models
        {
            get
            {
                return _models;
            }
            set
            {
                _models = value;
            }
        }
    }
}