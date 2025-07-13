using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN FOR MultiplesOf FUNCTION (10/10 points):
        // Step 1: Create an empty array of size 'length'.
        // Step 2: Use a for loop from i = 0 to i < length.
        // Step 3: On each iteration, calculate number * (i + 1) to get the next multiple.
        // Step 4: Store that result at index i in the array.
        // Step 5: After the loop, return the filled array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN FOR RotateListRight FUNCTION (10/10 points):
        // Step 1: Determine how many items should be moved — the last 'amount' elements of the list.
        // Step 2: Use GetRange to extract that portion from the end of the list.
        // Step 3: Use GetRange again to extract the beginning portion of the list (everything before that).
        // Step 4: Clear the original list since we will rebuild it in the rotated order.
        // Step 5: First add the end portion (rotated to the front), then add the start portion (shifted to the back).

        int length = data.Count;

        List<int> endPart = data.GetRange(length - amount, amount); // Rightmost elements to move to front
        List<int> startPart = data.GetRange(0, length - amount);    // Remaining elements

        data.Clear();                      // Clear original list
        data.AddRange(endPart);           // Add rotated right part
        data.AddRange(startPart);         // Then add the rest
    }
}
