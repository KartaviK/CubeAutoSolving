using System;

namespace RubiksAutoSolve
{
	class LayerByLayer : SolvingMethod
	{
		private int position = 0;
		public bool stopAlg = false;

		public override void SolveCube()
		{
			SolveFirstLayer();
			/*SolveCross();
			SolveSecondLayer();
			OrientateLastLayerCross();
			PermutateLastLayerEdges();
			OrientateLastLayerCorners();
			PermutateLastLayerCorners();*/
		}
		
		private void SolveFirstLayer()
		{
			stopAlg = false;

            for (position = 0; position < 20; position++)
            {
                if (!stopAlg)
                {
                    Generate(0, "");
                }
            }
        }
		
		private static int numberAttempts = 0;
		private static int formulaCount = 1;
		private static string[][] moves =
		{
			new string[] { "R", "R'", "R2" },
			new string[] { "L", "L'", "L2" },
			new string[] { "U", "U'", "U2" },
			new string[] { "D", "D'", "D2" },
			new string[] { "F", "F'", "F2" },
			new string[] { "B", "B'", "B2" }
		};

		// Метод рекурсивной генерации формулы для кубика
		private void Generate(int position, string pattern)
		{
			int last = position - 1;
			int penultimate = position - 2;
			string[] elements = pattern.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			string formula = "";
            
			for (int turn = 0; turn < moves.Length; turn++)
			{
				if (elements.Length >= 1)
				{
					if (Array.IndexOf(moves[turn], elements[last]) != -1)
					{
						if (turn != moves.Length - 1)
							turn++;
						else
							continue;
					}

					if (elements.Length >= 2)
					{
						if (Array.IndexOf(moves[turn], elements[penultimate]) != -1)
						{
							if (turn != moves.Length - 1)
							{
								turn++;
								
								if (Array.IndexOf(moves[turn], elements[last]) != -1)
								{
									if (turn != moves.Length - 1)
										turn++;
									else
										continue;
								}
							}
							else
							{
								continue;
							}
						}
					}
				}
				
				for (int variant = 0; variant < moves[turn].Length; variant++)
                {
                    formula = pattern + moves[turn][variant];
					//Rotate.DoMovesByFormula(formula);
					
                    

					if (position < this.position && !stopAlg)
						Generate(position + 1, pattern + moves[turn][variant] + " ");
				}
			}
		}

		private void SolveSecondLayer()
		{
			
		}

		private void OrientateLastLayerCross()
		{

		}

		private void PermutateLastLayerEdges()
		{

		}

		private void OrientateLastLayerCorners()
		{

		}

		private void PermutateLastLayerCorners()
		{

		}
	}
}
