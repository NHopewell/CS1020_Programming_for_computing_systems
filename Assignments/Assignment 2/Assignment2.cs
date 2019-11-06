/* 
   Assignment 2
   COIS 1020
   Nicholas Hopewell
   0496633

  Description:
 
- Calculate the AVERAGE salary of people with university degrees, college diplomas, and high school diplomas.
- Salary data is processed until the user specifies the calculations should stop.
- For each person, first: the education type (char edType) is input ('U' or 'u' for university, 'C' or 'c' for college, 'H' or 'h' for highschool.
                   second: the salary (double salaryData).
- The specification by the user to stop is done by entering 'Q' or 'q' (for quit)
- Prints error message if user enters invalid education type or negative salary.
- All input validation has also been accounted for. Any invalid or unexpected inputs at any stage should be covered and throw the user an error warning.
 
 
   Data Dictionary: 
 
 * bool validParse:      used as a loop control variable to see whether the user input a value which can be parsed to a character
 * bool validSalary:     used as a loop control variable to see whether the user input a value which can be parsed to a double
 * string edTypeString:  stores the users input education type as string
 * char edType:          stores the education type as a character if edTypeString can be parsed to a character
 * string salStringData: stores the users input salary as string
 * double salaryData:    stores salary as double if salStringData can be parsed to a double
 * double totalUni:      stores total of university salaries entered
 * double totalCol:      stores total of college salaries entered
 * double totalHigh:     stores total of high school salaries entered
 * double avgUni:        stores average of university salaries entered
 * double avgCol:        stores average of college salaries entered
 * double avgHigh:       stores average of high school salaries entered
 * int numUni:           stores number of university salaries entered
 * int numCol:           stores number of college salaries entered
 * int numHigh:          stores number of high school salaries entered
 
 */


using System;
public static class Assignment_2
{
    public static void Main()
    {
        // setting aside containers
        string edTypeString;
        char edType;
        string salStringData;
        // variable declarations
        double salaryData = 0.0;
        double totalUni = 0.0, avgUni = 0.0;
        double totalCol = 0.0, avgCol = 0.0;
        double totalHigh = 0.0, avgHigh = 0.0;
        int numUni = 0, numCol = 0, numHigh = 0;


        // one loop control value
        bool validParse;

        do
        {
            // prompt user
            Console.WriteLine("Please enter education type: \n 'U' for university. \n" +
                              "'C' for college. \n 'H' for highschool. \n Or enter 'Q' to quit. \n");

            // read input
            edTypeString = Console.ReadLine();
            validParse = Char.TryParse(edTypeString, out edType); //try to parse input to char, if possible then store in edType and validParse = true

            if (validParse) // if parsing to char was successful
            {
                if (char.ToUpper(edType) != 'Q' && char.ToUpper(edType) != 'U'
                    && char.ToUpper(edType) != 'C' && char.ToUpper(edType) != 'H') // if the user entered an inappropriate character. 
                {
                    // return message
                    Console.WriteLine("Please enter one of the possible education type options. Or enter 'Q' to quit. \n");
                }
                else
                {
                    // if parse was successful and proper character, store string to char
                    edType = char.Parse(edTypeString);
                }
            }
            else
            {
                // Can't parse - warn user
                Console.WriteLine(" Invalid entry. \n");
            }

        } while ((char.ToUpper(edType) != 'Q' && char.ToUpper(edType) != 'U' && char.ToUpper(edType) != 'C'
                  && char.ToUpper(edType) != 'H') || !validParse); // do while the user enters an incorrect character or a value which
                                                                   // cannot be parsed to a character.


        while (char.ToUpper(edType) != 'Q') // While users input is not Q
        {
            // loop control value
            bool validSalary;

            do
            {
                // prompt user
                Console.Write("Please enter salary.");
                salStringData = Console.ReadLine(); // read input
                validSalary = Double.TryParse(salStringData, out salaryData); // try to parse to double, if so store in salaryData, validSalary = true

                if (validSalary) // if true
                {
                    if (salaryData < 0) // is salaryData less than 0?
                    {
                        // prompt user
                        Console.WriteLine("Please try again and enter a positive salary");
                    }
                }
                else
                {
                    // prompt user to enter valid salary
                    Console.WriteLine("Please try again and enter a valid salary");
                }
            } while (!validSalary); // while salary can't be parsed to double/while false



            if (char.ToUpper(edType) == 'U' && salaryData >= 0) //  if univeristy
            {
                // store salary data entered in totalUni
                // increment number of uni salaries
                totalUni += salaryData;
                numUni++;
            }
            else if (char.ToUpper(edType) == 'C' && salaryData >= 0) // if college
            {
                // store salary data entered in totalCol
                // increment number of college salaries
                totalCol += salaryData;
                numCol++;
            }
            else if (char.ToUpper(edType) == 'H' && salaryData >= 0) // if highschool
            {
                // store salary data in totalHigh
                // increment number of highschool salaries
                totalHigh += salaryData;
                numHigh++;
            }

            do
            {
                // prompt again
                Console.WriteLine("Please enter education type: \n 'U' for university. \n" +
                                  "'C' for college. \n 'H' for highschool. \n Or enter 'Q' to quit. \n");

                edTypeString = Console.ReadLine(); // read input
                validParse = Char.TryParse(edTypeString, out edType); //try to parse to char, if so store in edType, validParse = true

                if (validParse) //true
                {
                    if (char.ToUpper(edType) != 'Q' && char.ToUpper(edType) != 'U'
                        && char.ToUpper(edType) != 'C' && char.ToUpper(edType) != 'H') // if the user did not enter proper character
                    {
                        // prompt user for correction
                        Console.WriteLine("Please enter one of the possible education type options. Or enter 'Q' to quit. \n");
                    }
                    else
                    {
                        // store parsed string in edType
                        edType = char.Parse(edTypeString);
                    }
                }
                else
                {
                    // warn user
                    Console.WriteLine(" Invalid entry. \n");
                }

            } while ((char.ToUpper(edType) != 'Q' && char.ToUpper(edType) != 'U' && char.ToUpper(edType) != 'C'
                      && char.ToUpper(edType) != 'H') || !validParse); // until valid parse and valid entry for education type
        }

            if (numUni > 0) // calculate only if at least one salary entered. If not default value.
            {
                // caluate average for university salaries
                avgUni = totalUni / numUni;
            }

            if (numCol > 0) // calculate only if at least one salary entered. If not default value.
            {
                // caluate average for college salaries
                avgCol = totalCol / numCol;
            }

            if (numHigh > 0) // calculate only if at least one salary entered. If not default value.
            {
                // caluate average for highschool salaries
                avgHigh = totalHigh / numHigh;
            }

            // display number of salaries entered and average salaries for each eduction type
            Console.WriteLine("{0} University salaries were entred. The average salary with a university degree is {3}. \n" +
                              "{1} College salaries were entered. The average salary with a college degree is {4} \n" +
                              "{2} High school salaries were entered. The average salary with a highschool degree is {5}",
                              numUni, numCol, numHigh,
                              avgUni.ToString("C"), avgCol.ToString("C"), avgHigh.ToString("C"));

            Console.ReadLine();


        }

    }
