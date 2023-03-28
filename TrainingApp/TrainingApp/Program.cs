


using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using TrainingApp;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    
    static uint silnia=1;

    static void Main(string[] args)
    {
        System.Diagnostics.Stopwatch StopWatch = new System.Diagnostics.Stopwatch();

    Console.WriteLine("Wybierz:");
        Console.WriteLine("(1) Silnia iteracyjnie");
        Console.WriteLine("(2) Silnia rekurencyjnie");
        Console.WriteLine("(3) Liczby pierwsze lista");
        Console.WriteLine("(4) Znaki w kodzie ASCI");
        Console.WriteLine("(5) Sortowanie bąbelkowe");

        var option = Console.ReadLine();
        Console.WriteLine("Wybrano: " + option);
        Console.WriteLine("podaj liczbę dodatnią:");
        var number = Console.ReadLine();
        while (number == "" || !uint.TryParse(number, out uint value))
        {
            Console.WriteLine(number + "\nFormat nieprawidłowy, podaj liczbę całkowitą dodatnią");
            number = Console.ReadLine();
        }

        var numberValid = uint.Parse(number);
        StopWatch.Start();
        switch (option)
        {
            case "1" :
                Console.WriteLine("Silnia iteracyjnie");
                uint silniaIterative = IterativeSilnia(numberValid);
                WriteLineInColor(ConsoleColor.Green, silniaIterative.ToString() + "\n");
                break;
            case "2":
                Console.WriteLine("Silnia rekurencyjnie");
                uint silniaRecursive = RecursiveSilnia(numberValid);
                WriteLineInColor(ConsoleColor.Green, silniaRecursive.ToString() + "\n");
                break;
            case "3":
                Console.WriteLine("Liczby pierwsze lista");
                FindPrimes(numberValid);
                break;
            case "4":
                Console.WriteLine("Znaki w kodzie ASCI");
                ASCI(numberValid);
                break;
            case "5":
                Console.WriteLine("Sortowanie bąbelkowe");
                var randomList = RandomList((int)numberValid);
                Console.WriteLine("Unsorted");
                printList(randomList);
                var sortedList = BubbleSort(randomList);
                Console.WriteLine("Sorted");
                printList(sortedList);
                break;
            default:
                Console.WriteLine("Nie ma takiej opcji");
                break;
        }

        StopWatch.Stop();
        Console.WriteLine("Time elapsed: " + StopWatch.Elapsed);
        Console.Write("Press anything to exit...");
        Console.ReadKey();
    }

    static uint IterativeSilnia(uint number)
    {
        uint silnia = 1;
        for (uint naturalNumber = 1; naturalNumber <= number; naturalNumber ++)
            silnia *= naturalNumber;
        return silnia;
    }

    static uint RecursiveSilnia(uint number)
    {
        if (number >= 1)
            return number * RecursiveSilnia(number-1);
        else
            return 1;
    }

    static List<int> BubbleSort(List<int> list)
    {
        //list.Sort();
        int maxIndex = list.Count;
        for (int index = maxIndex-1; index >= 0 ; index--)
        {
            for (int index1 = 0; index1 < index; index1++)
            { 
                if (list[index1] > list[index1+1])
                {
                    int currentVal = list[index1];
                    list.RemoveAt(index1);
                    list.Insert(index1+1, currentVal);
                }
            }
        }
        return list;
    }

    static List<int> RandomList(int number)
    {
        List<int> list = new List<int>();
        Random rand = new Random();

        for (int i = 0; i < number; i++)
        {
            int randomNum = rand.Next(number);
            list.Add(randomNum);
        }
        return list;
    }

    static void printList(List<int> list)
    {
        foreach (long item in list)
            WriteLineInColor(ConsoleColor.Green, item + ", ");
        Console.WriteLine();
    }

    static void ASCI(uint number)
    {
        for (int iNum = 1; iNum <= number; iNum ++)
        {
            WriteLineInColor(ConsoleColor.Green, (char)iNum + ", ");
        }
        Console.WriteLine();
    }

    static void FindPrimes(uint number)
    {
        List<uint> numbers = new List<uint>();
        List<uint> primes = new List<uint>();

        primes.Add(2);
        for (uint n = primes.Max() + 1; n <= number; n++)
            numbers.Add(n);

        for (int indexP = 0; indexP < primes.Count; indexP++)
        {
            for (int indexN = 0; indexN < numbers.Count; indexN++)
                if (numbers[indexN] % primes[indexP] == 0)
                    numbers.RemoveAt(indexN);
            if (numbers.Count > 0)
            {
                primes.Add(numbers[0]);
                numbers.RemoveAt(0);
            }
        }
        printList(primes);
    }

    static void printList(List<uint> list)
    {
        foreach (long item in list)
            WriteLineInColor(ConsoleColor.Green, item + ", ");
        Console.WriteLine();
    }

    static void WriteLineInColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    
}
