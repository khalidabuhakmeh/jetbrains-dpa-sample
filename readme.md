# JetBrains Dynamic Program Analysis Sample

This repository holds an ASP.NET Core sample with common
issues that may degrade performance in your web applications. These
issues are flagged by Dynamic Program Analysis, a feature of
JetBrains ReSharper and Rider product offerings.

These issues include:

- Small Object Heap (SOH) allocations
- Large Object Heap (LOH) allocations
- Closure Object capture
- Database Command Time
- Database Connections
- Database Commands
- Database Record retrieval
- ASP.NET Core
  - MVC Actions Timing
  - Razor Page Handler Timing
  - Razor View Component Timing

Advice in fixing these issues can be found on [JetBrains' documentation site.](https://www.jetbrains.com/help/rider/Dynamic_Program_Analysis.html)

## Taming Performance Goblins

When thinking about improving a less-than-optimal application experience, there are the usual suspects to consider:

- Network and I/O utilization
- CPU time and processing
- Memory utilization (which leads to garbage collection pressure)

More often than not, you want to start at the top of the list and work your way down solving problems. Doing less is more when doing optimization work, and you should always be measuring. Measurement tools include dotTrace, dotMemory, OpenTelemetry, BenchmarkDotNet, and more.

Network I/O includes code that calls web service, database access, file access. These operations are dependent on resources typically out of your app's control. These operations can be blocking and cause several milliseconds, if not seconds, worth of pauses in your app execution. The Network and I/O issues can also cause bottleneck issues that present as resource exhaustion (memory or CPU). Tracking external calls is critical to tracking down performance problems. Use OpenTelemetry here or DPA here. Generally, you'll see your biggest performance improvements here.

CPU time is another important factor regarding application performance. In general, the more processor time your app uses, the slower it will feel for your users. Tracking CPU time can help you determine bottlenecks and reconsider approaches. You can reduce time with code optimizations, cache reusable work, preprocess results, or avoid processing entirely. This optimization typically requires refactoring code. Use dotTrace for these issues.

.NET is a garbage collected technology, so having a basic understanding of allocations and generations is important to optimize your application. Increased memory pressure requires **more** garbage collection, which can periodically freeze your application while resources are freed. Additionally, excessive allocations can lead to `out of memory` exceptions that can cause your application to slow, then crash and restart. Memory optimization typically requires refactoring code and having a clear idea of your biggest allocators. Use dotMemory here.

In summary, focus on external factors first like database, web, and disk access before optimizing code, unless your memory and CPU issues are crashing your app. If your app is failing/crashing, by all means, tackle those stability issues first. Finally, always be measuring. You'll have more success fixing issues once you understand them, and that starts with measurements.

## Getting Started

You will need to download and install [.NET SDK 8](https://dot.net).

## Things to Try

- Find the issues shown by DPA
- Try running dotTrace and dotMemory on individual endpoints