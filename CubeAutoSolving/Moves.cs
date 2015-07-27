using System;
using System.Collections.Generic;
using System.Reflection;

namespace CubeAutoSolving
{
	static class Moves 
	{
		// Инициализация массива
		public static char[][,] cube = new char[6][,]
		{
			new char[3,3],
			new char[3,3],
			new char[3,3],
			new char[3,3],
			new char[3,3],
			new char[3,3]
		};
		
		public static void ResetCube()
		{
			// Одномерный массив чаров для инициализации массива куба
			char[] colors = new char[6]
			{
				'y',
				'r', 
				'g',
				'o', 
				'b', 
				'w' 
			};

			// Заполнения куба начальными данными
			for (int k = 0; k < 6; k++)
				for (int i = 0; i < 3; i++)
					for (int j = 0; j < 3; j++)
						cube[k][i, j] = colors[k];
		}

		public static string ScrambleCube()
		{
			Random random = new Random();
			string[][] moves = 
			{
				new string[] { "R", "R'", "R2" },
				new string[] { "U", "U'", "U2" },
				new string[] { "F", "F'", "F2" },
				new string[] { "L", "L'", "L2" },
				new string[] { "D", "D'", "D2" },
				new string[] { "B", "B'", "B2" }
			};
			string formula = "", scramble = "";
			int newRandom = 0, group = 0, move = 0, reverse = 0;

			for (int i = 0; i < 20; i++)
			{
				do
					newRandom = random.Next(0, 6);
				while (newRandom == group);

                group = newRandom;
				move = random.Next(0, 3);
                formula += moves[group][move] + " ";
				}
			formula = formula.Trim();
			DoMovesByFormula(formula);

			return ConvertScramble(formula);
		}

		public static string ConvertScramble(string scramble)
		{
			return scramble.Replace('R', 'L').Replace('U', 'D').Replace('L', 'R').Replace('D', 'U');
		}

		private static string[] FormulaToMoves(string formula)
		{
			List<string> moves = new List<string>();
			string move = "";
			string[] array = formula.Split(' ');
            foreach (string element in array)
			{
				if (element.EndsWith("2"))
				{
					move = element.Replace("2", "");
					moves.Add(move);
				}
				else if (element.EndsWith("'"))
					move = element.Replace("'", "i");
				else
					move = element;

				moves.Add(move);
			}

			return moves.ToArray();
		}
		
		// Вызов методов по строковой формуле (рефлексия)
		public static void DoMovesByFormula(string formula) 
		{
			string[] moves = FormulaToMoves(formula);
			foreach (string move in moves)
			{
				MethodInfo moveMethod = typeof(Moves).GetMethod(move);
				moveMethod.Invoke(null, null);
			}
		}

		//   Методы для движения граней
		#region Повороты

		//  Стандартные движения
		// Поворот задней грани по часовой стрелки
		public static void U()
		{
			// Вызов мтетода для внутренних блоков
			DoMoveInside(
				0, // Сторона
				true // Поворот по/против часовой стрелки (true/false)
			); 
			// Вызов метода для внешних блоков
			DoMoveOutside(
				new int[]
				{
					2, // Сторона 1 для внешнего поворота
					3, // Сторона 2 для внешнего поворота
					4, // Сторона 3 для внешнего поворота
					1  // Сторона 4 для внешнего поворота
				}, // Одномерный массив для передачи адресов сторон
				new int[] // 8 элементов
				{
					0, 0,
					0, 0,
					0, 0,
					0, 0
				}, // Одномерный массив для: фиксирования адреса / обратной последовательности адреса
				new bool[] // 8 элементов
				{ 
					false, true,
					false, true,
					false, true,
					false, true
				} // Одномерный bool-массив для инициализации массива ликвидации последовательности
			);
		}

		// Поворот задней грани против часовой стрелки
		public static void Ui()
		{
			DoMoveInside(
				0,
				false
			);
			DoMoveOutside(
				new int[]
				{
					2, 
					1, 
					4, 
					3
				},
				new int[]
				{
					0, 0,
					0, 0,
					0, 0,
					0, 0
				},
				new bool[] 
				{ 
					false, true,
					false, true,
					false, true,
					false, true
				}
			);
		}

