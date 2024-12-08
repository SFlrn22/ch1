```

BenchmarkDotNet v0.14.0, openSUSE Tumbleweed
AMD Ryzen 7 7735HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.404
  [Host]   : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2

Job=.NET 8.0  Runtime=.NET 8.0  

```
| Method          | Mean         | Error       | StdDev       |
|---------------- |-------------:|------------:|-------------:|
| EliminateProps  | 271,154.1 ns | 5,394.84 ns | 15,216.24 ns |
| EliminateProps1 |     260.6 ns |     2.94 ns |      2.60 ns |
