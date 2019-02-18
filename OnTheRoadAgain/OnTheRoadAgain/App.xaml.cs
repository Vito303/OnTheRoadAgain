using Android.OS;
using Prism;
using Prism.Ioc;
using OnTheRoadAgain.ViewModels;
using OnTheRoadAgain.Views;
using Prism.DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OnTheRoadAgain {
    public partial class App {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized() {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<InfoPage, InfoPageViewModel>();
            containerRegistry.Register(typeof(IA), typeof(A));
            containerRegistry.Register(typeof(ILog), typeof(Logger));
        }
    }

    public class A : IA {
        private ILog log;

        public A(ILog log) {
            this.log = log; 
        }

        public void Do() {
            log.Log("a");
        }
    }

    public class B : IA {
        public void Do() {
            System.Diagnostics.Debug.WriteLine("b");
        }
    }

    public interface ILog {
        void Log(string st);
    }

    public class Logger : ILog {
        public void Log(string st) {
            System.Diagnostics.Debug.WriteLine(st);
        }
    }
}
