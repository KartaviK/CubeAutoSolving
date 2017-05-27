using System;
using System.Collections.Generic;
using System.Reflection;

namespace RubiksAutoSolve
{
    static class SimpleRotate
    {
        public static void DoMovesByFormula(string move, ref char[][,] cube)
        {
            MethodInfo moveMethod = typeof(SimpleRotate).GetMethod(move, new Type[] { typeof(char[][,]).MakeByRefType() });
            moveMethod.Invoke(null, new object[] { cube });
        }

        /// <summary>
        /// Поворот верхней грани по часовой стрелке
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void U(ref char[][,] cube)
        {
            // Внутренние блоки
            char cache = cube[0][0, 0];
            cube[0][0, 0] = cube[0][2, 0];
            cube[0][2, 0] = cube[0][2, 2];
            cube[0][2, 2] = cube[0][0, 2];
            cube[0][0, 2] = cache;
            cache = cube[0][0, 1];
            cube[0][0, 1] = cube[0][1, 0];
            cube[0][1, 0] = cube[0][2, 1];
            cube[0][2, 1] = cube[0][1, 2];
            cube[0][1, 2] = cache;

            // Внешние блоки
            cache = cube[1][0, 0];
            cube[1][0, 0] = cube[2][0, 0];
            cube[2][0, 0] = cube[3][0, 0];
            cube[3][0, 0] = cube[4][0, 0];
            cube[4][0, 0] = cache;
            cache = cube[1][1, 0];
            cube[1][1, 0] = cube[2][1, 0];
            cube[2][1, 0] = cube[3][1, 0];
            cube[3][1, 0] = cube[4][1, 0];
            cube[4][1, 0] = cache;
            cache = cube[1][2, 0];
            cube[1][2, 0] = cube[2][2, 0];
            cube[2][2, 0] = cube[3][2, 0];
            cube[3][2, 0] = cube[4][2, 0];
            cube[4][2, 0] = cache;
        }

        /// <summary>
        /// Поворот верхней грани против часовой стрелки
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Ui(ref char[][,] cube)
        {
            char cache = cube[0][0, 0];
            cube[0][0, 0] = cube[0][0, 2];
            cube[0][0, 2] = cube[0][2, 2];
            cube[0][2, 2] = cube[0][2, 0];
            cube[0][2, 0] = cache;
            cache = cube[0][0, 1];
            cube[0][0, 1] = cube[0][1, 2];
            cube[0][1, 2] = cube[0][2, 1];
            cube[0][2, 1] = cube[0][1, 0];
            cube[0][1, 0] = cache;

            cache = cube[1][0, 0];
            cube[1][0, 0] = cube[4][0, 0];
            cube[4][0, 0] = cube[3][0, 0];
            cube[3][0, 0] = cube[2][0, 0];
            cube[2][0, 0] = cache;
            cache = cube[1][1, 0];
            cube[1][1, 0] = cube[4][1, 0];
            cube[4][1, 0] = cube[3][1, 0];
            cube[3][1, 0] = cube[2][1, 0];
            cube[2][1, 0] = cache;
            cache = cube[1][2, 0];
            cube[1][2, 0] = cube[4][2, 0];
            cube[4][2, 0] = cube[3][2, 0];
            cube[3][2, 0] = cube[2][2, 0];
            cube[2][2, 0] = cache;
        }

        /// <summary>
        /// Поворот верхней грани дважды
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Ud(ref char[][,] cube)
        {
            char cache = cube[0][0, 0];
            cube[0][0, 0] = cube[0][2, 2];
            cube[0][2, 2] = cache;
            cache = cube[0][0, 1];
            cube[0][0, 1] = cube[0][2, 1];
            cube[0][2, 1] = cache;
            cache = cube[0][0, 2];
            cube[0][0, 2] = cube[0][2, 0];
            cube[0][2, 0] = cache;
            cache = cube[0][1, 0];
            cube[0][1, 0] = cube[0][1, 2];

            cache = cube[1][0, 0];
            cube[1][0, 0] = cube[3][0, 0];
            cube[3][0, 0] = cache;
            cache = cube[1][1, 0];
            cube[1][1, 0] = cube[3][1, 0];
            cube[3][1, 0] = cache;
            cache = cube[1][2, 0];
            cube[1][2, 0] = cube[3][2, 0];
            cube[3][2, 0] = cache;
            cache = cube[4][0, 0];
            cube[4][0, 0] = cube[2][0, 0];
            cube[2][0, 0] = cache;
            cache = cube[4][1, 0];
            cube[4][1, 0] = cube[2][1, 0];
            cube[2][1, 0] = cache;
            cache = cube[4][2, 0];
            cube[4][2, 0] = cube[2][2, 0];
            cube[2][2, 0] = cache;
        }

