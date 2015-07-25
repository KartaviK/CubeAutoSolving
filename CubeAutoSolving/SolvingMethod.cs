

namespace CubeAutoSolving
{
	abstract class SolvingMethod
	{
		public abstract void SolveCube();

		//Универсальный метод проверки ориентации
		public void CheckOrientation()
		{
			switch (Moves.cube[0][1, 0])
			{
				case 'b':
					// Смежные
					if (Moves.cube[3][2, 1] == 'o')
						Moves.DoMovesByFormula("L Di Li D L");
					// Противоположные
					else if (Moves.cube[3][2, 1] == 'r')
						Moves.DoMovesByFormula("L Di Di Li D D L");
					break;
				case 'o':
					if (Moves.cube[3][2, 1] == 'g')
						Moves.DoMovesByFormula("L Di Li D L");
					else if (Moves.cube[3][2, 1] == 'b')
						Moves.DoMovesByFormula("L Di Di Li D D L Di");
					break;
				case 'g':
					if (Moves.cube[3][2, 1] == 'r')
						Moves.DoMovesByFormula("L Di Li D L");
					else if (Moves.cube[3][2, 1] == 'o')
						Moves.DoMovesByFormula("L Di Di Li D D L D D");
					break;
				case 'r':
					if (Moves.cube[3][2, 1] == 'b')
						Moves.DoMovesByFormula("L Di Li D L");
					else if (Moves.cube[3][2, 1] == 'g')
						Moves.DoMovesByFormula("L Di Di Li D D L D");
					break;
			}
		}

		public void SolveCross()
		{
			bool[] emptySockets;

			// Проверка креста
			if (Moves.cube[4][1, 0] == 'w' &&
				Moves.cube[4][0, 1] == 'w' &&
				Moves.cube[4][2, 1] == 'w' &&
				Moves.cube[4][1, 2] == 'w')
			{
				// Проверка смежных с крестом блоков если крест собран
				if (Moves.cube[0][1, 0] != 'b' ||
					Moves.cube[3][2, 1] != 'o' ||
					Moves.cube[5][1, 2] != 'g' ||
					Moves.cube[1][0, 1] != 'r')
						CheckOrientation();
			}
			else
			{
				emptySockets = new bool[]
				{
					Moves.cube[4][1, 0] != 'w',
					Moves.cube[4][0, 1] != 'w',
					Moves.cube[4][2, 1] != 'w',
					Moves.cube[4][1, 2] != 'w'
				};

				for (int i = 0; i < 6 && i != 4; i++)
				{
					if (emptySockets[0] == true)
					{
						//[i][1,0] ()
						if (Moves.cube[i][1, 0] == 'w')
						{
							if (i == 0)
								Moves.DoMovesByFormula("B Di R D");
							if (i == 1)
								Moves.DoMovesByFormula("B");
							if (i == 2)
								Moves.DoMovesByFormula("B B");
							if (i == 3)
								Moves.DoMovesByFormula("Bi");
							if (i == 5)
								Moves.DoMovesByFormula("U Li B L");
						}
						//[i][0,1] (i!=1)
						if (Moves.cube[i][0, 1] == 'w' && i != 1)
						{
							if (i == 0)
								Moves.DoMovesByFormula("D Li Di");
							if (i == 2)
								Moves.DoMovesByFormula("D L L Di");
							if (i == 3)
								Moves.DoMovesByFormula("R Bi Ri");
							if (i == 5)
								Moves.DoMovesByFormula("Di L D");
						}
						//[i][2,1] (i!=3)
						if (Moves.cube[i][2, 1] == 'w' && i != 3)
						{
							if (i == 0)
								Moves.DoMovesByFormula("Di R D");
							if (i == 1)
								Moves.DoMovesByFormula("Li B L");
							if (i == 2)
								Moves.DoMovesByFormula("Di R R D");
							if (i == 5)
								Moves.DoMovesByFormula("Di R D");
						}

						//[i][1,2] (i!=5)
						if (Moves.cube[i][1, 2] == 'w' && i != 5)
						{
							if (i == 0)
								Moves.DoMovesByFormula("B D Li Di");
							if (i == 1)
								Moves.DoMovesByFormula("D D Fi D D");
							if (i == 2)
								Moves.DoMovesByFormula("D D F F D D");
							if (i == 3)
								Moves.DoMovesByFormula("D D F D D");
						}
					}

					if (emptySockets[1] == true)
					{
						//[i][0,1] (i!=0)
						if (Moves.cube[i][0, 1] == 'w')
						{
							if (i == 1)
								Moves.DoMovesByFormula("D B Di");
							if (i == 2)
								Moves.B();
							if (i == 3)
								Moves.B();
							if (i == 3)
								Moves.Bi();
							if (i == 5)
								Moves.DoMovesByFormula("U L' B L");
						}

						//[i][0,1] (i!=1)
						if (Moves.cube[i][0, 1] == 'w' && i != 1)
						{
							if (i == 0)
							{
								Moves.DoMovesByFormula("D L' D'");
							}
							if (i == 2)
							{
								Moves.D();
								Moves.L();
								Moves.L();
								Moves.Di();
							}
							if (i == 3)
							{
								Moves.DoMovesByFormula("R B' R'");
							}
							if (i == 5)
							{
								Moves.DoMovesByFormula("D' L D");
							}
						}

						//[i][2,1] (i!=3)
						if (Moves.cube[i][2, 1] == 'w' && i != 3)
						{
							if (i == 0)
							{
								Moves.Di();
								Moves.R();
								Moves.D();
							}
							if (i == 1)
							{
								Moves.Li();
								Moves.B();
								Moves.L();
							}
							if (i == 2)
							{
								Moves.Di();
								Moves.R();
								Moves.R();
								Moves.D();
							}
							if (i == 5)
							{
								Moves.Di();
								Moves.R();
								Moves.D();
							}
						}

						//[i][1,2] (i!=5)
						if (Moves.cube[i][1, 2] == 'w' && i != 5)
						{
							if (i == 0)
							{
								Moves.B();
								Moves.D();
								Moves.Li();
								Moves.Di();
							}
							if (i == 1)
							{
								Moves.D();
								Moves.D();
								Moves.Fi();
								Moves.D();
								Moves.D();
							}
							if (i == 2)
							{
								Moves.D();
								Moves.D();
								Moves.F();
								Moves.F();
								Moves.D();
								Moves.D();
							}
							if (i == 3)
							{
								Moves.D();
								Moves.D();
								Moves.F();
								Moves.D();
								Moves.D();
							}
						}
					}

					if (emptySockets[2] == true)
					{

					}

					if (emptySockets[3] == true)
					{

					}
				}
			}
		}
	}
}
