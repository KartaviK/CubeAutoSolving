using System;
using System.Drawing;
using System.Reflection;

namespace CubeAutoSolving
{
    class Moves 
    {
        // Второстепенные переменные
        int i, j, k;
        // Переменная для свапа элементов char
        char cache;
        // Одномерный массив для ликвидация последовательности в формуле внутренних блоков
        int[] denie_i = new int[8];

        //  Инициализация
        // Инициализация массива
        public char[][,] cube = new char[6][,]{
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3],
            new char[3,3]
        };

        public char[][,] ColorsSet()
        {
            Form1 form = new Form1();

            // Одномерный массив чаров для инициализации массива куба
            char[] ColorsStart = new char[6]
            {
                'b', 
                'r', 
                'y',
                'o', 
                'w', 
                'g' 
            };

            // Заполнения куба начальными данными
            for (this.i = 0; this.i < 6; this.i++)
                for (this.j = 0; this.j < 3; this.j++)
                    for (this.k = 0; this.k < 3; this.k++)
                        this.cube[this.i][this.j, this.k] = ColorsStart[this.i];

            return this.cube;
        }
        /*
        // Вызов методов по строковой формуле (рефлексия)
        public void DoMovesByFormula(string className, string formula)
        {
            string[] moves = formula.Split(' ');
            Type classType = Type.GetType(className);
            foreach (string move in moves)
            {
                try
                {
                    MethodInfo moveMethod = classType.GetMethod(move);
                    moveMethod.Invoke(null, null);
                }
                catch(System.NullReferenceException)
                {

                }
            }
        }
        */
        //   Методы для движения граней
        //  Стандартные движения
        // Поворот задней грани по часовой стрелки
        public char[][,] B()
        {
            // Вызов мтетода для внутренних блоков
            DoMoveInside(
                0, // Сторона
                true // Поворот по/против часовой стрелки (true/false)
            ); 
            // Вызов метода для внешних блоков
            DoMoveOutside(
                new int[]
                {
                    2, // Сторона 1 для внешнего поворота
                    3, // Сторона 2 для внешнего поворота
                    4, // Сторона 3 для внешнего поворота
                    1  // Сторона 4 для внешнего поворота
                }, // Одномерный массив для передачи адресов сторон
                new int[] // 8 элементов
                {
                    0, 0,
                    0, 0,
                    0, 0,
                    0, 0
                }, // Одномерный массив для: фиксирования адреса / обратной последовательности адреса
                new bool[] // 8 элементов
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                } // Одномерный bool-массив для инициализации массива ликвидации последовательности
            );
            return this.cube;
        }

        // Поворот задней грани против часовой стрелки
        public char[][,] Bi()
        {
            DoMoveInside(
                0,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    2, 
                    1, 
                    4, 
                    3
                },
                new int[]
                {
                    0, 0,
                    0, 0,
                    0, 0,
                    0, 0
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }

        // Поворот левой грани по часовой стрелке
        public char[][,] L()
        {
            DoMoveInside(
                1,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    2,
                    0,
                    4
                },
                new int[] 
                {
                    0, 2,
                    0, 2,
                    0, 2,
                    2, 0
                },
                new bool[]
                {
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот левой грани против часовой стрелки
        public char[][,] Li()
        {
            DoMoveInside(
                1,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    4,
                    0,
                    2
                },
                new int[]
                {
                    0, 2,
                    2, 0,
                    0, 2,
                    0, 2
                },
                new bool[]
                {
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот верхней грани по часовой стрелке
        public char[][,] U()
        {
            DoMoveInside(
                2,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    5, 
                    3, 
                    0, 
                    1
                },
                new int[]
                {
                    0, 0,
                    0, 2,
                    2, 2,
                    2, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот верхней грани против часовой стрелки 
        public char[][,] Ui()
        {
            DoMoveInside(
                2,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    1, 
                    0, 
                    3
                },
                new int[]
                {
                    0, 0,
                    2, 0,
                    2, 2,
                    0, 2
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот правой грани по часовой стрелке        
        public char[][,] R()
        {
            DoMoveInside(
                3,
                true
            );
            DoMoveOutside(                
                new int[]
                {                   
                    5,
                    4, 
                    0, 
                    2                 
                }, 
                new int[] 
                {
                    2, 0,
                    0, 2,
                    2, 0,
                    2, 0
                },
                new bool[]
                {
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот правой грани против часовой стрелки
        public char[][,] Ri()
        {
            DoMoveInside(
                3,
                false
            );
            DoMoveOutside(                
                new int[] 
                {
                    5,
                    2,
                    0, 
                    4
                },
                new int[]
                {
                    2, 0,
                    2, 0,
                    2, 0,
                    0, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот нижней грани по часовой стрелки
        public char[][,] D()
        {
            DoMoveInside(
                4,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    1, 
                    0, 
                    3
                },
                new int[]
                {
                    2, 2,
                    0, 2,
                    0, 0,
                    2, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот нижней грани против часовой стрелки
        public char[][,] Di()
        {
            DoMoveInside(
                4,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    3,
                    0, 
                    1
                },
                new int[]
                {
                    2, 2,
                    2, 0,
                    0, 0,
                    0, 2
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот фронтовой грани по часовой стрелки
        public char[][,] F()
        {
            DoMoveInside(
                5,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    3,
                    2, 
                    1
                },
                new int[]
                {
                    2, 2,
                    2, 2,
                    2, 2,
                    2, 2
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }

        // Поворот фронтовой грани против часовой стрелки
        public char[][,] Fi()
        {
            DoMoveInside(
                5,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    4, 
                    1, 
                    2, 
                    3
                },
                new int[]
                {
                    2, 2,
                    2, 2,
                    2, 2,
                    2, 2
                },
                new bool[] 
                { 
                    false, true,
                    false, true,                
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }
        
        //   Нестандартные движения
        //  Повороты центральных слоев
        // Движение центральной стороны относительно левой стороны по часовой стрелке
        public char[][,] M()
        {
            DoMoveOutside(
                new int[]
                {
                    4,
                    5,
                    2,
                    0
                },
                new int[]
                {
                    1, 0,
                    1, 2,
                    1, 2,
                    1, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Движение центральной стороны относительно левой стороны против часовой стрелки
        public char[][,] Mi()
        {
            DoMoveOutside(
                new int[]
                {
                    4,
                    0,
                    2,
                    5
                },
                new int[]
                {
                    1, 0,
                    1, 2,
                    1, 2,
                    1, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Движение центральной стороны относительно фронтальной стороны по часовой стрелке
        public char[][,] S()
        {
            DoMoveOutside(
                new int[]
                {
                    4,
                    1,
                    2,
                    3
                },
                new int[]
                {
                    0, 1,
                    0, 1,
                    0, 1,
                    0, 1
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }

        // Движение центральной стороны относительно фронтальной стороны против часовой стрелки
        public char[][,] Si()
        {
            DoMoveOutside(
                new int[]
                {
                    4,
                    3,
                    2,
                    1
                },
                new int[]
                {
                    0, 1,
                    0, 1,
                    0, 1,
                    0, 1
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }

        // Движение центральной стороны относительно нижней стороны по часовой стрелке
        public char[][,] E()
        {
            DoMoveOutside(
                new int[]
                {
                    5,
                    1,
                    0,
                    3
                },
                new int[]
                {
                    0, 1,
                    1, 0,
                    0, 1,
                    1, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        // Движение центральной стороны относительно нижней стороны против часовой стрелки
        public char[][,] Ei()
        {
            DoMoveOutside(
                new int[]
                {
                    5,
                    3,
                    0,
                    1
                },
                new int[]
                {
                    0, 1,
                    1, 0,
                    0, 1,
                    1, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        //  Поворот + буква 'w'
        // Поворот правой стороны + среднего слоя по часовой стрелке
        public char[][,] Rw()
        {
            DoMoveInside(
                3,
                true
            );
            DoMoveOutside(
                new int[]
                {                   
                    5,
                    4, 
                    0, 
                    2                 
                },
                new int[] 
                {
                    2, 0,
                    0, 2,
                    2, 0,
                    2, 0
                },
                new bool[]
                {
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    0,
                    2,
                    5
                },
                new int[]
                {
                    1, 0,
                    1, 2,
                    1, 2,
                    1, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот правой стороны + среднего слоя ппротив часовой стрелки
        public char[][,] Rwi()
        {
            DoMoveInside(
                3,
                false
            );
            DoMoveOutside(
                new int[] 
                {
                    5,
                    2,
                    0, 
                    4
                },
                new int[]
                {
                    2, 0,
                    2, 0,
                    2, 0,
                    0, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    5,
                    2,
                    0
                },
                new int[]
                {
                    1, 0,
                    1, 2,
                    1, 2,
                    1, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот левой стороны + среднего слоя по часовой стрелке
        public char[][,] Lw()
        {
            DoMoveInside(
                1,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    2,
                    0,
                    4
                },
                new int[] 
                {
                    0, 2,
                    0, 2,
                    0, 2,
                    2, 0
                },
                new bool[]
                {
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    5,
                    2,
                    0
                },
                new int[]
                {
                    1, 0,
                    1, 2,
                    1, 2,
                    1, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот левой стороны + среднего слоя против часовой стрелки
        public char[][,] Lwi()
        {
            DoMoveInside(
                1,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    4,
                    0,
                    2
                },
                new int[]
                {
                    0, 2,
                    2, 0,
                    0, 2,
                    0, 2
                },
                new bool[]
                {
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    0,
                    2,
                    5
                },
                new int[]
                {
                    1, 0,
                    1, 2,
                    1, 2,
                    1, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот фронтовой стороны + среднего слоя по часовой стрелке
        public char[][,] Fw()
        {
            DoMoveInside(
                5,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    3,
                    2, 
                    1
                },
                new int[]
                {
                    2, 2,
                    2, 2,
                    2, 2,
                    2, 2
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    1,
                    2,
                    3
                },
                new int[]
                {
                    0, 1,
                    0, 1,
                    0, 1,
                    0, 1
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }

        // Поворот фронтовой стороны + среднего слоя против часовой стрелки
        public char[][,] Fwi()
        {
            DoMoveInside(
                5,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    4, 
                    1, 
                    2, 
                    3
                },
                new int[]
                {
                    2, 2,
                    2, 2,
                    2, 2,
                    2, 2
                },
                new bool[] 
                { 
                    false, true,
                    false, true,                
                    false, true,
                    false, true
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    3,
                    2,
                    1
                },
                new int[]
                {
                    0, 1,
                    0, 1,
                    0, 1,
                    0, 1
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }

        // Поворот задней стороны + среднего слоя по часовой стрелке
        public char[][,] Bw()
        {
            DoMoveInside(
                0, 
                true 
            );
            DoMoveOutside(
                new int[]
                {
                    2, 
                    3, 
                    4, 
                    1  
                }, 
                new int[] 
                {
                    0, 0,
                    0, 0,
                    0, 0,
                    0, 0
                }, 
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                } 
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    3,
                    2,
                    1
                },
                new int[]
                {
                    0, 1,
                    0, 1,
                    0, 1,
                    0, 1
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }

        // Поворот задней стороны + среднего слоя против часовой стрелки
        public char[][,] Bwi()
        {
            DoMoveInside(
                0,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    2, 
                    1, 
                    4, 
                    3
                },
                new int[]
                {
                    0, 0,
                    0, 0,
                    0, 0,
                    0, 0
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    1,
                    2,
                    3
                },
                new int[]
                {
                    0, 1,
                    0, 1,
                    0, 1,
                    0, 1
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }

        // Поворот верхней стороны + среднего слоя по часовой стрелке
        public char[][,] Uw()
        {
            DoMoveInside(
                2,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    5, 
                    3, 
                    0, 
                    1
                },
                new int[]
                {
                    0, 0,
                    0, 2,
                    2, 2,
                    2, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    3,
                    0,
                    1
                },
                new int[]
                {
                    0, 1,
                    1, 0,
                    0, 1,
                    1, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот верхней стороны + среднего слоя против часовой стрелки
        public char[][,] Uwi()
        {
            DoMoveInside(
                2,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    1, 
                    0, 
                    3
                },
                new int[]
                {
                    0, 0,
                    2, 0,
                    2, 2,
                    0, 2
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    1,
                    0,
                    3
                },
                new int[]
                {
                    0, 1,
                    1, 0,
                    0, 1,
                    1, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот нижней стороны + среднего слоя по часовой стрелке
        public char[][,] Dw()
        {
            DoMoveInside(
                4,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    1, 
                    0, 
                    3
                },
                new int[]
                {
                    2, 2,
                    0, 2,
                    0, 0,
                    2, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    1,
                    0,
                    3
                },
                new int[]
                {
                    0, 1,
                    1, 0,
                    0, 1,
                    1, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот нижней стороны + среднего слоя против часовой стрелки
        public char[][,] Dwi()
        {
            DoMoveInside(
                4,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    1, 
                    0, 
                    3
                },
                new int[]
                {
                    2, 2,
                    0, 2,
                    0, 0,
                    2, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    3,
                    0,
                    1
                },
                new int[]
                {
                    0, 1,
                    1, 0,
                    0, 1,
                    1, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        //  Повороты всего куба
        // Поворот куба относительно правой стороны по часовой стрелке
        public char[][,] x()
        {
            DoMoveInside(
                3,
                true
            );
            DoMoveOutside(
                new int[]
                {                   
                    5,
                    4, 
                    0, 
                    2                 
                },
                new int[] 
                {
                    2, 0,
                    0, 2,
                    2, 0,
                    2, 0
                },
                new bool[]
                {
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    0,
                    2,
                    5
                },
                new int[]
                {
                    1, 0,
                    1, 2,
                    1, 2,
                    1, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            DoMoveInside(
                1,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    4,
                    0,
                    2
                },
                new int[]
                {
                    0, 2,
                    2, 0,
                    0, 2,
                    0, 2
                },
                new bool[]
                {
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот куба относительно правой стороны против часовой стрелки
        public char[][,] xi()
        {
            DoMoveInside(
                3,
                false
            );
            DoMoveOutside(
                new int[] 
                {
                    5,
                    2,
                    0, 
                    4
                },
                new int[]
                {
                    2, 0,
                    2, 0,
                    2, 0,
                    0, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    5,
                    2,
                    0
                },
                new int[]
                {
                    1, 0,
                    1, 2,
                    1, 2,
                    1, 2
                },
                new bool[] 
                { 
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            DoMoveInside(
                1,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    2,
                    0,
                    4
                },
                new int[] 
                {
                    0, 2,
                    0, 2,
                    0, 2,
                    2, 0
                },
                new bool[]
                {
                    true, false,
                    true, false,
                    true, false,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот куба относительно верхней стороны по часовой стрелке
        public char[][,] y()
        {
            DoMoveInside(
                2,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    5, 
                    3, 
                    0, 
                    1
                },
                new int[]
                {
                    0, 0,
                    0, 2,
                    2, 2,
                    2, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    3,
                    0,
                    1
                },
                new int[]
                {
                    0, 1,
                    1, 0,
                    0, 1,
                    1, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            DoMoveInside(
                4,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    3,
                    0, 
                    1
                },
                new int[]
                {
                    2, 2,
                    2, 0,
                    0, 0,
                    0, 2
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот куба относительно верхней стороны против часовой стрелки
        public char[][,] yi()
        {
            DoMoveInside(
                2,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    1, 
                    0, 
                    3
                },
                new int[]
                {
                    0, 0,
                    2, 0,
                    2, 2,
                    0, 2
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    1,
                    0,
                    3
                },
                new int[]
                {
                    0, 1,
                    1, 0,
                    0, 1,
                    1, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            DoMoveInside(
                4,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    5,
                    1, 
                    0, 
                    3
                },
                new int[]
                {
                    2, 2,
                    0, 2,
                    0, 0,
                    2, 0
                },
                new bool[] 
                { 
                    false, true,
                    true, false,
                    false, true,
                    true, false
                }
            );
            return this.cube;
        }

        // Поворот куба относительно фронтальной стороны по часовой стрелке
        public char[][,] z()
        {
            DoMoveInside(
                5,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    3,
                    2, 
                    1
                },
                new int[]
                {
                    2, 2,
                    2, 2,
                    2, 2,
                    2, 2
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    1,
                    2,
                    3
                },
                new int[]
                {
                    0, 1,
                    0, 1,
                    0, 1,
                    0, 1
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            DoMoveInside(
                0,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    2, 
                    1, 
                    4, 
                    3
                },
                new int[]
                {
                    0, 0,
                    0, 0,
                    0, 0,
                    0, 0
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }

        // Поворот куба относительно фронтальной стороны против часовой стрелки
        public char[][,] zi()
        {
            DoMoveInside(
                5,
                false
            );
            DoMoveOutside(
                new int[]
                {
                    4, 
                    1, 
                    2, 
                    3
                },
                new int[]
                {
                    2, 2,
                    2, 2,
                    2, 2,
                    2, 2
                },
                new bool[] 
                { 
                    false, true,
                    false, true,                
                    false, true,
                    false, true
                }
            );
            DoMoveOutside(
                new int[]
                {
                    4,
                    3,
                    2,
                    1
                },
                new int[]
                {
                    0, 1,
                    0, 1,
                    0, 1,
                    0, 1
                },
                new bool[] 
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            DoMoveInside(
                0,
                true
            );
            DoMoveOutside(
                new int[]
                {
                    2,
                    3,
                    4,
                    1
                },
                new int[]
                {
                    0, 0,
                    0, 0,
                    0, 0,
                    0, 0
                },
                new bool[]
                { 
                    false, true,
                    false, true,
                    false, true,
                    false, true
                }
            );
            return this.cube;
        }
        
        // Универсальный метод для поворота блоков грани
        public void DoMoveOutside(
            int[] cubeFace,
            int[] fixedNumber, 
            bool[] denie
        )
        {
            // Поворот внешних блоков
            for (this.i = 0; this.i < 3; this.i++)
            {
                // Определение фиксирования
                for (this.j = 0; this.j < 8; this.j++)
                    denie_i[this.j] = (denie[this.j] ? this.i : 0);

                // cache = cube[0]
                this.cache =  this.cube[cubeFace[0]]
                [
                    Math.Abs(fixedNumber[0] - this.i + denie_i[0]),
                    Math.Abs(fixedNumber[1] - this.i + denie_i[1])
                ];
                // cube[0] = cube[1]                        
                this.cube[cubeFace[0]]
                [
                    Math.Abs(fixedNumber[0] - this.i + denie_i[0]),                     
                    Math.Abs(fixedNumber[1] - this.i + denie_i[1])
                ] = this.cube[cubeFace[1]]
                [
                    Math.Abs(fixedNumber[2] - this.i + denie_i[2]),
                    Math.Abs(fixedNumber[3] - this.i + denie_i[3])
                ];
                // cube[1] = cube[2]
                this.cube[cubeFace[1]]
                [
                    Math.Abs(fixedNumber[2] - this.i + denie_i[2]),
                    Math.Abs(fixedNumber[3] - this.i + denie_i[3])
                ] = this.cube[cubeFace[2]]
                [
                    Math.Abs(fixedNumber[4] - this.i + denie_i[4]),
                    Math.Abs(fixedNumber[5] - this.i + denie_i[5])
                ];
                // cube[2] = cube[3]
                this.cube[cubeFace[2]]
                [
                    Math.Abs(fixedNumber[4] - this.i + denie_i[4]),
                    Math.Abs(fixedNumber[5] - this.i + denie_i[5])
                ] = this.cube[cubeFace[3]]
                [
                    Math.Abs(fixedNumber[6] - this.i + denie_i[6]),
                    Math.Abs(fixedNumber[7] - this.i + denie_i[7])
                ];
                // cube[3] = cache
                this.cube[cubeFace[3]]
                [
                    Math.Abs(fixedNumber[6] - this.i + denie_i[6]),
                    Math.Abs(fixedNumber[7] - this.i + denie_i[7])
                ] = this.cache;
            }
        }

        public void DoMoveInside(int Face, bool invert)
        {
            // Определение, в какую сторону прокручивать внутренние блоки            
            int invertOne = (invert ? 0 : 2); // По часовой
            int invertTwo = (invert ? 2 : 0); // Против часовой

            // Поворот внутренних блоков
            for (this.i = 0; this.i < 2; this.i++)
            {
                this.cache = 
                    this.cube[Face][i,0];
                this.cube[Face][i,0] = 
                    this.cube[Face]
                [
                    invertOne, 
                    Math.Abs(invertTwo - i)
                ];
                this.cube[Face]
                [
                    invertOne, 
                    Math.Abs(invertTwo - i)
                ] = this.cube[Face]
                    [2 - i,
                    2];
                this.cube[Face]
                [
                    2 - i,
                    2
                ] = this.cube[Face]
                [
                    invertTwo,
                    Math.Abs(invertOne - i)
                ];
                this.cube[Face]
                [
                    invertTwo,
                    Math.Abs(invertOne - i)
                ] = this.cache;
            }
        }
    }
}