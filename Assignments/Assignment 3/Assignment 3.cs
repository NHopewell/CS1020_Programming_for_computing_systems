// Assginment 3
// Nicholas Hopewell
// 0496633

/* Account Transaction Program:
        This program allows the user to deposit ('D') and withdraw ('W') money from their account and see their account balance ('P').
        The user must only deposit or withdraw a positive amount.
        The program will continue to accept transactions until the user decides to exit ('Q') at which case the program prints 'Goodbye.' 
 */

/* Data Dictionary:
 
     * double balance is the container which stores the account balance.
     * char transation is the container which stores the transaction type (withdrawl, deposit ect.)
     * amountWithdrawl is the container which stores the amount the user wants to withdraw from their account
     * amountDeposit is the container which stores the amount the iser wants to deposit to their account
     * amount is the amount the user enters for withdrawl or deposit
     * amountString is the constainer which stores the amount the user enters as a string to be parsed to a double
     * validParse is a bool that is true when amountString can be parsed to a double (i.e.: the user enters a number).

 */


 
using System;
public static class Assignment_3
{
    public static void Main()
    {
        // delacare and initialize variables which need initialization
        double balance = 0.0;
        char transaction;
        double amountWithdrawl;
        double amountDeposit;
        


        // Prompt the user to enter a transaction type or quit.
        // This prompt will loop until 'Q' is entered. 
       do
       {
           Console.WriteLine("\nPlease enter a transaction: \n'W' = Withdrawal (+ $1.50 service fee) \n'D' = Deposit \n'P' = Print \nOr enter 'Q' to quit.\n");
           transaction = char.ToUpper(char.Parse(Console.ReadLine()));

           // for each possible entry, switch to the appropriate task.
           switch (transaction)
           {
               case 'W':
                   {
                       amountWithdrawl = GetAmount(); // call method to get amount
                       Withdrawal(amountWithdrawl, ref balance); // call method update balance with withdrawl
                       break;
                   }
               case 'D':
                   {
                       amountDeposit = GetAmount(); // call method to get amount
                       Deposit(amountDeposit, ref balance); // call method update balance with deposit
                      break;
                   }
               case 'P':
                   {
                      print(balance); // call method which prints users account balance
                      break;
                   }

           }

       } while (transaction != 'Q'); // break to below code when user enters Q


       Console.WriteLine("Goodbye."); // say goodbye to user.
       Console.ReadLine();
    }

    // prompt user for an amount and verify itis a number and is positive
    public static double GetAmount()
    {
        // define and initialize vars
        bool validParse;
        string amountString;
        double amount = 0.0;

        // prompt user to enter an amount that is positive
        do
        {
            Console.Write("\nPlease enter a positive amount: ");
            amountString = Console.ReadLine();
            validParse = Double.TryParse(amountString, out amount); // try to parse input to a double. If yes, store amount

            if (validParse) // if number is input
            {
                if (amount < 0.0) // if negative
                    Console.Write("\nNegative numbers are not valid. \n"); // no negative values allowed
            }
            else
                Console.WriteLine("\nInvalid entry. \n"); // not a number
                  
        } while (!validParse); // while the entry cannot be parsed to a double

        return amount;
    }

    // update balance with withdrawl amount
    public static void Withdrawal(double amount, ref double balance)
    {
        if (amount >= 0)
        {
            // if not enough money in account to withdraw input amount plus service charge
            if (balance - (amount + 1.50) < 0)
                Console.WriteLine("\nInsufficient funds for withdrawl.\n");// tell user they dont have the funds
            else
                balance -= (amount + 1.50); // if they do have the funds, update balance
        }

    }

    // update account with deposit amount
    public static void Deposit(double amount, ref double balance)
    {
        // if depositing more than 2k, update account and give 1% bonus to account balance
        if (balance + amount > 2000)
            balance += (amount + (amount * 0.01));
        else
            balance += amount; // if less than 2k, update balace with amount
    }

    // print account balance
    public static void print(double balance)
    {
        Console.WriteLine("\n *** Your account balance is {0}. ***", balance.ToString("C"));
    }
}
