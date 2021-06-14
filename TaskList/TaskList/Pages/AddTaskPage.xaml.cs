using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.DataBase.Task;
using TaskList.Models;
using TaskList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskPage : ContentPage
    {
        public AddTaskPage(TaskModel task)
        {
            InitializeComponent();
            BindingContext = new AddTaskViewModel(task);
        }


        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}