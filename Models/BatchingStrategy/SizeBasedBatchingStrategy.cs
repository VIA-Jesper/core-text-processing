namespace DistinctWebAPI.Models.BatchingStrategy;

public class SizeBasedBatchingStrategy(int batchSize) : IBatchingStrategy
{
    public IEnumerable<List<string>> GetBatches(IEnumerable<string> records)
    {
        return records.Select((value, index) => new { Value = value, Index = index })
            .GroupBy(x => x.Index / batchSize)
            .Select(group => group.Select(x => x.Value).ToList());
    }
}