        /// <summary>
        /// Поворот нижней грани по часовой стрелке
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void D(ref char[][,] cube)
        {
            char cache = cube[5][0, 0];
            cube[5][0, 0] = cube[5][2, 0];
            cube[5][2, 0] = cube[5][2, 2];
            cube[5][2, 2] = cube[5][0, 2];
            cube[5][0, 2] = cache;
            cache = cube[5][0, 1];
            cube[5][0, 1] = cube[5][1, 0];
            cube[5][1, 0] = cube[5][2, 1];
            cube[5][2, 1] = cube[5][1, 2];
            cube[5][1, 2] = cache;

            cache = cube[1][2, 2];
            cube[1][2, 2] = cube[4][2, 2];
            cube[4][2, 2] = cube[3][2, 2];
            cube[3][2, 2] = cube[2][2, 2];
            cube[2][2, 2] = cache;
            cache = cube[1][1, 2];
            cube[1][1, 2] = cube[4][1, 2];
            cube[4][1, 2] = cube[3][1, 2];
            cube[3][1, 2] = cube[2][1, 2];
            cube[2][1, 2] = cache;
            cache = cube[1][0, 2];
            cube[1][0, 2] = cube[4][0, 2];
            cube[4][0, 2] = cube[3][0, 2];
            cube[3][0, 2] = cube[2][0, 2];
            cube[2][0, 2] = cache;
        }

        /// <summary>
        /// Поворот нижней грани против часовой стрелки
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Di(ref char[][,] cube)
        {
            char cache = cube[5][0, 0];
            cube[5][0, 0] = cube[5][0, 2];
            cube[5][0, 2] = cube[5][2, 2];
            cube[5][2, 2] = cube[5][2, 0];
            cube[5][2, 0] = cache;
            cache = cube[5][0, 1];
            cube[5][0, 1] = cube[5][1, 2];
            cube[5][1, 2] = cube[5][2, 1];
            cube[5][2, 1] = cube[5][1, 0];
            cube[5][1, 0] = cache;

            cache = cube[1][2, 2];
            cube[1][2, 2] = cube[2][2, 2];
            cube[2][2, 2] = cube[3][2, 2];
            cube[3][2, 2] = cube[4][2, 2];
            cube[4][2, 2] = cache;
            cache = cube[1][1, 2];
            cube[1][1, 2] = cube[2][1, 2];
            cube[2][1, 2] = cube[3][1, 2];
            cube[3][1, 2] = cube[4][1, 2];
            cube[4][1, 2] = cache;
            cache = cube[1][0, 2];
            cube[1][0, 2] = cube[2][0, 2];
            cube[2][0, 2] = cube[3][0, 2];
            cube[3][0, 2] = cube[4][0, 2];
            cube[4][0, 2] = cache;
        }

