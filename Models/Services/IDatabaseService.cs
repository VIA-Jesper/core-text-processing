namespace DistinctWebAPI.Models.Services;

public interface IDatabaseService
{
    public void InsertRange(ICollection<string> records);
}