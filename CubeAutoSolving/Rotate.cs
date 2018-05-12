using System;
using System.Collections.Generic;
using System.Reflection;

namespace RubiksAutoSolve
{
    public static class Rotate
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

        #region Rotates
        /// <summary>
        /// Обертання верхньої грані за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на куб</param>
        public static void U(ref Cube cube)
        {
            // Внутренние блоки
            string cache = cube.edge[0][0, 0];
            cube.edge[0][0, 0] = cube.edge[0][0, 2];
            cube.edge[0][0, 2] = cube.edge[0][2, 2];
            cube.edge[0][2, 2] = cube.edge[0][2, 0];
            cube.edge[0][2, 0] = cache;
            cache = cube.edge[0][0, 1];
            cube.edge[0][0, 1] = cube.edge[0][1, 2];
            cube.edge[0][1, 2] = cube.edge[0][2, 1];
            cube.edge[0][2, 1] = cube.edge[0][1, 0];
            cube.edge[0][1, 0] = cache;

            // Внешние блоки
            cache = cube.edge[1][0, 0];
            cube.edge[1][0, 0] = cube.edge[2][0, 0];
            cube.edge[2][0, 0] = cube.edge[3][0, 0];
            cube.edge[3][0, 0] = cube.edge[4][0, 0];
            cube.edge[4][0, 0] = cache;
            cache = cube.edge[1][1, 0];
            cube.edge[1][1, 0] = cube.edge[2][1, 0];
            cube.edge[2][1, 0] = cube.edge[3][1, 0];
            cube.edge[3][1, 0] = cube.edge[4][1, 0];
            cube.edge[4][1, 0] = cache;
            cache = cube.edge[1][2, 0];
            cube.edge[1][2, 0] = cube.edge[2][2, 0];
            cube.edge[2][2, 0] = cube.edge[3][2, 0];
            cube.edge[3][2, 0] = cube.edge[4][2, 0];
            cube.edge[4][2, 0] = cache;
        }

        /// <summary>
        /// Обертання верхньої грані проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Ui(ref Cube cube)
        {
            string cache = cube.edge[0][0, 0];
            cube.edge[0][0, 0] = cube.edge[0][2, 0];
            cube.edge[0][2, 0] = cube.edge[0][2, 2];
            cube.edge[0][2, 2] = cube.edge[0][0, 2];
            cube.edge[0][0, 2] = cache;
            cache = cube.edge[0][0, 1];
            cube.edge[0][0, 1] = cube.edge[0][1, 0];
            cube.edge[0][1, 0] = cube.edge[0][2, 1];
            cube.edge[0][2, 1] = cube.edge[0][1, 2];
            cube.edge[0][1, 2] = cache;

            cache = cube.edge[1][0, 0];
            cube.edge[1][0, 0] = cube.edge[4][0, 0];
            cube.edge[4][0, 0] = cube.edge[3][0, 0];
            cube.edge[3][0, 0] = cube.edge[2][0, 0];
            cube.edge[2][0, 0] = cache;
            cache = cube.edge[1][1, 0];
            cube.edge[1][1, 0] = cube.edge[4][1, 0];
            cube.edge[4][1, 0] = cube.edge[3][1, 0];
            cube.edge[3][1, 0] = cube.edge[2][1, 0];
            cube.edge[2][1, 0] = cache;
            cache = cube.edge[1][2, 0];
            cube.edge[1][2, 0] = cube.edge[4][2, 0];
            cube.edge[4][2, 0] = cube.edge[3][2, 0];
            cube.edge[3][2, 0] = cube.edge[2][2, 0];
            cube.edge[2][2, 0] = cache;
        }

        /// <summary>
        /// Поворот верхньої грані два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Ud(ref Cube cube)
        {
            string cache = cube.edge[0][0, 0];
            cube.edge[0][0, 0] = cube.edge[0][2, 2];
            cube.edge[0][2, 2] = cache;
            cache = cube.edge[0][0, 1];
            cube.edge[0][0, 1] = cube.edge[0][2, 1];
            cube.edge[0][2, 1] = cache;
            cache = cube.edge[0][0, 2];
            cube.edge[0][0, 2] = cube.edge[0][2, 0];
            cube.edge[0][2, 0] = cache;
            cache = cube.edge[0][1, 0];
            cube.edge[0][1, 0] = cube.edge[0][1, 2];
            cube.edge[0][1, 2] = cache;

            cache = cube.edge[1][0, 0];
            cube.edge[1][0, 0] = cube.edge[3][0, 0];
            cube.edge[3][0, 0] = cache;
            cache = cube.edge[1][1, 0];
            cube.edge[1][1, 0] = cube.edge[3][1, 0];
            cube.edge[3][1, 0] = cache;
            cache = cube.edge[1][2, 0];
            cube.edge[1][2, 0] = cube.edge[3][2, 0];
            cube.edge[3][2, 0] = cache;
            cache = cube.edge[4][0, 0];
            cube.edge[4][0, 0] = cube.edge[2][0, 0];
            cube.edge[2][0, 0] = cache;
            cache = cube.edge[4][1, 0];
            cube.edge[4][1, 0] = cube.edge[2][1, 0];
            cube.edge[2][1, 0] = cache;
            cache = cube.edge[4][2, 0];
            cube.edge[4][2, 0] = cube.edge[2][2, 0];
            cube.edge[2][2, 0] = cache;
        }

        /// <summary>
        /// Поворот нижньої грані за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void D(ref Cube cube)
        {
            string cache = cube.edge[5][0, 0];
            cube.edge[5][0, 0] = cube.edge[5][0, 2];
            cube.edge[5][0, 2] = cube.edge[5][2, 2];
            cube.edge[5][2, 2] = cube.edge[5][2, 0];
            cube.edge[5][2, 0] = cache;
            cache = cube.edge[5][0, 1];
            cube.edge[5][0, 1] = cube.edge[5][1, 2];
            cube.edge[5][1, 2] = cube.edge[5][2, 1];
            cube.edge[5][2, 1] = cube.edge[5][1, 0];
            cube.edge[5][1, 0] = cache;

            cache = cube.edge[1][2, 2];
            cube.edge[1][2, 2] = cube.edge[4][2, 2];
            cube.edge[4][2, 2] = cube.edge[3][2, 2];
            cube.edge[3][2, 2] = cube.edge[2][2, 2];
            cube.edge[2][2, 2] = cache;
            cache = cube.edge[1][1, 2];
            cube.edge[1][1, 2] = cube.edge[4][1, 2];
            cube.edge[4][1, 2] = cube.edge[3][1, 2];
            cube.edge[3][1, 2] = cube.edge[2][1, 2];
            cube.edge[2][1, 2] = cache;
            cache = cube.edge[1][0, 2];
            cube.edge[1][0, 2] = cube.edge[4][0, 2];
            cube.edge[4][0, 2] = cube.edge[3][0, 2];
            cube.edge[3][0, 2] = cube.edge[2][0, 2];
            cube.edge[2][0, 2] = cache;
        }

