/* 
   Assignment 2
   Nicholas Hopewell
   0496633

- Calculate the AVERAGE salary of people with university degrees, college diplomas, and high school diplomas.
- Salary data is processed until the user specifies the calculations should stop.
- For each person, first: the education type (char edType) is input ('U' or 'u' for university, 'C' or 'c' for college, 'H' or 'h' for highschool.
                   second: the salary (double salaryData).
- The specification by the user to stop is done by entering 'Q' or 'q' (for quit)
- Prints error message if user enters invalid education type or negative salary.

 */


using System;
public static class Assignment_2
{
    public static void Main()
    {
        //char edType;
        string edType;
        string uniEntry, colEntry, highEntry;
        double salUni = 0.0, avgUni = 0.0;
        double salCol = 0.0, avgCol = 0.0; 
        double salHigh = 0.0, avgHigh = 0.0;
        int numUni = 0, numCol = 0, numHigh = 0;


        
        Console.WriteLine("Please enter education type:" + Environment.NewLine +
                               "'U' for university." + Environment.NewLine +
                               "'C' for college," + Environment.NewLine +
                               "'H' for highschool." + Environment.NewLine + 
                               "Or enter 'Q' to quit.");


        edType = Console.ReadLine();

        
        while (char.ToUpper(edType) != 'Q')
        {
            try
            {
                char.Parse(edType);
            }
            catch (FormatException)
            {
                // prompt user to enter valid input
                Console.WriteLine("Invalid entry. Please enter education type.");
                continue; // back to start of loop
            }

            if (edType.ToUpper = 'U')
            {
                numUni++;
                Console.WriteLine("Please enter salary.");
                uniEntry = Console.ReadLine();
                if (Double.TryParse(uniEntry == TRUE))
                {
                    salUni += Convert.ToDouble(uniEntry);
                }
                else 
                {
                    Console.WriteLine("Invalid entry. Please reenter.");
                    uniEntry = Console.ReadLine();
                    salUni += ToDouble(uniEntry);
                }

            }
            else if (edType.ToUpper = 'C')
            {
                numCol++;
                Console.WriteLine("Please enter salary.");
                colEntry = Console.ReadLine();
                try
                {
                    double.Parse(colEntry);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid entry. Please reentr salary");
                    continue;
                }
                salCol += Convert.Todouble(colEntry);
            }
            else if (edType.ToUpper = 'H')
            {
                numHigh++;
                Console.WriteLine("Please enter salary.");
                highEntry = Console.ReadLine();
                try
                {
                    double.Parse(highEntry);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid entry. Please reenter salary");
                    continue;
                }
                salHigh += To.double(highEntry);
            }
            else 
            {
                Console.WriteLine("Invalid entry. Please enter a valid education type.");
                continue;
            }

            Console.WriteLine("Please enter education type:" + Environment.NewLine +
                        "'U' for university." + Environment.NewLine +
                        "'C' for college," + Environment.NewLine +
                        "'H' for highschool." + Environment.NewLine + 
                        "Or enter 'Q' to quit.");

            edType = Console.ReadLine();     
        }






            // Read initial salary (seed the loop)
            Console.Write("Enter salary: ");
            salaryData = Convert.ToDouble(Console.ReadLine());
            
        } 

    }

}