        /// <summary>
        /// Поврот нижней грани дважды
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Dd(ref char[][,] cube)
        {
            char cache = cube[5][0, 0];
            cube[5][0, 0] = cube[5][2, 2];
            cube[5][2, 2] = cache;
            cache = cube[5][0, 1];
            cube[5][0, 1] = cube[5][2, 1];
            cube[5][2, 1] = cache;
            cache = cube[5][0, 2];
            cube[5][0, 2] = cube[5][2, 0];
            cube[5][2, 0] = cache;
            cache = cube[5][1, 0];
            cube[5][1, 0] = cube[5][1, 2];

            cache = cube[1][2, 2];
            cube[1][2, 2] = cube[3][2, 2];
            cube[3][2, 2] = cache;
            cache = cube[1][1, 2];
            cube[1][1, 2] = cube[3][1, 2];
            cube[3][1, 2] = cache;
            cache = cube[1][0, 2];
            cube[1][0, 2] = cube[3][0, 2];
            cube[3][0, 2] = cache;
            cache = cube[2][2, 2];
            cube[2][2, 2] = cube[4][2, 2];
            cube[4][2, 2] = cache;
            cache = cube[2][1, 2];
            cube[2][1, 2] = cube[4][1, 2];
            cube[4][1, 2] = cache;
            cache = cube[2][0, 2];
            cube[2][0, 2] = cube[4][0, 2];
            cube[4][0, 2] = cache;
        }

        /// <summary>
        /// Поворот правой грани по часовой стрелке
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void R(ref char[][,] cube)
        {
            char cache = cube[3][0, 0];
            cube[3][0, 0] = cube[3][2, 0];
            cube[3][2, 0] = cube[3][2, 2];
            cube[3][2, 2] = cube[3][0, 2];
            cube[3][0, 2] = cache;
            cache = cube[3][0, 1];
            cube[3][0, 1] = cube[3][1, 0];
            cube[3][1, 0] = cube[3][2, 1];
            cube[3][2, 1] = cube[3][1, 2];
            cube[3][1, 2] = cache;

            cache = cube[2][2, 0];
            cube[2][2, 0] = cube[5][2, 0];
            cube[5][2, 0] = cube[4][0, 2];
            cube[4][0, 2] = cube[0][2, 0];
            cube[0][2, 0] = cache;
            cache = cube[2][2, 1];
            cube[2][2, 1] = cube[5][2, 1];
            cube[5][2, 1] = cube[4][0, 1];
            cube[4][0, 1] = cube[0][2, 1];
            cube[0][2, 1] = cache;
            cache = cube[2][2, 2];
            cube[2][2, 2] = cube[5][2, 2];
            cube[5][2, 2] = cube[4][0, 0];
            cube[4][0, 0] = cube[0][2, 2];
            cube[0][2, 2] = cache;
        }

        /// <summary>
        /// Поворот правой грани против часовой стрелки
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Ri(ref char[][,] cube)
        {
            char cache = cube[3][0, 0];
            cube[3][0, 0] = cube[3][0, 2];
            cube[3][0, 2] = cube[3][2, 2];
            cube[3][2, 2] = cube[3][2, 0];
            cube[3][2, 0] = cache;
            cache = cube[3][0, 1];
            cube[3][0, 1] = cube[3][1, 2];
            cube[3][1, 2] = cube[3][2, 1];
            cube[3][2, 1] = cube[3][1, 0];
            cube[3][1, 0] = cache;
            
            cache = cube[2][2, 0];
            cube[2][2, 0] = cube[0][2, 0];
            cube[0][2, 0] = cube[4][0, 2];
            cube[4][0, 2] = cube[5][2, 0];
            cube[5][2, 0] = cache;
            cache = cube[2][2, 1];
            cube[2][2, 1] = cube[0][2, 1];
            cube[0][2, 1] = cube[4][0, 1];
            cube[4][0, 1] = cube[5][2, 1];
            cube[5][2, 1] = cache;
            cache = cube[2][2, 2];
            cube[2][2, 2] = cube[0][2, 2];
            cube[0][2, 2] = cube[4][0, 0];
            cube[4][0, 0] = cube[5][2, 2];
            cube[5][2, 2] = cache;
        }