        /// <summary>
        /// Поворот нижньої грані проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Di(ref Cube cube)
        {
            string cache = cube.edge[5][0, 0];
            cube.edge[5][0, 0] = cube.edge[5][2, 0];
            cube.edge[5][2, 0] = cube.edge[5][2, 2];
            cube.edge[5][2, 2] = cube.edge[5][0, 2];
            cube.edge[5][0, 2] = cache;
            cache = cube.edge[5][0, 1];
            cube.edge[5][0, 1] = cube.edge[5][1, 0];
            cube.edge[5][1, 0] = cube.edge[5][2, 1];
            cube.edge[5][2, 1] = cube.edge[5][1, 2];
            cube.edge[5][1, 2] = cache;

            cache = cube.edge[1][2, 2];
            cube.edge[1][2, 2] = cube.edge[2][2, 2];
            cube.edge[2][2, 2] = cube.edge[3][2, 2];
            cube.edge[3][2, 2] = cube.edge[4][2, 2];
            cube.edge[4][2, 2] = cache;
            cache = cube.edge[1][1, 2];
            cube.edge[1][1, 2] = cube.edge[2][1, 2];
            cube.edge[2][1, 2] = cube.edge[3][1, 2];
            cube.edge[3][1, 2] = cube.edge[4][1, 2];
            cube.edge[4][1, 2] = cache;
            cache = cube.edge[1][0, 2];
            cube.edge[1][0, 2] = cube.edge[2][0, 2];
            cube.edge[2][0, 2] = cube.edge[3][0, 2];
            cube.edge[3][0, 2] = cube.edge[4][0, 2];
            cube.edge[4][0, 2] = cache;
        }

        /// <summary>
        /// Поврот нижньої грані два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Dd(ref Cube cube)
        {
            string cache = cube.edge[5][0, 0];
            cube.edge[5][0, 0] = cube.edge[5][2, 2];
            cube.edge[5][2, 2] = cache;
            cache = cube.edge[5][0, 1];
            cube.edge[5][0, 1] = cube.edge[5][2, 1];
            cube.edge[5][2, 1] = cache;
            cache = cube.edge[5][0, 2];
            cube.edge[5][0, 2] = cube.edge[5][2, 0];
            cube.edge[5][2, 0] = cache;
            cache = cube.edge[5][1, 0];
            cube.edge[5][1, 0] = cube.edge[5][1, 2];
            cube.edge[5][1, 2] = cache;

            cache = cube.edge[1][2, 2];
            cube.edge[1][2, 2] = cube.edge[3][2, 2];
            cube.edge[3][2, 2] = cache;
            cache = cube.edge[1][1, 2];
            cube.edge[1][1, 2] = cube.edge[3][1, 2];
            cube.edge[3][1, 2] = cache;
            cache = cube.edge[1][0, 2];
            cube.edge[1][0, 2] = cube.edge[3][0, 2];
            cube.edge[3][0, 2] = cache;
            cache = cube.edge[2][2, 2];
            cube.edge[2][2, 2] = cube.edge[4][2, 2];
            cube.edge[4][2, 2] = cache;
            cache = cube.edge[2][1, 2];
            cube.edge[2][1, 2] = cube.edge[4][1, 2];
            cube.edge[4][1, 2] = cache;
            cache = cube.edge[2][0, 2];
            cube.edge[2][0, 2] = cube.edge[4][0, 2];
            cube.edge[4][0, 2] = cache;
        }

        /// <summary>
        /// Поворот правої грані за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void R(ref Cube cube)
        {
            string cache = cube.edge[3][0, 0];
            cube.edge[3][0, 0] = cube.edge[3][0, 2];
            cube.edge[3][0, 2] = cube.edge[3][2, 2];
            cube.edge[3][2, 2] = cube.edge[3][2, 0];
            cube.edge[3][2, 0] = cache;
            cache = cube.edge[3][0, 1];
            cube.edge[3][0, 1] = cube.edge[3][1, 2];
            cube.edge[3][1, 2] = cube.edge[3][2, 1];
            cube.edge[3][2, 1] = cube.edge[3][1, 0];
            cube.edge[3][1, 0] = cache;

            cache = cube.edge[2][2, 0];
            cube.edge[2][2, 0] = cube.edge[5][2, 0];
            cube.edge[5][2, 0] = cube.edge[4][0, 2];
            cube.edge[4][0, 2] = cube.edge[0][2, 0];
            cube.edge[0][2, 0] = cache;
            cache = cube.edge[2][2, 1];
            cube.edge[2][2, 1] = cube.edge[5][2, 1];
            cube.edge[5][2, 1] = cube.edge[4][0, 1];
            cube.edge[4][0, 1] = cube.edge[0][2, 1];
            cube.edge[0][2, 1] = cache;
            cache = cube.edge[2][2, 2];
            cube.edge[2][2, 2] = cube.edge[5][2, 2];
            cube.edge[5][2, 2] = cube.edge[4][0, 0];
            cube.edge[4][0, 0] = cube.edge[0][2, 2];
            cube.edge[0][2, 2] = cache;
        }

        /// <summary>
        /// Поворот правої грані проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Ri(ref Cube cube)
        {
            string cache = cube.edge[3][0, 0];
            cube.edge[3][0, 0] = cube.edge[3][2, 0];
            cube.edge[3][2, 0] = cube.edge[3][2, 2];
            cube.edge[3][2, 2] = cube.edge[3][0, 2];
            cube.edge[3][0, 2] = cache;
            cache = cube.edge[3][0, 1];
            cube.edge[3][0, 1] = cube.edge[3][1, 0];
            cube.edge[3][1, 0] = cube.edge[3][2, 1];
            cube.edge[3][2, 1] = cube.edge[3][1, 2];
            cube.edge[3][1, 2] = cache;

            cache = cube.edge[2][2, 0];
            cube.edge[2][2, 0] = cube.edge[0][2, 0];
            cube.edge[0][2, 0] = cube.edge[4][0, 2];
            cube.edge[4][0, 2] = cube.edge[5][2, 0];
            cube.edge[5][2, 0] = cache;
            cache = cube.edge[2][2, 1];
            cube.edge[2][2, 1] = cube.edge[0][2, 1];
            cube.edge[0][2, 1] = cube.edge[4][0, 1];
            cube.edge[4][0, 1] = cube.edge[5][2, 1];
            cube.edge[5][2, 1] = cache;
            cache = cube.edge[2][2, 2];
            cube.edge[2][2, 2] = cube.edge[0][2, 2];
            cube.edge[0][2, 2] = cube.edge[4][0, 0];
            cube.edge[4][0, 0] = cube.edge[5][2, 2];
            cube.edge[5][2, 2] = cache;
        }

