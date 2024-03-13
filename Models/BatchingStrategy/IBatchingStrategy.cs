namespace DistinctWebAPI.Models.BatchingStrategy;

public interface IBatchingStrategy
{
    IEnumerable<List<string>> GetBatches(IEnumerable<string> records);
}