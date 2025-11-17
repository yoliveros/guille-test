namespace src;

public class TodoItem
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Category { get; set; } = string.Empty;
  public List<ItemProgression> Progression { get; set; } = [];
}
