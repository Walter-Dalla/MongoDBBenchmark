using Benchmark.Repository;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MongoDB.Driver;

Console.WriteLine("Starting");






var summary = BenchmarkRunner.Run<Test>();


public class Test
{
    private readonly SyncTestRepository _syncTestRepository;
    private readonly AsyncTestRepository _asyncTestRepository;

    private int _asyncCountInsert = 0;
    private int _syncCountInsert = 0;

    private int _asyncCountFind = 0;
    private int _syncCountFind = 0;


    public Test()
    {
        Console.WriteLine("Connecting DB");
        string connectionString = "mongodb://localhost:27017"; // Replace with your MongoDB connection string
        MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
        MongoClient client = new MongoClient(settings);
        IMongoDatabase database = client.GetDatabase("BenchmarkDotNet"); // Replace with your database name

        _asyncTestRepository = new AsyncTestRepository(database);
        _syncTestRepository = new SyncTestRepository(database);
        Console.WriteLine("Connected DB");
    }


    [Benchmark]
    [IterationCount(10)]
    [WarmupCount(10)]
    [InnerIterationCount(1000)]
    public async Task AsyncInsert()
    {
        _asyncCountInsert++;
        await _asyncTestRepository.Insert(_asyncCountInsert);
    }

    [Benchmark]
    [IterationCount(10)]
    [WarmupCount(10)]
    [InnerIterationCount(1000)]
    public async Task AsyncFind()
    {
        _asyncCountFind++;
        await _asyncTestRepository.Find(_asyncCountFind);
    }

    [Benchmark]
    [IterationCount(10)]
    [WarmupCount(10)]
    [InnerIterationCount(1000)]
    public void SyncInsert()
    {
        _syncCountInsert++;
        _syncTestRepository.Insert(_syncCountInsert);
    }

    [Benchmark]
    [IterationCount(10)]
    [WarmupCount(10)]
    [InnerIterationCount(1000)]
    public void SyncFind()
    {
        _syncCountFind++;
        _syncTestRepository.Find(_syncCountFind);
    }

}