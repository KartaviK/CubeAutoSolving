using System;
using System.Collections.Generic;
using System.Reflection;

namespace RubiksAutoSolve
{
    public static class SimpleRotate
    {
        private static string[] colors = new string[6]
        {
            "y",
            "r",
            "g",
            "o",
            "b",
            "w"
        };

        public static void DoMove(string move, ref string[][,] cube)
        {
            MethodInfo moveMethod = typeof(SimpleRotate).GetMethod(move, new Type[] { typeof(string[][,]).MakeByRefType() });
            moveMethod.Invoke(null, new object[] { cube });
        }

        /// <summary>
        /// Поворот верхней грани по часовой стрелке
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void U(ref string[][,] cube)
        {
            // Внутренние блоки
            string cache = cube[0][0, 0];
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
        public static void Ui(ref string[][,] cube)
        {
            string cache = cube[0][0, 0];
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
        public static void Ud(ref string[][,] cube)
        {
            string cache = cube[0][0, 0];
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
        public static void D(ref string[][,] cube)
        {
            string cache = cube[5][0, 0];
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
        public static void Di(ref string[][,] cube)
        {
            string cache = cube[5][0, 0];
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
        public static void Dd(ref string[][,] cube)
        {
            string cache = cube[5][0, 0];
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
        public static void R(ref string[][,] cube)
        {
            string cache = cube[3][0, 0];
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
        public static void Ri(ref string[][,] cube)
        {
            string cache = cube[3][0, 0];
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
        public static void Rd(ref string[][,] cube)
        {
            string cache = cube[3][0, 0];
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

            cache = cube[2][2, 1];
            cube[2][2, 1] = cube[4][0, 1];
            cube[4][0, 1] = cache;
            cache = cube[2][2, 0];
            cube[2][2, 0] = cube[4][0, 2];
            cube[4][0, 2] = cache;
            cache = cube[2][2, 2];
            cube[2][2, 2] = cube[4][0, 0];
            cube[4][0, 0] = cache;
            cache = cube[0][2, 2];
            cube[0][2, 2] = cube[5][2, 2];
            cube[5][2, 2] = cache;
            cache = cube[0][2, 1];
            cube[0][2, 1] = cube[5][2, 1];
            cube[5][2, 1] = cache;
            cache = cube[0][2, 0];
            cube[0][2, 0] = cube[5][2, 0];
            cube[5][2, 0] = cache;
        }

        /// <summary>
        /// Поворот левой грани по часовой стрелке
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void L(ref string[][,] cube)
        {
            string cache = cube[1][0, 0];
            cube[1][0, 0] = cube[1][2, 0];
            cube[1][2, 0] = cube[1][2, 2];
            cube[1][2, 2] = cube[1][0, 2];
            cube[1][0, 2] = cache;
            cache = cube[1][0, 1];
            cube[1][0, 1] = cube[1][1, 0];
            cube[1][1, 0] = cube[1][2, 1];
            cube[1][2, 1] = cube[1][1, 2];
            cube[1][1, 2] = cache;

            cache = cube[4][2, 0];
            cube[4][2, 0] = cube[5][0, 2];
            cube[5][0, 2] = cube[2][0, 2];
            cube[2][0, 2] = cube[0][0, 2];
            cube[0][0, 2] = cache;
            cache = cube[4][2, 1];
            cube[4][2, 1] = cube[5][0, 1];
            cube[5][0, 1] = cube[2][0, 1];
            cube[2][0, 1] = cube[0][0, 1];
            cube[0][0, 1] = cache;
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
        public static void Li(ref string[][,] cube)
        {
            string cache = cube[1][0, 0];
            cube[1][0, 0] = cube[1][0, 2];
            cube[1][0, 2] = cube[1][2, 2];
            cube[1][2, 2] = cube[1][2, 0];
            cube[1][2, 0] = cache;
            cache = cube[1][0, 1];
            cube[1][0, 1] = cube[1][1, 2];
            cube[1][1, 2] = cube[1][2, 1];
            cube[1][2, 1] = cube[1][1, 0];
            cube[1][1, 0] = cache;

            cache = cube[4][2, 0];
            cube[4][2, 0] = cube[0][0, 2];
            cube[0][0, 2] = cube[2][0, 2];
            cube[2][0, 2] = cube[5][0, 2];
            cube[5][0, 2] = cache;
            cache = cube[4][2, 1];
            cube[4][2, 1] = cube[0][0, 1];
            cube[0][0, 1] = cube[2][0, 1];
            cube[2][0, 1] = cube[5][0, 1];
            cube[5][0, 1] = cache;
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
        public static void Ld(ref string[][,] cube)
        {
            string cache = cube[1][0, 0];
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

            cache = cube[4][2, 1];
            cube[4][2, 1] = cube[2][0, 1];
            cube[2][0, 1] = cache;
            cache = cube[4][2, 0];
            cube[4][2, 0] = cube[2][0, 2];
            cube[2][0, 2] = cache;
            cache = cube[4][2, 2];
            cube[4][2, 2] = cube[2][0, 0];
            cube[2][0, 0] = cache;
            cache = cube[0][0, 0];
            cube[0][0, 0] = cube[5][0, 0];
            cube[5][0, 0] = cache;
            cache = cube[0][0, 1];
            cube[0][0, 1] = cube[5][0, 1];
            cube[5][0, 1] = cache;
            cache = cube[0][0, 2];
            cube[0][0, 2] = cube[5][0, 2];
            cube[5][0, 2] = cache;
        }

        /// <summary>
        /// Поворот фронтальной грани по часовой стрелке
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void F(ref string[][,] cube)
        {
            string cache = cube[2][0, 0];
            cube[2][0, 0] = cube[2][2, 0];
            cube[2][2, 0] = cube[2][2, 2];
            cube[2][2, 2] = cube[2][0, 2];
            cube[2][0, 2] = cache;
            cache = cube[2][0, 1];
            cube[2][0, 1] = cube[2][1, 0];
            cube[2][1, 0] = cube[2][2, 1];
            cube[2][2, 1] = cube[2][1, 2];
            cube[2][1, 2] = cache;

            cache = cube[1][2, 0];
            cube[1][2, 0] = cube[5][0, 0];
            cube[5][0, 0] = cube[3][0, 2];
            cube[3][0, 2] = cube[0][2, 2];
            cube[0][2, 2] = cache;
            cache = cube[1][2, 1];
            cube[1][2, 1] = cube[5][1, 0];
            cube[5][1, 0] = cube[3][0, 1];
            cube[3][0, 1] = cube[0][1, 2];
            cube[0][1, 2] = cache;
            cache = cube[1][2, 2];
            cube[1][2, 2] = cube[5][2, 0];
            cube[5][2, 0] = cube[3][0, 0];
            cube[3][0, 0] = cube[0][0, 2];
            cube[0][0, 2] = cache;
        }

        /// <summary>
        /// Поворот фронтальной грани против часовой стрелки
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Fi(ref string[][,] cube)
        {
            string cache = cube[2][0, 0];
            cube[2][0, 0] = cube[2][0, 2];
            cube[2][0, 2] = cube[2][2, 2];
            cube[2][2, 2] = cube[2][2, 0];
            cube[2][2, 0] = cache;
            cache = cube[2][0, 1];
            cube[2][0, 1] = cube[2][1, 2];
            cube[2][1, 2] = cube[2][2, 1];
            cube[2][2, 1] = cube[2][1, 0];
            cube[2][1, 0] = cache;

            cache = cube[1][2, 0];
            cube[1][2, 0] = cube[0][2, 2];
            cube[0][2, 2] = cube[3][0, 2];
            cube[3][0, 2] = cube[5][0, 0];
            cube[5][0, 0] = cache;
            cache = cube[1][2, 1];
            cube[1][2, 1] = cube[0][1, 2];
            cube[0][1, 2] = cube[3][0, 1];
            cube[3][0, 1] = cube[5][1, 0];
            cube[5][1, 0] = cache;
            cache = cube[1][2, 2];
            cube[1][2, 2] = cube[0][0, 2];
            cube[0][0, 2] = cube[3][0, 0];
            cube[3][0, 0] = cube[5][2, 0];
            cube[5][2, 0] = cache;
        }

        /// <summary>
        /// Поврот фронтальной грани дважды
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Fd(ref string[][,] cube)
        {
            string cache = cube[2][0, 0];
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

            cache = cube[1][2, 0];
            cube[1][2, 0] = cube[3][0, 2];
            cube[3][0, 2] = cache;
            cache = cube[1][2, 1];
            cube[1][2, 1] = cube[3][0, 1];
            cube[3][0, 1] = cache;
            cache = cube[1][2, 2];
            cube[1][2, 2] = cube[3][0, 0];
            cube[3][0, 0] = cache;
            cache = cube[0][0, 2];
            cube[0][0, 2] = cube[5][2, 0];
            cube[5][2, 0] = cache;
            cache = cube[0][1, 2];
            cube[0][1, 2] = cube[5][1, 0];
            cube[5][1, 0] = cache;
            cache = cube[0][2, 2];
            cube[0][2, 2] = cube[5][0, 0];
            cube[5][0, 0] = cache;
        }

        /// <summary>
        /// Поворот задней грани по часовой стрелке
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void B(ref string[][,] cube)
        {
            string cache = cube[4][0, 0];
            cube[4][0, 0] = cube[4][2, 0];
            cube[4][2, 0] = cube[4][2, 2];
            cube[4][2, 2] = cube[4][0, 2];
            cube[4][0, 2] = cache;
            cache = cube[4][0, 1];
            cube[4][0, 1] = cube[4][1, 0];
            cube[4][1, 0] = cube[4][2, 1];
            cube[4][2, 1] = cube[4][1, 2];
            cube[4][1, 2] = cache;

            cache = cube[3][2, 0];
            cube[3][2, 0] = cube[5][2, 2];
            cube[5][2, 2] = cube[1][0, 2];
            cube[1][0, 2] = cube[0][0, 0];
            cube[0][0, 0] = cache;
            cache = cube[3][2, 1];
            cube[3][2, 1] = cube[5][1, 2];
            cube[5][1, 2] = cube[1][0, 1];
            cube[1][0, 1] = cube[0][1, 0];
            cube[0][1, 0] = cache;
            cache = cube[3][2, 2];
            cube[3][2, 2] = cube[5][0, 2];
            cube[5][0, 2] = cube[1][0, 0];
            cube[1][0, 0] = cube[0][2, 0];
            cube[0][2, 0] = cache;
        }

        /// <summary>
        /// Поворот задней грани против часовой стрелки
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Bi(ref string[][,] cube)
        {
            string cache = cube[4][0, 0];
            cube[4][0, 0] = cube[4][0, 2];
            cube[4][0, 2] = cube[4][2, 2];
            cube[4][2, 2] = cube[4][2, 0];
            cube[4][2, 0] = cache;
            cache = cube[4][0, 1];
            cube[4][0, 1] = cube[4][1, 2];
            cube[4][1, 2] = cube[4][2, 1];
            cube[4][2, 1] = cube[4][1, 0];
            cube[4][1, 0] = cache;

            cache = cube[3][2, 0];
            cube[3][2, 0] = cube[0][0, 0];
            cube[0][0, 0] = cube[1][0, 2];
            cube[1][0, 2] = cube[5][2, 2];
            cube[5][2, 2] = cache;
            cache = cube[3][2, 1];
            cube[3][2, 1] = cube[0][1, 0];
            cube[0][1, 0] = cube[1][0, 1];
            cube[1][0, 1] = cube[5][1, 2];
            cube[5][1, 2] = cache;
            cache = cube[3][2, 2];
            cube[3][2, 2] = cube[0][2, 0];
            cube[0][2, 0] = cube[1][0, 0];
            cube[1][0, 0] = cube[5][0, 2];
            cube[5][0, 2] = cache;
        }

        /// <summary>
        /// Поврот задней грани дважды
        /// </summary>
        /// <param name="cube">Ссылка на куб</param>
        public static void Bd(ref string[][,] cube)
        {
            string cache = cube[4][0, 0];
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

            cache = cube[3][2, 0];
            cube[3][2, 0] = cube[1][0, 2];
            cube[1][0, 2] = cache;
            cache = cube[3][2, 1];
            cube[3][2, 1] = cube[1][0, 1];
            cube[1][0, 1] = cache;
            cache = cube[3][2, 2];
            cube[3][2, 2] = cube[1][0, 0];
            cube[1][0, 0] = cache;
            cache = cube[0][2, 0];
            cube[0][2, 0] = cube[5][0, 2];
            cube[5][0, 2] = cache;
            cache = cube[0][1, 0];
            cube[0][1, 0] = cube[5][1, 2];
            cube[5][1, 2] = cache;
            cache = cube[0][0, 0];
            cube[0][0, 0] = cube[5][2, 2];
            cube[5][2, 2] = cache;
        }

        public static bool CheckFirstPhase(ref string[][,] cube)
        {
            return (cube[5][1, 0] == cube[5][1, 1] 
                && cube[5][0, 1] == cube[5][1, 1] 
                && cube[5][2, 1] == cube[5][1, 1] 
                && cube[5][1, 2] == cube[5][1, 1]);
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

        public static bool IsCubeSolved(ref string[][,] cube)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        if(cube[i][j, z] != cube[i][1,1])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        
        public static string[][,] CopyCube(ref string[][,] cube)
        {
            string[][,] temp = new string[6][,]
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
                for (int j = 0; j < 3; j++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        temp[i][j, z] = String.Copy(cube[i][j, z]);
                    }
                }
            }

            return temp;
        }
    }
}
