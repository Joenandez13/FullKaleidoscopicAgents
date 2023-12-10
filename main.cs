using System;

class Program
{
    static void Main()
    {
        const int MinTemperature = -30;
        const int MaxTemperature = 130;
        const int NumTemperatures = 5;

        int[] temperatures = new int[NumTemperatures];
        bool validInput = false;

        // Input temperatures and validate
        do
        {
            validInput = true;
            Console.WriteLine("Enter five daily Fahrenheit temperatures:");

            for (int i = 0; i < NumTemperatures; i++)
            {
                Console.Write($"Temperature {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out temperatures[i]))
                {
                    if (temperatures[i] < MinTemperature || temperatures[i] > MaxTemperature)
                    {
                        Console.WriteLine("Temperature out of range. Please reenter.");
                        validInput = false;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    validInput = false;
                    break;
                }
            }
        } while (!validInput);

        // Check temperature trend
        bool increasing = true;
        bool decreasing = true;

        for (int i = 1; i < NumTemperatures; i++)
        {
            if (temperatures[i] <= temperatures[i - 1])
            {
                increasing = false;
            }

            if (temperatures[i] >= temperatures[i - 1])
            {
                decreasing = false;
            }
        }

        // Display result based on temperature trend
        if (increasing)
        {
            Console.WriteLine("Getting warmer");
        }
        else if (decreasing)
        {
            Console.WriteLine("Getting cooler");
        }
        else
        {
            Console.WriteLine("It's a mixed bag");
        }

        // Display temperatures and average
        Console.WriteLine("Temperatures entered:");
        foreach (int temp in temperatures)
        {
            Console.Write($"{temp} ");
        }

        double average = CalculateAverage(temperatures);
        Console.WriteLine($"\nAverage temperature: {average:F2} degrees Fahrenheit");
    }

    static double CalculateAverage(int[] temperatures)
    {
        int sum = 0;

        foreach (int temp in temperatures)
        {
            sum += temp;
        }

        return (double)sum / temperatures.Length;
    }
}