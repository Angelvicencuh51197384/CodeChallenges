using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandProblem
{
	public class InslandsProblem
	{
		public int Islands(int[][] matrix)
		{
			int islands = 0;

			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[i].Length; j++)
				{
					if (matrix[i][j] == 1)
					{
						matrix[i][j] = 0;
						DiscoverOthers(matrix, i, j);
						islands++;
					}
				}
			}

			return islands;
		}

		private static void DiscoverOthers(int[][] matrix, int i, int j)
		{
			Review(matrix, i, j + 1);
			Review(matrix, i + 1, j);
			Review(matrix, i, j - 1);
			Review(matrix, i - 1, j);
		}

		private static void Review(int[][] matrix, int y, int x)
		{
			if (y >= 0 && y < matrix.Length && x >= 0 && x < matrix[y].Length && matrix[y][x] == 1)
			{
				matrix[y][x] = 0;
				DiscoverOthers(matrix, y, x);
			}
		}
	}
}
