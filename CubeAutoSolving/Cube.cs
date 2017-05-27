using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;

namespace RubiksAutoSolve
{
    public class Cube
    {
        private string[] colors = new string[6]
        {
            "y",
            "r",
            "g",
            "o",
            "b",
            "w"
        };

        public Edge[] edge;

        public Cube()
        {
            this.edge = new Edge[6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        this.edge[i][j, z] = colors[i];
                    }
                }
            }
        }

        public Cube(string[][,] cube)
        {
            for (int i = 0; i < 6; i++)
            {

            }
        }

        public void Reset()
        {
            string[] colors = new string[6]
            {
                "y",
                "r",
                "g",
                "o",
                "b",
                "w"
            };

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        this.edge[i][j, z] = colors[i];
                    }
                }
            }
        }

        public string ConvertScramble(string scramble)
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

        public string ScrambleCube()
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

        public void DoMovesByFormula(string formula)
        {
            string[] moves = FormulaToMoves(formula);

            foreach (string move in moves)
            {
                MethodInfo moveMethod = typeof(Rotate).GetMethod(move, new Type[] { });
                moveMethod.Invoke(null, null);
            }
        }

        private static string[] FormulaToMoves(string formula)
        {
            List<string> moves = new List<string>();
            string move = "";
            string[] array = formula.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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
    }

    public class Edge
    {
        private string[,] elements;

        public string this[int column, int line]
        {
            get
            {
                return elements[column, line];
            }
            set
            {
                this.elements[column, line] = value;
            }
        }

        Edge(string[,] elements)
        {
            this.elements = elements;
        }
    }
}
