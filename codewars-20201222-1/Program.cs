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

    static double sumOfNumberDiviableByX(long n, long x)
    {
      long multiplier = n - 1 - (n - 1) % x;
      return multiplier + multiplier * ((double)(multiplier / x - 1) / 2);
    }

    static void Main(string[] args)
    {
      int testMin, testMax;
      bool test;
      if ((Boolean.TryParse(args[0], out test)) && Int32.TryParse(args[1], out testMin) && (Int32.TryParse(args[2], out testMax)))
      {
        Stopwatch sw = new Stopwatch();
        Stopwatch swTest = new Stopwatch();
        for (var n = testMin; n < testMax; n++)
        {
          sw.Start();
          double sum = sumOfNumberDiviableByX(n, 3) + sumOfNumberDiviableByX(n, 5) - sumOfNumberDiviableByX(n, 15);
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
}
