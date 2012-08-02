using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfOrganizingMap
{
    /// <name>Cell</name>
    /// <type>Class</type>
    /// <author>John Wittenauer</author>
    /// <summary>
    /// This class represents the individual nodes of a self-organizing map.  Each cell object
    /// contains its position in the map, the number of weights in the weight vector, and the
    /// actual weight vector itself (which is an array of floating-point numbers).
    /// </summary>
    public class Cell
    {
        #region Attributes
        private int xPosition;
        private int yPosition;
        private int dimensionality;
        private double[] vector;
        #endregion


        #region Properties
        public int XPosition
        {
            get { return xPosition; }
        }

        public int YPosition
        {
            get { return yPosition; }
        }

        public int Dimensionality
        {
            get { return dimensionality; }
        }

        public double[] Vector
        {
            get { return vector; }
            set { vector = value; }
        }
        #endregion


        #region Instance Methods
        /// <name>Cell</name>
        /// <type>Constructor</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Initializes a new cell object.
        /// </summary>
        /// <param name="xPosition">X position in the map's lattice</param>
        /// <param name="yPosition">Y position in the map's lattice</param>
        /// <param name="numberOfDimensions">Degree of the weight vector</param>
        /// <param name="random">Random seed used for weight initialization</param>
        public Cell(int xPosition, int yPosition, int numberOfDimensions, Random random)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            dimensionality = numberOfDimensions;
            vector = new double[numberOfDimensions];

            for (int i = 0; i < numberOfDimensions; i++)
            {
                vector[i] = random.NextDouble();
            }
        }

        /// <name>Distance</name>
        /// <type>Method</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Calculates the euclidean distance between an input vector and the curent
        /// cell's weight vector
        /// </summary>
        /// <param name="inputVector">Input vector</param>
        /// <returns>Sum of the distances between each dimension of the vectors</returns>
        public double Distance(double[] inputVector)
        {
            double distance = 0;

            for (int i = 0; i < dimensionality; i++)
            {
                distance += (vector[i] - inputVector[i]) * (vector[i] - inputVector[i]);
            }

            return Math.Sqrt(distance);
        }

        /// <name>Distance</name>
        /// <type>Method</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Calculates the euclidean distance between another cell and the curent
        /// cell's weight vector
        /// </summary>
        /// <param name="otherCell">Comparison cell</param>
        /// <returns>Sum of the distances between each dimension of the vectors</returns>
        public double Distance(Cell otherCell)
        {
            double distance = 0;

            for (int i = 0; i < dimensionality; i++)
            {
                distance += (vector[i] - otherCell.Vector[i]) * (vector[i] - otherCell.Vector[i]);
            }

            return Math.Sqrt(distance);
        }
        #endregion
    }
}
