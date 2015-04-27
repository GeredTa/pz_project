using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monitor_kl2.Models
{
    public class Host
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IpAddr { get; set; }
        public int CpuUsege { get; set; }
        public int RamUsage { get; set; }

        public Status CurrentStatus { get; set; }

        public int Total
        {
            get { return (CpuUsege + RamUsage)/2; }
        }

        public enum Status
        {
            Active = 0,
            Activated  = 1, 
            Disabled = 2,
            AddedToList = 3,
            DeletedFromList = 4
        }
    }
}
