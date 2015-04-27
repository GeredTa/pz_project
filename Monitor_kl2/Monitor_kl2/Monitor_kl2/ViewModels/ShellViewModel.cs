using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monitor_kl2.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.AllActive
    {
        private string _adress;
        private IMonitorHost _monitHost;

        public ShellViewModel()
        {
            _monitHost = new MonitorHost();
        }

        public string Address
        {
            get { return _adress; }
            set
            {
                _adress = value;
                NotifyOfPropertyChange(() => Address);
                NotifyOfPropertyChange(() => CanConnect);
            }
        }

        public bool CanConnect
        {
            get { return (!string.IsNullOrWhiteSpace(Address) && !Items.Any(item => item.DisplayName == Address)); }
        }

        public void Connect()
        {
            ActivateItem(new MonitorViewModel(_monitHost) { DisplayName = Address });
            NotifyOfPropertyChange(() => CanConnect);
        }

        public void Close()
        {

        }

    }
}
