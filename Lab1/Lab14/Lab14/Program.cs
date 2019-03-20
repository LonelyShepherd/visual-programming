using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab14
{
  class Program
  {
    enum PasswordStrength
    {
      easy = 1,
      normal = 2,
      hard = 3
    }

    static Random random = new Random();

    static string generatePassword(PasswordStrength passwordStrength)
    {
      const string charsForEasy = "abcdefghijklmnopqrstuvwxyz";
      const string charsForNormal = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      const string charsForHard = charsForEasy + charsForNormal + "!@#$%^&*()_+/\\|";

      switch (passwordStrength)
      {
        case PasswordStrength.easy:
          return new string(Enumerable.Repeat(charsForEasy, 6)
            .Select(s => s[random.Next(s.Length)])
            .ToArray());
        case PasswordStrength.normal:
          return new string(Enumerable.Repeat(charsForNormal, random.Next(6, 10))
            .Select(s => s[random.Next(s.Length)])
            .ToArray());
        case PasswordStrength.hard:
        default:
          return new string(Enumerable.Repeat(charsForHard, random.Next(10, 30))
            .Select(s => s[random.Next(s.Length)])
            .ToArray());
      }
    }

    static void Main(string[] args)
    {
      string myString = "This is a test.";
      char[] separator = { ' ' };
      string[] myWords;

      myWords = myString.Split(separator);

      foreach (string word in myWords)
      {
        Console.WriteLine("{0}", word);
      }

      Console.WriteLine();
      Console.WriteLine("Enter 3 passwords with different strength (easy, normal and hard):");
      var enteredPasswords = Console.ReadLine().Split(new char[] { ' ' });

      List<string> generatedPasswords = new List<string>();

      int i = 0;

      foreach (PasswordStrength strength in (PasswordStrength[]) Enum.GetValues(typeof(PasswordStrength)))
      {
        var generated = generatePassword(strength);
        var entered = enteredPasswords[i];

        Console.WriteLine("Your password {0} and the generated password {1} does {2}. ({3})", 
          enteredPasswords[i], 
          generated,
          entered.Equals(generated) ? "match" : "not match",
          Convert.ToString(strength)
          );

        i++;
      }

      Console.ReadKey();
    }
  }
}