        /// <summary>
        /// Поврот правої грані два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Rd(ref Cube cube)
        {
            string cache = cube.edge[3][0, 0];
            cube.edge[3][0, 0] = cube.edge[3][2, 2];
            cube.edge[3][2, 2] = cache;
            cache = cube.edge[3][0, 1];
            cube.edge[3][0, 1] = cube.edge[3][2, 1];
            cube.edge[3][2, 1] = cache;
            cache = cube.edge[3][0, 2];
            cube.edge[3][0, 2] = cube.edge[3][2, 0];
            cube.edge[3][2, 0] = cache;
            cache = cube.edge[3][1, 0];
            cube.edge[3][1, 0] = cube.edge[3][1, 2];
            cube.edge[3][1, 2] = cache;

            cache = cube.edge[2][2, 1];
            cube.edge[2][2, 1] = cube.edge[4][0, 1];
            cube.edge[4][0, 1] = cache;
            cache = cube.edge[2][2, 0];
            cube.edge[2][2, 0] = cube.edge[4][0, 2];
            cube.edge[4][0, 2] = cache;
            cache = cube.edge[2][2, 2];
            cube.edge[2][2, 2] = cube.edge[4][0, 0];
            cube.edge[4][0, 0] = cache;
            cache = cube.edge[0][2, 2];
            cube.edge[0][2, 2] = cube.edge[5][2, 2];
            cube.edge[5][2, 2] = cache;
            cache = cube.edge[0][2, 1];
            cube.edge[0][2, 1] = cube.edge[5][2, 1];
            cube.edge[5][2, 1] = cache;
            cache = cube.edge[0][2, 0];
            cube.edge[0][2, 0] = cube.edge[5][2, 0];
            cube.edge[5][2, 0] = cache;
        }

        /// <summary>
        /// Поворот лівої грані за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void L(ref Cube cube)
        {
            string cache = cube.edge[1][0, 0];
            cube.edge[1][0, 0] = cube.edge[1][0, 2];
            cube.edge[1][0, 2] = cube.edge[1][2, 2];
            cube.edge[1][2, 2] = cube.edge[1][2, 0];
            cube.edge[1][2, 0] = cache;
            cache = cube.edge[1][0, 1];
            cube.edge[1][0, 1] = cube.edge[1][1, 2];
            cube.edge[1][1, 2] = cube.edge[1][2, 1];
            cube.edge[1][2, 1] = cube.edge[1][1, 0];
            cube.edge[1][1, 0] = cache;

            cache = cube.edge[4][2, 0];
            cube.edge[4][2, 0] = cube.edge[5][0, 2];
            cube.edge[5][0, 2] = cube.edge[2][0, 2];
            cube.edge[2][0, 2] = cube.edge[0][0, 2];
            cube.edge[0][0, 2] = cache;
            cache = cube.edge[4][2, 1];
            cube.edge[4][2, 1] = cube.edge[5][0, 1];
            cube.edge[5][0, 1] = cube.edge[2][0, 1];
            cube.edge[2][0, 1] = cube.edge[0][0, 1];
            cube.edge[0][0, 1] = cache;
            cache = cube.edge[4][2, 2];
            cube.edge[4][2, 2] = cube.edge[5][0, 0];
            cube.edge[5][0, 0] = cube.edge[2][0, 0];
            cube.edge[2][0, 0] = cube.edge[0][0, 0];
            cube.edge[0][0, 0] = cache;
        }

        /// <summary>
        /// Поворот лівої грані проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Li(ref Cube cube)
        {
            string cache = cube.edge[1][0, 0];
            cube.edge[1][0, 0] = cube.edge[1][2, 0];
            cube.edge[1][2, 0] = cube.edge[1][2, 2];
            cube.edge[1][2, 2] = cube.edge[1][0, 2];
            cube.edge[1][0, 2] = cache;
            cache = cube.edge[1][0, 1];
            cube.edge[1][0, 1] = cube.edge[1][1, 0];
            cube.edge[1][1, 0] = cube.edge[1][2, 1];
            cube.edge[1][2, 1] = cube.edge[1][1, 2];
            cube.edge[1][1, 2] = cache;

            cache = cube.edge[4][2, 0];
            cube.edge[4][2, 0] = cube.edge[0][0, 2];
            cube.edge[0][0, 2] = cube.edge[2][0, 2];
            cube.edge[2][0, 2] = cube.edge[5][0, 2];
            cube.edge[5][0, 2] = cache;
            cache = cube.edge[4][2, 1];
            cube.edge[4][2, 1] = cube.edge[0][0, 1];
            cube.edge[0][0, 1] = cube.edge[2][0, 1];
            cube.edge[2][0, 1] = cube.edge[5][0, 1];
            cube.edge[5][0, 1] = cache;
            cache = cube.edge[4][2, 2];
            cube.edge[4][2, 2] = cube.edge[0][0, 0];
            cube.edge[0][0, 0] = cube.edge[2][0, 0];
            cube.edge[2][0, 0] = cube.edge[5][0, 0];
            cube.edge[5][0, 0] = cache;
        }

        /// <summary>
        /// Поворот лівої грані два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Ld(ref Cube cube)
        {
            string cache = cube.edge[1][0, 0];
            cube.edge[1][0, 0] = cube.edge[1][2, 2];
            cube.edge[1][2, 2] = cache;
            cache = cube.edge[1][0, 1];
            cube.edge[1][0, 1] = cube.edge[1][2, 1];
            cube.edge[1][2, 1] = cache;
            cache = cube.edge[1][0, 2];
            cube.edge[1][0, 2] = cube.edge[1][2, 0];
            cube.edge[1][2, 0] = cache;
            cache = cube.edge[1][1, 0];
            cube.edge[1][1, 0] = cube.edge[1][1, 2];
            cube.edge[1][1, 2] = cache;

            cache = cube.edge[4][2, 1];
            cube.edge[4][2, 1] = cube.edge[2][0, 1];
            cube.edge[2][0, 1] = cache;
            cache = cube.edge[4][2, 0];
            cube.edge[4][2, 0] = cube.edge[2][0, 2];
            cube.edge[2][0, 2] = cache;
            cache = cube.edge[4][2, 2];
            cube.edge[4][2, 2] = cube.edge[2][0, 0];
            cube.edge[2][0, 0] = cache;
            cache = cube.edge[0][0, 0];
            cube.edge[0][0, 0] = cube.edge[5][0, 0];
            cube.edge[5][0, 0] = cache;
            cache = cube.edge[0][0, 1];
            cube.edge[0][0, 1] = cube.edge[5][0, 1];
            cube.edge[5][0, 1] = cache;
            cache = cube.edge[0][0, 2];
            cube.edge[0][0, 2] = cube.edge[5][0, 2];
            cube.edge[5][0, 2] = cache;
        }

        /// <summary>
        /// Поворот фронтальної грані за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void F(ref Cube cube)
        {
            string cache = cube.edge[2][0, 0];
            cube.edge[2][0, 0] = cube.edge[2][0, 2];
            cube.edge[2][0, 2] = cube.edge[2][2, 2];
            cube.edge[2][2, 2] = cube.edge[2][2, 0];
            cube.edge[2][2, 0] = cache;
            cache = cube.edge[2][0, 1];
            cube.edge[2][0, 1] = cube.edge[2][1, 2];
            cube.edge[2][1, 2] = cube.edge[2][2, 1];
            cube.edge[2][2, 1] = cube.edge[2][1, 0];
            cube.edge[2][1, 0] = cache;

            cache = cube.edge[1][2, 0];
            cube.edge[1][2, 0] = cube.edge[5][0, 0];
            cube.edge[5][0, 0] = cube.edge[3][0, 2];
            cube.edge[3][0, 2] = cube.edge[0][2, 2];
            cube.edge[0][2, 2] = cache;
            cache = cube.edge[1][2, 1];
            cube.edge[1][2, 1] = cube.edge[5][1, 0];
            cube.edge[5][1, 0] = cube.edge[3][0, 1];
            cube.edge[3][0, 1] = cube.edge[0][1, 2];
            cube.edge[0][1, 2] = cache;
            cache = cube.edge[1][2, 2];
            cube.edge[1][2, 2] = cube.edge[5][2, 0];
            cube.edge[5][2, 0] = cube.edge[3][0, 0];
            cube.edge[3][0, 0] = cube.edge[0][0, 2];
            cube.edge[0][0, 2] = cache;
        }

