

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
						Moves.DoMovesByFormula("L D' L' D L");
					// Противоположные
					else if (Moves.cube[3][2, 1] == 'r')
						Moves.DoMovesByFormula("L D2 L' D2 L");
					break;
				case 'o':
					if (Moves.cube[3][2, 1] == 'g')
						Moves.DoMovesByFormula("L D' L' D L");
					else if (Moves.cube[3][2, 1] == 'b')
						Moves.DoMovesByFormula("L D2 Li D2 L D'");
					break;
				case 'g':
					if (Moves.cube[3][2, 1] == 'r')
						Moves.DoMovesByFormula("L D' L' D L");
					else if (Moves.cube[3][2, 1] == 'o')
						Moves.DoMovesByFormula("L D2 L' D2 L D2");
					break;
				case 'r':
					if (Moves.cube[3][2, 1] == 'b')
						Moves.DoMovesByFormula("L D' L' D L");
					else if (Moves.cube[3][2, 1] == 'g')
						Moves.DoMovesByFormula("L D2 L' D2 L D");
					break;
			}
		}

		public void SolveCross()
		{
			bool[] emptySockets;
			string formula = "";

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
							switch (i)
							{
								case 0:
									formula = "B D' R D";
                                    break;
								case 1:
									formula = "B";
									break;
								case 2:
									formula = "B2";
									break;
								case 3:
									formula = "B'";
									break;
								case 5:
									formula = "U L' B L";
									break;
							}

							Moves.DoMovesByFormula(formula);
						}
						//[i][0,1] (i!=1)
						if (Moves.cube[i][0, 1] == 'w' && i != 1)
						{
							switch (i)
							{
								case 0:
									formula = "D L' D'";
									break;
								case 2:
									formula = "D L2 D'";
									break;
								case 3:
									formula = "R B' R'";
									break;
								case 5:
									formula = "D' L D";
									break;
							}

							Moves.DoMovesByFormula(formula);
						}
						//[i][2,1] (i!=3)
						if (Moves.cube[i][2, 1] == 'w' && i != 3)
						{
							switch (i)
							{
								case 0:
									formula = "D' R D";
									break;
								case 1:
									formula = "L' B L";
									break;
								case 2:
									formula = "D' R2 D";
									break;
								case 5:
									formula = "D' R D";
									break;
							}

							Moves.DoMovesByFormula(formula);
						}

						//[i][1,2] (i!=5)
						if (Moves.cube[i][1, 2] == 'w' && i != 5)
						{
							switch (i)
							{
								case 0:
									formula = "B D L' D'";
									break;
								case 1:
								case 2:
									formula = "D2 F' D2";
									break;
								case 3:
									formula = "D2 F D2";
									break;
							}

							Moves.DoMovesByFormula(formula);
						}
					}

					if (emptySockets[1] == true)
					{
						//[i][0,1] (i!=0)
						if (Moves.cube[i][0, 1] == 'w')
						{
							/*if (i == 1)
								Moves.DoMovesByFormula("D B Di");
							if (i == 2)
								Moves.B();
							if (i == 3)
								Moves.B();
							if (i == 3)
								Moves.Bi();
							if (i == 5)
								Moves.DoMovesByFormula("U L' B L");*/
							switch (i)
							{
								case 1:
									formula = "D B D'";
									break;
								/*case 2:
									formula = "B";
									break;
								case 3:
									formula = "B";
									break;
								case 3:
									formula = "B'";
									break;*/
								case 5:
									formula = "U L' B L";
                                    break;
							}

							Moves.DoMovesByFormula(formula);
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
