using System;
using System.Drawing;
using System.Windows.Forms;

namespace RubiksAutoSolve
{
	public partial class MainForm : Form
	{
        public Cube mainCube = new Cube();
        
		Color[] systemColors =
		{
			Color.Blue,
			Color.Red,
			Color.Yellow,
			Color.Orange,
			Color.White,
			Color.Green
		};

		PictureBox[][,] pictureElements;

		public MainForm()
		{
			InitializeComponent();

			pictureElements = new PictureBox[6][,]
			{
				new PictureBox[3, 3]
				{
					{
						y_r_b,
						y_r,
						y_g_r
					},
					{
						y_b,
						y,
						y_g
					},
					{
						y_b_o,
						y_o,
						y_o_g
					},
				},
				new PictureBox[3, 3]
				{
					{
						r_b_y,
						r_b,
						r_w_b
					},
					{
						r_y,
						r,
						r_w
					},
					{
						r_y_g,
						r_g,
						r_g_w
					},
				},
				new PictureBox[3, 3]
				{
					{
						g_r_y,
						g_r,
						g_w_r
					},
					{
						g_y,
						g,
						g_w
					},
					{
						g_y_o,
						g_o,
						g_o_w
					},
				},
				new PictureBox[3, 3]
				{
					{
						o_g_y,
						o_g,
						o_w_g
					},
					{
						o_y,
						o,
						o_w
					},
					{
						o_y_b,
						o_b,
						o_b_w
					},
				},
				new PictureBox[3, 3]
				{
					{
						b_o_y,
						b_o,
						b_w_o
					},
					{
						b_y,
						b,
						b_w
					},
					{
						b_y_r,
						b_r,
						b_r_w
					},
				},
				new PictureBox[3, 3]
				{
					{
						w_r_g,
						w_r,
						w_b_r
					},
					{
						w_g,
						w,
						w_b
					},
					{
						w_g_o,
						w_o,
						w_o_b
					},
				},
			};
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
            mainCube.Reset();

			RefreshCube();
		}
        
		private void startButton_Click(object sender, EventArgs e)
		{
            SolveForm dataForm = new SolveForm(mainCube);
            dataForm.ShowDialog();
            dataForm.Close();
			RefreshCube();
		}
        
		private void resetButton_Click(object sender, EventArgs e)
		{
			scrambleBox.Text = "";
            this.mainCube.Reset();
            RefreshCube();
		}

		private void scrambleButton_Click(object sender, EventArgs e)
		{
            if (String.IsNullOrWhiteSpace(scrambleBox.Text))
            {
                scrambleBox.Text = mainCube.ScrambleCube();
            }
            else
            {
                try
                {
                    mainCube.DoRotatesByFormula(mainCube.ConvertScramble(scrambleBox.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

			RefreshCube();
		}

		private void moveButton_Click(object sender, EventArgs e)
		{
			Button moveButton = (Button)sender;
			string moveName = moveButton.Text;
			mainCube.DoRotatesByFormula(moveName);
			RefreshCube();
		}
        
		public void RefreshCube()
		{
			for (int k = 0; k < 6; k++)
			{
				for (int i = 0; i < 3; i++)
				{ 
					for (int j = 0; j < 3; j++)
					{
                        pictureElements[k][i, j].BackColor = this.mainCube.edge[k][i, j].ToColor();
					}
				}
			}
		}
	}

	public static class Extentions
	{
		public static Color ToColor(this string character)
		{
			Color color = new Color();

			switch (character)
			{
				case "y":
					color = Color.Yellow;
					break;
				case "r":
					color = Color.Red;
					break;
				case "g":
					color = Color.Green;
					break;
				case "o":
					color = Color.Orange;
					break;
				case "b":
					color = Color.Blue;
					break;
				case "w":
					color = Color.White;
					break;
			}

			return color;
		}
	}
}
