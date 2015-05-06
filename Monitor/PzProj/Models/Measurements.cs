using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PzProj.Models
{

    public class Measurements
    {
        [Key]
        public int id { get; set; }
        public virtual Hosts host { get; set; }
        public virtual MeasurTypes type { get; set; }
        public int usage { get; set; }

    }
}