using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using Smart.Enums.Benchmarks.TestData;

namespace Smart.Enums.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Alphabetical)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net80, baseline: true)]
    public class Benchmarks
    {
        [Benchmark]
        public void GetAttribute_WithCache_Benchmark()
        {
            SmartEnumConfig.UseCache = true;
            _ = MyEnums.Color.Blue.GetAttribute<ColorAttribute>().Name;
        }

        [Benchmark]
        public void GetAttribute_WithoutCache_Benchmark()
        {
            SmartEnumConfig.UseCache = false;
            _ = MyEnums.Color.Blue.GetAttribute<ColorAttribute>().Name;
        }

        [Benchmark]
        public void EnumToString_Benchmark()
        {
            _ = MyEnums.Color.None.ToString();
        }
    }
}
