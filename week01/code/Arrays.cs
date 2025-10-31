public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create an empty array to store numbers.
        double[] multiples = new double[length];

        // Assign a variable L that tracks the number of items added to the array and index with an initial value of 0.
        int index = 0;
        // Use a for loop that starts with a i variable equals to 1, a conditional index<=length-1, and i++ incrementor.
        for (double i = 1;  index <= length-1; i++ )
        {
            // Add a conditional if statement to check if the number is an integer number. If so, execute code inside the conditional if statement. If not, use an else statement.  
            if (number % 1 == 0)
            {
                // Add a conditional if statement that evalutes i%number == 0, being number the starting number. If the evaluation is true, add the number i to the array and increase index by 1. 
                if (i % number == 0)
                {
                    multiples[index] = i;
                    index++;
                }
            }
            else
            {
                // Add a conditional if statement that evalutes i/10 %number == 0, being number the starting number. If the evaluation is true, add the number i/10 to the array and increase index by 1. 
                if (i / 10 % number == 0)
                {
                    multiples[index] = i/10;
                    index++;                    
                }
            }
            
            
        }        
        // When the condition of the loop is met it stops and the array is returned.

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // SOLUTION

        // Use a foreach loop to loop through each item.



        // foreach (int i in data)
        // {
        //     // If the item index is less than amount+1 will be sent to the next to the last index of the dynamic array.
        //     if (data.IndexOf(i) < amount + 1)
        //     {
        //         data.Add(i);
        //     }
        // }

        // Use a foreach loop to loop through each item again.
        // foreach (int i in data)
        // {
        //     // If the item index is less than amount+1 will be erased.
        //     if (data.IndexOf(i) < amount + 1)
        //     {
        //         data.Remove(i);
        //     }            
        // }
        // Use a for loop that use an integer variable i with an initial valuo of cero, ends when the condiditon i<number doesn't meet, and has a i++incrementor.

        for (int i = 0; i < amount; i++)
        {
            // Add a number equals to the last number of the arraty in the beggining.
            data.Insert(0, data[data.Count - 1]);
            // Assign a variable that stores the last index of the array
            int lastIndex = data.Count - 1;
            // Remove the last item of the array.
            data.RemoveAt(lastIndex);
        }
        
        

    }
}
