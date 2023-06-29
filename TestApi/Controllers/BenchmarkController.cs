using Benchmark.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BenchmarkController : ControllerBase
    {
        private readonly SyncTestRepository _syncTestRepository;
        private readonly AsyncTestRepository _asyncTestRepository;

        public BenchmarkController()
        {
            Console.WriteLine("Connecting DB");
            var connectionString = "mongodb://localhost:27017"; // Replace with your MongoDB connection string
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            var client = new MongoClient(settings);
            var database = client.GetDatabase("BenchmarkDotNet"); // Replace with your database name

            _asyncTestRepository = new AsyncTestRepository(database);
            _syncTestRepository = new SyncTestRepository(database);
            Console.WriteLine("Connected DB");
        }

        [HttpGet("LoopAsync/find")]
        public async Task<IActionResult> LoopFindAsync(int milliseconds, int referenceId)
        {
            var count = 0;
            var stopTime = DateTime.Now.AddMilliseconds(milliseconds);
            while (DateTime.Now < stopTime)
            {
                count++;
                await _asyncTestRepository.Find(referenceId);
            }
            return Accepted(count);
        }
        [HttpGet("LoopAsync/Insert")]
        public async Task<IActionResult> LoopInsertAsync(int milliseconds, int referenceId)
        {
            var count = 0;
            var stopTime = DateTime.Now.AddMilliseconds(milliseconds);
            while (DateTime.Now < stopTime)
            {
                count++;
                await _asyncTestRepository.Insert(referenceId);
            }
            return Accepted(count);
        }




        [HttpGet("LoopSync/find")]
        public IActionResult LoopFindSync(int milliseconds, int referenceId)
        {
            var count = 0;
            var stopTime = DateTime.Now.AddMilliseconds(milliseconds);
            while (DateTime.Now < stopTime)
            {
                count++;
                _syncTestRepository.Find(referenceId);
            }
            return Accepted(count);
        }
        [HttpGet("LoopSync/Insert")]
        public IActionResult LoopInsertSync(int milliseconds, int referenceId)
        {
            var count = 0;
            var stopTime = DateTime.Now.AddMilliseconds(milliseconds);
            while (DateTime.Now < stopTime)
            {
                count++;
                _syncTestRepository.Insert(referenceId);
            }
            return Accepted(count);
        }



        [HttpGet("Async")]
        public async Task<IActionResult> GetAsync(int referenceId)
        {
            var find = await _asyncTestRepository.Find(referenceId);
            return Accepted(find);
        }

        [HttpGet("Sync")]
        public IActionResult GetSync(int referenceId)
        {
            var find = _syncTestRepository.Find(referenceId);
            return Accepted(find);
        }
    }
}