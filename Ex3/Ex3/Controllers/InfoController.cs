using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ex3.Models;
using Ex3.Communication;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System.Drawing;
using System.Text;
using System.Xml;

namespace Ex3.Controllers
{
    public class InfoController : Controller
    {
        static List<InfoModel> positions = new List<InfoModel>()
        {
            new InfoModel {Lon = 0, Lat = 0}
        };

        // GET: Info
        public ActionResult Index()
        {
            return View();
        }

       
        [HttpGet]
        public ActionResult display(string ip, int port, int? time=0)
        {

            // need to check if the ip+port are good?

            ViewBag.time = time;

            Client client = Client.Instance;
            client.connect(ip, port);

            return View();
        }

        [HttpPost]
        public string GetPosition()
        {
            InfoModel info = InfoModel.Instance;
            ViewBag.lat = info.GetLat();
            ViewBag.lon = info.GetLon();

            var pos = InfoModel.Instance;
            string posString = pos.Lat.ToString() + "," + pos.Lon.ToString();
            return posString;
         //   return ToXml(pos);
        }

        private string ToXml(InfoModel position)
        {
            //Initiate XML stuff
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(sb, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("positions");

            position.ToXml(writer);

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            return sb.ToString();
        }

    }
}