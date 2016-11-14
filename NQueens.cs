using System;

namespace aa
{


	public class Board
	{
		readonly int[] boardLine;

		public Board(int n)
		{
			boardLine = new int[n];
		}

		public bool IsPossibleToPlace(int row, int column)
		{
			for (var i = 0; i < row; i++)
			{
				if (boardLine[i] == column || (i - row) == (boardLine[i] - column) || (i - row) == (column - boardLine[i]))
				{
					return false;
				}
			}
			return true;
		}

		public void Print(int[] boardLine)
		{
			var n = boardLine.Length;
			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < n; j++)
				{
					if (boardLine[i] == j)
					{
						Console.Write(" * ");
					}
					else
					{
						Console.Write(" _ ");
					}
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		public void PlaceQueen(int r, int n)
		{
			for (var c = 0; c < n; c++)
			{
				if (IsPossibleToPlace(r, c))
				{
					boardLine[r] = c;
					if (r == n - 1)
					{
						Print(boardLine);
					}
					else
					{
						PlaceQueen(r + 1, n);
					}
				}
			}
		}

		public void GetSolution()
		{
			PlaceQueen(0, boardLine.Length);
		}

		private static void Main(string[] args)
		{
			var queen = new Board(4);
			queen.GetSolution();
			Console.ReadLine();
		}
	}
}