        /// <summary>
        /// Поврот правой грани дважды
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Rd(ref char[][,] cube)
        {
            char cache = cube[3][0, 0];
            cube[3][0, 0] = cube[3][2, 2];
            cube[3][2, 2] = cache;
            cache = cube[3][0, 1];
            cube[3][0, 1] = cube[3][2, 1];
            cube[3][2, 1] = cache;
            cache = cube[3][0, 2];
            cube[3][0, 2] = cube[3][2, 0];
            cube[3][2, 0] = cache;
            cache = cube[3][1, 0];
            cube[3][1, 0] = cube[3][1, 2];

            cache = cube[2][1, 2];
            cube[2][1, 2] = cube[4][1, 0];
            cube[4][1, 0] = cache;
            cache = cube[2][0, 2];
            cube[2][0, 2] = cube[4][2, 0];
            cube[4][2, 0] = cache;
            cache = cube[2][2, 2];
            cube[2][2, 2] = cube[4][0, 0];
            cube[4][0, 0] = cache;
            cache = cube[0][2, 2];
            cube[0][2, 2] = cube[5][2, 2];
            cube[5][2, 2] = cache;
            cache = cube[0][1, 2];
            cube[0][1, 2] = cube[5][1, 2];
            cube[5][1, 2] = cache;
            cache = cube[0][0, 2];
            cube[0][0, 2] = cube[5][0, 2];
            cube[5][0, 2] = cache;
        }

        /// <summary>
        /// Поворот левой грани по часовой стрелке
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void L(ref char[][,] cube)
        {
            char cache = cube[1][0, 0];
            cube[1][0, 0] = cube[1][2, 0];
            cube[1][2, 0] = cube[1][2, 2];
            cube[1][2, 2] = cube[1][0, 2];
            cube[1][0, 2] = cache;
            cache = cube[1][0, 1];
            cube[1][0, 1] = cube[1][1, 0];
            cube[1][1, 0] = cube[1][2, 1];
            cube[1][2, 1] = cube[1][1, 2];
            cube[1][1, 2] = cache;

            cache = cube[4][0, 2];
            cube[4][0, 2] = cube[5][2, 0];
            cube[5][2, 0] = cube[2][2, 0];
            cube[2][2, 0] = cube[0][2, 0];
            cube[0][2, 0] = cache;
            cache = cube[4][1, 2];
            cube[4][1, 2] = cube[5][1, 0];
            cube[5][1, 0] = cube[2][1, 0];
            cube[2][1, 0] = cube[0][1, 0];
            cube[0][1, 0] = cache;
            cache = cube[4][2, 2];
            cube[4][2, 2] = cube[5][0, 0];
            cube[5][0, 0] = cube[2][0, 0];
            cube[2][0, 0] = cube[0][0, 0];
            cube[0][0, 0] = cache;
        }

        /// <summary>
        /// Поворот левой грани против часовой стрелки
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Li(ref char[][,] cube)
        {
            char cache = cube[1][0, 0];
            cube[1][0, 0] = cube[1][0, 2];
            cube[1][0, 2] = cube[1][2, 2];
            cube[1][2, 2] = cube[1][2, 0];
            cube[1][2, 0] = cache;
            cache = cube[1][0, 1];
            cube[1][0, 1] = cube[1][1, 2];
            cube[1][1, 2] = cube[1][2, 1];
            cube[1][2, 1] = cube[1][1, 0];
            cube[1][1, 0] = cache;

            cache = cube[4][0, 2];
            cube[4][0, 2] = cube[0][2, 0];
            cube[0][2, 0] = cube[2][2, 0];
            cube[2][2, 0] = cube[5][2, 0];
            cube[5][2, 0] = cache;
            cache = cube[4][1, 2];
            cube[4][1, 2] = cube[0][1, 0];
            cube[0][1, 0] = cube[2][1, 0];
            cube[2][1, 0] = cube[5][1, 0];
            cube[5][1, 0] = cache;
            cache = cube[4][2, 2];
            cube[4][2, 2] = cube[0][0, 0];
            cube[0][0, 0] = cube[2][0, 0];
            cube[2][0, 0] = cube[5][0, 0];
            cube[5][0, 0] = cache;
        }

