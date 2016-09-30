using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeAutoSolving
{
    /// <summary>
    ///     Faces of one side for four outer blocks movement
    /// </summary>
    public class Face
    {
        /// <summary>
        ///     Number of four outer edges
        /// </summary>
        private int[] faces = new int[4];

        public Face(int[] faces)
        {
            this.faces = faces;
        }

        /// <summary>
        ///     Represents one of the four edges for outer movement
        /// </summary>
        /// <param name="indexer">
        ///     Index from 0 to 3 for 4 outer edges
        /// </param>
        /// <returns>
        ///     Number of face
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        ///     Index must be from 0 to 3
        /// </exception>
        public int this[int indexer]
        {
            get
            {
                return this.faces[indexer];
            }
            set
            {
                if (indexer >= 0 && indexer <= 3)
                {
                    this.faces[indexer] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index must be from 0 to 3");
                }
            }
        }
    }

    public class FixedNumber
    {
        private int[] numbers = new int[8];

        public FixedNumber(int[] numbers)
        {
            this.numbers = numbers;
        }

        public int this[int indexer]
        {
            get
            {
                if (indexer < 0 || indexer > 7)
                {
                    throw new IndexOutOfRangeException("Index must be from 0 to 7");
                }

                return this.numbers[indexer];
            }
            set
            {
                if (indexer < 0 || indexer > 7)
                {
                    throw new IndexOutOfRangeException("Index must be from 0 to 7");
                }

                if (value < 0 || value > 2)
                {
                    throw new Exception("Value must be 0, 1 or 2");
                }

                this.numbers[indexer] = value;
            }
        }
    }

    public class IsFixed
    {
        private bool[] isFixed = new bool[8];

        public IsFixed(bool[] isFixed)
        {
            this.isFixed = isFixed;
        }

        public bool this[int indexer]
        {
            get
            {
                if (indexer < 0 || indexer > 7)
                {
                    throw new IndexOutOfRangeException("Index must be from 0 to 7");
                }

                return this.isFixed[indexer];
            }
            set
            {
                if (indexer < 0 || indexer > 7)
                {
                    throw new IndexOutOfRangeException("Index must be from 0 to 7");
                }

                this.isFixed[indexer] = value;
            }
        }
    }

    /// <summary>
    ///     Data for inner blocks of side for movement
    /// </summary>
    public class Inner
    {
        /// <summary>
        ///     Number of inner side
        /// </summary>
        private int side;
        /// <summary>
        ///     Is clockwise turn
        /// </summary>
        private bool clockwise;

        /// <summary>
        ///     Side property represents inside blocks which side will be rotated
        /// </summary>
        /// <value>
        ///     Number of side can be from 0 to 5
        /// </value>
        /// <exception cref="InvalidValueException">
        ///     Value must be from 0 to 5
        /// </exception>
        public int Side
        {
            get
            {
                return this.side;
            }
            set
            {
                if (value >= 0 && value <= 5)
                {
                    this.side = value;
                }
                else
                {
                    throw new Exception("Invalid value. It must be from 0 to 5");
                }
            }
        }

        /// <summary>
        ///     Clockwise property is in which direction will be rotated side
        /// </summary>
        /// <value>
        ///     true: clockwise; false: counter-clockwise
        /// </value>
        public bool Clockwise
        {
            get
            {
                return this.clockwise;
            }
            set
            {
                this.clockwise = value;
            }
        }
    }

    /// <summary>
    ///     Data for outer blocks of side for movement
    /// </summary>
    public class Outer
    {
        /// <summary>
        ///     Faces of one side for four outer blocks movement
        /// </summary>
        private Face face;
        private FixedNumber fixedNumber;
        private IsFixed isFixed;

        /// <summary>
        ///     Face property represents the numbers of outer edges
        /// </summary>
        public Face Face
        {
            get
            {
                return this.face;
            }
            set
            {
                this.face = value;
            }
        }

        public FixedNumber FixedNumber
        {
            get
            {
                return this.fixedNumber;
            }
            set
            {
                this.fixedNumber = value;
            }
        }

        public IsFixed IsFixed
        {
            get
            {
                return this.IsFixed;
            }
            set
            {
                this.IsFixed = value;
            }
        }
    }

    /// <summary>
    ///     Main data of one movement
    /// </summary>
    public class MoveData
    {
        /// <summary>
        ///     Data for inner blocks of side for movement
        /// </summary>
        private Inner innerData = new Inner();
        /// <summary>
        ///     Data for outer blocks of side for movement
        /// </summary>
        private Outer outerData = new Outer();

        /// <summary>
        ///     Inner property represents the data for movement for inner blocks
        /// </summary>
        /// <value>
        ///     Data of inner blocks
        /// </value>
        public Inner Inner
        {
            get
            {
                return this.innerData;
            }
            set
            {
                this.innerData = value;
            }
        }

        /// <summary>
        ///     Outer property represents the data for movement for outer blocks
        /// </summary>
        /// <value>
        ///     Data of outer blocks
        /// </value>
        public Outer Outer
        {
            get
            {
                return this.outerData;
            }
            set
            {
                this.outerData = value;
            }
        }
    }
}
