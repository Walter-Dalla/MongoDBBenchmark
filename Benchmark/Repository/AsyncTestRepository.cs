using Benchmark.Domain.Models;
using MongoDB.Driver;

namespace Benchmark.Repository
{
    public class AsyncTestRepository
    {
        private readonly IMongoCollection<AsyncTest> _collection;

        public AsyncTestRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<AsyncTest>("Sync");
        }

        public async Task Insert(int referenceId)
        {
            await _collection.InsertOneAsync(new AsyncTest()
            {
                CriatedAt = DateTime.Now,
                ReferenceId = referenceId
            });
        }

        public async Task Find(int referenceId)
        {
            await _collection.FindAsync(p => p.ReferenceId == referenceId);
        }
    }
}
