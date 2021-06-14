using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaskList.DataBase.Task;
using TaskList.Models;

namespace TaskList.ViewModels
{
   public class AddTaskViewModel : BaseViewModel
    {
        private bool isEdit;
        TaskDatabase database;
        private TaskModel task;
        public TaskModel Task
        {
            get => task;
            set => SetProperty(ref task, value);
        }
        //command
        //public ICommand EditCommand => new RelayCommand(DeleteTask);
        public ICommand SaveCommand => new RelayCommand(SaveTask);
        public ICommand DeleteCommand => new RelayCommand(DeleteTask);
        public AddTaskViewModel(TaskModel task)
        {
            isEdit = task == null ? false : true;
            Title = isEdit ? "Edit Task" : "Add Task";
            Task = task == null ? new TaskModel() : task;
            InitialDb();
        }
        private async void InitialDb()
        {
            database = await TaskDatabase.Instance;
        }

        private async void  SaveTask()
        {
            if (isEdit)
            {
                EditTask();
                return;
            }
            await database.SaveItemAsync(Task);
            await App.Current.MainPage.Navigation.PopAsync();
        }
        private async void EditTask()
        {
            await database.EditItemAsync(Task);
            await App.Current.MainPage.Navigation.PopAsync();
           
        }

        private async void DeleteTask()
        {
            
            await database.DeleteItemAsync(Task);
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
