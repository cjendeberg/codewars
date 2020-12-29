using System;
using System.Diagnostics;

namespace codewars_20201222_1
{
  class Program
  {

    static long sumOfNumberDiviableBy3And5(long n)
    {
      long sum = 0;
      for (var i = 1; i < n; i++)
      {
        if ((i % 3 == 0) || (i % 5 == 0))
        {
          sum += i;
        }
      }
      return sum;
    }

    static long sumOfNumberDiviableByXAlt(long n, long x)
    {
      long multiplier = n - 1 - (n - 1) % x;
      long result = 0;
      long numDivisable = multiplier / x;
      if (numDivisable % 2 == 1)
      {
        // There an odd number of numbers divisable by x
        // Numbers (including zero) can be paired and the sum of each pair is equal to multiplier
        result = multiplier * (numDivisable + 1) / 2;
      }
      else
      {
        // Numbers, excluding middle element can be paired. Amounts to one less pair but the unpaired number is added
        // multiplier * numDivisable / 2 + multiplier / 2
        result = (multiplier * numDivisable + multiplier) / 2;
      }
      return result;
    }

    static void ShowUsage()
    {
      Console.WriteLine("dotnet run --from FROM --to TO [--test]");
    }
    static void Main(string[] args)
    {
      int from = -1, to = -1;
      bool test = false;
      for (int i = 0; i < args.Length; i++)
      {
        switch (args[i])
        {
          case "--from":
            if (!((++i) < args.Length) || !Int32.TryParse(args[i], out from))
            {
              ShowUsage();
            }
            break;
          case "--to":
            if (!((++i) < args.Length) || !Int32.TryParse(args[i], out to))
            {
              ShowUsage();
            }
            break;
          case "--test":
            test = true;
            break;
          default:
            ShowUsage();
            Environment.Exit(1);
            break;
        }
      }
      if ((from == -1) || (to == -1))
      {
        ShowUsage();
        Environment.Exit(1);
      }
      Stopwatch sw = new Stopwatch();
      Stopwatch swTest = new Stopwatch();
      for (var n = from; n < to; n++)
      {
        sw.Start();
        long sum = sumOfNumberDiviableByXAlt(n, 3) + sumOfNumberDiviableByXAlt(n, 5) - sumOfNumberDiviableByXAlt(n, 15);
        sw.Stop();

        if (test)
        {
          Console.WriteLine("Test...");
          swTest.Start();
          double testSum = sumOfNumberDiviableBy3And5(n);
          swTest.Stop();
          if (test && (sum != testSum))
          {
            Console.WriteLine($"Error: Sums are not equal: sum: {sum} testSum: {testSum}");
            Environment.Exit(1);
          }
        }
        Console.WriteLine($"n: {n} Sum: {sum}");
      }
      Console.WriteLine("Elapsed={0} Test elapsed={1}", sw.Elapsed, swTest.Elapsed);
    }
  }
}
