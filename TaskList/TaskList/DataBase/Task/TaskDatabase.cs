
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskList.Models;
using TaskList.Repository;
using TaskList.Utils;

namespace TaskList.DataBase.Task
{
    public class TaskDatabase : IRepository<TaskModel>
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<TaskDatabase> Instance = new AsyncLazy<TaskDatabase>(async () =>
        {
            var instance = new TaskDatabase();
            CreateTableResult result = await Database.CreateTableAsync<TaskModel>();
            return instance;
        });
        public TaskDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public async Task<int> DeleteItemAsync(TaskModel item)
        {
            return await  Database.DeleteAsync(item);
        }

        public async Task<TaskModel> GetItemAsync(int id)
        {
            return await Database.Table<TaskModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<List<TaskModel>> GetItemsAsync()
        {
            return await Database.Table<TaskModel>().ToListAsync();
        }

        public async Task<List<TaskModel>> GetItemsNotDoneAsync()
        {
            return await Database.QueryAsync<TaskModel>("SELECT * FROM [TaskModel] WHERE [Done] = 0");
        }

        public async Task<int> SaveItemAsync(TaskModel item)
        {
           
            return await  Database.InsertAsync(item);
            
        }
        public async Task<int> EditItemAsync(TaskModel item)
        {
           
            return await  Database.UpdateAsync(item);
             
        }
    }
}
