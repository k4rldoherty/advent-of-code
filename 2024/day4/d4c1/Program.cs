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
			for (int i = 0; i < chars.Count; i++)
			{
				for (int j = 0; j < chars[0].Count; j++)
				{
					char currLetter = chars[i][j];
					if(currLetter.Equals('X'))
					{
						Console.WriteLine($"{currLetter}");
						// Check up, down, left, right, and diagonal ...
					}
				}
			}
			return 0;
		}
	}
}
