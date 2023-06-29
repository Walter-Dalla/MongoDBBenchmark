using Benchmark.Domain.Models;
using MongoDB.Driver;

namespace Benchmark.Repository
{
    public class SyncTestRepository
    {
        private readonly IMongoCollection<SyncTest> _collection;

        public SyncTestRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<SyncTest>("Async");
        }

        public void Insert(int referenceId)
        {
            _collection.InsertOne(new SyncTest()
            {
                CreatedAt = DateTime.Now,
                ReferenceId = referenceId
            });
        }

        public void Find(int referenceId)
        {
            _collection.Find(p => p.ReferenceId == referenceId);
        }
    }
}
