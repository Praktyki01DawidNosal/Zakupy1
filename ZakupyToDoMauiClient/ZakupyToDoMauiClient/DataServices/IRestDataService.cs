using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakupyToDoMauiClient.Models;

namespace ToDoMauiClient.DataServices
{
    public interface IRestDataService
    {
        Task<List<ZakupyToDo>> GetAllToDosAsync();
        Task AddToDoAsync(ZakupyToDo toDo);
        Task UpdateToDoAsync(ZakupyToDo toDo);
        Task DeleteToDoAsync(int id);
    }
}
