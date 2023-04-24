

using Microsoft.VisualBasic.FileIO;
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
        Console.WriteLine("1    - praca na długich liczbach: np. sortowanie, liczby pierwsze");
        Console.WriteLine("2    - praca na krótkiej liczbie lub ciągu znaków");
        Console.WriteLine("3    - praca na pliku: otwieranie, nadpisywanie, dopisywanie");
        Console.WriteLine("4    - praca na klasie Person");
        Console.WriteLine("5    - długości typów prostych");
        Console.WriteLine("6    - praca na liście: List, IEnumerable");
        Console.WriteLine("7    - znaki w kodzie ASCI");
        Console.WriteLine("q    - quit");

        var option = Console.ReadLine();
        while (option != "q")
        {
            switch (option)
            {
                case "1":
                    Console.WriteLine("Praca na długiej liczbie (sortowanie, liczby pierwsze)");
                    WorkOnLongNumbers();
                    break;
                case "2":
                    Console.WriteLine("Praca na krótkiej liczbie (parsowanie PESEL, NIP, ASCI)");
                    WorkOnShortNumbers();
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
                case "6":
                    Console.WriteLine("LIsta: dodawanie, usuwanie, sortowanie");
                    WorkOnList();
                    WorkOnEnumerable();
                    break;
                case "7":
                    Console.WriteLine("Znaki w ASCI");
                    WriteCharsInASCI();
                    break;
                default:
                    Console.WriteLine("Nie ma takiej opcji, wybierz 1-5 lub q");
                    break;
            }
            Console.Write("\nWybierz kolejną opcję: ");
            option = Console.ReadLine();
        }
        Console.Write("Do zobaczenia");
        //Console.ReadKey();
        return;
    }

    static void WorkOnList()
    {
        List<string> list = new List<string>();
        list.Add("101");
        list.Add("two");
        list.Add("III");
        list.Add("four");
        list.Add("Event");
        list.Add("foreach");
        list.Add("go to");
        list.Add("function");
        list.Add("question");
        var listInString = PrintList<string>("Przykładowa lista:", list);
        WriteLineInColor(ConsoleColor.Green, listInString);

        Console.WriteLine();
        var listCount = list.Count();
        Console.WriteLine("Liczba elementów: " + listCount);
        var firstElement = list.FirstOrDefault();
        Console.WriteLine("Pierwszy element: " + firstElement);
        var lasttElement = list.LastOrDefault();
        Console.WriteLine("Ostatni element: " + lasttElement);
        var maxElement = list.Max();
        Console.WriteLine("Max element: " + maxElement);
        var foundElement = list.Find(x => x.StartsWith("f"));
        Console.WriteLine("Znaleziony element zaczynający się na f: " + foundElement);
        var index = list.FindIndex(x => x.Equals("four"));
        Console.WriteLine("Indeks znalezionego elementu: " + index);

        list.Sort();
        var sortedListInString = PrintList<string>("Lista posortowana", list);
        WriteLineInColor(ConsoleColor.Green, sortedListInString);

        var elements = list.FindAll(x => x.StartsWith("f"));
        var selectedElementsInString = PrintList<string>("Lista elementów zaczynających się na f", elements);
        WriteLineInColor(ConsoleColor.Green, selectedElementsInString);

        var orderByElemets = list.OrderByDescending(x => x).ToList();
        var orderedListInString = PrintList<string>("Lista posortowana malejąco", orderByElemets);
        WriteLineInColor(ConsoleColor.Green, orderedListInString);

    }

    static void WorkOnEnumerable()
    {
        Console.WriteLine();
        Console.WriteLine("Przykładowa lista typu IEnumerable:");
        //Person p = new Person();
        //IEnumerable<Person> ennumList = new IEnumerable<Person>();
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

    static void WorkOnShortNumbers()
    {
        Console.WriteLine("Wybierz:");
        Console.WriteLine("(1) Sprawdź poprawność numeru PESEL");
        Console.WriteLine("(2) Sprawdź poprawność daty urodzenia");

        var option = Console.ReadLine();
        Console.WriteLine("Wybrano: " + option);
        switch (option)
        {
            case "1":
                Console.WriteLine("Podaj przykładowy nr PESEL");
                var inputPesel = Console.ReadLine();
                break;
            case "2":
                Console.WriteLine("Podaj datę urodzenia");
                var inputData = Console.ReadLine();
                break;
            default:
                Console.WriteLine("Nie ma takiej opcji");
                break;
        }
    }

    static void WorkOnLongNumbers()
    {
        Console.WriteLine("Wybierz:");
        Console.WriteLine("(1a) Silnia iteracyjnie");
        Console.WriteLine("(1b) Silnia rekurencyjnie");
        Console.WriteLine("(2) Liczby pierwsze lista");
        Console.WriteLine("(3a) Sortowanie bąbelkowe");
        Console.WriteLine("(3b) Sortowanie szybkie");

        var option = Console.ReadLine();
        Console.WriteLine("Wybrano: " + option);
        Console.WriteLine("podaj liczbę dodatnią: ");
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
            case "3a":
                Console.WriteLine("Sortowanie bąbelkowe");
                var randomList = RandomList((int)numberValid);
                var randomNumbers = PrintList<int>("Unsorted", randomList);
                WriteLineInColor(ConsoleColor.Green, randomNumbers);
                var sortedList = BubbleSort(randomList);
                var sortedNumbers = PrintList<int>("Sorted", sortedList);
                WriteLineInColor(ConsoleColor.Blue, sortedNumbers);
                break;
            case "3b":
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

    static void WorkOnFile(string file, string textToWrite)
    {
        Console.WriteLine(file);
        Console.WriteLine(textToWrite);
    }

    static void WorkOnDateTime(DateTime date)
    {
        Console.WriteLine(date.ToString());
    }

    static string PrintList<T>(string title, List<T> list)
    {
        string listToString = "\n" + title.ToUpper() + ":\n";
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

    static void WriteCharsInASCI()
    {
        for (int iNum = 0; iNum <= 255; iNum ++)
        {
            string stringToWrite = $"{iNum}: {(char)iNum} | ";
            WriteLineInColor(ConsoleColor.Green, stringToWrite);
            if (iNum % 10 == 0)
                Console.WriteLine();
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

    static List<int> QueryList(List<int> listToQuery)
    {
        //List<uint> queriedList = new List<uint>();
        //if (listToQuery.Count > 0)
        listToQuery.Find(x => x == 0);
        return listToQuery;
    }


    static void WriteLineInColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    
}
