// Name: Nicholas Hopewell		// Code File Lab5_3_1.cs
// Student Number: 0496633
// Lab 4, Part 2
// Program Description: This program consists of two classes: a dynamic BankAccount
//    and a static BankAccountDemo (which contains Main()).  The sole purpose of
//    Main() is to test the various properties and methods of BankAccount objects.

using System;
public static class BankAccountDemo
{
    public static void Main()
    {
        int acctNumber;
        double amount;
        BankAccount savings = new BankAccount();
        BankAccount chequing = new BankAccount(12345, 350.45);
        BankAccount newAcct;

        // input a 5 digit account number and balance for savings
        do
        {
            Console.Write("Enter a 5-digit account number => ");
            acctNumber = Convert.ToInt32(Console.ReadLine());
        } while ((acctNumber < 10000) || (acctNumber > 99999));
        savings.AcctNum = acctNumber;

        // print out the account information
        Console.WriteLine("Account {0} contains {1:C2}", savings.AcctNum, savings.Balance);
        Console.WriteLine("Account {0} contains {1:C2}", chequing.AcctNum, chequing.Balance);

        // prompt the user to enter an amount to deposit to savings
        do
        {
            Console.Write("Enter amount to deposit to savings: ");
            amount = Convert.ToDouble(Console.ReadLine());
        } while (amount < 0);

        // perform the deposit to savings
        savings.Deposit(amount);

        // print out the savings account information
        Console.WriteLine("Savings account balance: {0}.", savings.Balance);

        // prompt the user to enter an amount to withdraw from chequing
        do
        {
            Console.Write("Enter amount to withdraw from chequings: ");
            amount = Convert.ToDouble(Console.ReadLine());
        } while (amount < 0);

        // perform the withdrawal from chequing
        chequing.Withdrawal(amount);

        // print out the chequing account information
        Console.WriteLine("Chequing account balance: {0}.", chequing.Balance);

        // apply the interest to savings
        savings.Interest();

        // print out the savings account information
        Console.WriteLine("Savings account balance after interest: {0}.", savings.Balance);

        // combine chequing and savings into newAcct using overloaded operator
        newAcct = chequing + savings;

        // print out the newAcct account information
        Console.WriteLine("Account {0} contains {1:C2}", newAcct.AcctNum, newAcct.Balance);
        Console.ReadLine();
    }
}