        /// <summary>
        /// Поворот фронтальної грані проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Fi(ref Cube cube)
        {
            string cache = cube.edge[2][0, 0];
            cube.edge[2][0, 0] = cube.edge[2][2, 0];
            cube.edge[2][2, 0] = cube.edge[2][2, 2];
            cube.edge[2][2, 2] = cube.edge[2][0, 2];
            cube.edge[2][0, 2] = cache;
            cache = cube.edge[2][0, 1];
            cube.edge[2][0, 1] = cube.edge[2][1, 0];
            cube.edge[2][1, 0] = cube.edge[2][2, 1];
            cube.edge[2][2, 1] = cube.edge[2][1, 2];
            cube.edge[2][1, 2] = cache;

            cache = cube.edge[1][2, 0];
            cube.edge[1][2, 0] = cube.edge[0][2, 2];
            cube.edge[0][2, 2] = cube.edge[3][0, 2];
            cube.edge[3][0, 2] = cube.edge[5][0, 0];
            cube.edge[5][0, 0] = cache;
            cache = cube.edge[1][2, 1];
            cube.edge[1][2, 1] = cube.edge[0][1, 2];
            cube.edge[0][1, 2] = cube.edge[3][0, 1];
            cube.edge[3][0, 1] = cube.edge[5][1, 0];
            cube.edge[5][1, 0] = cache;
            cache = cube.edge[1][2, 2];
            cube.edge[1][2, 2] = cube.edge[0][0, 2];
            cube.edge[0][0, 2] = cube.edge[3][0, 0];
            cube.edge[3][0, 0] = cube.edge[5][2, 0];
            cube.edge[5][2, 0] = cache;
        }

        /// <summary>
        /// Поврот фронтальної грані два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Fd(ref Cube cube)
        {
            string cache = cube.edge[2][0, 0];
            cube.edge[2][0, 0] = cube.edge[2][2, 2];
            cube.edge[2][2, 2] = cache;
            cache = cube.edge[2][0, 1];
            cube.edge[2][0, 1] = cube.edge[2][2, 1];
            cube.edge[2][2, 1] = cache;
            cache = cube.edge[2][0, 2];
            cube.edge[2][0, 2] = cube.edge[2][2, 0];
            cube.edge[2][2, 0] = cache;
            cache = cube.edge[2][1, 0];
            cube.edge[2][1, 0] = cube.edge[2][1, 2];
            cube.edge[2][1, 2] = cache;

            cache = cube.edge[1][2, 0];
            cube.edge[1][2, 0] = cube.edge[3][0, 2];
            cube.edge[3][0, 2] = cache;
            cache = cube.edge[1][2, 1];
            cube.edge[1][2, 1] = cube.edge[3][0, 1];
            cube.edge[3][0, 1] = cache;
            cache = cube.edge[1][2, 2];
            cube.edge[1][2, 2] = cube.edge[3][0, 0];
            cube.edge[3][0, 0] = cache;
            cache = cube.edge[0][0, 2];
            cube.edge[0][0, 2] = cube.edge[5][2, 0];
            cube.edge[5][2, 0] = cache;
            cache = cube.edge[0][1, 2];
            cube.edge[0][1, 2] = cube.edge[5][1, 0];
            cube.edge[5][1, 0] = cache;
            cache = cube.edge[0][2, 2];
            cube.edge[0][2, 2] = cube.edge[5][0, 0];
            cube.edge[5][0, 0] = cache;
        }

        /// <summary>
        /// Поворот задньої грані за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void B(ref Cube cube)
        {
            string cache = cube.edge[4][0, 0];
            cube.edge[4][0, 0] = cube.edge[4][0, 2];
            cube.edge[4][0, 2] = cube.edge[4][2, 2];
            cube.edge[4][2, 2] = cube.edge[4][2, 0];
            cube.edge[4][2, 0] = cache;
            cache = cube.edge[4][0, 1];
            cube.edge[4][0, 1] = cube.edge[4][1, 2];
            cube.edge[4][1, 2] = cube.edge[4][2, 1];
            cube.edge[4][2, 1] = cube.edge[4][1, 0];
            cube.edge[4][1, 0] = cache;

            cache = cube.edge[3][2, 0];
            cube.edge[3][2, 0] = cube.edge[5][2, 2];
            cube.edge[5][2, 2] = cube.edge[1][0, 2];
            cube.edge[1][0, 2] = cube.edge[0][0, 0];
            cube.edge[0][0, 0] = cache;
            cache = cube.edge[3][2, 1];
            cube.edge[3][2, 1] = cube.edge[5][1, 2];
            cube.edge[5][1, 2] = cube.edge[1][0, 1];
            cube.edge[1][0, 1] = cube.edge[0][1, 0];
            cube.edge[0][1, 0] = cache;
            cache = cube.edge[3][2, 2];
            cube.edge[3][2, 2] = cube.edge[5][0, 2];
            cube.edge[5][0, 2] = cube.edge[1][0, 0];
            cube.edge[1][0, 0] = cube.edge[0][2, 0];
            cube.edge[0][2, 0] = cache;
        }

        /// <summary>
        /// Поворот задньої грані проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Bi(ref Cube cube)
        {
            string cache = cube.edge[4][0, 0];
            cube.edge[4][0, 0] = cube.edge[4][2, 0];
            cube.edge[4][2, 0] = cube.edge[4][2, 2];
            cube.edge[4][2, 2] = cube.edge[4][0, 2];
            cube.edge[4][0, 2] = cache;
            cache = cube.edge[4][0, 1];
            cube.edge[4][0, 1] = cube.edge[4][1, 0];
            cube.edge[4][1, 0] = cube.edge[4][2, 1];
            cube.edge[4][2, 1] = cube.edge[4][1, 2];
            cube.edge[4][1, 2] = cache;

            cache = cube.edge[3][2, 0];
            cube.edge[3][2, 0] = cube.edge[0][0, 0];
            cube.edge[0][0, 0] = cube.edge[1][0, 2];
            cube.edge[1][0, 2] = cube.edge[5][2, 2];
            cube.edge[5][2, 2] = cache;
            cache = cube.edge[3][2, 1];
            cube.edge[3][2, 1] = cube.edge[0][1, 0];
            cube.edge[0][1, 0] = cube.edge[1][0, 1];
            cube.edge[1][0, 1] = cube.edge[5][1, 2];
            cube.edge[5][1, 2] = cache;
            cache = cube.edge[3][2, 2];
            cube.edge[3][2, 2] = cube.edge[0][2, 0];
            cube.edge[0][2, 0] = cube.edge[1][0, 0];
            cube.edge[1][0, 0] = cube.edge[5][0, 2];
            cube.edge[5][0, 2] = cache;
        }

