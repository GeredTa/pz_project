using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PzProj.Models
{
    public class MeasurTypes
    {
        [Key]
        public int id { get; set; }
        public int name { get; set; }
        public int description { get; set; }
    }
}