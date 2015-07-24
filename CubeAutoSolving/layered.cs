
namespace CubeAutoSolving
{
    class layered
    {
        /*Moves moves = new Moves();
        bool[] emptySockets;
        int i;

        //Универсальный метод проверки ориентации
        public void X_orientatin()
        {
            switch (moves.cube[0][1, 0]) 
            {
                case 'b':
                    // Смежные
                    if (moves.cube[3][2, 1] == 'o')
                        moves.DoMovesByFormula("layerd", "L Di Li D L");
                    // Противоположные
                    else if (moves.cube[3][2, 1] == 'r')
                        moves.DoMovesByFormula("layerd", "L Di Di Li D D L");
                    break;
                case 'o':
                    if (moves.cube[3][2, 1] == 'g')
                        moves.DoMovesByFormula("layerd", "L Di Li D L");
                    else if (moves.cube[3][2, 1] == 'b')
                        moves.DoMovesByFormula("layerd", "L Di Di Li D D L Di");
                    break;
                case 'g':
                    if (moves.cube[3][2, 1] == 'r')
                        moves.DoMovesByFormula("layerd", "L Di Li D L");
                    else if (moves.cube[3][2, 1] == 'o')
                        moves.DoMovesByFormula("layerd", "L Di Di Li D D L D D");
                    break;
                case 'r':
                    if (moves.cube[3][2, 1] == 'b')
                        moves.DoMovesByFormula("layerd", "L Di Li D L");
                    else if (moves.cube[3][2, 1] == 'g')
                        moves.DoMovesByFormula("layerd", "L Di Di Li D D L D");
                    break;
            }//Конец проверки ориентации
        }

        public void FirstStage()
        {
            // Проверка креста
            if (
                moves.cube[4][1, 0] == 'w' &&
                moves.cube[4][0, 1] == 'w' &&
                moves.cube[4][2, 1] == 'w' &&
                moves.cube[4][1, 2] == 'w'
                )
            {
                // Проверка смежных с крестом блоков если крест собран
                if (moves.cube[0][1, 0] == 'b' &&
                    moves.cube[3][2, 1] == 'o' &&
                    moves.cube[5][1, 2] == 'g' &&
                    moves.cube[1][0, 1] == 'r'
                )
                {
                    SecondStage();
                }
                else
                {
                    X_orientatin();
                    SecondStage();
                }
            }
            else
            {
                emptySockets = new bool[]{
                    moves.cube[4][1, 0] != 'w',
                    moves.cube[4][0, 1] != 'w',
                    moves.cube[4][2, 1] != 'w',
                    moves.cube[4][1, 2] != 'w'
                };

                for (i = 0; i < 6 && i != 4; i++)
                {
                    if (emptySockets[0] == true)
                    {
                        //[i][1,0] ()
                        if (moves.cube[i][1, 0] == 'w')
                        {
                            if (i == 0)
                                moves.DoMovesByFormula("layerd", "B Di R D");
                            if (i == 1)
                                moves.DoMovesByFormula("layerd", "B");
                            if (i == 2)
                                moves.DoMovesByFormula("layerd", "B B");
                            if (i == 3)
                                moves.DoMovesByFormula("layerd", "Bi");
                            if (i == 5)
                                moves.DoMovesByFormula("layerd", "U Li B L");
                        }
                        //[i][0,1] (i!=1)
                        if (moves.cube[i][0, 1] == 'w' && i != 1)
                        {
                            if (i == 0)
                                moves.DoMovesByFormula("layerd", "D Li Di");
                            if (i == 2)
                                moves.DoMovesByFormula("layerd", "D L L Di");
                            if (i == 3)
                                moves.DoMovesByFormula("layerd", "R Bi Ri");
                            if (i == 5)
                                moves.DoMovesByFormula("layerd", "Di L D");
                        }
                        //[i][2,1] (i!=3)
                        if (moves.cube[i][2, 1] == 'w' && i != 3)
                        {
                            if (i == 0)
                                moves.DoMovesByFormula("layerd", "Di R D");
                            if (i == 1)
                                moves.DoMovesByFormula("layerd", "Li B L");
                            if (i == 2)
                                moves.DoMovesByFormula("layerd", "Di R R D");
                            if (i == 5)
                                moves.DoMovesByFormula("layerd", "Di R D");
                        }

                        //[i][1,2] (i!=5)
                        if (moves.cube[i][1, 2] == 'w' && i != 5)
                        {
                            if (i == 0)
                                moves.DoMovesByFormula("layerd", "B D Li Di");
                            if (i == 1)
                                moves.DoMovesByFormula("layerd", "D D Fi D D");
                            if (i == 2)
                                moves.DoMovesByFormula("layerd", "D D F F D D");
                            if (i == 3)
                                moves.DoMovesByFormula("layerd", "D D F D D");
                        }
                    }

                    if (emptySockets[1] == true)
                    {
                        //[i][0,1] (i!=0)
                        if (moves.cube[i][0, 1] == 'w')
                        {
                            if (i == 1)
                                moves.DoMovesByFormula("layerd", "D B Di");
                            if (i == 2)
                                moves.B();
                            if (i == 3)
                                    moves.B();
                            if (i == 3)
                                moves.Bi();
                            if (i == 5)
                            {
                                moves.U();
                                moves.Li();
                                moves.B();
                                moves.L();
                            }
                        }

                        //[i][0,1] (i!=1)
                        if (moves.cube[i][0, 1] == 'w' && i != 1)
                        {
                            if (i == 0)
                            {
                                moves.D();
                                moves.Li();
                                moves.Di();
                            }
                            if (i == 2)
                            {
                                moves.D();
                                moves.L();
                                moves.L();
                                moves.Di();
                            }
                            if (i == 3)
                            {
                                moves.R();
                                moves.Bi();
                                moves.Ri();
                            }
                            if (i == 5)
                            {
                                moves.Di();
                                moves.L();
                                moves.D();
                            }
                        }

                        //[i][2,1] (i!=3)
                        if (moves.cube[i][2, 1] == 'w' && i != 3)
                        {
                            if (i == 0)
                            {
                                moves.Di();
                                moves.R();
                                moves.D();
                            }
                            if (i == 1)
                            {
                                moves.Li();
                                moves.B();
                                moves.L();
                            }
                            if (i == 2)
                            {
                                moves.Di();
                                moves.R();
                                moves.R();
                                moves.D();
                            }
                            if (i == 5)
                            {
                                moves.Di();
                                moves.R();
                                moves.D();
                            }
                        }

                        //[i][1,2] (i!=5)
                        if (moves.cube[i][1, 2] == 'w' && i != 5)
                        {
                            if (i == 0)
                            {
                                moves.B();
                                moves.D();
                                moves.Li();
                                moves.Di();
                            }
                            if (i == 1)
                            {
                                moves.D();
                                moves.D();
                                moves.Fi();
                                moves.D();
                                moves.D();
                            }
                            if (i == 2)
                            {
                                moves.D();
                                moves.D();
                                moves.F();
                                moves.F();
                                moves.D();
                                moves.D();
                            }
                            if (i == 3)
                            {
                                moves.D();
                                moves.D();
                                moves.F();
                                moves.D();
                                moves.D();
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

        public void SecondStage()
        {

        }

        public void ThirdStage()
        {

        }

        public void FourthStage()
        {

        }

        public void FivethStage()
        {

        }

        public void SixthStage()
        {

        }

        public void SeventhStage()
        {

        }*/
    }
}