        /// <summary>
        /// Поврот левой грани дважды
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Ld(ref char[][,] cube)
        {
            char cache = cube[1][0, 0];
            cube[1][0, 0] = cube[1][2, 2];
            cube[1][2, 2] = cache;
            cache = cube[1][0, 1];
            cube[1][0, 1] = cube[1][2, 1];
            cube[1][2, 1] = cache;
            cache = cube[1][0, 2];
            cube[1][0, 2] = cube[1][2, 0];
            cube[1][2, 0] = cache;
            cache = cube[1][1, 0];
            cube[1][1, 0] = cube[1][1, 2];

            cache = cube[4][1, 2];
            cube[4][1, 2] = cube[2][1, 0];
            cube[2][1, 0] = cache;
            cache = cube[4][0, 2];
            cube[4][0, 2] = cube[2][2, 0];
            cube[2][2, 0] = cache;
            cache = cube[4][2, 2];
            cube[4][2, 2] = cube[2][0, 0];
            cube[2][0, 0] = cache;
            cache = cube[0][0, 0];
            cube[0][0, 0] = cube[5][0, 0];
            cube[5][0, 0] = cache;
            cache = cube[0][1, 0];
            cube[0][1, 0] = cube[5][1, 0];
            cube[5][1, 0] = cache;
            cache = cube[0][2, 0];
            cube[0][2, 0] = cube[5][2, 0];
            cube[5][2, 0] = cache;
        }

        /// <summary>
        /// Поворот фронтальной грани по часовой стрелке
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void F(ref char[][,] cube)
        {
            char cache = cube[2][0, 0];
            cube[2][0, 0] = cube[2][2, 0];
            cube[2][2, 0] = cube[2][2, 2];
            cube[2][2, 2] = cube[2][0, 2];
            cube[2][0, 2] = cache;
            cache = cube[2][0, 1];
            cube[2][0, 1] = cube[2][1, 0];
            cube[2][1, 0] = cube[2][2, 1];
            cube[2][2, 1] = cube[2][1, 2];
            cube[2][1, 2] = cache;

            cache = cube[1][0, 2];
            cube[1][0, 2] = cube[5][0, 0];
            cube[5][0, 0] = cube[3][2, 0];
            cube[3][2, 0] = cube[0][2, 2];
            cube[0][2, 2] = cache;
            cache = cube[1][1, 2];
            cube[1][1, 2] = cube[5][0, 1];
            cube[5][0, 1] = cube[3][1, 0];
            cube[3][1, 0] = cube[0][2, 1];
            cube[0][1, 0] = cache;
            cache = cube[1][2, 2];
            cube[1][2, 2] = cube[5][0, 2];
            cube[5][0, 2] = cube[3][0, 0];
            cube[3][0, 0] = cube[0][2, 0];
            cube[0][2, 0] = cache;
        }

        /// <summary>
        /// Поворот фронтальной грани против часовой стрелки
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Fi(ref char[][,] cube)
        {
            char cache = cube[2][0, 0];
            cube[2][0, 0] = cube[2][0, 2];
            cube[2][0, 2] = cube[2][2, 2];
            cube[2][2, 2] = cube[2][2, 0];
            cube[2][2, 0] = cache;
            cache = cube[2][0, 1];
            cube[2][0, 1] = cube[2][1, 2];
            cube[2][1, 2] = cube[2][2, 1];
            cube[2][2, 1] = cube[2][1, 0];
            cube[2][1, 0] = cache;

            cache = cube[1][0, 2];
            cube[1][0, 2] = cube[0][2, 2];
            cube[0][2, 2] = cube[3][2, 0];
            cube[3][2, 0] = cube[5][0, 0];
            cube[5][0, 0] = cache;
            cache = cube[1][1, 2];
            cube[1][1, 2] = cube[0][2, 1];
            cube[0][2, 1] = cube[3][1, 0];
            cube[3][1, 0] = cube[5][0, 1];
            cube[5][0, 1] = cache;
            cache = cube[1][2, 2];
            cube[1][2, 2] = cube[0][2, 0];
            cube[0][2, 0] = cube[3][0, 0];
            cube[3][0, 0] = cube[5][0, 2];
            cube[5][0, 2] = cache;
        }

