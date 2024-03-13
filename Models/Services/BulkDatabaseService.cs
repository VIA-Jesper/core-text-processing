using DistinctWebAPI.Database;
using DistinctWebAPI.Models.BatchingStrategy;
using DistinctWebAPI.Models.Entities;
using EFCore.BulkExtensions;

namespace DistinctWebAPI.Models.Services;

public class BulkDatabaseService : IDatabaseService
{
    private readonly TextDbContext _context;
    private readonly IBatchingStrategy _batchingStrategy;

    public BulkDatabaseService(TextDbContext context, IBatchingStrategy batchingStrategy)
    {
        _context = context;
        _batchingStrategy = batchingStrategy;
    }

    public void InsertRange(ICollection<string> records)
    {
        if (!records.Any()) return;
        
        var batches = _batchingStrategy.GetBatches(records);
        ParallelBulkInsert(batches);
    }

    private void ParallelBulkInsert(IEnumerable<List<string>> batches)
    {
        Parallel.ForEach(batches, async batch =>
        {
            await using var parallelContext = new TextDbContext(_context.GetConfig());
            var distinctWords = batch.Select(text => new DistinctWord { Text = text });
            await parallelContext.BulkInsertAsync(distinctWords);
        });
    }
}