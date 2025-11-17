namespace src.Tests;

public class TodoListTest
{
  [Theory]
  [InlineData(1, "test title", "test description", "test category")]
  public void AddItemTest(int id, string title, string description, string category)
  {
    var todoList = new TodoList();
    todoList.AddItem(id, title, description, category);

    var newItem = DB.Items.Find(f => f.Id == id);
    Assert.NotNull(newItem);
  }

  [Fact]
  public void PrintItemsTest()
  {
    var output = new StringWriter();
    Console.SetOut(output);

    var todoList = new TodoList();
    todoList.PrintItems();
    var lines = output.ToString()
      .Split(Environment.NewLine,StringSplitOptions.TrimEntries);
    Assert.Equal("1) First task First task description (?) Completed:False", lines[0]);
  }
}
