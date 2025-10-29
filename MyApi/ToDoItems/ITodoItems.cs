namespace MyApi.ToDoItems;

public record TodoItem(int Id, string Title, bool IsDone, string Category);
public record CreateTodoItem(string Title, string Category);

public interface ITodoItems
{
    Task<List<TodoItem>> GetAllItems();
    Task<TodoItem?> GetItem(int Id);
    Task<TodoItem> CreateItem(CreateTodoItem newItem);
    Task UpdateItem(TodoItem itemModificato);
    Task DeleteItem(int Id);
}

public interface GenericCrud<T, U>
{
    Task<List<T>> GetAllItems();
    Task<T?> GetItem(U Id);
    Task<T> CreateItem(CreateTodoItem newItem);
    Task UpdateItem(T itemModificato);
    Task DeleteItem(U Id);
}