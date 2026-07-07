using System;
using System.Diagnostics;
using BenchmarkDotNet.Running;
using Smart.Enums;
using Smart.Enums.Benchmarks;
using Smart.Enums.Benchmarks.TestData;

_ = BenchmarkRunner.Run<Benchmarks>();

SmartEnumConfig.UseCache = false;
var stopwatch = Stopwatch.StartNew();

for (var i = 0; i < 1_000_000; i++)
    _ = MyEnums.NameType.FirstName.GetAttribute<SmartEnumAttribute>().Name;

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds + " ms");

Console.WriteLine("Press any key...");
Console.ReadKey();
