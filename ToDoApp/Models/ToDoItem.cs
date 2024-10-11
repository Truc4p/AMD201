namespace ToDoApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }         // Unique identifier for each item
        public string Title { get; set; }   // The title of the To-Do task
        public bool IsCompleted { get; set; } // Is the task completed?
    }
}