        /// <summary>
        /// Поврот задньої грані два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Bd(ref Cube cube)
        {
            string cache = cube.edge[4][0, 0];
            cube.edge[4][0, 0] = cube.edge[4][2, 2];
            cube.edge[4][2, 2] = cache;
            cache = cube.edge[4][0, 1];
            cube.edge[4][0, 1] = cube.edge[4][2, 1];
            cube.edge[4][2, 1] = cache;
            cache = cube.edge[4][0, 2];
            cube.edge[4][0, 2] = cube.edge[4][2, 0];
            cube.edge[4][2, 0] = cache;
            cache = cube.edge[4][1, 0];
            cube.edge[4][1, 0] = cube.edge[4][1, 2];
            cube.edge[4][1, 2] = cache;

            cache = cube.edge[3][2, 0];
            cube.edge[3][2, 0] = cube.edge[1][0, 2];
            cube.edge[1][0, 2] = cache;
            cache = cube.edge[3][2, 1];
            cube.edge[3][2, 1] = cube.edge[1][0, 1];
            cube.edge[1][0, 1] = cache;
            cache = cube.edge[3][2, 2];
            cube.edge[3][2, 2] = cube.edge[1][0, 0];
            cube.edge[1][0, 0] = cache;
            cache = cube.edge[0][2, 0];
            cube.edge[0][2, 0] = cube.edge[5][0, 2];
            cube.edge[5][0, 2] = cache;
            cache = cube.edge[0][1, 0];
            cube.edge[0][1, 0] = cube.edge[5][1, 2];
            cube.edge[5][1, 2] = cache;
            cache = cube.edge[0][0, 0];
            cube.edge[0][0, 0] = cube.edge[5][2, 2];
            cube.edge[5][2, 2] = cache;
        }

        /// <summary>
        /// Поворот центрової грані относительно лівої за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void M(ref Cube cube)
        {
            string cache = cube.edge[5][1, 2];
            cube.edge[5][1, 2] = cube.edge[2][1, 2];
            cube.edge[2][1, 2] = cube.edge[0][1, 2];
            cube.edge[0][1, 2] = cube.edge[4][1, 0];
            cube.edge[4][1, 0] = cache;
            cache = cube.edge[5][1, 1];
            cube.edge[5][1, 1] = cube.edge[2][1, 1];
            cube.edge[2][1, 1] = cube.edge[0][1, 1];
            cube.edge[0][1, 1] = cube.edge[4][1, 1];
            cube.edge[4][1, 1] = cache;
            cache = cube.edge[5][1, 0];
            cube.edge[5][1, 0] = cube.edge[2][1, 0];
            cube.edge[2][1, 0] = cube.edge[0][1, 0];
            cube.edge[0][1, 0] = cube.edge[4][1, 2];
            cube.edge[4][1, 2] = cache;
        }

        /// <summary>
        /// Поворот центрової грані относительно лівої проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Mi(ref Cube cube)
        {
            string cache = cube.edge[5][1, 2];
            cube.edge[5][1, 2] = cube.edge[4][1, 0];
            cube.edge[4][1, 0] = cube.edge[0][1, 2];
            cube.edge[0][1, 2] = cube.edge[2][1, 2];
            cube.edge[2][1, 2] = cache;
            cache = cube.edge[5][1, 1];
            cube.edge[5][1, 1] = cube.edge[4][1, 1];
            cube.edge[4][1, 1] = cube.edge[0][1, 1];
            cube.edge[0][1, 1] = cube.edge[2][1, 1];
            cube.edge[2][1, 1] = cache;
            cache = cube.edge[5][1, 0];
            cube.edge[5][1, 0] = cube.edge[4][1, 2];
            cube.edge[4][1, 2] = cube.edge[0][1, 0];
            cube.edge[0][1, 0] = cube.edge[2][1, 0];
            cube.edge[2][1, 0] = cache;
        }

        /// <summary>
        /// Поворот центрової грані относительно лівої два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Md(ref Cube cube)
        {
            string cache = cube.edge[5][1, 2];
            cube.edge[5][1, 2] = cube.edge[0][1, 2];
            cube.edge[0][1, 2] = cache;
            cache = cube.edge[5][1, 1];
            cube.edge[5][1, 1] = cube.edge[0][1, 1];
            cube.edge[0][1, 1] = cache;
            cache = cube.edge[5][1, 0];
            cube.edge[5][1, 0] = cube.edge[0][1, 0];
            cube.edge[0][1, 0] = cache;
            cache = cube.edge[2][1, 2];
            cube.edge[2][1, 2] = cube.edge[4][1, 0];
            cube.edge[4][1, 0] = cache;
            cache = cube.edge[2][1, 1];
            cube.edge[2][1, 1] = cube.edge[4][1, 1];
            cube.edge[4][1, 1] = cache;
            cache = cube.edge[2][1, 0];
            cube.edge[2][1, 0] = cube.edge[4][1, 2];
            cube.edge[4][1, 2] = cache;
        }

        /// <summary>
        /// Поворот центрової грані относительно нижньої за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void E(ref Cube cube)
        {
            string cache = cube.edge[4][0, 1];
            cube.edge[4][0, 1] = cube.edge[3][0, 1];
            cube.edge[3][0, 1] = cube.edge[2][0, 1];
            cube.edge[2][0, 1] = cube.edge[1][0, 1];
            cube.edge[1][0, 1] = cache;
            cache = cube.edge[4][1, 1];
            cube.edge[4][1, 1] = cube.edge[3][1, 1];
            cube.edge[3][1, 1] = cube.edge[2][1, 1];
            cube.edge[2][1, 1] = cube.edge[1][1, 1];
            cube.edge[1][1, 1] = cache;
            cache = cube.edge[4][2, 1];
            cube.edge[4][2, 1] = cube.edge[3][2, 1];
            cube.edge[3][2, 1] = cube.edge[2][2, 1];
            cube.edge[2][2, 1] = cube.edge[1][2, 1];
            cube.edge[1][2, 1] = cache;
        }

        /// <summary>
        /// Поворот центрової грані относительно нижньої проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Ei(ref Cube cube)
        {
            string cache = cube.edge[4][0, 1];
            cube.edge[4][0, 1] = cube.edge[1][0, 1];
            cube.edge[1][0, 1] = cube.edge[2][0, 1];
            cube.edge[2][0, 1] = cube.edge[3][0, 1];
            cube.edge[3][0, 1] = cache;
            cache = cube.edge[4][1, 1];
            cube.edge[4][1, 1] = cube.edge[1][1, 1];
            cube.edge[1][1, 1] = cube.edge[2][1, 1];
            cube.edge[2][1, 1] = cube.edge[3][1, 1];
            cube.edge[3][1, 1] = cache;
            cache = cube.edge[4][2, 1];
            cube.edge[4][2, 1] = cube.edge[1][2, 1];
            cube.edge[1][2, 1] = cube.edge[2][2, 1];
            cube.edge[2][2, 1] = cube.edge[3][2, 1];
            cube.edge[3][2, 1] = cache;
        }

