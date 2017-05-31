using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubiksAutoSolve
{
	public partial class SolveForm : Form
	{
        public SolveForm(Cube cube)
		{
            this.cube = cube;
			InitializeComponent();
        }

        private Cube cube;
        private int position = 0;
        private int secondPosition = 0;
        private ulong numberAttempts = 0;
        public string firstPhaseAnswer = "";
        public bool stopAlg = false;
        private List<string> formulsCache = new List<string>();
        private Stopwatch time = new Stopwatch();
        private string[][] firstMoves =
        {
            new string[] { "U", "Ui", "Ud" },
            new string[] { "D", "Di", "Dd" },
            new string[] { "R", "Ri", "Rd" },
            new string[] { "L", "Li", "Ld" },
            new string[] { "F", "Fi", "Fd" },
            new string[] { "B", "Bi", "Bd" }
        };
        private string[][] secondMoves =
        {
            new string[] { "U", "Ui", "Ud" },
            new string[] { "D", "Di", "Dd" },
            new string[] { "Rd" },
            new string[] { "Ld" },
            new string[] { "Fd" },
            new string[] { "Bd" }
        };
        

        private void Phase(int position, string pattern, Cube cube)
        {
            if (stopAlg)
            {
                return;
            }

            //formulsCache.Add(pattern);
            
            if (Rotate.CheckFirstPhase(ref cube, ref pattern))
            {
                formulsCache.Add(pattern);
                stopAlg = true;

                return;
            }
            
            int last = position - 1;
            int penultimate = position - 2;
            string[] elements = pattern.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int turn = 0; turn < firstMoves.Length; turn++)
            {
                if (elements.Length >= 1)
                {
                    if (Array.IndexOf(firstMoves[turn], elements[last]) != -1)
                    {
                        if (turn != firstMoves.Length - 1)
                        {
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
                        if (turn == 0 || turn == 2)
                        {
                            if (Array.IndexOf(firstMoves[turn + 1], elements[last]) != -1)
                            {
                                turn += 2;
                            }
                        }
                        else if (turn == 1 || turn == 3)
                        {
                            if (Array.IndexOf(firstMoves[turn - 1], elements[last]) != -1)
                            {
                                turn++;
                            }
                        } 
                        else if (turn >= 4)
                        {
                            continue;
                        }
                    }
                }
                
                for (int variant = 0; variant < firstMoves[turn].Length; variant++)
                {
                    if ((turn + 2) % 2 == 0)
                    {
                        if (Array.IndexOf(firstMoves[turn + 1], elements[last]) != -1)
                        {
                            if (turn != 4)
                            {
                                turn += 2;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    Cube tempCube = (Cube)cube.Clone();
                    tempCube.DoRotate(firstMoves[turn][variant]);
                    
                    numberAttempts++;

                    if (position < this.position)
                        Phase(position + 1, $"{pattern}{firstMoves[turn][variant]} ", tempCube);
                }
            }
        }

        private void SecondPhase(int position, string pattern, Cube cube)
        {
            if (stopAlg)
            {
                return;
            }

            if (Rotate.IsCubeSolved(ref cube))
            {
                formulsCache.Add(pattern);
                stopAlg = true;

                return;
            }

            int last = position - 1;
            int penultimate = position - 2;
            string[] elements = pattern.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int turn = 0; turn < secondMoves.Length; turn++)
            {
                if (elements.Length >= 1)
                {
                    if (Array.IndexOf(secondMoves[turn], elements[last]) != -1)
                    {
                        if (turn != secondMoves.Length - 1)
                        {
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
                    if (Array.IndexOf(secondMoves[turn], elements[penultimate]) != -1)
                    {
                        if (turn == 0 || turn == 2)
                        {
                            if (Array.IndexOf(secondMoves[turn + 1], elements[last]) != -1)
                            {
                                turn += 2;
                            }
                        }
                        else if (turn == 1 || turn == 3)
                        {
                            if (Array.IndexOf(secondMoves[turn - 1], elements[last]) != -1)
                            {
                                turn++;
                            }
                        }
                        else if (turn >= 4)
                        {
                            continue;
                        }
                    }
                }

                for (int variant = 0; variant < secondMoves[turn].Length; variant++)
                {
                    if ((turn + 2) % 2 == 0)
                    {
                        if (Array.IndexOf(secondMoves[turn + 1], elements[last]) != -1)
                        {
                            if (turn != 4)
                            {
                                turn += 2;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    Cube tempCube = (Cube)cube.Clone();
                    tempCube.DoRotate(secondMoves[turn][variant]);

                    numberAttempts++;

                    if (position < this.secondPosition)
                        SecondPhase(position + 1, $"{pattern}{secondMoves[turn][variant]} ", tempCube);
                }
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            if (Rotate.IsCubeSolved(ref cube))
            {
                richTextBox1.AppendText($"Cube is not scrambled{Environment.NewLine}");

                return;
            }
            
            pictureBox1.BackColor = Color.Red;
            this.Refresh();
            numberAttempts = 0;
            this.position = Convert.ToInt32(textBox1.Text);
            this.secondPosition = Convert.ToInt32(textBox2.Text);

            time.Start();
            Parallel.For(0, 6, (i, state) => {
                Cube iteratorCopy = (Cube)cube.Clone();

                for (int z = 0; z < 3; z++)
                {
                    iteratorCopy.DoRotate(firstMoves[i][z]);
                    string formula = firstMoves[i][z];

                    if (!Rotate.CheckFirstPhase(ref iteratorCopy, ref formula))
                    {
                        Phase(1, $"{firstMoves[i][z]} ", iteratorCopy);
                    }
                    else
                    {
                        stopAlg = true;
                        //formulsCache.Add(formula);
                        state.Stop();
                    }

                    iteratorCopy = (Cube)cube.Clone();
                }
            });
            
            time.Stop();
            richTextBox1.AppendText("----------------" + Environment.NewLine);
            richTextBox1.AppendText("Total time in sec: " + time.Elapsed.TotalSeconds.ToString() + Environment.NewLine);
            
            if (formulsCache.Count >= 1)
            {
                firstPhaseAnswer = formulsCache[0];

                foreach (string move in formulsCache)
                {
                    if (firstPhaseAnswer.Length > move.Length)
                    {
                        firstPhaseAnswer = move;
                    }
                    
                }

                if (stopAlg)
                {
                    this.cube.DoRotatesByFormula(firstPhaseAnswer);

                    if (!Rotate.IsCubeSolved(ref this.cube))
                    {
                        stopAlg = false;

                        Parallel.For(0, 6, (i, state) => {
                            Cube iteratorCopy = (Cube)cube.Clone();
                            
                            foreach(string move in secondMoves[i])
                            {
                                //formulsCache.Add(move);
                                iteratorCopy.DoRotate(move);
                                string formula = move;

                                if (!Rotate.IsCubeSolved(ref iteratorCopy))
                                {
                                    SecondPhase(1, $"{move} ", iteratorCopy);
                                }
                                else
                                {
                                    stopAlg = true;
                                    formulsCache.Add(formula);
                                    state.Stop();
                                }

                                iteratorCopy = (Cube)cube.Clone();
                            }
                        });
                    }
                }
            }

            richTextBox1.AppendText("Answer: ");

            foreach(string move in formulsCache)
            {
                richTextBox1.AppendText(move + Environment.NewLine);
            }

            pictureBox1.BackColor = Color.Green;
            richTextBox1.AppendText($"Number attempts: {numberAttempts}" + Environment.NewLine);
            richTextBox1.AppendText("----------------" + Environment.NewLine);
            /*
            foreach (string str in formulsCache)
            {
                richTextBox1.AppendText($"{Environment.NewLine}{str}");
            }
            */
            time.Reset();
        }
    }
}
