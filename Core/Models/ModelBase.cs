namespace Core.Models;

public class ModelBase
{
    public int Id { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; set; } = DateTime.Now;

}
