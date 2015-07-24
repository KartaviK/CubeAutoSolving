using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace CubeAutoSolving
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            secondCube = move.ColorsSet();
            VizualizatingCube(secondCube);
        }


        Moves move = new Moves();
        int i, j, k;
        
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

        char[] ColorsStart_2 = new char[6]
            {
                'b', 
                'r', 
                'y',
                'o', 
                'w', 
                'g' 
            };

        public char[][,] secondCube = new char[6][,]{
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3]
        };

        // Метод для начала автономной сборки куба
        private void StartSolving(object sender, System.EventArgs e)
        {

        }

        // Методы кнопок для поворотов граней
        private void InizializatingCube_Click(object sender, System.EventArgs e)
        {
            secondCube = move.ColorsSet();
            VizualizatingCube(secondCube);
        }

        private void DoRightEdge(object sender, System.EventArgs e)
        {
            secondCube = move.R();
            VizualizatingCube(secondCube);
        }

        private void DoRightEdgeInvert(object sender, System.EventArgs e)
        {
            secondCube = move.Ri();
            VizualizatingCube(secondCube);
        }

        private void DoLeftEdge(object sender, System.EventArgs e)
        {
            secondCube = move.L();
            VizualizatingCube(secondCube);
        }

        private void DoLeftEdgeInvert(object sender, System.EventArgs e)
        {
            secondCube = move.Li();
            VizualizatingCube(secondCube);
        }

        private void DoFrontEdge(object sender, System.EventArgs e)
        {
            secondCube = move.F();
            VizualizatingCube(secondCube);
        }

        private void DoFrontEdgeInvert(object sender, System.EventArgs e)
        {
            secondCube = move.Fi();
            VizualizatingCube(secondCube);
        }

        private void DoBackEdge(object sender, System.EventArgs e)
        {
            secondCube = move.B();
            VizualizatingCube(secondCube);
        }

        private void DoBackEdgeInvert(object sender, System.EventArgs e)
        {
            secondCube = move.Bi();
            VizualizatingCube(secondCube);
        }

        private void DoUpEdge(object sender, System.EventArgs e)
        {
            secondCube = move.U();
            VizualizatingCube(secondCube);
        }

        private void DoUpEdgeInvert(object sender, System.EventArgs e)
        {
            secondCube = move.Ui();
            VizualizatingCube(secondCube);
        }

        private void DoDownEdge(object sender, System.EventArgs e)
        {
            secondCube = move.D();
            VizualizatingCube(secondCube);
        }

        private void DoDownEdgeInvert(object sender, System.EventArgs e)
        {
            secondCube = move.Di();
            VizualizatingCube(secondCube);
        }

        private void DoMiddleEdge(object sender, System.EventArgs e)
        {
            secondCube = move.M();
            VizualizatingCube(secondCube);
        }

        private void DoMiddleEdgeInvert(object sender, System.EventArgs e)
        {
            secondCube = move.Mi();
            VizualizatingCube(secondCube);
        }

        private void DoSecondMeddleEdge(object sender, System.EventArgs e)
        {
            secondCube = move.S();
            VizualizatingCube(secondCube);
        }

        private void DoSecondMiddleEdge(object sender, System.EventArgs e)
        {
            secondCube = move.Si();
            VizualizatingCube(secondCube);
        }

        private void DoThirdMiddleEdge(object sender, System.EventArgs e)
        {
            secondCube = move.E();
            VizualizatingCube(secondCube);
        }

        private void DoThirdMiddleEdgeInvert(object sender, System.EventArgs e)
        {
            secondCube = move.Ei();
            VizualizatingCube(secondCube);
        }

        // Метод для обработки массива и последующей его визуализации
        public void VizualizatingCube(char[][,] newCube)
        {
            for (this.i = 0; this.i < 6; this.i++)
                for (this.j = 0; this.j < 3; this.j++)
                    for (this.k = 0; this.k < 3; this.k++)
                    {
                        if (this.i == 0) // Первая грань / 0 / B
                        {
                            if (this.j == 0) // Первый столбец первой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.b_r_w.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.b_r.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.b_y_r.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 1) // Второй столбец первой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.b_w.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.b.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.b_y.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 2) // Третий столбец первой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.b_w_o.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.b_o.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.b_o_y.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                        }
                        else if (this.i == 1) // Вторая грань / 1 / L
                        {
                            if (this.j == 0) // Первый столбец третьей грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.r_w_b.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.r_w.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.r_g_w.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 1) // Второй столбец третьей грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.r_b.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.r.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.r_g.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 2) // Третий столбец третьей грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.r_b_y.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.r_y.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.r_y_g.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                        }
                        else if (this.i == 2) // Третья грань / 2 / U
                        {
                            if (this.j == 0) // Первый столбец третьей грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.y_r_b.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.y_r.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.y_g_r.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 1) // Второй столбец третьей грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.y_b.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.y.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.y_g.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 2) // Третий столбец третьей грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.y_b_o.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.y_o.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.y_o_g.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                        }
                        else if (this.i == 3) // Четвертая грань / 3 / R
                        {
                            if (this.j == 0) // Первый столбец четвертой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.o_y_b.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.o_y.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.o_g_y.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 1) // Второй столбец четвертой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.o_b.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.o.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.o_g.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 2) // Третий столбец четвертой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.o_b_w.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.o_w.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.o_w_g.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                        }
                        else if (this.i == 4) // Пятая грань / 4 / D
                        {
                            if (this.j == 0) // Первый столбец пятой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.w_o_b.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.w_o.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.w_g_o.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 1) // Второй столбец пятой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.w_b.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.w.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.w_g.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 2) // Третий столбец пятой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.w_b_r.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.w_r.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.w_r_g.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                        }
                        else if (this.i == 5) // Шестая грань / 5 / F
                        {
                            if (this.j == 0) // Первый столбец шестой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.g_r_y.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.g_r.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.g_w_r.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 1) // Второй столбец шестой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.g_y.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.g.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.g_w.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                            else if (this.j == 2) // Третий столбец шестой грани
                            {
                                if (this.k == 0) // Первый элемент
                                    this.g_y_o.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 1) // Второй элемент
                                    this.g_o.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                                else if (this.k == 2) // Третий Элемент
                                    this.g_o_w.BackColor =
                                        SwitchColor(newCube[this.i][this.j, this.k]);
                            }
                        }
                    }
        }

        // Метод для определения цвета по значению в массиве cube
        public Color SwitchColor(char element)
        {
            Color endResult = Color.Empty;
            
            // Сравнение
            switch (element)
            {
                case 'b':
                    endResult = this.systemColors[0];
                    break;
                case 'r':
                    endResult = this.systemColors[1];
                    break;
                case 'y':
                    endResult = this.systemColors[2];
                    break;
                case 'o':
                    endResult = this.systemColors[3];
                    break;
                case 'w':
                    endResult = this.systemColors[4];
                    break;
                case 'g':
                    endResult = this.systemColors[5];
                    break;
            }
            /*
            for (this.i = 0; this.i < 6; this.i++)
                if (this.ColorsStart_2[i] == element)
                    endResult = this.systemColors[this.i];
            */
            // Возвращение нужного цвета
            return endResult;
        }
    }
}
