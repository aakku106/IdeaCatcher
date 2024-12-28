namespace IdeaCatcherApp.Models;

public class IdeaFolder
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<IdeaNote> Notes { get; set; } = new();
}