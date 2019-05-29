using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
    public class InfoModel
    {
        [Required]
        public double Lon { get; set; }
        [Required]
        public double Lat { get; set; }
    }
}