        /// <summary>
        /// Поврот фронтальной грани дважды
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Fd(ref char[][,] cube)
        {
            char cache = cube[2][0, 0];
            cube[2][0, 0] = cube[2][2, 2];
            cube[2][2, 2] = cache;
            cache = cube[2][0, 1];
            cube[2][0, 1] = cube[2][2, 1];
            cube[2][2, 1] = cache;
            cache = cube[2][0, 2];
            cube[2][0, 2] = cube[2][2, 0];
            cube[2][2, 0] = cache;
            cache = cube[2][1, 0];
            cube[2][1, 0] = cube[2][1, 2];

            cache = cube[1][0, 2];
            cube[1][0, 2] = cube[3][2, 0];
            cube[3][2, 0] = cache;
            cache = cube[1][1, 2];
            cube[1][1, 2] = cube[3][1, 0];
            cube[3][1, 0] = cache;
            cache = cube[1][2, 2];
            cube[1][2, 2] = cube[3][0, 0];
            cube[3][0, 0] = cache;
            cache = cube[0][2, 0];
            cube[0][2, 0] = cube[5][0, 2];
            cube[5][0, 2] = cache;
            cache = cube[0][2, 1];
            cube[0][2, 1] = cube[5][0, 1];
            cube[5][0, 1] = cache;
            cache = cube[0][2, 2];
            cube[0][2, 2] = cube[5][0, 0];
            cube[5][0, 0] = cache;
        }

        /// <summary>
        /// Поворот задней грани по часовой стрелке
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void B(ref char[][,] cube)
        {
            char cache = cube[4][0, 0];
            cube[4][0, 0] = cube[4][2, 0];
            cube[4][2, 0] = cube[4][2, 2];
            cube[4][2, 2] = cube[4][0, 2];
            cube[4][0, 2] = cache;
            cache = cube[4][0, 1];
            cube[4][0, 1] = cube[4][1, 0];
            cube[4][1, 0] = cube[4][2, 1];
            cube[4][2, 1] = cube[4][1, 2];
            cube[4][1, 2] = cache;

            cache = cube[3][0, 2];
            cube[3][0, 2] = cube[5][2, 2];
            cube[5][2, 2] = cube[2][2, 0];
            cube[2][2, 0] = cube[0][0, 0];
            cube[0][0, 0] = cache;
            cache = cube[3][1, 2];
            cube[3][1, 2] = cube[5][2, 1];
            cube[5][2, 1] = cube[2][1, 0];
            cube[2][1, 0] = cube[0][0, 1];
            cube[0][0, 1] = cache;
            cache = cube[3][2, 2];
            cube[3][2, 2] = cube[5][2, 0];
            cube[5][2, 0] = cube[2][0, 0];
            cube[2][0, 0] = cube[0][0, 2];
            cube[0][0, 2] = cache;
        }

        /// <summary>
        /// Поворот задней грани против часовой стрелки
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Bi(ref char[][,] cube)
        {
            char cache = cube[4][0, 0];
            cube[4][0, 0] = cube[4][0, 2];
            cube[4][0, 2] = cube[4][2, 2];
            cube[4][2, 2] = cube[4][2, 0];
            cube[4][2, 0] = cache;
            cache = cube[4][0, 1];
            cube[4][0, 1] = cube[4][1, 2];
            cube[4][1, 2] = cube[4][2, 1];
            cube[4][2, 1] = cube[4][1, 0];
            cube[4][1, 0] = cache;

            cache = cube[3][0, 2];
            cube[3][0, 2] = cube[0][0, 0];
            cube[0][0, 0] = cube[2][2, 0];
            cube[2][2, 0] = cube[5][2, 2];
            cube[5][2, 2] = cache;
            cache = cube[3][1, 2];
            cube[3][1, 2] = cube[0][0, 1];
            cube[0][0, 1] = cube[2][1, 0];
            cube[2][1, 0] = cube[5][2, 1];
            cube[5][2, 1] = cache;
            cache = cube[3][2, 2];
            cube[3][2, 2] = cube[0][0, 2];
            cube[0][0, 2] = cube[2][0, 0];
            cube[2][0, 0] = cube[5][2, 0];
            cube[5][2, 0] = cache;
        }

