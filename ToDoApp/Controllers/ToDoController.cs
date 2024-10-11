using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        // In-memory list to simulate a database
        private static List<ToDoItem> toDoItems = new List<ToDoItem>
        {
            new ToDoItem { Id = 1, Title = "Learn ASP.NET Core", IsCompleted = false },
            new ToDoItem { Id = 2, Title = "Build a To-Do App", IsCompleted = true }
        };

        // 1. Read - Display all ToDo Items
        public IActionResult Index()
        {
            return View(toDoItems);
        }

        // 2. Create - Show form to create a new ToDo item
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 2. Create - Handle form submission for new ToDo item
        [HttpPost]
        public IActionResult Create(ToDoItem item)
        {
            item.Id = toDoItems.Count + 1; // Generate a new Id for the item
            toDoItems.Add(item);
            return RedirectToAction("Index");
        }

        // 3. Update - Show form to edit an existing ToDo item
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = toDoItems.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // 3. Update - Handle form submission for editing an existing ToDo item
        [HttpPost]
        public IActionResult Edit(ToDoItem updatedItem)
        {
            var item = toDoItems.FirstOrDefault(i => i.Id == updatedItem.Id);
            if (item == null)
            {
                return NotFound();
            }
            item.Title = updatedItem.Title;
            item.IsCompleted = updatedItem.IsCompleted;
            return RedirectToAction("Index");
        }

        // 4. Delete - Show confirmation page for deleting an item
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = toDoItems.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // 4. Delete - Handle deletion of an item
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = toDoItems.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                toDoItems.Remove(item);
            }
            return RedirectToAction("Index");
        }
    }
}
