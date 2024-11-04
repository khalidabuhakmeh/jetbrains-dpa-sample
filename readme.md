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

## Getting Started

You will need to download and install [.NET SDK 8](https://dot.net).

## Things to Try

- Find the issues shown by DPA
- Try running dotTrace and dotMemory on individual endpoints