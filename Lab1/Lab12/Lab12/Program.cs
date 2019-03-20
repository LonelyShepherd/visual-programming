using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab12
{
  class Program
  {
    static double findAvg(List<int> numbers)
    {
      return numbers.Average();
    }

    static void findMax(List<int> numbers, out int number)
    {
      number = numbers.Max();
    }

    static void findMin(List<int> numbers, out int number)
    {
      number = numbers.Min();
    }

    static void Main(string[] args)
    {
      // Console.WriteLine("How many numbers you want to enter?");
      Console.WriteLine("How many random numbers you want to be generated?");

      int n = Convert.ToInt32(Console.ReadLine());

      List<int> numbers = new List<int>();
      Random random = new Random();

      for (int i = 0; i < n; i++)
      {
        //numbers.Add(Convert.ToInt32(Console.ReadLine()));

        var number = random.Next(1, 1000);
        Console.Write("{0} ", number);
        numbers.Add(number);
      }

      var avg = findAvg(numbers);
      int max, min;

      findMax(numbers, out max);
      findMin(numbers, out min);

      Console.WriteLine();
      Console.WriteLine("The average value from the entered numbers is: {0}.", avg /* numbers.Average() */);
      Console.WriteLine("The max value from the entered numbers is: {0}.", max /* numbers.Max() */);
      Console.WriteLine("The min value from the entered numbers is: {0}.", min /*numbers.Min() */);

      Console.ReadKey();
    }
  }
}
