using System;
using System.Drawing;
using System.Windows.Forms;

namespace CubeAutoSolving
{
    public partial class MainForm : Form
    {
        // Инициализация цвета для блоков picture
        Color[] systemColors =
        {
            Color.Blue,
            Color.Red,
            Color.Yellow,
            Color.Orange,
            Color.White,
            Color.Green
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Moves.ResetCube();

            VizualizatingCube();
        }

        // Метод для начала автономной сборки куба
        private void buttonStart_Click(object sender, EventArgs e)
        {
			LayerByLayer lbl = new LayerByLayer();
			lbl.SolveCube();
        }

        // Методы кнопок для поворотов граней
        private void buttonReset_Click(object sender, EventArgs e)
        {
            Moves.ResetCube();
            VizualizatingCube();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            Button moveButton = (Button)sender;
            string moveName = moveButton.Text;
            Moves.DoMovesByFormula(moveName);
            VizualizatingCube();
        }

        // Метод для обработки массива и последующей его визуализации
        public void VizualizatingCube()
        {
            for (int k = 0; k < 6; k++)
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (k == 0) // Первая грань / 0 / B
                        {
                            if (i == 0) // Первый столбец первой грани
                            {
                                if (j == 0) // Первый элемент
                                    b_r_w.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    b_r.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    b_y_r.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 1) // Второй столбец первой грани
                            {
                                if (j == 0) // Первый элемент
                                    b_w.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    b.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    b_y.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 2) // Третий столбец первой грани
                            {
                                if (j == 0) // Первый элемент
                                    b_w_o.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    b_o.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    b_o_y.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                        }
                        else if (k == 1) // Вторая грань / 1 / L
                        {
                            if (i == 0) // Первый столбец третьей грани
                            {
                                if (j == 0) // Первый элемент
                                    r_w_b.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    r_w.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    r_g_w.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 1) // Второй столбец третьей грани
                            {
                                if (j == 0) // Первый элемент
                                    r_b.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    r.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    r_g.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 2) // Третий столбец третьей грани
                            {
                                if (j == 0) // Первый элемент
                                    r_b_y.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    r_y.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    r_y_g.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                        }
                        else if (k == 2) // Третья грань / 2 / U
                        {
                            if (i == 0) // Первый столбец третьей грани
                            {
                                if (j == 0) // Первый элемент
                                    y_r_b.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    y_r.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    y_g_r.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 1) // Второй столбец третьей грани
                            {
                                if (j == 0) // Первый элемент
                                    y_b.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    y.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    y_g.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 2) // Третий столбец третьей грани
                            {
                                if (j == 0) // Первый элемент
                                    y_b_o.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    y_o.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    y_o_g.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                        }
                        else if (k == 3) // Четвертая грань / 3 / R
                        {
                            if (i == 0) // Первый столбец четвертой грани
                            {
                                if (j == 0) // Первый элемент
                                    o_y_b.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    o_y.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    o_g_y.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 1) // Второй столбец четвертой грани
                            {
                                if (j == 0) // Первый элемент
                                    o_b.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    o.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    o_g.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 2) // Третий столбец четвертой грани
                            {
                                if (j == 0) // Первый элемент
                                    o_b_w.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    o_w.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    o_w_g.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                        }
                        else if (k == 4) // Пятая грань / 4 / D
                        {
                            if (i == 0) // Первый столбец пятой грани
                            {
                                if (j == 0) // Первый элемент
                                    w_o_b.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    w_o.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    w_g_o.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 1) // Второй столбец пятой грани
                            {
                                if (j == 0) // Первый элемент
                                    w_b.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    w.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    w_g.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 2) // Третий столбец пятой грани
                            {
                                if (j == 0) // Первый элемент
                                    w_b_r.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    w_r.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    w_r_g.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                        }
                        else if (k == 5) // Шестая грань / 5 / F
                        {
                            if (i == 0) // Первый столбец шестой грани
                            {
                                if (j == 0) // Первый элемент
                                    g_r_y.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    g_r.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    g_w_r.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 1) // Второй столбец шестой грани
                            {
                                if (j == 0) // Первый элемент
                                    g_y.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    g.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    g_w.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                            else if (i == 2) // Третий столбец шестой грани
                            {
                                if (j == 0) // Первый элемент
                                    g_y_o.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 1) // Второй элемент
                                    g_o.BackColor = Moves.cube[k][i, j].ToColor();
                                else if (j == 2) // Третий Элемент
                                    g_o_w.BackColor = Moves.cube[k][i, j].ToColor();
                            }
                        }
                    }
        }
	}

    public static class Extentions
    {
        public static Color ToColor(this char character)
        {
            Color color = new Color();

            switch (character)
            {
                case 'b':
                    color = Color.Blue;
                    break;
                case 'r':
                    color = Color.Red;
                    break;
                case 'y':
                    color = Color.Yellow;
                    break;
                case 'o':
                    color = Color.Orange;
                    break;
                case 'w':
                    color = Color.White;
                    break;
                case 'g':
                    color = Color.Green;
                    break;
            }

            return color;
        }
    }
}
