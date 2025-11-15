using guille_test.src;

class Program
{
  static void Main()
  {
    TodoList todoList = new();
    Console.WriteLine("Welcome to de Todo List app");
    int command;
    var isValidInput = false;

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
      isValidInput = int.TryParse(input, out command);

      if (!isValidInput)
        Console.WriteLine("Invalid input. Select a valid number");

      switch (command)
      {
        case 0:
          Console.WriteLine("Exiting...");
          continue;
        case 1:
          // TodoItem newItem;
          Console.ReadLine();
          break;
        case 2:
          break;
        case 3:
          break;
        case 4:
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

