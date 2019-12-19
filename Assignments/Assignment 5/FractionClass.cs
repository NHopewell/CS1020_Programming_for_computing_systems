/* Assignment 5
 * Nicholas Hopewell - 0496633
 * 
 * Objects of the Fraction class have two public properties: Numerator and Denominator
 *  in which the private numerator and denominator data fields can be accessed. Also, Fraction objects have
 *  one private void method Reduce() which reduces the fraction to its simplest form,
 *  an overrided ToString() method which prints out the fraction as it would look
 *  before it is converted to a decimal, and 4 overloaded operators (+ * <= and >=).
 */

using System;
public class Fraction
{
    private int numerator, denominator;
    // No Parameter Constructor
     public Fraction()
     {
         numerator = 0;
         denominator = 1;
     }
     // Two Parameter Constructor
     public Fraction(int num, int den)
     {
         numerator = num;
         denominator = den;
         Reduce(); // call reduce 
     }
     // Numerator Property
     public int Numerator
     {
         get
         { 
             return numerator; 
         }
         set
         { 
             numerator = value;
             Reduce(); // call reduce 
         }
     }
    // Denominator Property
     public int Denominator
     {
         get
         { 
             return denominator; 
         }
         set
         {
             // ensuring the denominator is not zero
             if (value == 0) 
                 denominator = 1; // setting to 1 if 0
             else
                 denominator = value;
             Reduce(); //call reduce
         }
     }
    //Reduce method
     private void Reduce()
     {
         // checking for input
         if (numerator == 0 | denominator == 1)
         {
             return;
         }

         int reducer = 1;
         int small;

         // set reducer to smaller of two in terms of absolute val
         if (Math.Abs(numerator) <= Math.Abs(denominator))
             small = Math.Abs(numerator);
         else
             small = Math.Abs(denominator);
         // starting from smallest and going to 2 (saving one unneeded iteration)
         for (int i = small; i > 1; i--)
         {
             // if num mod val is 0 and denom mod val is 0, it can evenly divide into both
             if ((numerator % i == 0) && (denominator % i == 0))
             {
                 reducer = i; // set reducer to this val
                 break; // break loop
             }  
         }
         if (reducer != 1) // if a val besides 1 can evenly divide both
         {
             // divide both vals by reducer and assign them back
             denominator = denominator / reducer;
             numerator =numerator / reducer;
         }

     }
     // ToString method
     public override string ToString()
     {
         // return the fraction as an equation

         if (numerator == denominator) // if equal, return whole number (denominator)
             return Convert.ToString(denominator);
         else if (numerator == 0)  // if denominator is 0, return 0
             return Convert.ToString(0);
         else if (denominator == 1) // if denominator is 1, return whole number (numerator)
             return Convert.ToString(numerator);
         else if (denominator == -1) // if denominator is -1, return negative whole number (numerator)
             return "-" + Convert.ToString(numerator);
         else // if both are negative, must convert to postive instead of showing neg val over neg val
             if (numerator < 0 && denominator < 0) 
             {   // return ABSOLUTE val to convert to positive
                 return Convert.ToString(Math.Abs(numerator)) + "/" + Convert.ToString(Math.Abs(denominator)); 
             }
             else
             {   // else, return equation format with string concatenation
                 return Convert.ToString(numerator) + "/" + Convert.ToString(denominator); 
             }
     }
     // Multiply method
     public static Fraction operator *(Fraction fract1, Fraction fract2)
     {
         // multiples two faction objects
         int newNum, newDenom;

         // get new numerator by multiplying numerators of both fractions
         newNum = fract1.Numerator * fract2.Numerator;
         // get new denominator in the way way
         newDenom = fract1.Denominator * fract2.Denominator;

         // make new Fraction object
         Fraction multiFraction = new Fraction(newNum, newDenom);
         // return fraction
         multiFraction.Reduce();
         return multiFraction;

     }
     // Add operator
     public static Fraction operator +(Fraction fract1, Fraction fract2)
     {
         // adds two fraction objects
         int numOne, denomOne, numTwo, denomTwo, resultNum;
         
         // set numerator to prod of fraction 1 num and fraction 2 denom
         numOne= fract1.numerator * fract2.denominator;
         // set denominator to prod of fraction 1 denom and fraction 2 denom
         denomOne = fract1.denominator * fract2.denominator;
         // set numerator to prod of fraction 2 num and fraction 1 denom
         numTwo = fract2.numerator * fract1.denominator;
         // not neccessary:
         denomTwo= fract2.denominator * fract1.denominator;

         // resulting num after adding for final numerator
         resultNum = numOne + numTwo;

         // create new fraction with these parameters
         Fraction commonFrac = new Fraction(resultNum, denomOne);
         // return the fraction
         return commonFrac;

     }
     // Greater Than or Equal operator
     public static bool operator >=(Fraction fract1, Fraction fract2)
     {
         // to compare actual values, making sure one is cast to double 
         double realNumOne = fract1.numerator / (double) fract1.denominator;
         double realNumTwo = fract2.numerator / (double) fract2.denominator;

         // avoiding equality comparision with real numbers for brownie points
         if (realNumOne - realNumTwo > 0.0001 | realNumOne - realNumTwo == 0)
             return true;
         else
             return false;
     }
     // Less Than or Equal operator
     public static bool operator <=(Fraction fract1, Fraction fract2)
     {
         // to compare actual values, making sure one is cast to double 
         double realNumOne = fract1.numerator / (double)fract1.denominator;
         double realNumTwo = fract2.numerator / (double)fract2.denominator;

         // avoiding equality comparision with real numbers for even more brownie points
         if (realNumOne - realNumTwo < -0.0001 | realNumOne - realNumTwo == 0)
             return true;
         else
             return false;
     }
}
