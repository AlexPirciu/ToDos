using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDos.Models;
using ToDos.Services;

namespace ToDos.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoItemService todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "Manage your to do list.";
            var items = await todoItemService.GetIncompleteItemsAsync();
            var model = new TodoViewModel()
            {
                Items = items
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItemModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var succesful = await todoItemService.AddItemAsync(newItem);
            if (!succesful)
            {
                return BadRequest(new { error = "Could not add item" });
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var succesful = await todoItemService.MarkDoneAsync(id);
            if (!succesful)
            {
                return BadRequest(new { error = "Could not mark item as done." });
            }
            return RedirectToAction("Index");
        }
    }
}
