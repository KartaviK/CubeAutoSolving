using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

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
                    formula = pattern + moves[turn][variant];
                    Rotate.DoMovesByFormula(formula);

                    richTextBox1.AppendText(formula + Environment.NewLine);
                    numberAttempts++;

                    if (position < this.position && !stopAlg)
                        Generate(position + 1, pattern + moves[turn][variant] + " ");
                }
            }
        }
        
        private static string[] firstMoves =
        {
            "U", "D", "R", "L", "F", "B",
        };

        private static string[] secondMoves =
        {
            "U", "D", "R2", "L2", "F2", "B2",
        };

        private string[][] cacheCube;
        private string formula;

        private void Phase(int position, string pattern)
        {
            int last = position - 1;
            int penultimate = position - 2;
            string[] elements = pattern.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string formula = "";

            for (int turn = 0; turn < firstMoves.Length; turn++)
            {
                if (elements.Length >= 1)
                {
                    if (elements[last] == firstMoves[turn])
                    {
                        if (turn != firstMoves.Length - 1)
                            turn++;
                        else
                            continue;
                    }
                }

                if (elements.Length >= 2)
                {
                    if (elements[penultimate] == firstMoves[turn])
                    {

                    }
                }

                for (int variant = 0; variant < moves[turn].Length; variant++)
                {
                    formula = pattern + moves[turn][variant];
                    Rotate.DoMovesByFormula(formula);

                    richTextBox1.AppendText(formula + Environment.NewLine);
                    numberAttempts++;

                    if (position < this.position)
                        Generate(position + 1, pattern + moves[turn][variant] + " ");
                }
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            numberAttempts = 0;
            //LayerByLayer lbl = new LayerByLayer();
            pictureBox1.BackColor = Color.Red;
            this.Refresh();

            for (position = 0; position < 20; position++)
            {
                Generate(0, "");
            }

            pictureBox1.BackColor = Color.Green;
        }
    }
}