		// Поворот левой грани по часовой стрелке
		public static void L()
		{
			DoMoveInside(
				1,
				true
			);
			DoMoveOutside(
				new int[]
				{
					5,
					2,
					0,
					4
				},
				new int[] 
				{
					0, 2,
					0, 2,
					0, 2,
					2, 0
				},
				new bool[]
				{
					true, false,
					true, false,
					true, false,
					true, false
				}
			);
		}

		// Поворот левой грани против часовой стрелки
		public static void Li()
		{
			DoMoveInside(
				1,
				false
			);
			DoMoveOutside(
				new int[]
				{
					5,
					4,
					0,
					2
				},
				new int[]
				{
					0, 2,
					2, 0,
					0, 2,
					0, 2
				},
				new bool[]
				{
					true, false,
					true, false,
					true, false,
					true, false
				}
			);
		}

		// Поворот верхней грани по часовой стрелке
		public static void F()
		{
			DoMoveInside(
				2,
				true
			);
			DoMoveOutside(
				new int[]
				{
					5, 
					3, 
					0, 
					1
				},
				new int[]
				{
					0, 0,
					0, 2,
					2, 2,
					2, 0
				},
				new bool[] 
				{ 
					false, true,
					true, false,
					false, true,
					true, false
				}
			);
		}

		// Поворот верхней грани против часовой стрелки 
		public static void Fi()
		{
			DoMoveInside(
				2,
				false
			);
			DoMoveOutside(
				new int[]
				{
					5,
					1, 
					0, 
					3
				},
				new int[]
				{
					0, 0,
					2, 0,
					2, 2,
					0, 2
				},
				new bool[] 
				{ 
					false, true,
					true, false,
					false, true,
					true, false
				}
			);
		}

		// Поворот правой грани по часовой стрелке		
		public static void R()
		{
			DoMoveInside(
				3,
				true
			);
			DoMoveOutside(				
				new int[]
				{				   
					5,
					4, 
					0, 
					2				 
				}, 
				new int[] 
				{
					2, 0,
					0, 2,
					2, 0,
					2, 0
				},
				new bool[]
				{
					true, false,
					true, false,
					true, false,
					true, false
				}
			);
		}

		// Поворот правой грани против часовой стрелки
		public static void Ri()
		{
			DoMoveInside(
				3,
				false
			);
			DoMoveOutside(				
				new int[] 
				{
					5,
					2,
					0, 
					4
				},
				new int[]
				{
					2, 0,
					2, 0,
					2, 0,
					0, 2
				},
				new bool[] 
				{ 
					true, false,
					true, false,
					true, false,
					true, false
				}
			);
		}

		// Поворот нижней грани по часовой стрелки
		public static void B()
		{
			DoMoveInside(
				4,
				true
			);
			DoMoveOutside(
				new int[]
				{
					5,
					1, 
					0, 
					3
				},
				new int[]
				{
					2, 2,
					0, 2,
					0, 0,
					2, 0
				},
				new bool[] 
				{ 
					false, true,
					true, false,
					false, true,
					true, false
				}
			);
		}

		// Поворот нижней грани против часовой стрелки
		public static void Bi()
		{
			DoMoveInside(
				4,
				false
			);
			DoMoveOutside(
				new int[]
				{
					5,
					3,
					0, 
					1
				},
				new int[]
				{
					2, 2,
					2, 0,
					0, 0,
					0, 2
				},
				new bool[] 
				{ 
					false, true,
					true, false,
					false, true,
					true, false
				}
			);
		}

		// Поворот фронтовой грани по часовой стрелки
		public static void D()
		{
			DoMoveInside(
				5,
				true
			);
			DoMoveOutside(
				new int[]
				{
					4,
					3,
					2, 
					1
				},
				new int[]
				{
					2, 2,
					2, 2,
					2, 2,
					2, 2
				},
				new bool[] 
				{ 
					false, true,
					false, true,
					false, true,
					false, true
				}
			);
		}

		// Поворот фронтовой грани против часовой стрелки
		public static void Di()
		{
			DoMoveInside(
				5,
				false
			);
			DoMoveOutside(
				new int[]
				{
					4, 
					1, 
					2, 
					3
				},
				new int[]
				{
					2, 2,
					2, 2,
					2, 2,
					2, 2
				},
				new bool[] 
				{ 
					false, true,
					false, true,				
					false, true,
					false, true
				}
			);
		}
		
