## Benchmark Results

### Benchmark Table
| Method | Iterations | Mean | Error | StdDev | Median | Gen0 | Gen1 | Gen2 | Allocated |
|---|---|---:|---:|---:|---:|---:|---:|---:|---:|
| BuildReportString | 100 | 2,674.6 ns | 54.15 ns | 157.09 ns | 2,654.0 ns | 4.4327 | 0.0038 | - | 20,856 B |
| BuildReportStringBuilder | 100 | 458.2 ns | 9.13 ns | 14.75 ns | 451.1 ns | 0.1750 | 0.0005 | - | 824 B |
| BuildReportString | 1000 | 176,486.3 ns | 1,689.45 ns | 1,580.31 ns | 176,308.7 ns | 603.7598 | 8.5449 | - | 2,840,456 B |
| BuildReportStringBuilder | 1000 | 10,250.2 ns | 203.82 ns | 200.17 ns | 10,221.3 ns | 6.6223 | 0.1373 | - | 31,192 B |
| BuildReportString | 10000 | 28,798,839.0 ns | 566,275.54 ns | 1,035,466.93 ns | 28,803,156.2 ns | 80,187.5000 | 11,937.5000 | - | 379,436,456 B |
| BuildReportStringBuilder | 10000 | 135,958.0 ns | 1,824.66 ns | 1,617.51 ns | 136,255.2 ns | 83.2520 | 11.4746 | - | 391,744 B |
| BuildReportString | 100000 | 6,870,074,340.0 ns | 80,319,605.56 ns | 75,131,008.91 ns | 6,846,948,100.0 ns | 10,713,000.0000 | 10,614,000.0000 | 10,600,000.0000 | 47,914,736,352 B |
| BuildReportStringBuilder | 100000 | 1,512,075.9 ns | 6,603.58 ns | 6,177.00 ns | 1,512,553.1 ns | 683.5938 | 638.6719 | - | 4,187,848 B |

---

### Questions & Analysis

#### 1. Which approach was faster with 100 iterations?
* **StringBuilder** was faster. It took **458.2 ns** compared to **2,674.6 ns** for normal string concatenation (approx. 6 times faster).

#### 2. Which approach was faster with 100,000 iterations?
* **StringBuilder** was significantly faster. It took **1,512,075.9 ns** (~1.51 ms) compared to **6,870,074,340.0 ns** (~6.87 seconds) for normal string concatenation (approx. 4,543 times faster).

#### 3. Which approach allocated more memory?
* **Normal String Concatenation** allocated drastically more memory across all iteration sizes. At 100,000 iterations, it allocated **47,914,736,352 Bytes** (~47.9 GB) versus **4,187,848 Bytes** (~4.18 MB) by `StringBuilder`.

#### 4. What happened to string concatenation performance as the loop size increased?
* String concatenation performance degraded non-linearly (time complexity roughly **$O(N^2)$**). As iterations increased 1,000x (from 100 to 100,000), execution time ballooned from **2.67 microseconds** to **6.87 seconds**, causing severe Garbage Collection pressure across Gen0, Gen1, and Gen2.

#### 5. Why does repeated string concatenation create additional allocations?
* Strings in C# are **immutable** (cannot be modified after creation). Every time the `+=` operator is executed in a loop, C# creates a brand new string object in the Managed Heap, copies the content of the old string along with the appended text into it, and abandons the old string to be collected by the Garbage Collector.

#### 6. Why does StringBuilder usually perform better when text is repeatedly appended?
* `StringBuilder` is **mutable** and maintains an internal dynamic character buffer array. When calling `.Append()`, it simply inserts the new data into the existing buffer without creating new string objects. If the buffer fills up, it expands by doubling its capacity, resulting in far fewer heap allocations and amortized **$O(1)$** time per append operation.

#### 7. Is StringBuilder always better than normal string operations? Explain.
* **No.** For simple, single-line, or few string operations (e.g., `string full = firstName + " " + lastName;`), normal string concatenation or string interpolation (`$"{firstName} {lastName}"`) is better. In these cases, the C# compiler uses `string.Concat` under the hood, which calculates total length beforehand and creates a single allocation without the overhead of instantiating a `StringBuilder` object. `StringBuilder` is only preferred when modifying strings repeatedly within loops or handling large dynamic text builds.