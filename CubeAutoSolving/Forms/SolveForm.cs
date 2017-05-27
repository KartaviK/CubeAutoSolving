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
        private ulong numberAttempts = 0;
        public string firstPhaseAnswer = "";
        public bool stopAlg = false;
        private List<string> formulsCache = new List<string>();
        private List<string[][,]> cacheCube = new List<string[][,]>();
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
            new string[] { "U", "Ui", "U2" },
            new string[] { "D", "Di", "D2" },
            new string[] { "R2" },
            new string[] { "L2" },
            new string[] { "F2" },
            new string[] { "B2" }
        };

        private Stopwatch time = new Stopwatch();/*
        private string[][,] cacheCube = new string[6][,]
        {
            new string[3,3],
            new string[3,3],
            new string[3,3],
            new string[3,3],
            new string[3,3],
            new string[3,3]
        };*/

        private bool Phase(int position, string pattern, string[][,] cube)
        {
            if (stopAlg)
            {
                return false;
            }

            formulsCache.Add(pattern);
            //cacheCube.Add(cube);
            
            if (SimpleRotate.IsCubeSolved(ref cube))
            {
                formulsCache.Add(pattern);
                stopAlg = true;

                return true;
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
                
                for (int variant = 0; variant < firstMoves[turn].Length; variant++)
                {
                    string[][,] tempCube = new string[6][,]
                    {
                        new string[3,3],
                        new string[3,3],
                        new string[3,3],
                        new string[3,3],
                        new string[3,3],
                        new string[3,3]
                    };

                    tempCube = SimpleRotate.CopyCube(ref cube);

                    SimpleRotate.DoMove(firstMoves[turn][variant], ref tempCube);

                    if (position < this.position)
                        return Phase(position + 1, $"{pattern}{firstMoves[turn][variant]} ", tempCube);
                }
            }

            return false;
        }
        
        private void solveButton_Click(object sender, EventArgs e)
        {
            if (SimpleRotate.IsCubeSolved(ref this.cube))
            {
                richTextBox1.AppendText($"Cube is not scrambled{Environment.NewLine}");

                return;
            }

            string[][,] firstCopy = new string[6][,]
            {
                new string[3,3],
                new string[3,3],
                new string[3,3],
                new string[3,3],
                new string[3,3],
                new string[3,3]
            };

            for (int i = 0; i < 6; i++)
            {
                Array.Copy(this.cube.edge[i], firstCopy[i], this.cube[i].Length);
            }

            time.Start();
            pictureBox1.BackColor = Color.Red;
            this.Refresh();
            numberAttempts = 0;
            this.position = Convert.ToInt32(textBox1.Text);
            
            
            Parallel.For(0, 6, (i, state) => {
                string[][,] iteratorCopy = new string[6][,]
                {
                    new string[3,3],
                    new string[3,3],
                    new string[3,3],
                    new string[3,3],
                    new string[3,3],
                    new string[3,3]
                };

                iteratorCopy = SimpleRotate.CopyCube(ref firstCopy);

                for (int z = 0; z < 3; z++)
                {
                    SimpleRotate.DoMove(firstMoves[i][z], ref iteratorCopy);
                    //formulsCache.Add(firstMoves[i][z] + Environment.NewLine);
                    
                    if (!SimpleRotate.CheckFirstPhase(ref iteratorCopy))
                    {
                        if (Phase(1, $"{firstMoves[i][z]} ", iteratorCopy))
                        {

                        }
                    }
                    else
                    {
                        firstPhaseAnswer = $"{firstMoves[i][z]} ";
                        state.Stop();
                    }

                    formulsCache.Add(firstMoves[i][z]);
                    //cacheCube.Add(iteratorCopy);

                    for (int q = 0; q < 6; q++)
                    {
                        Array.Copy(iteratorCopy[q], firstCopy[q], iteratorCopy[q].Length);
                    }
                }
            });
            
            time.Stop();
            
            richTextBox1.AppendText(time.Elapsed.TotalSeconds.ToString() + Environment.NewLine);
            richTextBox1.AppendText(firstPhaseAnswer + Environment.NewLine);
            pictureBox1.BackColor = Color.Green;

            int a = 0;
            
            foreach(string str in formulsCache)
            {
                richTextBox1.AppendText($"{str}{Environment.NewLine}");
                /*
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int z = 0; z < 3; z++)
                        {
                            //richTextBox1.AppendText($"{(cacheCube[a])[i][j, z]} ");
                        }
                    }

                    richTextBox1.AppendText($"{Environment.NewLine}");
                }
                */
                //a++;
            }
            
            time.Reset();
        }
    }
}