		//   Нестандартные движения
		//  Повороты центральных слоев
		// Движение центральной стороны относительно левой стороны по часовой стрелке
		public static void M()
		{
			DoMoveOutside(
				new int[]
				{
					4,
					5,
					2,
					0
				},
				new int[]
				{
					1, 0,
					1, 2,
					1, 2,
					1, 2
				},
				new bool[] 
				{ 
					true, false,
					true, false,
					true, false,
					true, false
				}
			);
		}

		// Движение центральной стороны относительно левой стороны против часовой стрелки
		public static void Mi()
		{
			DoMoveOutside(
				new int[]
				{
					4,
					0,
					2,
					5
				},
				new int[]
				{
					1, 0,
					1, 2,
					1, 2,
					1, 2
				},
				new bool[] 
				{ 
					true, false,
					true, false,
					true, false,
					true, false
				}
			);
		}

		// Движение центральной стороны относительно фронтальной стороны по часовой стрелке
		public static void E()
		{
			DoMoveOutside(
				new int[]
				{
					4,
					3,
					2,
					1
				},
				new int[]
				{
					0, 1,
					0, 1,
					0, 1,
					0, 1
				},
				new bool[] 
				{ 
					false, true,
					false, true,
					false, true,
					false, true
				}
			);
		}

		// Движение центральной стороны относительно фронтальной стороны против часовой стрелки
		public static void Ei()
		{
			DoMoveOutside(
				new int[]
				{
					4,
					1,
					2,
					3
				},
				new int[]
				{
					0, 1,
					0, 1,
					0, 1,
					0, 1
				},
				new bool[] 
				{ 
					false, true,
					false, true,
					false, true,
					false, true
				}
			);
		}

		// Движение центральной стороны относительно нижней стороны по часовой стрелке
		public static void S()
		{
			DoMoveOutside(
				new int[]
				{
					5,
					1,
					0,
					3
				},
				new int[]
				{
					0, 1,
					1, 0,
					0, 1,
					1, 0
				},
				new bool[] 
				{ 
					false, true,
					true, false,
					false, true,
					true, false
				}
			);
		}

		// Движение центральной стороны относительно нижней стороны против часовой стрелки
		public static void Si()
		{
			DoMoveOutside(
				new int[]
				{
					5,
					3,
					0,
					1
				},
				new int[]
				{
					0, 1,
					1, 0,
					0, 1,
					1, 0
				},
				new bool[] 
				{ 
					false, true,
					true, false,
					false, true,
					true, false
				}
			);
		}

		// Поворот + буква 'w'
		// Поворот правой стороны + среднего слоя по часовой стрелке
		public static void Rw()
		{
			R();
			Mi();
		}

		// Поворот правой стороны + среднего слоя против часовой стрелки
		public static void Rwi()
		{
			Ri();
			M();
		}

		// Поворот левой стороны + среднего слоя по часовой стрелке
		public static void Lw()
		{
			L();
			M();
		}

		// Поворот левой стороны + среднего слоя против часовой стрелки
		public static void Lwi()
		{
			Li();
			Mi();
		}

		// Поворот фронтовой стороны + среднего слоя по часовой стрелке
		public static void Fw()
		{
			F();
			S();
		}

		// Поворот фронтовой стороны + среднего слоя против часовой стрелки
		public static void Fwi()
		{
			Fi();
			Si();
		}

		// Поворот задней стороны + среднего слоя по часовой стрелке
		public static void Bw()
		{
			B();
			Si();
		}

		// Поворот задней стороны + среднего слоя против часовой стрелки
		public static void Bwi()
		{
			Bi();
			S();
		}

		// Поворот верхней стороны + среднего слоя по часовой стрелке
		public static void Uw()
		{
			U();
			Ei();
		}

		// Поворот верхней стороны + среднего слоя против часовой стрелки
		public static void Uwi()
		{
			Ui();
			E();
		}

		// Поворот нижней стороны + среднего слоя по часовой стрелке
		public static void Dw()
		{
			D();
			E();
		}