        /// <summary>
        /// Поворот центрової грані относительно нижньої два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Ed(ref Cube cube)
        {
            string cache = cube.edge[2][2, 1];
            cube.edge[2][2, 1] = cube.edge[4][2, 1];
            cube.edge[4][2, 1] = cache;
            cache = cube.edge[2][1, 1];
            cube.edge[2][1, 1] = cube.edge[4][1, 1];
            cube.edge[4][1, 1] = cache;
            cache = cube.edge[2][0, 1];
            cube.edge[2][0, 1] = cube.edge[4][0, 1];
            cube.edge[4][0, 1] = cache;
            cache = cube.edge[1][2, 1];
            cube.edge[1][2, 1] = cube.edge[3][2, 1];
            cube.edge[3][2, 1] = cache;
            cache = cube.edge[1][1, 1];
            cube.edge[1][1, 1] = cube.edge[3][1, 1];
            cube.edge[3][1, 1] = cache;
            cache = cube.edge[1][0, 1];
            cube.edge[1][0, 1] = cube.edge[3][0, 1];
            cube.edge[3][0, 1] = cache;
        }

        /// <summary>
        /// Поворот центрової грані относительно фронтальної за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void S(ref Cube cube)
        {
            string cache = cube.edge[0][0, 1];
            cube.edge[0][0, 1] = cube.edge[1][1, 2];
            cube.edge[1][1, 2] = cube.edge[5][2, 1];
            cube.edge[5][2, 1] = cube.edge[3][1, 0];
            cube.edge[3][1, 0] = cache;
            cache = cube.edge[0][1, 1];
            cube.edge[0][1, 1] = cube.edge[1][1, 1];
            cube.edge[1][1, 1] = cube.edge[5][1, 1];
            cube.edge[5][1, 1] = cube.edge[3][1, 1];
            cube.edge[3][1, 1] = cache;
            cache = cube.edge[0][2, 1];
            cube.edge[0][2, 1] = cube.edge[1][1, 0];
            cube.edge[1][1, 0] = cube.edge[5][0, 1];
            cube.edge[5][0, 1] = cube.edge[3][1, 2];
            cube.edge[3][1, 2] = cache;
        }

        /// <summary>
        /// Поворот центрової грані относительно фронтальної проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Si(ref Cube cube)
        {
            string cache = cube.edge[0][0, 1];
            cube.edge[0][0, 1] = cube.edge[3][1, 0];
            cube.edge[3][1, 0] = cube.edge[5][2, 1];
            cube.edge[5][2, 1] = cube.edge[1][1, 2];
            cube.edge[1][1, 2] = cache;
            cache = cube.edge[0][1, 1];
            cube.edge[0][1, 1] = cube.edge[3][1, 1];
            cube.edge[3][1, 1] = cube.edge[5][1, 1];
            cube.edge[5][1, 1] = cube.edge[1][1, 1];
            cube.edge[1][1, 1] = cache;
            cache = cube.edge[0][2, 1];
            cube.edge[0][2, 1] = cube.edge[3][1, 2];
            cube.edge[3][1, 2] = cube.edge[5][0, 1];
            cube.edge[5][0, 1] = cube.edge[1][1, 0];
            cube.edge[1][1, 0] = cache;
        }

        /// <summary>
        /// Поворот центрової грані относительно фронтальної два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Sd(ref Cube cube)
        {
            string cache = cube.edge[0][0, 1];
            cube.edge[0][0, 1] = cube.edge[5][2, 1];
            cube.edge[5][2, 1] = cache;
            cache = cube.edge[0][1, 1];
            cube.edge[0][1, 1] = cube.edge[5][1, 1];
            cube.edge[5][1, 1] = cache;
            cache = cube.edge[0][2, 1];
            cube.edge[0][2, 1] = cube.edge[5][0, 1];
            cube.edge[5][0, 1] = cache;
            cache = cube.edge[1][1, 0];
            cube.edge[1][1, 0] = cube.edge[3][1, 2];
            cube.edge[3][1, 2] = cache;
            cache = cube.edge[1][1, 1];
            cube.edge[1][1, 1] = cube.edge[3][1, 1];
            cube.edge[3][1, 1] = cache;
            cache = cube.edge[1][1, 2];
            cube.edge[1][1, 2] = cube.edge[3][1, 0];
            cube.edge[3][1, 0] = cache;
        }
        #endregion

        #region Twise rotates
        /// <summary>
        /// Поврот правої грані разом з центровою за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Rw(ref Cube cube)
        {
            R(ref cube);
            Mi(ref cube);
        }
        
        /// <summary>
        /// Поворот правої грані разом з центровою проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Rwi(ref Cube cube)
        {
            Ri(ref cube);
            M(ref cube);
        }

        /// <summary>
        /// Поворот правої грані разом з центровою два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Rwd(ref Cube cube)
        {
            Rd(ref cube);
            Md(ref cube);
        }

        /// <summary>
        /// Поворот лівої грані разом з центровою за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Lw(ref Cube cube)
        {
            L(ref cube);
            M(ref cube);
        }
        
        /// <summary>
        /// Поворот лівої грані разом з центровою проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Lwi(ref Cube cube)
        {
            Li(ref cube);
            Mi(ref cube);
        }

        /// <summary>
        /// Поворот лівої грані разом з центровою два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Lwd(ref Cube cube)
        {
            Ld(ref cube);
            Md(ref cube);
        }

        /// <summary>
        /// Поворот фронтальної грані разом з центровою за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Fw(ref Cube cube)
        {
            F(ref cube);
            S(ref cube);
        }
        
        /// <summary>
        /// Поворот фронтальної грані разом з централньой проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Fwi(ref Cube cube)
        {
            Fi(ref cube);
            Si(ref cube);
        }

        /// <summary>
        /// Поворот фронталньой грані разом з центровою два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Fwd(ref Cube cube)
        {
            Fd(ref cube);
            Sd(ref cube);
        }

        /// <summary>
        /// Поворот задньої грані разом з центровою за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Bw(ref Cube cube)
        {
            B(ref cube);
            Si(ref cube);
        }

        /// <summary>
        /// Поворот задньої грані разом з центровою грані проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Bwi(ref Cube cube)
        {
            Bi(ref cube);
            S(ref cube);
        }

        /// <summary>
        /// Поворот задньої грані разом з центровою два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Bwd(ref Cube cube)
        {
            Bd(ref cube);
            Sd(ref cube);
        }

        /// <summary>
        /// Поворот верхньої грані разом з центровою за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Uw(ref Cube cube)
        {
            U(ref cube);
            Ei(ref cube);
        }

        /// <summary>
        /// Поворот верхньої грані разом з центровою проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Uwi(ref Cube cube)
        {
            Ui(ref cube);
            E(ref cube);
        }

        /// <summary>
        /// Поворот верхньої  грані разом з центровою два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Uwd(ref Cube cube)
        {
            Ud(ref cube);
            Ed(ref cube);
        }

        /// <summary>
        /// Поворот нижньої грані разом з центровою за часовою стрілкою
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Dw(ref Cube cube)
        {
            D(ref cube);
            E(ref cube);
        }

        /// <summary>
        /// Поворот нижньої грані разом з центровою проти часової стрілки
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Dwi(ref Cube cube)
        {
            Di(ref cube);
            Ei(ref cube);
        }

