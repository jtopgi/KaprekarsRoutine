/*
[2016-10-10] Challenge #287 [Easy] Kaprekar's Routine
Write a function that, given a 4-digit number, returns the largest digit in that number. Numbers between 0 and 999 are counted as 4-digit numbers with leading 0's.
Bonus 1: Write a function that, given a 4-digit number, performs the "descending digits" operation.
Bonus 2: Write a function that counts the number of iterations in Kaprekar's Routine.
Challenge Source: https://www.reddit.com/r/dailyprogrammer/comments/56tbds/20161010_challenge_287_easy_kaprekars_routine/
*/

using System;
using System.Linq;

namespace KaprekarsRoutine
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int routineCounter = 0;

			Console.WriteLine("Please input an integer from 0 to 9999:");
			string inputedInteger = Console.ReadLine();
			try
			{
				int intInputedInteger = Convert.ToInt32(inputedInteger);
				if (intInputedInteger <= 9999 && intInputedInteger >= 0)
				{
					//Find largest digit
					int[] outputSortedValues = SortedValues(FourDigitConverter(inputedInteger));
					Console.WriteLine("The largest digit in the inputed integer is: " + outputSortedValues[0]);

					//Sort digits
					int stringOutputSortedValues = IntArray2Int(outputSortedValues);
					Console.WriteLine("The digits of your number sorted in descending order is: " + stringOutputSortedValues); 

					//Perform Kaprekar's Routine
					int[] outputReversedArray = ReverseArray(SortedValues(FourDigitConverter(inputedInteger)));
					KaprekarsRoutine(outputSortedValues, outputReversedArray, routineCounter);
				}
				else
				{
					Console.WriteLine("The inputed integer is out of bounds, please try again.");
				}
			}
			catch
			{
				Console.WriteLine("Invalid Integer.");
			}

		}

		// Pads the inputed integer so that it will have four decimal places
		private static string FourDigitConverter(string inputFourDigitConverter)
		{
			string outputFourDigitConverter = inputFourDigitConverter.PadLeft(4, '0');
			return outputFourDigitConverter;
		}

		// Detect integers in string and sorts ascendingly 
		private static int[] SortedValues(string inputSortedValues)
		{
			int[] intarrayOfInputSortedValues = inputSortedValues.Select(c => c - '0').ToArray(); //Creates an int array of the inputed string
			Array.Sort(intarrayOfInputSortedValues);
			Array.Reverse(intarrayOfInputSortedValues);
			int[] outputSortedValues = intarrayOfInputSortedValues;
			return outputSortedValues;
		}

		// Reverses order of input array
		private static int[] ReverseArray(int[] inputReverseArray)
		{
			Array.Reverse(inputReverseArray);
			int[] outputReverseArray = inputReverseArray;
			return outputReverseArray;
		}

		// Convert int array to integer
		private static int IntArray2Int(int[] inputIntArray2Int)
		{
			string stringInputIntArray2Int = string.Join("", inputIntArray2Int);
			int outputInputArray2Int = Convert.ToInt32(stringInputIntArray2Int);
			return outputInputArray2Int;
		}

		// Kaprekar's Routine
		private static void KaprekarsRoutine(int[] input1KaprekarsRoutine, int[] input2KaprekarsRoutine, int routineCounter)
		{
			int intInput1KaprekarsRoutine = IntArray2Int(input1KaprekarsRoutine);
			int intInput2KaprekarsRoutine = IntArray2Int(input2KaprekarsRoutine);

			int subtractionKaprekarsRoutine = intInput1KaprekarsRoutine - intInput2KaprekarsRoutine;

			int kRoutineCounter = routineCounter;

			if (subtractionKaprekarsRoutine != 6174 && subtractionKaprekarsRoutine != 0)
			{
				int[] ifOutput1KaprekarsRoutine = SortedValues(FourDigitConverter(Convert.ToString(subtractionKaprekarsRoutine)));
				int[] ifOutput2KaprekarsRoutine = ReverseArray(SortedValues(FourDigitConverter(Convert.ToString(subtractionKaprekarsRoutine))));
				kRoutineCounter++;
				KaprekarsRoutine(ifOutput1KaprekarsRoutine, ifOutput2KaprekarsRoutine,kRoutineCounter);
			}
			else if (subtractionKaprekarsRoutine == 0)
			{
				Console.WriteLine("The Kaprekar's Routine is: " + kRoutineCounter);
			}
			else
			{
				Console.WriteLine("The Kaprekar's Routine is: " + kRoutineCounter);
			}
		}

	}
}