		// Поворот нижней стороны + среднего слоя против часовой стрелки
		public static void Dwi()
		{
			Di();
			Ei();
		}

		//  Повороты всего куба
		// Поворот куба относительно правой стороны по часовой стрелке
		public static void x()
		{
			R();
			Mi();
			Li();
		}

		// Поворот куба относительно правой стороны против часовой стрелки
		public static void xi()
		{
			Ri();
			M();
			L();
		}

		// Поворот куба относительно верхней стороны по часовой стрелке
		public static void y()
		{
			U();
			Ei();
			Di();
		}

		// Поворот куба относительно верхней стороны против часовой стрелки
		public static void yi()
		{
			Ui();
			E();
			D();
		}

		// Поворот куба относительно фронтальной стороны по часовой стрелке
		public static void z()
		{
			F();
			S();
			Bi();
		}

		// Поворот куба относительно фронтальной стороны против часовой стрелки
		public static void zi()
		{
			Fi();
			Si();
			B();
		}
		
		#endregion

		// Универсальный метод для поворота блоков грани
		private static void DoMoveOutside(int[] cubeFace, int[] fixedNumber, bool[] isFixed)
		{
			// Одномерный массив для ликвидация последовательности в формуле внутренних блоков
			int[] delta = new int[8];
			// Переменная для свапа элементов char
			char cache;
			// Поворот внешних блоков
			for (int k = 0; k < 3; k++)
			{
				// Определение фиксирования
				for (int i = 0; i < 8; i++)
					delta[i] = (isFixed[i] ? k : 0);

				// cache = cube[0]
				cache =  cube[cubeFace[0]]
				[
					Math.Abs(fixedNumber[0] - k + delta[0]),
					Math.Abs(fixedNumber[1] - k + delta[1])
				];
				// cube[0] = cube[1]						
				cube[cubeFace[0]]
				[
					Math.Abs(fixedNumber[0] - k + delta[0]),					 
					Math.Abs(fixedNumber[1] - k + delta[1])
				] = cube[cubeFace[1]]
				[
					Math.Abs(fixedNumber[2] - k + delta[2]),
					Math.Abs(fixedNumber[3] - k + delta[3])
				];
				// cube[1] = cube[2]
				cube[cubeFace[1]]
				[
					Math.Abs(fixedNumber[2] - k + delta[2]),
					Math.Abs(fixedNumber[3] - k + delta[3])
				] = cube[cubeFace[2]]
				[
					Math.Abs(fixedNumber[4] - k + delta[4]),
					Math.Abs(fixedNumber[5] - k + delta[5])
				];
				// cube[2] = cube[3]
				cube[cubeFace[2]]
				[
					Math.Abs(fixedNumber[4] - k + delta[4]),
					Math.Abs(fixedNumber[5] - k + delta[5])
				] = cube[cubeFace[3]]
				[
					Math.Abs(fixedNumber[6] - k + delta[6]),
					Math.Abs(fixedNumber[7] - k + delta[7])
				];
				// cube[3] = cache
				cube[cubeFace[3]]
				[
					Math.Abs(fixedNumber[6] - k + delta[6]),
					Math.Abs(fixedNumber[7] - k + delta[7])
				] = cache;
			}
		}

		private static void DoMoveInside(int edge, bool invert)
		{
			// Определение, в какую сторону прокручивать внутренние блоки			
			int invertOne = (invert ? 0 : 2); // По часовой
			int invertTwo = (invert ? 2 : 0); // Против часовой
			 // Переменная для свапа элементов char
			char cache;

			// Поворот внутренних блоков
			for (int i = 0; i < 2; i++)
			{
				cache = 
					cube[edge][i,0];
				cube[edge][i,0] = 
					cube[edge]
				[
					invertOne, 
					Math.Abs(invertTwo - i)
				];
				cube[edge]
				[
					invertOne, 
					Math.Abs(invertTwo - i)
				] = cube[edge]
				[
					2 - i,
					2
				];
				cube[edge]
				[
					2 - i,
					2
				] = cube[edge]
				[
					invertTwo,
					Math.Abs(invertOne - i)
				];
				cube[edge]
				[
					invertTwo,
					Math.Abs(invertOne - i)
				] = cache;
			}
		}
	}
}