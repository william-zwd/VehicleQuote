using System;
using System.Collections.Generic;
using System.Xml;
using VehicleQuote.Api.Models;

namespace VehicleQuote.Api
{

    /// <summary>
    /// Used for parsing out make and model data
    /// </summary>
    public static class MakesModels 
    {
        public static List<VehicleMake> GetVehicleMakes(string dataFile)
        {
            var list = new List<VehicleMake>();

            var xmlDOC = new XmlDocument();
            xmlDOC.Load(dataFile);
            var nodeList = xmlDOC.DocumentElement.SelectNodes("/makes/make");

            foreach(XmlNode node in nodeList)
            {
                try
                {
                    int id = Int32.Parse(node.Attributes.GetNamedItem("id").InnerText);
                    string description = node.Attributes.GetNamedItem("description").InnerText;

                    var make = new VehicleMake()
                    {
                        ID = id,
                        Description = description
                    };

                    list.Add(make);
                }
                catch (Exception)
                {

                }
            }

            return list;
        }

        public static List<VehicleModel> GetVehicleModels(string dataFile)
        {
            var list = new List<VehicleModel>();

            var xmlDOC = new XmlDocument();
            xmlDOC.Load(dataFile);
            var makeNodeList = xmlDOC.DocumentElement.SelectNodes("/modelsbymake/make");

            foreach (XmlNode makeNode in makeNodeList)
            {
                string makeIDStr = makeNode.Attributes.GetNamedItem("id").InnerText;
                var modelNodeList = makeNode.SelectNodes("model");

                foreach(XmlNode modelNode in modelNodeList)
                {
                    try
                    {
                        int makeID = Int32.Parse(makeIDStr);
                        int id = Int32.Parse(modelNode.Attributes.GetNamedItem("id").InnerText);
                        string description = modelNode.Attributes.GetNamedItem("description").InnerText;

                        var model = new VehicleModel()
                        {
                            MakeID = makeID,
                            ID = id,
                            Description = description
                        };

                        list.Add(model);
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            return list;
        }
    }
}