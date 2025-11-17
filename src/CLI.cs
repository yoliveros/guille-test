namespace guille_test.src;

public class CLI(ITodoList todoList, ITodoListRepository todoListRepository)
{
  static int? GetValidNumber(string? input)
  {
    if (input == null)
      return null;

    bool isValid = int.TryParse(input, out var id);
    if (!isValid)
      return null;

    return id;
  }

  void AddItem()
  {
    Console.Write("Set a title: ");
    var title = Console.ReadLine();
    Console.Write("Set a description: ");
    var description = Console.ReadLine();
    Console.Write("Set a category: ");
    var category = Console.ReadLine();

    if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(category))
      return;
    todoList.AddItem(todoListRepository.GetNextId(), title, description, category);
  }

  void UpdateItem()
  {
    Console.Write("Id: ");
    var input = Console.ReadLine();
    var id = GetValidNumber(input);
    if (id == null)
    {
      Console.WriteLine("Invalid id");
      return;
    }

    Console.Write("New description: ");
    var newDescription = Console.ReadLine();
    if (newDescription == null)
    {
      Console.WriteLine("Description is invalid");
      return;
    }

    todoList.UpdateItem((int)id, newDescription);
  }

  void RemoveItem()
  {
    Console.Write("Id: ");
    var input = Console.ReadLine();
    var id = GetValidNumber(input);

    if (id == null)
    {
      Console.WriteLine("Invalid id");
      return;
    }

    todoList.RemoveItem((int)id);
  }

  void RegisterProgression()
  {
    Console.Write("Id: ");
    var input = Console.ReadLine();
    var id = GetValidNumber(input);

    if (id == null)
    {
      Console.WriteLine("Invalid id");
      return;
    }

    Console.Write("New progression: ");
    input = Console.ReadLine();
    bool isValid = decimal.TryParse(input, out var newProgression);
    if (!isValid)
    {
      Console.WriteLine("Progress must be a decimal number");
      return;
    }

    todoList.RegisterProgression((int)id, DateTime.Now, newProgression);
  }

  public void Run()
  {
    Console.WriteLine("Welcome to de Todo List app");
    int command;

    do
    {
      Console.WriteLine("\n1. Add item\n" +
          "2. Update item\n" +
          "3. Remove item\n" +
          "4. Register progression\n" +
          "5. Print items\n" +
          "0. Exit\n");
      Console.Write("\nSelect and option: ");
      var input = Console.ReadLine();
      bool isValidInput = int.TryParse(input, out command);

      if (!isValidInput)
        Console.WriteLine("Invalid input. Select a valid number");

      switch (command)
      {
        case 0:
          Console.WriteLine("Exiting...");
          continue;
        case 1:
          AddItem();
          break;
        case 2:
          UpdateItem();
          break;
        case 3:
          RemoveItem();
          break;
        case 4:
          RegisterProgression();
          break;
        case 5:
          todoList.PrintItems();
          break;
        default:
          Console.WriteLine("Option not valid");
          break;
      }

    } while (command != 0);
  }
}

