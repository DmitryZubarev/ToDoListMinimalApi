namespace ToDoApi.Modules.ToDoItems.Models
{
    public class ItemType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Item>? Items { get; set; }
    }
}
