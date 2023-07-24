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
