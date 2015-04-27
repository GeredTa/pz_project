using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitor_kl2.Models;

namespace Monitor_kl2
{
    public interface IMonitorHost
    {
        Dictionary<int, Host> ActualStats();
    }
}
