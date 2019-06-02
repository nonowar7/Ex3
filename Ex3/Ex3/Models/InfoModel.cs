using Ex3.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml;

namespace Ex3.Models
{
    public class InfoModel
    {
        private static InfoModel s_instace = null;

        public static InfoModel Instance
        {
            get
            {
                if (s_instace == null)
                {
                    s_instace = new InfoModel();
                }
                return s_instace;
            }
        }

        [Required]
        public double Lon { get; set; }
        [Required]
        public double Lat { get; set; }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Position");
            writer.WriteElementString("Lon", this.Lon.ToString());
            writer.WriteElementString("Lat", this.Lat.ToString());
            writer.WriteEndElement();
        }

        public double GetLon()
        {
            Client client = Client.Instance;
            string line = client.getLine("longitude");
            double data = Double.Parse(client.getData(line));
            Lon = data;
            return data;
        }

        public double GetLat()
        {
            Client client = Client.Instance;
            string line = client.getLine("latitude");
            double data = Double.Parse(client.getData(line));
            Lat = data;
            return data;
        }
    }
}