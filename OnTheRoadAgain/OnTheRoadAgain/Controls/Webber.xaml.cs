using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnTheRoadAgain.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Webber : ContentView {
        private readonly IA _service;

        #region Url3 (Bindable string)
        public static readonly BindableProperty Url3Property = BindableProperty.Create(
            "Url3", //Public name to use
            typeof(string), //this type
            typeof(Webber), //parent type (this control)
            string.Empty); //default value
        public string Url3 {
            get { return (string)GetValue(Url3Property); }
            set { SetValue(Url3Property, value); }
        }
        #endregion Url3 (Bindable string)

        public Webber() {
            InitializeComponent();
            Init();
        }

        public Webber(IA service = null) {
            InitializeComponent();
            Init();
            _service = service;
        }

        public async void Init() {
            WebView.Navigated += WebViewOnNavigated;
            _service?.Do();
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e) {
            var st = await WebView.EvaluateJavaScriptAsync("PMapToBigMap(!0)");
        }
    }
}