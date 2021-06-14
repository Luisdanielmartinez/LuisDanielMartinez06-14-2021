using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Repository
{
   public interface IRepository <T>
    {
       Task<List<T>> GetItemsAsync();
       Task<List<T>> GetItemsNotDoneAsync();
       Task<T> GetItemAsync(int id);
       Task<int> SaveItemAsync(T item);
        Task<int> EditItemAsync(T item);
        Task<int> DeleteItemAsync(T item);
    }
}
