 /*    
      Assginment 4
      COIS 1020
      Nicholas Hopewell
      0496633 
 
 
 Program Description:
 
     This program allows users to book, cancel, and print seat reservations from a total of 10 seats.
     The user is warned if they enter an invalid option.
     Seats are labelled 0-9 according to their index of the array. 
     When a user books a seat their name is stored in an available location in the array (as long as free seats exist).
     If all seats are booked the customer is warned that the plane is completely full. 
     When a user cancels, their name is removed from the plane seat bookings (the array), freeing that seat.
     If the user tries to cancel before booking a seat and their name cannot be found in the bookings, they will be warned.
     The user can also choose to look at all bookings by printing them out.
     Finally, the user may choose to quit and see the a goodbye message. 
 
 
 Data Dictionary:
 
    * string[] seatArray: array where seat bookings are stored. Initiallied to empty strings.
    * char command: command given from user to book 'b', cancel 'c', and print 'p' seats. 
    * string name: stores users name when booking or canceling seats. 
    * int open: initialized to -1, if a seat is available, open = the index of that seat. 
    * int index: when canceling, index = the location in the array where the persons name is stored
 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize array to empty stings, akin to 'null' as default. 
            string[] seatArray = new string[10] {"", "", "", "", "", "", "", "", "", ""};
            char command;


            // repeatedly prompt the user to choose an option until they choose to quit by entering 'q'
            do 
            {

                Console.Write("\nPlease choose an option:");
                Console.WriteLine();
                Console.WriteLine("'b' or 'B' to book a seat.\n'c' or 'C' to cancel a seat.\n'p' or 'P' to print seating assignments.\n'Or enter 'q' or 'Q' to quit.\n");
                command = char.ToUpper(char.Parse(Console.ReadLine())); // parse input to uppercase character

                // warn user if they have entered an invalid option.
                if (command != 'B' && command != 'C' && command != 'P' && command != 'Q')
                    Console.WriteLine("You have entered an invalid option.");
                else
                {
                    // switch to invoke associated method for each option the user can enter
                    switch (command)
                    {
                        case 'B':
                            {
                                // for booking
                                Booking(seatArray);
                                break;
                            }
                        case 'C':
                            {
                                // to cancel
                                Cancel(seatArray);
                                break;
                            }
                        case 'P':
                            {
                                // to print seatings
                                PrintSeat(seatArray);
                                break;
                            }
                    }
                }
                    

            } while(char.ToUpper(command) != 'Q'); // while the users does not enter 'q'

            // after user quits, print goodbye
            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }
        
        //FindEmptySeat Method:
        public static int FindEmptySeat(string[] SeatAssign)
        {
            // initialize open to -1, indicating no seats available
            int open = -1;
            for (int i = 0; i < SeatAssign.Length; ++i)
            {
                if(SeatAssign[i] == "")  // if empty string at index of array, assign open to index value
                    open = i;
            }
            return open; // return val
        }

        //FindCustomer Method:
        public static int FindCustomerSeat(string[] SeatAssign, string cName)
        {
            // initialize index to -1, indicating customers name is not in array
            int index = -1;
            for (int i = 0; i < SeatAssign.Length; ++i)
            {
                if (SeatAssign[i] == cName) // if name at any index of array, assign index to index value
                    index = i;
            }
            return index; // return val
        }

        // Booking Method
        public static void Booking(string[] SeatAssign)
        {
            string name;
            int seat;
            // prompt user to enter name
            Console.WriteLine("\nPlease enter your name.");
            name = Console.ReadLine();
            
            // find empty seat for user by invoing FindEmptySeat method
            seat = FindEmptySeat(SeatAssign);
            if (seat != -1) // if seat open
            {
                // assign customers name to index in array and inform them of this
                SeatAssign[seat] = name;
                Console.WriteLine("{0} has booked seat number {1}.", name, seat);
            }
            else // if no seats open
                 // warn customer and do not book seat
                    Console.WriteLine("We're sorry {0}, the plane is full.", name);
        }

        // Cancel Method:
        public static void Cancel(string[] SeatAssign)
        {
            string name;
            int seat;

            //prompt user for name
            Console.WriteLine("\nPlease enter your name.");
            name = Console.ReadLine();

            // find if they have booked a seat by invoking the FindCustomerSeat method
            seat = FindCustomerSeat(SeatAssign, name);
            if (seat != -1) // if customer has booked
            {
                // set index to empty string and inform user of cancelation 
                SeatAssign[seat] = ""; 
                Console.WriteLine("{0}, your seat has successfully been cancelled.", name);
            }
            else // if not booked, warn customer they have not booked a seat
                Console.WriteLine("We're sorry {0}, you do not have a seat on the plane booked.", name);
        }

        // PrintSeat Method:
        public static void PrintSeat(string[] SeatAssign)
        {
            Console.WriteLine(); // skip line
            // print out seat assignments for each customer on plane
            for(int i = 0; i < SeatAssign.Length; ++i)
                if (SeatAssign[i] != "")
                    Console.WriteLine("{0} is assigned to seat {1}.", SeatAssign[i], i);
        }
    }
}
