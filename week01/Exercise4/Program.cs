using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        // Get numbers from user
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            // Only add the number to the list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Part 1: Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Part 2: Compute the average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Part 3: Find the maximum
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
        
        // Stretch Challenge 1: Find the smallest positive number (closest to zero)
        int? smallestPositive = null; // Using nullable int to handle case where no positives exist
        
        foreach (int number in numbers)
        {
            if (number > 0)
            {
                // If smallestPositive hasn't been set yet, or we found a smaller positive number
                if (smallestPositive == null || number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
        }
        
        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        
        // Stretch Challenge 2: Sort and display the list
        numbers.Sort();
        
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}