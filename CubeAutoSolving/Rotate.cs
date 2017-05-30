using System;
using System.Collections.Generic;
using System.Reflection;

namespace RubiksAutoSolve
{
	static class Rotate 
	{
        private const int movesCount = 24;
        private const int edgesCount = 6;

		// Инициализация массива
		public static string[][,] cube = new string[edgesCount][,]
		{
			new string[3,3],
			new string[3,3],
			new string[3,3],
			new string[3,3],
			new string[3,3],
			new string[3,3]
		};



        /// <summary>
        /// Возвращает куб в собранное положение
        /// </summary>
		public static void ResetCube()
		{
			string[] colors = new string[edgesCount]
			{
				"y",
				"r",
				"g",
				"o",
				"b",
				"w"
			};

			for (int k = 0; k < edgesCount; k++)
			{
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						cube[k][i, j] = colors[k];
					}
				}
			}
		}

        /// <summary>
        /// Генерирует рандомный скрамбл и сразу же выполняет его
        /// </summary>
        /// <returns>Строку с сгенерированной формулой</returns>
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
			string[] scramble = new string[20];
            string formula;
            int newRandom = 0;
            int group = 0;
            int move = 0;

			for (int i = 0; i < 20; i++)
			{
				do
				{
					newRandom = random.Next(0, 6);
				}
				while (newRandom == group);

                group = newRandom;
				move = random.Next(0, 3);
                scramble[i] = moves[group][move];
			}

			formula = string.Join(" ", scramble);
			DoMovesByFormula(formula);

			return ConvertScramble(formula);
		}

        /// <summary>
        /// Отзеркаливает скрамбл
        /// </summary>
        /// <param name="scramble">Строка с сгенерированным скрамблом</param>
        /// <returns>Отзеркаленый скрамбл</returns>
		public static string ConvertScramble(string scramble)
		{
			string[] moves = scramble.Split(' ');

			for (int i = 0; i < moves.Length; i += 2)
			{
				switch (moves[i][0])
				{
					case 'R':
						moves[i].Replace('R', 'L');
						break;
					case 'U':
						moves[i].Replace('U', 'B');
						break;
					case 'L':
						moves[i].Replace('L', 'R');
						break;
					case 'B':
						moves[i].Replace('B', 'U');
						break;
				}
			}

			return string.Join(" ", moves);
		}

        /// <summary>
        /// Переводит формулу в массив вращений
        /// </summary>
        /// <param name="formula">Строка с формулой</param>
        /// <returns>Массив вращений</returns>
		private static string[] FormulaToMoves(string formula)
		{
			List<string> moves = new List<string>();
			string move = "";
			string[] array = formula.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in array)
			{
				if (element.EndsWith("2"))
				{
					move = element.Replace("2", "");
					moves.Add(move);
				}
				else if (element.EndsWith("'"))
				{
					move = element.Replace("'", "i");
				}
				else
				{
					move = element;
				}

				moves.Add(move);
			}

			return moves.ToArray();
		}

        /// <summary>
        /// Вызывает функции вращения граней по их названию
        /// </summary>
        /// <param name="formula">Строка с формулой</param>
        public static void DoMovesByFormula(string formula) 
		{
			string[] moves = FormulaToMoves(formula);

			foreach (string move in moves)
			{
				MethodInfo moveMethod = typeof(Rotate).GetMethod(move, new Type[] { });
				moveMethod.Invoke(null, null);
			}
		}

        /// <summary>
        /// Вызывает функции вращения граней по их названию
        /// </summary>
        /// <param name="formula">Строка с формулой</param>
        public static void DoMovesByFormula(string formula, ref string[][,] cube)
        {
            string[] moves = FormulaToMoves(formula);

            foreach (string move in moves)
            {
                MethodInfo moveMethod = typeof(Rotate).GetMethod(move, new Type[] { typeof(string[][,]).MakeByRefType() });
                moveMethod.Invoke(null, new object[] { cube });
            }
        }

        // Методы для движения граней
        // Все значения просчитаны заранее, изменения приведут к нарушению работы
        #region Повороты

        // Стандартные движения
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

        public static void U(ref string[][,] cube)
        {
            DoMoveInside(
                0,
                true,
                ref cube
            );
            DoMoveOutside(
                new int[]
                {
                    2,
					3,
					4,
					1
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
                },
                ref cube
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

        public static void Ui(ref string[][,] cube)
        {
            DoMoveInside(
                0,
                false,
                ref cube
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
                },
                ref cube
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

        public static void L(ref string[][,] cube)
        {
            DoMoveInside(
                1,
                true,
                ref cube
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
                },
                ref cube
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

        public static void Li(ref string[][,] cube)
        {
            DoMoveInside(
                1,
                false,
                ref cube
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
                },
                ref cube
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

        public static void F(ref string[][,] cube)
        {
            DoMoveInside(
                2,
                true,
                ref cube
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
                },
                ref cube
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

        public static void Fi(ref string[][,] cube)
        {
            DoMoveInside(
                2,
                false,
                ref cube
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
                },
                ref cube
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

        public static void R(ref string[][,] cube)
        {
            DoMoveInside(
                3,
                true,
                ref cube
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
                },
                ref cube
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

        public static void Ri(ref string[][,] cube)
        {
            DoMoveInside(
                3,
                false,
                ref cube
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
                },
                ref cube
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

        public static void B(ref string[][,] cube)
        {
            DoMoveInside(
                4,
                true,
                ref cube
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
                },
                ref cube
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

        public static void Bi(ref string[][,] cube)
        {
            DoMoveInside(
                4,
                false,
                ref cube
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
                },
                ref cube
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

        public static void D(ref string[][,] cube)
        {
            DoMoveInside(
                5,
                true,
                ref cube
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
                },
                ref cube
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

        public static void Di(ref string[][,] cube)
        {
            DoMoveInside(
                5,
                false,
                ref cube
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
                },
                ref cube
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

		// Движение центральной стороны относительно нижней стороны по часовой стрелке
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

		// Движение центральной стороны относительно нижней стороны против часовой стрелки
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

		// Движение центральной стороны относительно фронтальной стороны по часовой стрелке
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

		// Движение центральной стороны относительно фронтальной стороны против часовой стрелки
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

		// Универсальный метод для поворота внешних блоков грани
		private static void DoMoveOutside(int[] cubeFace, int[] fixedNumber, bool[] isFixed)
		{
			// Одномерный массив для ликвидация последовательности в формуле внутренних блоков
			int[] delta = new int[8];
			// Переменная для свапа элементов
			string cache;
			// Поворот внешних блоков
			for (int k = 0; k < 3; k++)
			{
				// Определение фиксирования
				for (int i = 0; i < 8; i++)
				{
					delta[i] = (isFixed[i] ? k : 0);
				}

				// cache = cube[0]
				cache =  cube[cubeFace[0]]
				[
					Math.Abs(fixedNumber[0] - k + delta[0]),
					Math.Abs(fixedNumber[1] - k + delta[1])
				];

				for (int i = 0, j = -2; i < 3; i++, j += 2)
				{
					cube[cubeFace[i]]
					[
						Math.Abs(fixedNumber[j + 2] - k + delta[j + 2]),
						Math.Abs(fixedNumber[j + 3] - k + delta[j + 3])
					] = cube[cubeFace[i + 1]]
					[
						Math.Abs(fixedNumber[j + 4] - k + delta[j + 4]),
						Math.Abs(fixedNumber[j + 5] - k + delta[j + 5])
					];
				}

				// cube[3] = cache
				cube[cubeFace[3]]
				[
					Math.Abs(fixedNumber[6] - k + delta[6]),
					Math.Abs(fixedNumber[7] - k + delta[7])
				] = cache;
			}
		}

        private static void DoMoveOutside(int[] cubeFace, int[] fixedNumber, bool[] isFixed, ref string[][,] cube)
        {
            // Одномерный массив для ликвидация последовательности в формуле внутренних блоков
            int[] delta = new int[8];
            // Переменная для свапа элементов
            string cache;
            // Поворот внешних блоков
            for (int k = 0; k < 3; k++)
            {
                // Определение фиксирования
                for (int i = 0; i < 8; i++)
                {
                    delta[i] = (isFixed[i] ? k : 0);
                }

                // cache = cube[0]
                cache = cube[cubeFace[0]]
                [
                    Math.Abs(fixedNumber[0] - k + delta[0]),
                    Math.Abs(fixedNumber[1] - k + delta[1])
                ];

                for (int i = 0, j = -2; i < 3; i++, j += 2)
                {
                    cube[cubeFace[i]]
                    [
                        Math.Abs(fixedNumber[j + 2] - k + delta[j + 2]),
                        Math.Abs(fixedNumber[j + 3] - k + delta[j + 3])
                    ] = cube[cubeFace[i + 1]]
                    [
                        Math.Abs(fixedNumber[j + 4] - k + delta[j + 4]),
                        Math.Abs(fixedNumber[j + 5] - k + delta[j + 5])
                    ];
                }

                // cube[3] = cache
                cube[cubeFace[3]]
                [
                    Math.Abs(fixedNumber[6] - k + delta[6]),
                    Math.Abs(fixedNumber[7] - k + delta[7])
                ] = cache;
            }
        }

        // Универсальный метод для поворота внутренних блоков грани
        private static void DoMoveInside(int edge, bool invert)
		{
			// Определение, в какую сторону прокручивать внутренние блоки			
			int invertOne = (invert ? 0 : 2); // По часовой
			int invertTwo = (invert ? 2 : 0); // Против часовой
			// Переменная для свапа
			string cache;

			// Поворот внутренних блоков
			for (int i = 0; i < 2; i++)
			{
				cache = cube[edge][i,0];
				cube[edge][i,0] = cube[edge]
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

        private static void DoMoveInside(int edge, bool invert, ref string[][,] cube)
        {
            // Определение, в какую сторону прокручивать внутренние блоки			
            int invertOne = (invert ? 0 : 2); // По часовой
            int invertTwo = (invert ? 2 : 0); // Против часовой
                                              // Переменная для свапа
            string cache;

            // Поворот внутренних блоков
            for (int i = 0; i < 2; i++)
            {
                cache = cube[edge][i, 0];
                cube[edge][i, 0] = cube[edge]
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