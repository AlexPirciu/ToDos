using System.Collections.Generic;
using System.Threading.Tasks;
using ToDos.Models;

namespace ToDos.Services
{
    public interface ITodoItemService
    {
        Task<List<TodoItemModel>> GetIncompleteItemsAsync();
    }
}
