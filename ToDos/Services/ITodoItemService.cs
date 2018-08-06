using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDos.Models;

namespace ToDos.Services
{
    public interface ITodoItemService
    {
        Task<List<TodoItemModel>> GetIncompleteItemsAsync();

        Task<bool> AddItemAsync(TodoItemModel newItem);

        Task<bool> MarkDoneAsync(Guid id);
    }
}
