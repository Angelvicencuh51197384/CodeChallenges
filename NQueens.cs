using System;

namespace aa
{


	public class Queens
	{
		readonly int[] x;

		public Queens(int N)
		{
			x = new int[N];
		}

		public bool IsPossibleToPlace(int row, int column)
		{
			for (int i = 0; i < row; i++)
			{
				if (x[i] == column || (i - row) == (x[i] - column) || (i - row) == (column - x[i]))
				{
					return false;
				}
			}
			return true;
		}

		public void Print(int[] x)
		{
			int N = x.Length;
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (x[i] == j)
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
			/**
			 * Using backtracking this method prints all possible placements of n
			 * queens on an n x n chessboard so that they are non-attacking.
			 */
			for (int c = 0; c < n; c++)
			{
				if (IsPossibleToPlace(r, c))
				{
					x[r] = c;
					if (r == n - 1)
					{
						Print(x);
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
			PlaceQueen(0, x.Length);
		}

		static void Main(string[] args)
		{
			Queens Q = new Queens(4);
			Q.GetSolution();
			Console.ReadLine();
		}
	}
}
