```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9168/25H2/2025Update/HudsonValley2)
Intel Core i7-8750H CPU 2.20GHz (Max: 2.21GHz) (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.401
  [Host]     : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v3


```
| Method                   | Mean           | Error        | StdDev       | Gen0          | Gen1          | Gen2         | Allocated   |
|------------------------- |---------------:|-------------:|-------------:|--------------:|--------------:|-------------:|------------:|
| BuildReportString        | 1,527,027.7 μs | 27,554.61 μs | 24,426.45 μs | 13703000.0000 | 13625000.0000 | 2270000.0000 | 10961.42 MB |
| BuildReportStringBuilder |       762.0 μs |     15.13 μs |     19.67 μs |      341.7969 |      171.8750 |            - |     1.98 MB |
