using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ex3.Models;
using Ex3.Communication;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System.Drawing;

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
        public ActionResult display(string ip, int port)
        {

            // need to check if the ip+port are good?

            Client client = new Client();
            client.connect(ip, port);

            string lat = client.getInfo("latitude");
            string lon = client.getInfo("longitude");

            ViewBag.lat = Double.Parse(lat);
            ViewBag.lon = Double.Parse(lon);

            return View();
        }

    }
}