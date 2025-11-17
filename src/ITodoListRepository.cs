namespace src;

public interface ITodoListRepository
{
  int GetNextId();
  List<string> GetAllCategores();
}
