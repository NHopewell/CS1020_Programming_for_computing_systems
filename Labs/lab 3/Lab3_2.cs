// Name: Nicholas Hopewell
// Student Number: 0496633
// Lab 3, Part 2
// Program Description: This program uses two user defined methods to compute 
//    the gross pay and net pay for an employee after entering the employee�s
//    last name, hours worked, hourly rate, and percentage of tax.



using System;
public static class Lab3_2
{
    public static void Main()
    {
        // declare variables
        int hrsWrked;
        double ratePay, taxRate, grossPay, overTime = 0, netPay = 0;
        string lastName;

        // enter the employee's last name
        Console.Write("Enter the last name of the employee => ");
        lastName = Console.ReadLine();

        // enter (and validate) the number of hours worked (positive number)
        do
        {
            Console.Write("Enter the number of hours worked (> 0) => ");
            hrsWrked = Convert.ToInt32(Console.ReadLine());
        } while (hrsWrked < 0);

        // enter (and validate) the hourly rate of pay (positive number)
        // *** Insert the code to enter and validate the ratePay 
        do
        {
            Console.Write("Enter the hourly rate of pay (>0) => ");
            ratePay = Convert.ToDouble(Console.ReadLine());
        } while (ratePay < 0);

        // enter (and validate) the percentage of tax (between 0 and 1)
        // *** Insert the code to enter and validate taxRate 
        do
        {
            Console.Write("Enter the percentage of tax (between 0 and 1) => ");
            taxRate = Convert.ToDouble(Console.ReadLine());
        } while (taxRate <= 0 || taxRate >= 1);

        // Call a method to calculate the gross pay (call by value)
        grossPay = CalculateGross(hrsWrked, ratePay);

        //Call method to calculate overtime pay
        overTime = CalculateOT(hrsWrked, ratePay);

        // add overtime
        grossPay += overTime;

        // Invoke a method to calculate the net pay (call by reference)
        CalculateNet(grossPay, taxRate, ref netPay);

        // print out the results
        Console.WriteLine("{0} worked {1} hours at {2:C} per hour", lastName,
                          hrsWrked, ratePay);
        // *** Insert the code to print out the Gross Pay and Net Pay
        Console.WriteLine("Gross pay: {0}. \nNet pay: {1}.", grossPay, netPay);
        Console.ReadLine();
    }

    // Method: CalculateGross
    // Parameters
    //      hours: integer storing the number of hours of work
    //      rate: double storing the hourly rate
    // Returns: double storing the computed gross pay
    public static double CalculateGross(int hours, double rate)
    {
        // *** Insert the contents of the CalculateGross Method
        double gross;
        gross = hours * rate;
        return gross;

    }


    // Method: CalculateOT

    public static double CalculateOT(int hours, double rate)
    {
        double over = 0;

        if (hours > 40)
            over = (hours - 40) * (rate * 0.5);
        return over;
    }


    // Method: CalculateNet
    // Parameters
    //      grossP: double storing the grossPay
    //      tax: double storing tax percentage to be removed from gross pay
    //      netP: call by reference double storing the computed net pay
    // Returns: void 
    public static void CalculateNet(double grossP, double tax, ref double netP)
    {
        // *** Insert the details of the CalculateNet Method
        netP = grossP * (1 - tax);
    }
}