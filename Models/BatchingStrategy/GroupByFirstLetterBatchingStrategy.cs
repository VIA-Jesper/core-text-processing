namespace DistinctWebAPI.Models.BatchingStrategy;

public class GroupByFirstLetterBatchingStrategy : IBatchingStrategy
{
    public IEnumerable<List<string>> GetBatches(IEnumerable<string> records)
    {
        return records.GroupBy(word => word[0])
            .Select(group => group.ToList());
    }
}