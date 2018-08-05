using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDos.Models;

namespace ToDos.Services
{
    public class FakeTodoItemsService : ITodoItemService
    {
        public Task<List<TodoItemModel>> GetIncompleteItemsAsync()
        {
            var item1 = new TodoItemModel
            {
                Title = "Learn ASP.NET Core",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };

            var item2 = new TodoItemModel
            {
                Title = "Build awesome apps",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };

            List<TodoItemModel> items = new List<TodoItemModel>() { item1, item2 };

            return Task.FromResult(items);
        }
    }
}
