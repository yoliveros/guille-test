
namespace guille_test.src;

public class TodoList : ITodoList
{
  public TodoList()
  {
    TodoItem firstItem = new()
    {
      Id = 1,
      Title = "First task",
      Description = "First task description",
      Category = "?",
      IsCompleted = false
    };
    DB.Items.Add(firstItem);
  }

  public void AddItem(int id, string title, string description, string category)
  {
    var lastItem = DB.Items.Last();
    var item = new TodoItem
    {
      Id = lastItem == null ? 1 : lastItem.Id + 1,
      Title = title,
      Description = description,
      Category = category
    };

    DB.Items.Add(item);
  }

  public void PrintItems()
  {
    if (DB.Items == null)
      return;

    foreach (TodoItem item in DB.Items)
    {
      string formatted = $"{item.Id}) {item.Title} {item.Description} ({item.Category}) Completed:{item.IsCompleted}";
      Console.WriteLine(formatted);
    }
  }

  public void RegisterProgression(int id, DateTime dateTime, decimal percent)
  {
    throw new NotImplementedException();
  }

  public void UpdateItem(int id, string description)
  {
    throw new NotImplementedException();
  }
}
