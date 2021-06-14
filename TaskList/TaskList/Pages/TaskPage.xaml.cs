using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Models;
using TaskList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        public TaskPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new TaskViewModel();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage(null));
        }
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var task = e.SelectedItem as TaskModel;
                await Navigation.PushAsync(new AddTaskPage(task));
            }
        }
    }
}