using System;
using TaskList.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TaskPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
