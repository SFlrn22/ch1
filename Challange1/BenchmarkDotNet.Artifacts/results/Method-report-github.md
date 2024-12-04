```

BenchmarkDotNet v0.14.0, openSUSE Tumbleweed
AMD Ryzen 7 7735HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.404
  [Host]   : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2

Job=.NET 8.0  Runtime=.NET 8.0  

```
| Method          | Mean     | Error   | StdDev  |
|---------------- |---------:|--------:|--------:|
| EliminateProps1 | 269.2 ns | 3.53 ns | 3.30 ns |
| EliminateProps2 | 317.5 ns | 1.21 ns | 1.14 ns |