        /// <summary>
        /// Поворот нижньої грані разом з центровою два рази
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void Dwd(ref Cube cube)
        {
            Dd(ref cube);
            Ed(ref cube);
        }
        #endregion

        #region Cube rotates
        /// <summary>
        /// Поворот усоьго куба за часовою стрілкою относительно правої стороны
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void x(ref Cube cube)
        {
            R(ref cube);
            Mi(ref cube);
            Li(ref cube);
        }

        /// <summary>
        /// Поворот усоьго куба проти часової стрілки относительно правої стороны
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void xi(ref Cube cube)
        {
            Ri(ref cube);
            M(ref cube);
            L(ref cube);
        }

        /// <summary>
        /// Поворот усоьго куба два рази относительно правої стороны
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void xd(ref Cube cube)
        {
            Rd(ref cube);
            Md(ref cube);
            Ld(ref cube);
        }

        /// <summary>
        /// Поворот усоьго куба за часовою стрілкою относительно верхньої стороны
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void y(ref Cube cube)
        {
            U(ref cube);
            Ei(ref cube);
            Di(ref cube);
        }

        /// <summary>
        /// Поворот усоьго куба проти часової стрілки относительно верхньої стороны
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void yi(ref Cube cube)
        {
            Ui(ref cube);
            E(ref cube);
            D(ref cube);
        }

        /// <summary>
        /// Поворот усоьго куба два рази относительно верхньої стороны
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void yd(ref Cube cube)
        {
            Ud(ref cube);
            Ed(ref cube);
            Dd(ref cube);
        }

        /// <summary>
        /// Поворот усоьго куба за часовою стрілкою относителньо фронтальної стороны
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void z(ref Cube cube)
        {
            F(ref cube);
            S(ref cube);
            Bi(ref cube);
        }

        /// <summary>
        /// Поворот усоьго куба проти часової стрілки относителньо фронтальної стороны
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void zi(ref Cube cube)
        {
            Fi(ref cube);
            Si(ref cube);
            B(ref cube);
        }

        /// <summary>
        /// Поворот усоьго куба два рази относителньо фронтальної стороны
        /// </summary>
        /// <param name="cube">Силка на об'єкт куба</param>
        public static void zd(ref Cube cube)
        {
            Fd(ref cube);
            Sd(ref cube);
            Bd(ref cube);
        }
        #endregion 

