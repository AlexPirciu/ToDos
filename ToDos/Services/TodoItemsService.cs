using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDos.Data;
using ToDos.Models;

namespace ToDos.Services
{
    public class TodoItemsService : ITodoItemService
    {
        private readonly ApplicationDbContext context;

        public TodoItemsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TodoItemModel>> GetIncompleteItemsAsync()
        {
            return await context.Items
                .Where(x => x.IsDone == false)
                .ToListAsync();
        }

        public async Task<bool> AddItemAsync(TodoItemModel newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            context.Items.Add(newItem);

            var saveResult = await context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
