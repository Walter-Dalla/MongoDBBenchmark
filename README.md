# Benchmarking MongoDB Async and Sync Operations

This code benchmarks the performance of MongoDB async and sync operations. It uses the BenchmarkDotNet library to run a series of benchmarks that measure the time it takes to insert and find documents in a MongoDB database.

The code is configured to run 10 iterations of each benchmark, with a warmup of 10 iterations. The inner iteration count is set to 1000, which means that each benchmark will run for a total of 10000 iterations.

The code uses the following MongoDB connection string:


mongodb://localhost:27017
```

You can replace this connection string with your own MongoDB connection string.

The code also uses the following database name:

```
BenchmarkDotNet
```

You can replace this database name with your own database name.

To run the benchmarks, you can use the following command:

```
dotnet run


The benchmarks will be run and the results will be printed to the console.

The results of the benchmarks will show you how much faster the async operations are than the sync operations.


Please note that during benchmark execution, if you attempt to run the code without first building it without using the publishing tool on Visual Studio, you may encounter issues. 
Therefore, it is essential to build in publishing mode the code before running the benchmarks to ensure smooth and accurate results.


## Run Exemple
```
BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3208/22H2/2022Update)
AMD Ryzen 5 1600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.103
  [Host]     : .NET 6.0.14 (6.0.1423.7309), X64 RyuJIT AVX2
  Job-MIGCUF : .NET 6.0.14 (6.0.1423.7309), X64 RyuJIT AVX2

InvocationCount=1000  IterationCount=10  UnrollFactor=1
WarmupCount=10

|      Method |        Mean |       Error |      StdDev |
|------------ |------------:|------------:|------------:|
| AsyncInsert |    279.9 us |    31.64 us |    18.83 us |
|   AsyncFind | 31,026.6 us |   492.48 us |   325.74 us |
|  SyncInsert |    224.2 us |     6.57 us |     3.91 us |
|    SyncFind | 12,003.4 us | 3,343.34 us | 2,211.41 us |

// * Hints *
Outliers
  Test.AsyncFind: InvocationCount=1000, IterationCount=10, UnrollFactor=1, WarmupCount=10  -> 2 outliers were removed (16.98 ms, 20.12 ms)
  Test.SyncInsert: InvocationCount=1000, IterationCount=10, UnrollFactor=1, WarmupCount=10 -> 1 outlier  was  detected (224.57 us)

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  Median : Value separating the higher half of all measurements (50th percentile)
  1 us   : 1 Microsecond (0.000001 sec)
```	

## To-Do
```
* Add more benchmarks to measure the performance of other MongoDB operations.
* Add more configuration options to the code, such as the number of iterations and the warmup count.
* Make the code more portable by using a connection string builder instead of a hard-coded connection string.
```

## Author
```
Walter Dalla
```
## License

```
This code is licensed under the MIT License.
``````
