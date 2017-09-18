/*
El problema de las N reinas consiste en situar N reinas en un tablero de ajedrez de N x N sin que se amenacen entre ellas.
*Cosas por considerar:
-Una reina amenaza a otra si esta en la misma fila, la misma columna o en la misma diagonal.
-Solamente N=2 y N=3 no tienen soluciones.


El programa debe aceptar como entrada el valor de N, y debe regresar el numero de soluciones posibles y las soluciones representadas del alguna manera (una matriz con 1’s representando a las reinas, un vector con las posiciones de las reinas,
o cualquier forma que quieras elegir y sea eficiente)

Para probar el numero de soluciones validas aquí esta el resultado esperado para los primeros 10 tamaños:
N = 1 Soluciones posibles 1
N = 2 Soluciones posibles 0
N = 3 Soluciones posibles 0
N = 4 Soluciones posibles 2
N = 5 Soluciones posibles 10
N = 6 Soluciones posibles 4
N = 7 Soluciones posibles 40
N = 8 Soluciones posibles 92
N = 9 Soluciones posibles 352
N = 10 Soluciones posibles 724

Como un tip” Muchas soluciones son solo la rotación o vista espejo de una de las soluciones ya obtenidas, consideren evaluar
de esa manera para hacer mas eficiente el tiempo de respuesta.

Referencias utiles:
-El problema en si es simple, pero si queda alguna duda pueden leer mas detalles aquí https://developers.google.com/optimization/puzzles/queens#setup
Cuidado porque viene una posible solución en python en la sección de Solving N-queens para que tengan cuidado si leen esta
referencia.
-EL problema de las 8 reinas https://en.wikipedia.org/wiki/Eight_queens_puzzle tiene muchos años y es muy famoso, si juegan
ajedrez seguramente han escuchado al respecto.
*/

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
