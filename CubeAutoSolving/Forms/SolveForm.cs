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
        public SolveForm()
		{
			InitializeComponent();
        }
        
        private int position = 0;
        private ulong numberAttempts = 0;
        public string firstPhaseAnswer = "";
        public bool stopAlg = false;
        private List<string> formulsCache = new List<string>();
        private string[][] firstMoves =
        {
            new string[] { "U", "Ui", "U2" },
            new string[] { "D", "Di", "D2" },
            new string[] { "R", "Ri", "R2" },
            new string[] { "L", "Li", "L2" },
            new string[] { "F", "Fi", "F2" },
            new string[] { "B", "Bi", "B2" }
        };

        private string[][] secondMoves =
        {
            new string[] { "U", "Ui", "U2" },
            new string[] { "D", "Di", "D2" },
            new string[] { "R2" },
            new string[] { "L2" },
            new string[] { "F2" },
            new string[] { "B2" }
        };

        private Stopwatch time = new Stopwatch();
        private char[][,] cacheCube = new char[6][,]
        {
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3]
        };

        private void Phase(int position, string pattern, char[][,] cube)
        {
            if (stopAlg)
            {
                return;
            }

            if (SimpleRotate.CheckFirstPhase(ref cube))
            {
                firstPhaseAnswer = pattern;
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
                        else if(turn == 1 || turn == 3)
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

                string formula = "";
                
                for (int variant = 0; variant < firstMoves[turn].Length; variant++)
                {
                    formula = pattern + firstMoves[turn][variant];
                    Rotate.DoMovesByFormula(firstMoves[turn][variant], ref cube);

                    if (position < this.position)
                        Phase(position + 1, $"{formula} ", cube);
                }
            }
        }
        
        private void solveButton_Click(object sender, EventArgs e)
        {
            char[][,] cc = new char[6][,]
                {
                    new char[3,3],
                    new char[3,3],
                    new char[3,3],
                    new char[3,3],
                    new char[3,3],
                    new char[3,3]
                };

            for (int i = 0; i < 6; i++)
            {
                Array.Copy(Rotate.cube[i], cc[i], Rotate.cube[i].Length);
            }

            SimpleRotate.Ri(ref cc);

            time.Start();
            pictureBox1.BackColor = Color.Red;
            this.Refresh();
            numberAttempts = 0;
            this.position = Convert.ToInt32(textBox1.Text);
            
            Parallel.For(0, 6, (i, state) => {
                char[][,] bb = new char[6][,]
                {
                    new char[3,3],
                    new char[3,3],
                    new char[3,3],
                    new char[3,3],
                    new char[3,3],
                    new char[3,3]
                };

                for (int j = 0; j < 6; j++)
                {
                    Array.Copy(cc[j], bb[j], cc[j].Length);
                }

                for (int z = 0; z < 3; z++)
                {
                    Rotate.DoMovesByFormula(firstMoves[i][z], ref bb);

                    if (!SimpleRotate.CheckFirstPhase(ref bb))
                    {
                        Phase(1, $"{firstMoves[i][z]} ", bb);
                    }
                    else
                    {
                        firstPhaseAnswer = $"{firstMoves[i][z]} ";
                        state.Stop();
                    }
                    
                    for (int q = 0; q < 6; q++)
                    {
                        Array.Copy(bb[q], cc[q], cc[q].Length);
                    }
                }
            });
            
            time.Stop();
            
            richTextBox1.AppendText(time.Elapsed.TotalSeconds.ToString() + Environment.NewLine);
            richTextBox1.AppendText(firstPhaseAnswer + Environment.NewLine);
            pictureBox1.BackColor = Color.Green;

            time.Reset();
        }
    }
}
