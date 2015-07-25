

namespace CubeAutoSolving
{
	class LayerByLayer : SolvingMethod
	{
		public override void SolveCube()
		{
			SolveCross();
			SolveFirstLayer();
			SolveSecondLayer();
			OrientateLastLayerCross();
			PermutateLastLayerEdges();
			OrientateLastLayerCorners();
			PermutateLastLayerCorners();
		}
		
		private void SolveFirstLayer()
		{

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
