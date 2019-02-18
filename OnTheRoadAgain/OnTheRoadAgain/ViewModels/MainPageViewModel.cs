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


namespace OnTheRoadAgain.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        private INavigationService _navigationService;

        private readonly IA _service;

        public DelegateCommand NavigateToInfoCommand { get; private set; }

        private string _url;
        public string Url {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        public ICommand navigated { get; set; }

        public MainPageViewModel(INavigationService navigationService, IA service)
            : base(navigationService) {
            Title = "Razmere na cestah";
            Url = "https://www.promet.si/portal/sl/razmere.aspx"; //PMapToBigMap(!0)

            _navigationService = navigationService;
            _service = service;
            _service.Do();

            NavigateToInfoCommand = new DelegateCommand(NavigateToInfo);

            navigated =  new Command(() => {
                System.Diagnostics.Debug.WriteLine("Navigated");
            });
        }

        private void NavigateToInfo() {
            _navigationService.NavigateAsync("InfoPage");
        }
    }
}
