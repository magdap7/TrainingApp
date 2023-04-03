


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
    static Stopwatch StopWatch = new System.Diagnostics.Stopwatch();
    static void Main(string[] args)
    {
        Console.WriteLine("Wybierz:");
        Console.WriteLine("1    - praca na długiej liczbie");
        Console.WriteLine("2    - praca na krótkiej liczbie");
        Console.WriteLine("3    - praca na pliku");
        Console.WriteLine("4    - praca na klasie");
        Console.WriteLine("5    - długości typów");
        Console.WriteLine("q    - quit");

        var option = Console.ReadLine();
        while (option != "q")
        {
            switch (option)
            {
                case "1":
                    Console.WriteLine("Praca na długiej liczbie (sortowanie, liczby pierwsze)");
                    WorkOnNumber();
                    break;
                case "2":
                    Console.WriteLine("Praca na krótkiej liczbie (parsowanie PESEL, NIP, ASCI)");
                    break;
                case "3":
                    Console.WriteLine("Praca na pliku (zapis w różnym trybie i odczyt)");
                    break;
                case "4":
                    Console.WriteLine("Praca na klasie (dodaj do listy, usuń, eventy, wyjątki)");
                    break;
                case "5":
                    Console.WriteLine("Długości typów prostych");
                    TypeLengths();
                    break;
                default:
                    Console.WriteLine("Nie ma takiej opcji, wybierz 1-5 lub q");
                    break;
            }
            option = Console.ReadLine();
        }
        Console.Write("Do zobaczenia");
        Console.ReadKey();
    }

    static void TypeLengths()
    {
        Console.WriteLine("ulong: \t" + ulong.MaxValue);
        Console.WriteLine("long: \t" + long.MaxValue);
        Console.WriteLine("uint: \t" + uint.MaxValue);
        Console.WriteLine("int: \t" + int.MaxValue);
        Console.WriteLine("float: \t" + float.MaxValue);
        Console.WriteLine("double: \t" + double.MaxValue);
        Console.WriteLine("decimal: \t" + decimal.MaxValue);
        Console.WriteLine("char: \t" + char.MaxValue);
    }


    static void WorkOnNumber()
    {
        Console.WriteLine("Wybierz:");
        Console.WriteLine("(1a) Silnia iteracyjnie");
        Console.WriteLine("(1b) Silnia rekurencyjnie");
        Console.WriteLine("(2) Liczby pierwsze lista");
        Console.WriteLine("(3) Znaki w kodzie ASCI");
        Console.WriteLine("(4a) Sortowanie bąbelkowe");
        Console.WriteLine("(4b) Sortowanie szybkie");

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
            case "1a":
                Console.WriteLine("Silnia iteracyjnie");
                uint silniaIterative = IterativeSilnia(numberValid);
                WriteLineInColor(ConsoleColor.Green, silniaIterative.ToString() + "\n");
                break;
            case "1b":
                Console.WriteLine("Silnia rekurencyjnie");
                uint silniaRecursive = RecursiveSilnia(numberValid);
                WriteLineInColor(ConsoleColor.Green, silniaRecursive.ToString() + "\n");
                break;
            case "2":
                Console.WriteLine("Liczby pierwsze");
                var primes = FindPrimes(numberValid);
                var foundPrimes = PrintList<uint>("Primes", primes);
                WriteLineInColor(ConsoleColor.Green, foundPrimes);
                break;
            case "3":
                Console.WriteLine("Znaki w kodzie ASCI");
                ASCI(numberValid);
                break;
            case "4a":
                Console.WriteLine("Sortowanie bąbelkowe");
                var randomList = RandomList((int)numberValid);
                var randomNumbers = PrintList<int>("Unsorted", randomList);
                WriteLineInColor(ConsoleColor.Green, randomNumbers);
                var sortedList = BubbleSort(randomList);
                var sortedNumbers = PrintList<int>("Sorted", sortedList);
                WriteLineInColor(ConsoleColor.Blue, sortedNumbers);
                break;
            case "4b":
                Console.WriteLine("Sortowanie szybkie");
                break;
            default:
                Console.WriteLine("Nie ma takiej opcji");
                break;
        }
        StopWatch.Stop();
        Console.WriteLine("Time elapsed: " + StopWatch.Elapsed);
        StopWatch.Reset();
    }

    static void WorkOnShortNumber()
    {//PESEL, NIP, ASCI
        string shortNumber="";
        Console.WriteLine(shortNumber);
    }

    static void WorkOnFile(string file, string testToWrite)
    {
        Console.WriteLine(file);
        Console.WriteLine(testToWrite);
    }

    static void WorkOnDateTime(DateTime date)
    {
        Console.WriteLine(date.ToString());
    }

    static string PrintList<T>(string title, List<T> list)
    {
        string listToString = title + ":\n";
        foreach (T item in list)
            listToString = listToString + item + ", ";
        int left = listToString.Length - 2;
        return listToString.Substring(0, left) + "\n";
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

    static void ASCI(uint number)
    {
        for (int iNum = 1; iNum <= number; iNum ++)
        {
            WriteLineInColor(ConsoleColor.Green, (char)iNum + ", ");
        }
        Console.WriteLine();
    }

    static List<uint> FindPrimes(uint number)
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
        return primes;
    }
   
    static void WriteLineInColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    
}
