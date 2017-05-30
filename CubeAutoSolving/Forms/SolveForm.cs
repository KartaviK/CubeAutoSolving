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
        private List<string> formulsCache = new List<string>(); // TODO
        private List<string[][,]> cacheCube = new List<string[][,]>(); // TODO
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

        private Stopwatch time = new Stopwatch();

        private void Phase(int position, string pattern, Cube cube)
        {
            if (stopAlg)
            {
                return;
            }

            formulsCache.Add(pattern);
            
            if (SimpleRotate.IsCubeSolved(ref cube))
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
                    Cube tempCube = (Cube)cube.Clone();
                    tempCube.DoRotate(firstMoves[turn][variant]);

                    if (position < this.position)
                        Phase(position + 1, $"{pattern}{firstMoves[turn][variant]} ", (Cube)tempCube.Clone());
                }
            }
        }
        
        private void solveButton_Click(object sender, EventArgs e)
        {
            if (SimpleRotate.IsCubeSolved(ref cube))
            {
                richTextBox1.AppendText($"Cube is not scrambled{Environment.NewLine}");

                return;
            }

            Cube firstCopy = (Cube)cube.Clone();
            pictureBox1.BackColor = Color.Red;
            this.Refresh();
            numberAttempts = 0;
            this.position = Convert.ToInt32(textBox1.Text);

            time.Start();
            Parallel.For(0, 6, (i, state) => {
                Cube iteratorCopy = (Cube)cube.Clone();

                for (int z = 0; z < 3; z++)
                {
                    iteratorCopy.DoRotate(firstMoves[i][z]);
                    
                    if (!SimpleRotate.CheckFirstPhase(ref iteratorCopy))
                    {
                        Phase(1, $"{firstMoves[i][z]} ", iteratorCopy);
                    }
                    else
                    {
                        firstPhaseAnswer = $"{firstMoves[i][z]} ";
                        state.Stop();
                    }

                    formulsCache.Add(firstMoves[i][z]);
                }
            });
            
            time.Stop();
            
            richTextBox1.AppendText(time.Elapsed.TotalSeconds.ToString() + Environment.NewLine);
            richTextBox1.AppendText(firstPhaseAnswer + Environment.NewLine);
            pictureBox1.BackColor = Color.Green;
            
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
