// Name: Nicholas Hopewell
// Student Number: 0486633
// Lab 4, Part 2
// Program Description: This program uses four user-defined methods: one
//    to input an array of numbers, one to compute the average the array, one 
//    to find the largest number in the array, and one to find the smallest 
//    number in the array.

using System;
public static class Lab4_2
{
    public static void Main()
    {
        int[] compStats = new int[25];
        int n = 0, large, small;
        double avg = 0;

        // Input values into the array
        InpArray(compStats, ref n);

        // Find the average of the elements in the array
        avg = FindAverage(compStats, n);

        // Find the largest element in the array
        large = FindLarge(compStats, n);

        // Find the largest element in the array
        small = FindSmall(compStats, n);

        // Print out the results
        Console.WriteLine("\nThe Average of the array is {0:F}", avg);
        Console.WriteLine("\nThe largest value is {0}, and the smallest value is {1}", large, small);

        // Pause until user is done
        Console.ReadLine();
    }

    // Method:       InpArray
    // Description:  Input values into an array.
    // Parameters:   arrValues: the array to fill.
    //               num: number of elements in the array.
    // Returns:      void
    public static void InpArray(int[] arrValues, ref int num)
    {
        // input the number of data values to put in the array
        do
        {
            Console.Write("Enter the number of elements (<= 25) => ");
            num = Convert.ToInt32(Console.ReadLine());
        } while (num < 0 || num > 25);

        // loop to enter the values
        for (int i = 0; i < num; ++i)
        {
            Console.Write("Enter the Element {0} => ", i);
            arrValues[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    // Method:       FindAverage
    // Description:  Computes the average of the elements in the array.
    // Parameters:   arrVals: array to be processed
    //               num: number of elements in the array.
    // Returns:      the average of the elements in the array
    public static double FindAverage(int[] arrVals, int num)
    {
        double total = 0.0;
        double avg = 0.0;

        for (int i = 0; i < num; ++i)
        {
            total += arrVals[i];
        }
        avg = total / num;
        return avg;
    }

    // Method:       FindLarge
    // Description:  Determines the largest element in the array.
    // Parameters:   arrVals: array to be processed
    //               num: number of elements in the array.
    // Returns:      the largest element in the array
    public static int FindLarge(int[] arrVals, int num)
    {
        int large = arrVals[0];

        for (int i = 1; i < num; ++i)
        {
            if (arrVals[i] > large)
                large = arrVals[i];

        }

        return large;
    }

    // Method:       FindSmall
    // Description:  Determines the smallest element in the array.
    // Parameters:   arrVals: array to be processed
    //               num: number of elements in the array.
    // Returns:      the smallest element in the array
    public static int FindSmall(int[] arrVals, int num)
    {
        int small = arrVals[0];

        for (int i = 1; i < num; ++i)
        {
            if (arrVals[i] < small)
                small = arrVals[i];

        }

        return small;

    }
}
