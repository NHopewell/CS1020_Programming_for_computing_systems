

/* Assignment 5
 * Nicholas Hopewell - 0496633
 * COIS 1020h Winter 2018
 * 
 * 
 * 
 * Program description: 
 *      This program comes preloaded with some constructed fractions and also prompts the user to input
 *      his or her own fractions. The program then does some math and logical comparisions with the user
 *      defined fraction and the pre-constructed fractions. Specifically, the program adds, multiples,
 *      and compared ( <= and >= )the fractions. The pre-built fractions cover a lot of different varieties
 *      of fractions to test the math works correctly. The program also covers all applicable input validation
 *      and exception handling. The program continues prompting the user to keep entering fractions until they
 *      decide to stop and exit the program. If the user enters a 0 for the deonminator, it is corrected to 1.
 *      
 *      The purpose of Main() is to simply test the Fraction class and its overloaded operators. You'll see by
 *      running the program that the Fraction class and it's possibile outputs and eventualities can exhaustively
 *      be tested via user input through Main().
 *      
 * 
 * Data Dictionary:
 *      This assignment does not ask for a data dictionary.    
 */


using System;
public static class FractionAssignment
{
    public static void Main()
    {
        // different fractions for testing - notice how the third fraction automatically changes in the program to -6
        Fraction fraction2 = new Fraction(1, 2); 
        Fraction fraction3 = new Fraction(6, -1); // neagtive denom
        Fraction fraction4 = new Fraction(11, -5); // neagtive denom
        Fraction fraction5 = new Fraction(3, 9); // can be reduced
        Fraction fraction6 = new Fraction(5, 11); // cannot be reduced any more
        char choice = 'x';

        Console.WriteLine("### WELCOME TO NICKS FRACTION PROGRAM ####\n\n");

        do
        {
            Fraction fraction1 = new Fraction(); // user will populate

            try
            {
                do
                {
                    // prompt user
                    Console.Write("Would you like to enter a fraction? (y/n): ");
                    choice = Convert.ToChar(Console.ReadLine()); // convert to character
                    if (char.ToLower(choice) != 'y' && char.ToLower(choice) != 'n') //check for proper selection
                    {
                        Console.WriteLine("Please choose from the two available options.");
                    }
                } while (char.ToLower(choice) != 'y' && char.ToLower(choice) != 'n'); // until proper choice is made

                if (char.ToLower(choice) == 'y') // if yes
                {
                    // initialize
                    int inpNum = 0;
                    bool inp = true;
                    do
                    {
                        try
                        {
                            Console.Write("Enter a numerator => "); // prompt for numerator
                            inpNum = Convert.ToInt32(Console.ReadLine()); // try to convert to int
                            inp = false;
                        }
                        catch (FormatException) // catch anything but int
                        {
                            Console.WriteLine("The numerator must be an integer."); // warn user
                        }
                    } while (inp); // while true

                    fraction1.Numerator = inpNum; // set numerator to input val

                    // initialize
                    int inpDenom = 0;
                    inp = true;
                    do
                    {
                        try
                        {
                            Console.Write("Enter a denominator => "); // prompt for denominator
                            inpDenom = Convert.ToInt32(Console.ReadLine()); // try to convert to int
                            if (inpDenom == 0)
                                Console.WriteLine("**Warning: User entered a denominator of 0, converted denominator to 1**"); 
                            inp = false;
                        }
                        catch (FormatException) // catch anything but int
                        {
                            Console.WriteLine("The denominator must be an integer."); // warn user
                        }
                    } while (inp);// while true

                    fraction1.Denominator = inpDenom; // set denominator to input val

                    // print smallest form of entered fraction
                    Console.WriteLine("\nFraction entered reduced to it's smallest form: {0}", fraction1.ToString());
                    Console.WriteLine("Now let's do some math with this fraction...\n");

                    // print reduced fraction plus four different fractions and the result after adding
                    //(using overloaded operators)
                    Console.WriteLine(
                        "Your fraction {0} + {1} is equal to {2}", 
                            fraction1.ToString(), fraction2.ToString(), (fraction1 + fraction2).ToString()
                        );
                    Console.WriteLine(
                        "Your fraction {0} + {1} is equal to {2}", 
                            fraction1.ToString(), fraction3.ToString(), (fraction1 + fraction3).ToString()
                        );
                    Console.WriteLine(
                        "Your fraction {0} + {1} is equal to {2}", 
                            fraction1.ToString(), fraction4.ToString(), (fraction1 + fraction4).ToString()
                        );
                    Console.WriteLine(
                        "Your fraction {0} + {1} is equal to {2}", 
                            fraction1.ToString(), fraction5.ToString(), (fraction1 + fraction5).ToString()
                        );
                    Console.WriteLine(
                        "Your fraction {0} + {1} is equal to {2}\n", 
                            fraction1.ToString(), fraction6.ToString(), (fraction1 + fraction6).ToString()
                        );
                    // print reduced fraction multiplied by four different fractions and the result after multiplying 
                    //(using overloaded operators)
                    Console.WriteLine(
                        "Your fraction {0} * {1} is equal to {2}",
                            fraction1.ToString(), fraction2.ToString(), (fraction1 * fraction2).ToString()
                        );
                    Console.WriteLine(
                        "Your fraction {0} * {1} is equal to {2}", 
                            fraction1.ToString(), fraction3.ToString(), (fraction1 * fraction3).ToString()
                        );
                    Console.WriteLine(
                        "Your fraction {0} * {1} is equal to {2}", 
                            fraction1.ToString(), fraction4.ToString(), (fraction1 * fraction4).ToString()
                            );
                    Console.WriteLine(
                        "Your fraction {0} * {1} is equal to {2}", 
                            fraction1.ToString(), fraction5.ToString(), (fraction1 * fraction5).ToString()
                            );
                    Console.WriteLine(
                        "Your fraction {0} * {1} is equal to {2}\n", 
                            fraction1.ToString(), fraction6.ToString(), (fraction1 * fraction6).ToString()
                            );
                    // print reduced fraction compared to four different fractions for greater than or equal to and the 
                    // after comparison (using overloaded operators)
                    Console.WriteLine(
                        "Your fraction {0} >= {1} is equal to {2}", 
                            fraction1.ToString(), fraction2.ToString(), fraction1 >= fraction2);
                    Console.WriteLine(
                        "Your fraction {0} >= {1} is equal to {2}", 
                            fraction1.ToString(), fraction3.ToString(), fraction1 >= fraction3);
                    Console.WriteLine(
                        "Your fraction {0} >= {1} is equal to {2}", 
                            fraction1.ToString(), fraction4.ToString(), fraction1 >= fraction4);
                    Console.WriteLine(
                        "Your fraction {0} >= {1} is equal to {2}",
                            fraction1.ToString(), fraction5.ToString(), fraction1 >= fraction5);
                    Console.WriteLine(
                        "Your fraction {0} >= {1} is equal to {2}\n", 
                            fraction1.ToString(), fraction6.ToString(), fraction1 >= fraction6);
                    // print reduced fraction compared to four different fractions for less than or equal to and the result
                    // after comparison (using overloaded operators)
                    Console.WriteLine(
                        "Your fraction {0} <= {1} is equal to {2}", 
                            fraction1.ToString(), fraction2.ToString(), fraction1 <= fraction2);
                    Console.WriteLine(
                        "Your fraction {0} <= {1} is equal to {2}", 
                            fraction1.ToString(), fraction3.ToString(), fraction1 <= fraction3);
                    Console.WriteLine(
                        "Your fraction {0} <= {1} is equal to {2}", 
                            fraction1.ToString(), fraction4.ToString(), fraction1 <= fraction4);
                    Console.WriteLine(
                        "Your fraction {0} <= {1} is equal to {2}", 
                            fraction1.ToString(), fraction5.ToString(), fraction1 <= fraction5);
                    Console.WriteLine(
                        "Your fraction {0} <= {1} is equal to {2}\n", 
                            fraction1.ToString(), fraction6.ToString(), fraction1 <= fraction6);
                }
            }
            catch (FormatException) // anything but a character is entered
            {
                Console.WriteLine("\nPlease choose from the two available options.\n"); // warn user
            }
            catch (System.OverflowException) // catching an integer overflow is user enters huge integer 
            {
                Console.WriteLine("\nValue entered is too large. Please try again with a smaller number.\n");
            }

        } while (char.ToLower(choice) != 'n'); // while user has not chose 'n' for no

        Console.WriteLine("Goodbye and have a good day!."); // say goodbye
        Console.ReadLine();



    }
}
