using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VehicleQuote.Api.Tests
{
    [TestClass]
    public class MakesModelsUnitTest
    {
        private string _path;

        public MakesModelsUnitTest()
        {
            _path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            _path += @"/../../../VehicleQuote/App_Data";
        }

        [TestMethod]
        public void VehicleMakeFileExist()
        {
            var dataFile = _path + @"/makes.xml";
            Assert.IsTrue(File.Exists(dataFile), "Data file of vehicle make should exist in App_Data fold");
        }

        [TestMethod]
        public void VehicleModelFileExist()
        {
            var dataFile = _path + @"/modelsbymake.xml";
            Assert.IsTrue(File.Exists(dataFile), "Data file of vehicle model should exist in App_Data fold");
        }

        [TestMethod]
        public void VehicleMakeFileHasData()
        {
            var dataFile = _path + @"/makes.xml";
            var makes = MakesModels.GetVehicleMakes(dataFile);
            Assert.IsNotNull(makes, "Data file of vehicle make should has data");
        }

        [TestMethod]
        public void VehicleModelFileHasData()
        {
            var dataFile = _path + @"/modelsbymake.xml";
            var models = MakesModels.GetVehicleModels(dataFile);
            Assert.IsNotNull(models, "Data file of vehicle model should has data");
        }
    }
}
