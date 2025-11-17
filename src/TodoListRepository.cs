namespace src;

public class TodoListRepository : ITodoListRepository
{
  public List<string> GetAllCategores()
  {
    return ["Category1", "Category2", "Category3"];
  }

  public int GetNextId()
  {
    var lastItem = DB.Items.Last();
    return lastItem.Id + 1;
  }
}