        /// <summary>
        /// Функція перевірки рішення першої фази алгоритму
        /// </summary>
        /// <param name="cube">Силка на куб</param>
        /// <param name="pattern">Якщо формула потребує поворота куба, додає хід</param>
        /// <returns>Якщо фаза вірішена, повертає true</returns>
        public static bool CheckFirstPhase(ref Cube cube, ref string pattern)
        {
            if ((cube.edge[0][0, 0] == cube.edge[0][1, 1] || cube.edge[0][0, 0] == cube.edge[5][1, 1])
                && (cube.edge[0][0, 1] == cube.edge[0][1, 1] || cube.edge[0][0, 1] == cube.edge[5][1, 1])
                && (cube.edge[0][0, 2] == cube.edge[0][1, 1] || cube.edge[0][0, 2] == cube.edge[5][1, 1])
                && (cube.edge[0][1, 0] == cube.edge[0][1, 1] || cube.edge[0][1, 0] == cube.edge[5][1, 1])
                && (cube.edge[0][1, 2] == cube.edge[0][1, 1] || cube.edge[0][1, 2] == cube.edge[5][1, 1])
                && (cube.edge[0][2, 0] == cube.edge[0][1, 1] || cube.edge[0][2, 0] == cube.edge[5][1, 1])
                && (cube.edge[0][2, 1] == cube.edge[0][1, 1] || cube.edge[0][2, 1] == cube.edge[5][1, 1])
                && (cube.edge[0][2, 2] == cube.edge[0][1, 1] || cube.edge[0][2, 2] == cube.edge[5][1, 1])
                && (cube.edge[5][0, 0] == cube.edge[0][1, 1] || cube.edge[5][0, 0] == cube.edge[5][1, 1])
                && (cube.edge[5][0, 1] == cube.edge[0][1, 1] || cube.edge[5][0, 1] == cube.edge[5][1, 1])
                && (cube.edge[5][0, 2] == cube.edge[0][1, 1] || cube.edge[5][0, 2] == cube.edge[5][1, 1])
                && (cube.edge[5][1, 0] == cube.edge[0][1, 1] || cube.edge[5][1, 0] == cube.edge[5][1, 1])
                && (cube.edge[5][1, 2] == cube.edge[0][1, 1] || cube.edge[5][1, 2] == cube.edge[5][1, 1])
                && (cube.edge[5][2, 0] == cube.edge[0][1, 1] || cube.edge[5][2, 0] == cube.edge[5][1, 1])
                && (cube.edge[5][2, 1] == cube.edge[0][1, 1] || cube.edge[5][2, 1] == cube.edge[5][1, 1])
                && (cube.edge[5][2, 2] == cube.edge[0][1, 1] || cube.edge[5][2, 2] == cube.edge[5][1, 1]))
            {
                if ((cube.edge[2][0, 1] == cube.edge[2][1, 1] || cube.edge[2][0, 1] == cube.edge[4][1, 1])
                    && (cube.edge[2][2, 1] == cube.edge[2][1, 1] || cube.edge[2][2, 1] == cube.edge[4][1, 1])
                    && (cube.edge[4][0, 1] == cube.edge[2][1, 1] || cube.edge[4][0, 1] == cube.edge[4][1, 1])
                    && (cube.edge[4][2, 1] == cube.edge[2][1, 1] || cube.edge[4][2, 1] == cube.edge[4][1, 1]))
                {
                    return true;
                }
                else if ((cube.edge[1][0, 1] == cube.edge[1][1, 1] || cube.edge[1][0, 1] == cube.edge[3][1, 1])
                    && (cube.edge[1][2, 1] == cube.edge[1][1, 1] || cube.edge[1][2, 1] == cube.edge[3][1, 1])
                    && (cube.edge[3][0, 1] == cube.edge[1][1, 1] || cube.edge[3][0, 1] == cube.edge[3][1, 1])
                    && (cube.edge[3][2, 1] == cube.edge[1][1, 1] || cube.edge[3][2, 1] == cube.edge[3][1, 1]))
                {
                    cube.DoRotate("yi");
                    pattern += "yi ";

                    return true;
                }
            }
            else if ((cube.edge[2][0, 0] == cube.edge[2][1, 1] || cube.edge[2][0, 0] == cube.edge[4][1, 1])
                && (cube.edge[2][0, 1] == cube.edge[2][1, 1] || cube.edge[2][0, 1] == cube.edge[4][1, 1])
                && (cube.edge[2][0, 2] == cube.edge[2][1, 1] || cube.edge[2][0, 2] == cube.edge[4][1, 1])
                && (cube.edge[2][1, 0] == cube.edge[2][1, 1] || cube.edge[2][1, 0] == cube.edge[4][1, 1])
                && (cube.edge[2][1, 2] == cube.edge[2][1, 1] || cube.edge[2][1, 2] == cube.edge[4][1, 1])
                && (cube.edge[2][2, 0] == cube.edge[2][1, 1] || cube.edge[2][2, 0] == cube.edge[4][1, 1])
                && (cube.edge[2][2, 1] == cube.edge[2][1, 1] || cube.edge[2][2, 1] == cube.edge[4][1, 1])
                && (cube.edge[2][2, 2] == cube.edge[2][1, 1] || cube.edge[2][2, 2] == cube.edge[4][1, 1])
                && (cube.edge[4][0, 0] == cube.edge[2][1, 1] || cube.edge[4][0, 0] == cube.edge[4][1, 1])
                && (cube.edge[4][0, 1] == cube.edge[2][1, 1] || cube.edge[4][0, 1] == cube.edge[4][1, 1])
                && (cube.edge[4][0, 2] == cube.edge[2][1, 1] || cube.edge[4][0, 2] == cube.edge[4][1, 1])
                && (cube.edge[4][1, 0] == cube.edge[2][1, 1] || cube.edge[4][1, 0] == cube.edge[4][1, 1])
                && (cube.edge[4][1, 2] == cube.edge[2][1, 1] || cube.edge[4][1, 2] == cube.edge[4][1, 1])
                && (cube.edge[4][2, 0] == cube.edge[2][1, 1] || cube.edge[4][2, 0] == cube.edge[4][1, 1])
                && (cube.edge[4][2, 1] == cube.edge[2][1, 1] || cube.edge[4][2, 1] == cube.edge[4][1, 1])
                && (cube.edge[4][2, 2] == cube.edge[2][1, 1] || cube.edge[4][2, 2] == cube.edge[4][1, 1]))
            {
                if ((cube.edge[5][0, 1] == cube.edge[5][1, 1] || cube.edge[5][0, 1] == cube.edge[0][1, 1])
                    && (cube.edge[5][2, 1] == cube.edge[5][1, 1] || cube.edge[5][2, 1] == cube.edge[0][1, 1])
                    && (cube.edge[0][0, 1] == cube.edge[5][1, 1] || cube.edge[0][0, 1] == cube.edge[0][1, 1])
                    && (cube.edge[0][2, 1] == cube.edge[5][1, 1] || cube.edge[0][2, 1] == cube.edge[0][1, 1]))
                {
                    cube.DoRotate("x");
                    pattern += "x ";

                    return true;
                }
                else if((cube.edge[1][0, 1] == cube.edge[1][1, 1] || cube.edge[1][0, 1] == cube.edge[3][1, 1])
                    && (cube.edge[1][2, 1] == cube.edge[1][1, 1] || cube.edge[1][2, 1] == cube.edge[3][1, 1])
                    && (cube.edge[3][0, 1] == cube.edge[1][1, 1] || cube.edge[3][0, 1] == cube.edge[3][1, 1])
                    && (cube.edge[3][2, 1] == cube.edge[1][1, 1] || cube.edge[3][2, 1] == cube.edge[3][1, 1]))
                {
                    cube.DoRotate("x");
                    cube.DoRotate("yi");
                    pattern += "x yi ";

                    return true;
                }
            }
            else if ((cube.edge[1][0, 0] == cube.edge[1][1, 1] || cube.edge[1][0, 0] == cube.edge[3][1, 1])
                && (cube.edge[1][0, 1] == cube.edge[1][1, 1] || cube.edge[1][0, 1] == cube.edge[3][1, 1])
                && (cube.edge[1][0, 2] == cube.edge[1][1, 1] || cube.edge[1][0, 2] == cube.edge[3][1, 1])
                && (cube.edge[1][1, 0] == cube.edge[1][1, 1] || cube.edge[1][1, 0] == cube.edge[3][1, 1])
                && (cube.edge[1][1, 2] == cube.edge[1][1, 1] || cube.edge[1][1, 2] == cube.edge[3][1, 1])
                && (cube.edge[1][2, 0] == cube.edge[1][1, 1] || cube.edge[1][2, 0] == cube.edge[3][1, 1])
                && (cube.edge[1][2, 1] == cube.edge[1][1, 1] || cube.edge[1][2, 1] == cube.edge[3][1, 1])
                && (cube.edge[1][2, 2] == cube.edge[1][1, 1] || cube.edge[1][2, 2] == cube.edge[3][1, 1])
                && (cube.edge[3][0, 0] == cube.edge[1][1, 1] || cube.edge[3][0, 0] == cube.edge[3][1, 1])
                && (cube.edge[3][0, 1] == cube.edge[1][1, 1] || cube.edge[3][0, 1] == cube.edge[3][1, 1])
                && (cube.edge[3][0, 2] == cube.edge[1][1, 1] || cube.edge[3][0, 2] == cube.edge[3][1, 1])
                && (cube.edge[3][1, 0] == cube.edge[1][1, 1] || cube.edge[3][1, 0] == cube.edge[3][1, 1])
                && (cube.edge[3][1, 2] == cube.edge[1][1, 1] || cube.edge[3][1, 2] == cube.edge[3][1, 1])
                && (cube.edge[3][2, 0] == cube.edge[1][1, 1] || cube.edge[3][2, 0] == cube.edge[3][1, 1])
                && (cube.edge[3][2, 1] == cube.edge[1][1, 1] || cube.edge[3][2, 1] == cube.edge[3][1, 1])
                && (cube.edge[3][2, 2] == cube.edge[1][1, 1] || cube.edge[3][2, 2] == cube.edge[3][1, 1]))
            {
                if ((cube.edge[2][0, 1] == cube.edge[2][1, 1] || cube.edge[2][0, 1] == cube.edge[4][1, 1])
                    && (cube.edge[2][2, 1] == cube.edge[2][1, 1] || cube.edge[2][2, 1] == cube.edge[4][1, 1])
                    && (cube.edge[4][0, 1] == cube.edge[2][1, 1] || cube.edge[4][0, 1] == cube.edge[4][1, 1])
                    && (cube.edge[4][2, 1] == cube.edge[2][1, 1] || cube.edge[4][2, 1] == cube.edge[4][1, 1]))
                {
                    cube.DoRotate("z");
                    pattern += "z ";

                    return true;
                }
                else if((cube.edge[5][0, 1] == cube.edge[5][1, 1] || cube.edge[5][0, 1] == cube.edge[0][1, 1])
                    && (cube.edge[5][2, 1] == cube.edge[5][1, 1] || cube.edge[5][2, 1] == cube.edge[0][1, 1])
                    && (cube.edge[0][0, 1] == cube.edge[5][1, 1] || cube.edge[0][0, 1] == cube.edge[0][1, 1])
                    && (cube.edge[0][2, 1] == cube.edge[5][1, 1] || cube.edge[0][2, 1] == cube.edge[0][1, 1]))
                {
                    cube.DoRotate("z");
                    cube.DoRotate("yi");
                    pattern += "z yi ";

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Перевірка на кінцеве рішення другої фази (повна сборка куба)
        /// </summary>
        /// <param name="cube">Силка на куб</param>
        /// <returns>Якщо куб зібран, повертає true</returns>
        public static bool IsCubeSolved(ref Cube cube)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        if(cube.edge[i][j, z] != cube.edge[i][1,1])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
