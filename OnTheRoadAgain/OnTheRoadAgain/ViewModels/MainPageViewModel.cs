using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Debug = System.Diagnostics.Debug;

namespace OnTheRoadAgain.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        private INavigationService _navigationService;

        private readonly IEnumerable<IA> _service;
        //     private readonly IA _service;

        public DelegateCommand NavigateToInfoCommand { get; private set; }

        private string _url;
        public string Url {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        public ICommand navigated { get; set; }

        public MainPageViewModel(INavigationService navigationService, IEnumerable<IA>  service)
            : base(navigationService) {
            Title = "Razmere na cestah";
            Url = "https://www.promet.si/portal/sl/razmere.aspx"; //PMapToBigMap(!0)

            //var value = await webView.InvokeScriptAsync("eval", new string[] { "document.getElementById('lblDestination')" }
            _navigationService = navigationService;
            _service = service;
            //_service = service;
            _service.ForEach( w => w.Do());
            NavigateToInfoCommand = new DelegateCommand(NavigateToInfo);

            navigated =  new Command(() => {
                Debug.WriteLine("Navigated");
                //service.Do();
            });
        }

        private void NavigateToInfo() {
            _navigationService.NavigateAsync("InfoPage");
        }
    }
}
