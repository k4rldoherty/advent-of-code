// See https://aka.ms/new-console-template for more information
using System;

namespace d4c1
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
			for (int r = 0; r < chars.Count; r++)
			{
				for (int c = 0; c < chars[0].Count; c++)
				{
					char currLetter = chars[r][c];
					if(!currLetter.Equals('X')) continue;
					if(r-3 >= 0) occurances += CountUp(chars, r, c);
					if(r+3 < chars.Count) occurances += CountDown(chars, r, c);
					if(c-3 >= 0) occurances += CountLeft(chars, r, c);
					if(c+3 < chars[0].Count) occurances += CountRight(chars, r, c);
					// Diagonal
					if(r-3 >= 0 && c-3 >= 0) occurances += CountDiagUpLeft(chars, r, c);
					if(r-3 >= 0 && c+3 < chars[0].Count) occurances += CountDiagUpRight(chars, r, c);
					if(r+3 < chars.Count && c+3 < chars[0].Count) occurances += CountDiagDownRight(chars, r, c);
					if(r+3 < chars.Count && c-3 >= 0) occurances += CountDiagDownLeft(chars, r, c);
				}
			}
			return occurances;
		}

		public static int CountUp(List<List<char>> chars, int row, int col)
		{
			if(!chars[row-1][col].Equals('M')) return 0;
			if(!chars[row-2][col].Equals('A')) return 0;
			if(!chars[row-3][col].Equals('S')) return 0;
			return 1;
		}
		public static int CountDown(List<List<char>> chars, int row, int col)
		{
			if(!chars[row+1][col].Equals('M')) return 0;
			if(!chars[row+2][col].Equals('A')) return 0;
			if(!chars[row+3][col].Equals('S')) return 0;
			return 1;
		}
		public static int CountRight(List<List<char>> chars, int row, int col)
		{
			if(!chars[row][col+1].Equals('M')) return 0;
			if(!chars[row][col+2].Equals('A')) return 0;
			if(!chars[row][col+3].Equals('S')) return 0;
			return 1;
		}
		public static int CountLeft(List<List<char>> chars, int row, int col)
		{
			if(!chars[row][col-1].Equals('M')) return 0;
			if(!chars[row][col-2].Equals('A')) return 0;
			if(!chars[row][col-3].Equals('S')) return 0;
			return 1;
		}
		public static int CountDiagUpRight(List<List<char>> chars, int row, int col)
		{
			if(!chars[row-1][col+1].Equals('M')) return 0;
			if(!chars[row-2][col+2].Equals('A')) return 0;
			if(!chars[row-3][col+3].Equals('S')) return 0;
			return 1;
		}
		public static int CountDiagUpLeft(List<List<char>> chars, int row, int col)
		{
			if(!chars[row-1][col-1].Equals('M')) return 0;
			if(!chars[row-2][col-2].Equals('A')) return 0;
			if(!chars[row-3][col-3].Equals('S')) return 0;
			return 1;
		}
		public static int CountDiagDownRight(List<List<char>> chars, int row, int col)
		{
			if(!chars[row+1][col+1].Equals('M')) return 0;
			if(!chars[row+2][col+2].Equals('A')) return 0;
			if(!chars[row+3][col+3].Equals('S')) return 0;
			return 1;
		}
		public static int CountDiagDownLeft(List<List<char>> chars, int row, int col)
		{
			if(!chars[row+1][col-1].Equals('M')) return 0;
			if(!chars[row+2][col-2].Equals('A')) return 0;
			if(!chars[row+3][col-3].Equals('S')) return 0;
			return 1;
		}
	}
}
