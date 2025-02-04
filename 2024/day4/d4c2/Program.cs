// See https://aka.ms/new-console-template for more information
using System;

namespace d4c2
{
	class Program
	{
		public static void Main(string[] args)
		{
			string FilePath = string.Empty;
			if (args.Length == 0) FilePath = "../testinput.txt";
			else
			{
				if (args[0].ToString().Equals("-s")) FilePath = "../input.txt";
				else
				{
					Console.WriteLine("USEAGE: dotnet run {-s}");
					return;
				}
			}
			List<List<char>> chars = ProcessInput(FilePath);
			int Result = CountOccurances(chars);
			Console.WriteLine(Result);
		}

		public static List<List<char>> ProcessInput(string inputfile)
		{
			List<List<char>> letters = new();
			String? line;
			StreamReader sr = new(inputfile);
			while ((line = sr.ReadLine()) != null)
			{
				List<char> chars = line.ToList();
				letters.Add(chars);
			}
			sr.Close();
			return letters;
		}

		public static int CountOccurances(List<List<char>> chars)
		{
			// for every letter there can be 8 directions up, down, right, left, and diagonal up left ..brute force is to try all of them but theres definetely a better way
			var occurances = 0;
			for (int r = 1; r < chars.Count - 1; r++)
			{
				for (int c = 1; c < chars[0].Count - 1; c++)
				{
					char currLetter = chars[r][c];
					if(!currLetter.Equals('A')) continue;
					occurances += CountXMasses(chars, r, c);
				}
			}
			return occurances;
		}

		public static int CountXMasses(List<List<char>> chars, int row, int col)
		{
			// Check each direction to ensure 
			var topLeft = chars[row-1][col-1];
			var topRight = chars[row-1][col+1];
			var bottomLeft = chars[row+1][col-1];
			var bottomRight = chars[row+1][col+1];

			if(
					((topLeft == 'M' && bottomRight == 'S')
					&&
					(bottomLeft == 'M' && topRight == 'S'))
					||
					((topLeft == 'S' && bottomRight == 'M')
					&&
					(bottomLeft == 'S' && topRight == 'M'))
					||
					((topLeft == 'M' && bottomRight == 'S')
					&&
					(bottomLeft == 'S' && topRight == 'M'))
					||
					((topLeft == 'S' && bottomRight == 'M')
					&&
					(bottomLeft == 'M' && topRight == 'S'))
			  ) return 1;
			return 0;
		}
	}
}
