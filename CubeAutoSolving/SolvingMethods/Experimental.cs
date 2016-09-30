using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CubeAutoSolving.SolvingMethods
{
    public static class Experimental
    {
        /// <summary>
        ///     Elapsed time on the computation
        /// </summary>
        private static Stopwatch time = new Stopwatch();
        /// <summary>
        ///     Attempts formula generation
        /// </summary>
        private static int attempts = 0;
        /// <summary>
        ///     Current number of movements in the formula
        /// </summary>
        private static int formulaCount = 1;
        /// <summary>
        ///     The position of the last movement in the formula
        /// </summary>
        private static int position = 0;
        /// <summary>
        ///     All types of movements
        /// </summary>
        private static string[][] moves =
        {
            new string[] { "R", "R'", "R2" },
            new string[] { "L", "L'", "L2" },
            new string[] { "U", "U'", "U2" },
            new string[] { "D", "D'", "D2" },
            new string[] { "F", "F'", "F2" },
            new string[] { "B", "B'", "B2" }
        };

        private static void Generate(
            int position,
            string pattern)
        {
            if (time.ElapsedMilliseconds >= 2000) // 10 минут работы алгоритма (Во время рефакторинга добавить точку выхода во время выполнения)
                return;

            int last = position - 1;
            int penultimate = position - 2;
            string[] elements = pattern.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries
                );
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
                    // Вывод (Во время рефакторинга убрать)
                    //Console.WriteLine("Formula count: {0}; time: {1}; attempts: {2}; formula: {3}", formulaCount < position ? position + 1 : formulaCount, time.Elapsed, ++numberAttempts, pattern + moves[turn][variant]);
                    formula = pattern + moves[turn][variant];
                    Rotate.DoMovesByFormula(formula);

                    if (position < Experimental.position)
                        Generate(position + 1, pattern + moves[turn][variant] + " ");
                }
            }
        }
    }
}
