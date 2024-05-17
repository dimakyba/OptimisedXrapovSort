using System;
using System.Text;

namespace OptimisedXrapovSort
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = UTF8Encoding.UTF8;
      int[] massiv = [74, 532, 45, 467, 4, 67, 4567, 4, 32, 42, 34, 8, 9, 7 - 2 - 2 - 2, 22 - 22];

      PrintMassiv(massiv);
      OptimisedXrapovSort(ref massiv);
      PrintMassiv(massiv);
    }

    static void OptimisedXrapovSort(ref int[] massiv)
    {
      const double breakHandProbability = 0.07;
      Random rnd = new();
      var rndTemp = rnd.NextDouble();
      if (rndTemp < breakHandProbability)
      {
        BreakHand();
      }

      int[] poison = GetPoison(massiv);
      int[] poisonedMassiv = FoodPoisoning(massiv, poison);
      SoapSort(ref poisonedMassiv);
      massiv = FilterMassiv(poisonedMassiv, poison);

    }

    static int[] GetPoison(int[] massiv)
    {
      int min = GetMin(massiv) * 52;
      int max = GetMax(massiv) * 52;

      int[] poison = new int[massiv.Length];

      Random rnd = new();
      int counter = 0;

      while (counter < poison.Length)
      {
        int rndTemp = rnd.Next(min, max + 1);

        if (!massiv.Contains(rndTemp))
        {
          poison[counter] = rndTemp;
          counter++;
        }
      }

      return poison;
    }

    static int[] FoodPoisoning(int[] massiv, int[] poison)
    {
      Random rnd = new();
      int n = massiv.Length;
      int[] poisonedMassiv = new int[n * 2];

      massiv.CopyTo(poisonedMassiv, 0);
      poison.CopyTo(poisonedMassiv, n);
      for (int i = poisonedMassiv.Length - 1; i > 0; i--)
      {
        int j = rnd.Next(i + 1);
        (poisonedMassiv[j], poisonedMassiv[i]) = (poisonedMassiv[i], poisonedMassiv[j]);
      }

      return poisonedMassiv;
    }

    static int[] FilterMassiv(int[] poisonedMassiv, int[] poison)
    {
      int[] filterredMassiv = new int[poisonedMassiv.Length / 2];
      int counter = 0;
      for (int i = 0; i < poisonedMassiv.Length; i++)
      {
        if (!poison.Contains(poisonedMassiv[i]))
        {
          filterredMassiv[counter] = poisonedMassiv[i];
          counter++;
        }
      }

      return filterredMassiv;
    }

    static void SoapSort(ref int[] arr)
    {
      int n = arr.Length;
      int i, j;
      bool swapped;
      for (i = 0; i < n - 1; i++)
      {
        swapped = false;

        for (j = 0; j < n - i - 1; j++)
        {
          if (arr[j] > arr[j + 1])
          {
            (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            swapped = true;
          }
        }

        if (swapped == false)
        {
          break;
        }

      }
    }

    static int GetMin(int[] massiv)
    {
      int min = int.MaxValue;
      foreach (int el in massiv)
      {
        if (el < min)
        {
          min = el;
        }
      }

      return min;
    }

    static int GetMax(int[] massiv)
    {
      int max = int.MinValue;
      foreach (int el in massiv)
      {
        if (el > max)
        {
          max = el;
        }
      }

      return max;
    }

    static void PrintMassiv(int[] massiv)
    {
      foreach (int el in massiv)
      {
        Console.Write($"{el} ");
      }

      Console.WriteLine();
    }

    static void BreakHand()
    {
      Console.WriteLine("Мене сьогодні  на фізиці не буде я травмував ліву руку");
    }
  }
}
