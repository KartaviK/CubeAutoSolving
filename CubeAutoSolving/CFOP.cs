

namespace CubeAutoSolving
{
    class CFOP : SolvingMethod
    {
		public override void SolveCube()
		{
			SolveCross();
			SolveF2L();
			OrientateLastLayer();
			PermutateLastLayer();
		}

		private void SolveF2L()
		{

		}

		private void OrientateLastLayer()
		{

		}

		private void PermutateLastLayer()
		{

		}
    }
}
