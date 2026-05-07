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

        // PLAN:
        // Step 1: Create an empty array of type double with size equal to 'length'.
        //         This array will hold all the multiples we calculate.
        // Step 2: Use a loop that runs 'length' times (from index 0 to length-1).
        //         Each position i in the array represents the (i+1)-th multiple.
        // Step 3: At each iteration i, calculate the multiple as: number * (i + 1)
        //         For example, if number=7: index 0 → 7*1=7, index 1 → 7*2=14, etc.
        // Step 4: Store the result in array[i].
        // Step 5: After the loop, return the completed array.

        double[] result = new double[length]; // Step 1: create the array with the correct size

        for (int i = 0; i < length; i++) // Step 2: loop through each position
        {
            result[i] = number * (i + 1); // Step 3 & 4: calculate and store the multiple
        }

        return result; // Step 5: return the filled array
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

        // PLAN:
        // Step 1: Calculate the 'splitIndex', which is where we cut the list.
        //         splitIndex = data.Count - amount
        //         Example: list has 9 elements, amount=3 → splitIndex = 9-3 = 6
        //         This means: the last 3 elements will move to the front.
        // Step 2: Use GetRange(splitIndex, amount) to extract the LAST 'amount' elements.
        //         These are the elements that will move to the beginning.
        //         Example: {1,2,3,4,5,6,7,8,9} → lastPart = {7,8,9}
        // Step 3: Use GetRange(0, splitIndex) to extract the FIRST part of the list.
        //         These are the elements that will move to the end.
        //         Example: firstPart = {1,2,3,4,5,6}
        // Step 4: Clear the original list so we can rebuild it in the new order.
        // Step 5: Add lastPart first (using AddRange), then firstPart after.
        //         Result: {7,8,9,1,2,3,4,5,6}

        int splitIndex = data.Count - amount; // Step 1: find the cut point

        List<int> lastPart = data.GetRange(splitIndex, amount); // Step 2: extract last elements
        List<int> firstPart = data.GetRange(0, splitIndex);     // Step 3: extract first elements

        data.Clear();              // Step 4: empty the original list
        data.AddRange(lastPart);   // Step 5a: add the last part first
        data.AddRange(firstPart);  // Step 5b: then add the first part
    

    }
}
