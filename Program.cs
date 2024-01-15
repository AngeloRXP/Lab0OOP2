using System;
using System.IO;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Lab01Practice;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Lab 0: Basics of C#\n");

        Console.WriteLine("\nTask 1: Creating variables\n");

        int intLowerNumber = LowerNumber();
        int intHigherNumber = HigherNumber(intLowerNumber);

        int difference = intHigherNumber - intLowerNumber;
        Console.WriteLine($"The difference between {intHigherNumber} and {intLowerNumber} is: {difference}");


        Console.WriteLine("\nTask 2: Looping and Input Validation\n");

        while (intLowerNumber < 0)
        {
            Console.WriteLine($"{intLowerNumber} is an invalid number. Please enter a valide positive number: ");
            intLowerNumber = LowerNumber();
        }

        if (intLowerNumber > 0)
        {
            Console.WriteLine($"Validation 2.1: 'low' number ({intLowerNumber}) is positive\n");
        }

        while (intHigherNumber < intLowerNumber)
        {
            Console.WriteLine($"These character is invalid. Enter the 'high' number: ");
            intHigherNumber = HigherNumber(intHigherNumber);

        }

        if (intHigherNumber > intLowerNumber)
        {
            Console.WriteLine($"Validation 2.2: 'high' number ({intHigherNumber}) is greater than 'low' number ({intLowerNumber})\n");
        }

        Console.WriteLine("Task3: Using Arrays and File I/O\n");

        string myFile = "numbers.txt";

        int[] setOfNumbers = NewArray(intLowerNumber, intHigherNumber);

        TransferInfoToTxt(myFile, setOfNumbers);

        SumOfNumbers(myFile);

        List<int> newList = new List<int>(setOfNumbers);//creating a variable newList (type 'int list') and inputting the array 'setOfNumbers' as the parameter

        List<double> doubleNewList = ConvertNewListToDouble(newList); 

        CheckPrimeNumbers(intLowerNumber, intHigherNumber);


    }
    static int LowerNumber()
    {
        int userLower;
        Console.WriteLine("Enter the 'low' number: ");
        string low = Console.ReadLine();

        while (!int.TryParse(low, out userLower))
        {
            Console.WriteLine("These character is invalid. Enter the 'low' number: ");
            low = Console.ReadLine();
        }

        return userLower;

    }

    static int HigherNumber(int lower)
    {
        int userHigher;
        Console.WriteLine("Enter the 'high' number: ");
        string high = Console.ReadLine();

        while (!int.TryParse(high, out userHigher) || userHigher <= lower)
        {
            Console.WriteLine("These character is invalid. Enter the 'high' number: ");
            high = Console.ReadLine();
        }
        return userHigher;
    }


    static int[] NewArray(int smaller, int greater)
    {
        int[] array1 = new int[(greater - smaller) + 1];
        for (int i = 0, addNumber = smaller; i < array1.Length; i++, addNumber++)
        {
            array1[i] = addNumber;
        }
        return array1;
    }

    static void TransferInfoToTxt(string fileName, int[] numbers)
    {
        Array.Reverse(numbers);
        File.WriteAllLines(fileName, Array.ConvertAll(numbers, n => n.ToString()));
        Console.WriteLine($"Number written to {fileName} as required.");
    }

    static int SumOfNumbers(string fileName)
    {
        string[] numbers = File.ReadAllLines(fileName);
        int sum = 0;
        foreach (string number in numbers)
        {
            if (int.TryParse(number, out int intNumber))
            {
                sum += intNumber;
            }
        }
        Console.WriteLine($"The sum of all numbers is equal to {sum}.");
        return sum;
    }
    static List<double> ConvertNewListToDouble(List<int> intList)
    {
        return intList.ConvertAll<double>(x => x);
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    static void CheckPrimeNumbers(int low, int high)
    {
        Console.WriteLine($"Prime numbers between {low} and {high}: ");
        for (int i = low; i <= high; i++)
        {
            if (IsPrime(i))
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine();
    }
}