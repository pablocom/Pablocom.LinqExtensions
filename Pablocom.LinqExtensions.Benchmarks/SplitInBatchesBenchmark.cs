using BenchmarkDotNet.Attributes;

namespace Pablocom.LinqExtensions.Benchmarks;

[MemoryDiagnoser]
public class SplitInBatchesBenchmark
{
    private static int[] numbers = Enumerable.Range(0, 100000).ToArray();

    [Benchmark]
    public void SplitToBatches()
    {
        var batches = numbers.SplitToBatches(100);
    }
}
