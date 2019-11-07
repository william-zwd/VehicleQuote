using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleQuote.Controllers;

namespace VehicleQuote.Tests
{
    [TestClass]
    public class VehicleQuoteUnitTest
    {
        private VehicleController _controller;

        public VehicleQuoteUnitTest()
        {
            _controller = new VehicleController();
            var path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            path += @"/../../../VehicleQuote/App_Data";
            _controller.Path = path;
        }

        [TestMethod]
        public void GetVehicleMakes()
        {
            var makes = _controller.GetVehicleMakes();
            Assert.IsTrue(makes.Count == 6, "Data file of vehicle make has 6 valid records.");
        }

        [TestMethod]
        public void GetVehicleModelByInvalidMakeID()
        {
            var models = _controller.GetVehicleModelByMakeID(0);
            Assert.IsTrue(models.Count == 0, "Data file of vehicle model of make id 0 has no valid record.");
        }

        [TestMethod]
        public void GetVehicleModelByValidMakeID()
        {
            var models = _controller.GetVehicleModelByMakeID(1);
            Assert.IsNotNull(models, "Data file of vehicle model of make id 1 has valid records.");
        }
    }
}
