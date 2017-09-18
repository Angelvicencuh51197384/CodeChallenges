/* Write a function `int islands(matrix of ints)` that identifies islands in a matrix.
An island is a set of true values linked vertically or horizontally.
Note: true values can *NOT* be linked diagonally.
i.e.
1,0,0
1,1,1
1,0,1
returns 1 island
as
1,
1,1,1
1, ,1 represents one island
Test cases:
input:
1,0,1,1,0
0,1,0,1,0
1,0,0,0,0
0,0,1,1,1
islands = 5
input:
1,0,1
0,1,0
1,0,1
islands = 5
input:
0,1,1
0,1,0
1,1,0
islands = 1
input:
0,0,1,1,0
1,1,0,1,0
1,1,0,1,0
0,0,1,1,1
0,1,1,0,0
islands = 2

int islands(int[][] matrix) {
return -1;
}
*/


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
