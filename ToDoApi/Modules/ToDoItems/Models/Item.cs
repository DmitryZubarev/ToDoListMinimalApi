namespace ToDoApi.Modules.ToDoItems.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }

        public ItemType Type { get; set; }
    }
}
