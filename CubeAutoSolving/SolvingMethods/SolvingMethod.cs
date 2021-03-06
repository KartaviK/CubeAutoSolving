﻿

namespace RubiksAutoSolve
{
	abstract class SolvingMethod
	{/*
		public abstract void SolveCube();

		//Универсальный метод проверки ориентации
		private void CheckOrientation()
		{
            string formula = "";
            string firstElement = Rotate.cube[0][1, 0];
            string secondElement = Rotate.cube[3][2, 1];
            
			switch (firstElement)
			{
				case "b":
					if (secondElement == 'o')
						formula = "L D' L' D L";
					else if (secondElement == 'r')
						formula = "L D2 L' D2 L";
					else
						formula = "R' B R B' R'";
					break;
				case 'o':
					if (secondElement == 'g')
						formula = "L D' L' D L";
					else if (secondElement == 'b')
						formula = "L D2 Li D2 L D'";
					else
						formula = "R' B R B' R'";
					break;
				case 'g':
					if (secondElement == 'r')
						formula = "L D' L' D L";
					else if (secondElement == 'o')
						formula = "L D2 L' D2 L D2";
					else
						formula = "R' B R B' R'";
					break;
				case 'r':
					if (secondElement == 'b')
						formula = "L D' L' D L";
					else if (secondElement == 'g')
						formula = "L D2 L' D2 L D";
					else
						formula = "R' B R B' R'";
					break;
			}

            Rotate.DoMovesByFormula(formula);
		}
        *//*
		public void SolveCross()
		{
			// string formula = "";
			int number = 0;

			bool[] emptySockets = 
				{
					Rotate.cube[4][1, 0] != 'w',
					Rotate.cube[4][0, 1] != 'w',
					Rotate.cube[4][2, 1] != 'w',
					Rotate.cube[4][1, 2] != 'w'
				};

			for (int i = 0; i < 4; i++)
				if (emptySockets[i] == true)
					number++;

			if (number == 0)
			{
				if (Rotate.cube[0][1, 0] != 'b' ||
					Rotate.cube[3][2, 1] != 'o' ||
					Rotate.cube[5][1, 2] != 'g' ||
					Rotate.cube[1][0, 1] != 'r')
					CheckOrientation();
			}
			else if (number == 1)
				OneElementCross();
			else if (number == 2)
				TwoElementsCross();
			else if (number == 3)
				ThreeElementsCross();
			else if (number == 4)
				FourElementsCross();
		}

		private void OneElementCross()
		{
			string formula = "";

			for (int i = 0; i < 6 && i != 4; i++)
			{
				if (Rotate.cube[4][1, 0] != Rotate.cube[4][1, 1])
				{
					if (Rotate.cube[i][1, 0] == Rotate.cube[4][1, 1])
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
					}

					Rotate.DoMovesByFormula(formula);
				}
				//[i][0,1] (i!=1)
				if (Rotate.cube[i][0, 1] == 'w' && i != 1)
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
					Rotate.DoMovesByFormula(formula);
				}

				//[i][2,1] (i!=3)
				if (Rotate.cube[i][2, 1] == 'w' && i != 3)
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
					Rotate.DoMovesByFormula(formula);
				}

				//[i][1,2] (i!=5)
				if (Rotate.cube[i][1, 2] == 'w' && i != 5)
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
					Rotate.DoMovesByFormula(formula);
				}
			}
		}

		private void TwoElementsCross()
		{

		}

		private void ThreeElementsCross()
		{

		}

		private void FourElementsCross()
		{

		}*/
	}
}
/*
					if (Moves.cube[4][0, 1] != 'w')
					{
						//[i][0,1] (i!=0)
							switch (i)
							{
								case 1:
									formula = "D B D'";
									break;
								case 2:
								case 3:
									formula = "B";
									break;
								case 4:
									formula = "B'";
									break;
								case 5:
									formula = "U L' B L";
                                    break;
							}

							Moves.DoMovesByFormula(formula);

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

					}


					}
		}
			/*}
			

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
							switch (i)
							{
								case 1:
									formula = "D B D'";
									break;
								case 2:
								case 3:
									formula = "B";
									break;
								case 4:
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
									formula = "D2 F' D2";
									break;
								case 2:
									formula = "D2 F2 D2";
									break;
								case 3:
									formula = "D2 F D2";
									break;
							}

							Moves.DoMovesByFormula(formula);
						}
					}

					if (emptySockets[2] == true)
					{

					}

					if (emptySockets[3] == true)
					{

					}
				}
			}*/