        /// <summary>
        /// Поврот задней грани дважды
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Bd(ref char[][,] cube)
        {
            char cache = cube[4][0, 0];
            cube[4][0, 0] = cube[4][2, 2];
            cube[4][2, 2] = cache;
            cache = cube[4][0, 1];
            cube[4][0, 1] = cube[4][2, 1];
            cube[4][2, 1] = cache;
            cache = cube[4][0, 2];
            cube[4][0, 2] = cube[4][2, 0];
            cube[4][2, 0] = cache;
            cache = cube[4][1, 0];
            cube[4][1, 0] = cube[4][1, 2];

            cache = cube[3][0, 2];
            cube[3][0, 2] = cube[2][2, 0];
            cube[2][2, 0] = cache;
            cache = cube[3][1, 2];
            cube[3][1, 2] = cube[2][1, 0];
            cube[2][1, 0] = cache;
            cache = cube[3][2, 2];
            cube[3][2, 2] = cube[2][0, 0];
            cube[2][0, 0] = cache;
            cache = cube[0][0, 2];
            cube[0][0, 2] = cube[5][2, 0];
            cube[5][2, 0] = cache;
            cache = cube[0][0, 1];
            cube[0][0, 1] = cube[5][2, 1];
            cube[5][2, 1] = cache;
            cache = cube[0][0, 0];
            cube[0][0, 0] = cube[5][2, 2];
            cube[5][2, 2] = cache;
        }

        public static bool CheckFirstPhase(ref char[][,] cube)
        {
            return cube[5][0, 1] == cube[5][1, 1] 
                && cube[5][1, 0] == cube[5][1, 1] 
                && cube[5][1, 2] == cube[5][1, 1] 
                && cube[5][2, 1] == cube[5][1, 1];
            /*return (cube[0][0, 0] == cube[0][1, 1] || cube[0][0, 0] == cube[5][1, 1])
                && (cube[0][0, 1] == cube[0][1, 1] || cube[0][0, 1] == cube[5][1, 1])
                && (cube[0][0, 2] == cube[0][1, 1] || cube[0][0, 2] == cube[5][1, 1])
                && (cube[0][1, 0] == cube[0][1, 1] || cube[0][1, 0] == cube[5][1, 1])
                && (cube[0][1, 2] == cube[0][1, 1] || cube[0][1, 2] == cube[5][1, 1])
                && (cube[0][2, 0] == cube[0][1, 1] || cube[0][2, 0] == cube[5][1, 1])
                && (cube[0][2, 1] == cube[0][1, 1] || cube[0][2, 1] == cube[5][1, 1])
                && (cube[0][2, 2] == cube[0][1, 1] || cube[0][2, 2] == cube[5][1, 1]) // Верхняя сторона
                && (cube[5][0, 0] == cube[0][1, 1] || cube[5][0, 0] == cube[5][1, 1])
                && (cube[5][0, 1] == cube[0][1, 1] || cube[5][0, 1] == cube[5][1, 1])
                && (cube[5][0, 2] == cube[0][1, 1] || cube[5][0, 2] == cube[5][1, 1])
                && (cube[5][1, 0] == cube[0][1, 1] || cube[5][1, 0] == cube[5][1, 1])
                && (cube[5][1, 2] == cube[0][1, 1] || cube[5][1, 2] == cube[5][1, 1])
                && (cube[5][2, 0] == cube[0][1, 1] || cube[5][2, 0] == cube[5][1, 1])
                && (cube[5][2, 1] == cube[0][1, 1] || cube[5][2, 1] == cube[5][1, 1])
                && (cube[5][2, 2] == cube[0][1, 1] || cube[5][2, 2] == cube[5][1, 1]) // Нижняя сторона
                && (cube[2][1, 0] == cube[2][1, 1] || cube[2][1, 0] == cube[4][1, 1])
                && (cube[2][1, 2] == cube[2][1, 1] || cube[5][1, 2] == cube[4][1, 1]) // фронтальные ребра
                && (cube[4][1, 0] == cube[2][1, 1] || cube[4][1, 0] == cube[4][1, 1])
                && (cube[4][1, 2] == cube[2][1, 1] || cube[4][1, 2] == cube[4][1, 1]);  // Задние ребра*/
        }
    }
}
