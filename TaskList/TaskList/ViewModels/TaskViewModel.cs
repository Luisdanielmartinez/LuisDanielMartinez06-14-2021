using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TaskList.DataBase.Task;
using TaskList.Models;

namespace TaskList.ViewModels
{
   public class TaskViewModel: BaseViewModel
    {
        private ObservableCollection<TaskModel> taskList;
        public ObservableCollection<TaskModel> TaskList
        {
            get => taskList;
            set => SetProperty(ref taskList, value);
        }

        public TaskViewModel()
        {
            InitialDb();
            Title = "Todo";
        }
        private async void  InitialDb()
        {
            TaskDatabase database = await TaskDatabase.Instance;
            TaskList=new ObservableCollection<TaskModel>( await database.GetItemsAsync());
        }
    }
}
