using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Caliburn.Micro;
using Monitor_kl2.Models;

namespace Monitor_kl2.ViewModels
{
    public class MonitorViewModel : Screen
    {
        private IMonitorHost _host;
        private string _status;
        private int _numberOfVisibleHosts;
        private Dictionary<int, Host> _allHostsList;
        private Timer _timer;
        public BindableCollection<Host> HostList { get; set; }
        public int NumberOfVisibleHosts
        {
            get { return _numberOfVisibleHosts; }
            set
            {
                _numberOfVisibleHosts = value;
                NotifyOfPropertyChange(() => NumberOfVisibleHosts);
            }

        }

        public MonitorViewModel(IMonitorHost host)
        {
            _host = host;
            HostList = new BindableCollection<Host>();
            _allHostsList = new Dictionary<int, Host>();
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _numberOfVisibleHosts = 10;
            _timer = new Timer(2000)
            {
                AutoReset = true
            };
            _timer.Elapsed += (s, e) => RefreshHosts();
            _timer.Start();

        }


        protected override void OnDeactivate(bool close)
        {
            _timer.Stop();
            _timer.Dispose();
            base.OnDeactivate(close);
        }

        public void RefreshHosts()
        {
            Status = "Wczytywanie";
            UpdateAllHostList();
            UpdateHostList();
            Status = "Gotowy";
        }

        /// <summary>
        /// Zarządza aktualnie wyświetlanymi hostami
        /// </summary>
        private void UpdateHostList()
        {
            var newHostList = _allHostsList.Values.Where(h => h.CurrentStatus == Host.Status.Active).OrderBy(h => h.Total).Take(NumberOfVisibleHosts)
                .Concat(_allHostsList.Values.Where(h => h.CurrentStatus != Host.Status.Active));

            //hosty do usuniecia z listy
            var hostsToRemove = HostList.Where(hl => !newHostList.Select(nhl => nhl.Id).Contains(hl.Id)).ToArray();
            HostList.RemoveRange(hostsToRemove);

            //hosty do dodania
            foreach (var h in newHostList)
            {
                var exHost = HostList.FirstOrDefault(hst => hst.Id == h.Id);
                if (exHost != null)
                    exHost = h;
                else
                {
                    h.CurrentStatus = Host.Status.AddedToList;
                    HostList.Add(h);
                }
            }
        }

        /// <summary>
        /// Zaznacza nowo dodane hosty - ustawia CurrentState
        /// </summary>
        private void UpdateAllHostList()
        {
            var newHosts = _host.ActualStats();

            if (_allHostsList.Count == 0)
                _allHostsList = newHosts;

            else
            {
                
                // usunac te z deleted
                foreach (var h in _allHostsList)
                {
                    h.Value.CurrentStatus = Host.Status.Active;

                    if (!newHosts.ContainsKey(h.Key))
                        h.Value.CurrentStatus = Host.Status.Disabled;
                }
                foreach (var nh in newHosts)
                {
                    if (!_allHostsList.ContainsKey(nh.Key))
                    {
                        _allHostsList.Add(nh.Key, nh.Value);
                        nh.Value.CurrentStatus = Host.Status.Activated;
                    }
                }
            }
            
            var chargedHsots = _allHostsList.Values.OrderBy(h => h.Total).Take(NumberOfVisibleHosts);
        }



    }
}
