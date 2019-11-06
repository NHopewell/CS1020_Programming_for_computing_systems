
/* Nicholas Hopewell
   0496633
 
  This program first welcomes the customer to Rich Hortons and then asks him or her to enter their
  last name or type 'quit' to exit. If the customer choosing to quit, a message thanking them for
  considering Rich Hortons is displayed. If the user did not chose to quit they are then asked to
  enter the number of donuts they would like to order. The program then tries to parse their entry
  to an integer, if it cannot it asks the user to enter a valid input. If it can parse the users 
  entry to an integer it will adjust the cost per donut accordingly, charge the gourmet cover,
  and include HST if the order is under 12 donuts. The total cost of the order is then calculated 
  from these values. If the user enters 0 donuts or a negative number of donuts, it does not calculate 
  the cost of the order but instead says that the input is not acceptable and to please enter a valid 
  input. After these calculations, the program outputs the users last name on the order as well as the '
  total cost of the amount of donuts they ordered. The program then waits for 10 seconds then informs 
  the user that it will close in 10 seconds. After 6 seconds it shows a goodbye message thanking the
  customer for choosing Rich Hortons. After 4 additional seconds the program exits.*/


/* Data Dictionary of VARIABLES (not including constants)
   
   lastName:       Stores user-entered last name
   entry:          Stores user-entered # of donuts to order
   numberOfDonuts: Entry parsed from a string to an int
   costPerDonut:   Stores cost of donut depending on # of donuts ordered
   totalCost:      Stores total cost of the order which can include the numer of donuts, cost per donut, gourmet cover and HST */

using System; //using System namespace
public static class NHopewell_COIS1020_ASS1
{
    public static void Main()
    {
        // declare constants
        const double HST = 0.13;
        const decimal GOURMET_COVER = 0.25M;
        // store uninitialized string variables 
        string lastName, entry;
        // store uninitialized decimal variables
        decimal costPerDonut, totalCost;

        // welcome customer
        Console.WriteLine("Welcome to Rich Hortons!");

        while (true) 
        {
            // prompt customer for their last name then store input
            Console.Write("Please enter your last name, or type \"quit\" to exit: ");
            lastName = Console.ReadLine();

            // exit loop if quit entered
            if (lastName.ToLower() == "quit")
                break; // exit

            //prompt user for number of donuts and store input
            Console.Write("Please enter the number of donuts you would like to order: ");
            entry = Console.ReadLine();

            // try to parse the users input to an integer
            try
            {
                int numberOfDonuts = int.Parse(entry); // store parsed value

                if (numberOfDonuts <= 0)
                {
                    // if number of donuts less than or equal to 0, prompt user for acceptable input
                    Console.WriteLine("{0} is not an acceptable input, please try again.",
                        numberOfDonuts);
                    continue; // go back to start of loop
                }
                else if (numberOfDonuts <= 7)
                {
                    // if number of donuts less than 7 then CpD = 1 (1 dollar)
                    costPerDonut = 1.00M;
                    // calculate total cost as CpD, NoD, gourmet cover, and include HST
                    totalCost = (costPerDonut * numberOfDonuts + GOURMET_COVER) * ((decimal)1 + (decimal)HST);
                }
                else if (numberOfDonuts < 12)
                {
                    // if number of donuts less than 12 then CpD = .90 (90 cents)
                    costPerDonut = 0.90M;
                    // calculate total cost as CpD, NoD, gourmet cover, and include HST
                    totalCost = (costPerDonut * numberOfDonuts + GOURMET_COVER) * ((decimal)1 + (decimal)HST);
                }
                else if (numberOfDonuts >= 12 && numberOfDonuts < 15)
                {
                    // CpD does not change for less than 15 donuts
                    costPerDonut = 0.90M;
                    // calculate total cost as CpD, NoD, gourmet cover but do not include HST
                    totalCost = costPerDonut * numberOfDonuts + GOURMET_COVER;
                }
                else
                {
                    //CpD for orders of 15 donuts and above is .75 (75 cents)
                    costPerDonut = 0.75M;
                    // calculate total cost as CpD, NoD, gourmet cover but do not include HST
                    totalCost = costPerDonut * numberOfDonuts + GOURMET_COVER;
                }

            }
            
            // catch input in format which could not be parsed to an integer
            catch (FormatException)
            {
                // prompt user to enter valid input
                Console.WriteLine("The value entered is not valid. Please enter a valid input.");
                continue; // back to start of loop
            }

            // return costumers order details:
            // return last name
            Console.WriteLine("Customer: {0}", lastName);
            // return number of donuts in order and cost
            Console.WriteLine("Total cost for {0} donut(s): {1}", entry, totalCost.ToString("C2")); 
            System.Threading.Thread.Sleep(10000); // wait 10 seconds
            // inform user program will exit
            Console.WriteLine("...");
            Console.WriteLine("The program will exit in 10 seconds");
            Console.WriteLine("...");
            System.Threading.Thread.Sleep(6000); // wait 6 seconds
            break; // exit loop
        }

        // thank customer
        Console.WriteLine("Thank you for considering Rich Horton's! Goodbye.");
        System.Threading.Thread.Sleep(4000); // wait 4 seconds
    }

}
