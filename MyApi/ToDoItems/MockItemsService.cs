namespace MyApi.ToDoItems
{
    public class MockItems : ITodoItems
    {
        private static List<TodoItem>
            todoItems = new List<TodoItem>() {
          new TodoItem (1,"1",false, "Sport"),
          new TodoItem (2,"2", true, "Hobbies") };

        public async Task<TodoItem> CreateItem(CreateTodoItem newItem)
        {
            var newId = 1;
            await Task.Delay(1000);
            if (todoItems.Count > 0)
                newId = todoItems.Max(i => i.Id) + 1;

            var item = new TodoItem(newId, newItem.Title, false,
                    newItem.Category);
            todoItems.Add(item);
            return item;
        }

        public async Task DeleteItem(int Id)
        {
            await Task.Delay(1000);
            var item = todoItems.FirstOrDefault(x => x.Id == Id);
            if (item is not null)
            {
                todoItems.Remove(item);
            }
        }

        public async Task<List<TodoItem>> GetAllItems()
        {
            await Task.Delay(1000);
            return todoItems;
        }

        public async Task<TodoItem?> GetItem(int id)
        {
            await Task.Delay(1000);
            var item = todoItems.FirstOrDefault(x => x.Id == id);
            return item;
        }

        public async Task UpdateItem(TodoItem itemModificato)
        {
            await Task.Delay(1000);
            var item = todoItems.FirstOrDefault(x => x.Id ==
                itemModificato.Id);
            if (item is not null)
            {

                var newItem = item with
                {
                    Title = itemModificato.Title,
                    Category = itemModificato.Category,
                    IsDone = itemModificato.IsDone,
                };
                todoItems.Remove(item);
                todoItems.Add(newItem);
            }
        }
    }

}
