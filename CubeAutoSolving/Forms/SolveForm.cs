using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;

namespace RubiksAutoSolve
{
	public partial class SolveForm : Form
	{
        public SolveForm()
		{
			InitializeComponent();
        }

        private int position = 0;
        public bool stopAlg = false;

        private static int numberAttempts = 0;
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
            if (position >= 2)
            {
                return;
            }

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

                                if (Array.IndexOf(moves[turn], elements[last]) != -1 && (turn + 1) % 2 == 0)
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
                    Rotate.DoMovesByFormula(formula);

                    richTextBox1.AppendText(formula + Environment.NewLine);
                    numberAttempts++;

                    if (position < this.position && !stopAlg)
                        Generate(position + 1, pattern + moves[turn][variant] + " ");
                }
            }
        }

        private static List<List<string>> formulsCache = new List<List<string>>();
        private static string[][] firstMoves =
        {
            new string[] { "U", "U'" },
            new string[] { "D", "D'" },
            new string[] { "R", "R'" },
            new string[] { "L", "L'" },
            new string[] { "F", "F'" },
            new string[] { "B", "B'" }
        };

        private static string[][] secondMoves =
        {
            new string[] { "U", "U'" },
            new string[] { "D", "D'" },
            new string[] { "R2" },
            new string[] { "L2" },
            new string[] { "F2" },
            new string[] { "B2" }
        };

        private static Stopwatch time = new Stopwatch();
        private char[][,] cacheCube = new char[6][,]
        {
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3]
        };
        private string formula;

        private void Phase(int position, string pattern)
        {
            bool paralel = false;
            int last = position - 1;
            int penultimate = position - 2;
            string[] elements = pattern.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string formula = "";

            for (int turn = 0; turn < firstMoves.Length; turn++)
            {
                if (elements.Length >= 1)
                {
                    if (Array.IndexOf(firstMoves[turn], elements[last]) != -1)
                    {
                        if (turn != firstMoves.Length - 1)
                        {
                            if ((turn + 1) % 2 != 0)
                            {
                                paralel = true;
                            }

                            turn++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                if (elements.Length >= 2)
                {
                    if (Array.IndexOf(firstMoves[turn], elements[penultimate]) != -1)
                    {
                        if (turn != firstMoves.Length - 1)
                        {
                            if (paralel)
                            {
                                turn++;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                for (int variant = 0; variant < firstMoves[turn].Length; variant++)
                {
                    formula = pattern + firstMoves[turn][variant];
                    //Rotate.DoMovesByFormula(formula);

                   // if (formulsCache[position])
                   
                    
                    if (!formulsCache[position].Contains(formula))
                    {
                        formulsCache[position].Add(formula);
                    }
                    else
                    {
                        
                    }
                    
                    numberAttempts++;
                    
                    richTextBox1.AppendText(formula + Environment.NewLine);

                    if (position < this.position)
                        Phase(position + 1, formula + " ");
                }
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                formulsCache.Add(new List<string>());
            }
            
            Array.Copy(Rotate.cube, this.cacheCube, Rotate.cube.Length);

            for (int k = 0; k < 6; k++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        
                    }
                }
            }

            time.Start();
            numberAttempts = 0;
            //LayerByLayer lbl = new LayerByLayer();
            pictureBox1.BackColor = Color.Red;
            this.Refresh();

            for (position = 0; position <= 5; position++)
            {
                Phase(0, "");
            }
            
            time.Stop();

            richTextBox1.AppendText(time.Elapsed.TotalSeconds.ToString() + Environment.NewLine + numberAttempts);

            pictureBox1.BackColor = Color.Green;
        }
    }
}
