
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
    };
    DB.Items.Add(firstItem);
  }

  public void AddItem(int id, string title, string description, string category)
  {
    var item = new TodoItem
    {
      Id = id,
      Title = title,
      Description = description,
      Category = category
    };

    DB.Items.Add(item);
  }

  public void RemoveItem(int id)
  {
    var currItem = DB.Items.Find(f => f.Id == id);
    if (currItem == null)
    {
      Console.WriteLine("Item not found");
      return;
    }

    decimal sumProgress = GetCurrentProgression(currItem.Progression);
    if (sumProgress > 50)
    {
      Console.WriteLine("An item with a progress greater than 50% can not be deleted");
      return;
    }

    DB.Items.Remove(currItem);
  }

  public void PrintItems()
  {
    string formatted;
    decimal progression;
    foreach (TodoItem item in DB.Items)
    {
      progression = GetCurrentProgression(item.Progression);
      formatted = $"{item.Id}) {item.Title} {item.Description} ({item.Category}) Completed:{progression == 100}";
      Console.WriteLine(formatted);
      foreach (ItemProgression progress in item.Progression)
      {
        formatted = $"{progress.DateTime} - {(int)progress.Progression}%";
        Console.Write(formatted);
        Console.Write('\t');
        Console.Write('|');
        for (int i = 0; i < 100; i++)
        {
          if (i < progress.Progression)
            Console.Write('0');
          else
            Console.Write(' ');
        }
        Console.WriteLine('|');
      }
    }
  }

  static decimal GetCurrentProgression(List<ItemProgression> items)
  {
    decimal result = 0;
    foreach (ItemProgression itemProgression in items)
    {
      result += itemProgression.Progression;
    }

    return result;
  }

  public void RegisterProgression(int id, DateTime dateTime, decimal percent)
  {
    var currItem = DB.Items.Find(f => f.Id == id);
    if (currItem == null)
    {
      Console.WriteLine("Item not found");
      return;
    }

    decimal sumProgress = GetCurrentProgression(currItem.Progression);

    if (sumProgress > 100)
    {
      Console.WriteLine("Progress can not be greater than 100");
      return;
    }

    ItemProgression newProgress = new()
    {
      DateTime = dateTime,
      Progression = percent
    };

    currItem.Progression.Add(newProgress);
  }

  public void UpdateItem(int id, string description)
  {
    var currItem = DB.Items.Find(f => f.Id == id);
    if (currItem == null)
    {
      Console.WriteLine("Item not found");
    }
  }
}

