using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfOrganizingMap
{
    /// <name>Map</name>
    /// <type>Class</type>
    /// <author>John Wittenauer</author>
    /// <summary>
    /// This class contains the structure and logic for the map itself.  The various parameters
    /// passed down from the user interface are attributes of the class and control the map's
    /// size, learning rate and so on.  The map can be trained one iteration (or epoch) at a
    /// time so the user interface can display progress visually as the map training progresses.
    /// </summary>
    public class Map
    {
        #region Attributes
        private int xSize;
        private int ySize;
        private int mapRadius;
        private int dimensionality;
        private int epoch;
        private int epochLimit;
        private double timeConstant;
        private double learningRate;
        private bool exponentialRadiusDecay;
        private bool exponentialLearningDecay;
        private bool exponentialInfluenceDecay;
        private Parser input;
        private Cell[,] lattice;
        private double[,] uMatrix;
        private double averageQuantizationError;
        #endregion


        #region Properties
        public int XSize
        {
            get { return xSize; }
        }

        public int YSize
        {
            get { return ySize; }
        }

        public int MapRadius
        {
            get { return mapRadius; }
        }

        public int Dimensionality
        {
            get { return dimensionality; }
        }

        public int Epoch
        {
            get { return epoch; }
        }

        public int EpochLimit
        {
            get { return epochLimit; }
        }

        public double TimeConstant
        {
            get { return timeConstant; }
        }

        public double LearningRate
        {
            get { return learningRate; }
        }

        public bool ExponentialRadiusDecay
        {
            get { return exponentialRadiusDecay; }
            set { exponentialRadiusDecay = value; }
        }

        public bool ExponentialLearningDecay
        {
            get { return exponentialLearningDecay; }
            set { exponentialLearningDecay = value; }
        }

        public bool ExponentialInfluenceDecay
        {
            get { return exponentialInfluenceDecay; }
            set { exponentialInfluenceDecay = value; }
        }

        public Parser Input
        {
            get { return input; }
        }

        public Cell[,] Lattice
        {
            get { return lattice; }
        }

        public double[,] UMatrix
        {
            get { return uMatrix; }
        }

        public double AverageQuantizationError
        {
            get { return averageQuantizationError; }
        }
        #endregion


        #region Instance Methods
        /// <name>Map</name>
        /// <type>Constructor</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Initializes the map based on parameters provided by the user.
        /// </summary>
        /// <param name="xSize">Horizontal size of the map</param>
        /// <param name="ySize">Vertical size of the map</param>
        /// <param name="numberOfDimensions">Degree of the weight vector on each cell</param>
        /// <param name="epochLimit">Maximum number of training iterations</param>
        /// <param name="learningRate">Learning rate for the map</param>
        public Map(int xSize, int ySize, int numberOfDimensions, int epochLimit, double learningRate, Parser input)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            mapRadius = Math.Max(xSize, ySize) / 2;
            dimensionality = numberOfDimensions;
            epoch = 0;
            this.epochLimit = epochLimit;
            timeConstant = epochLimit / Math.Log((double)mapRadius);
            this.learningRate = learningRate;
            averageQuantizationError = 0.0;

            // Set the map's parser object to the parser passed in for map initialization
            this.input = input;

            // The map is initialized with linear decay of the neighborhood, learning rate
            // and influence - these are properties on the map object that can be changed
            // at any time
            exponentialRadiusDecay = false;
            exponentialLearningDecay = false;
            exponentialInfluenceDecay = false;

            // Instantiate the two-dimensional array of cells
            lattice = new Cell[xSize, ySize];
            Random random = new Random();

            // Initialize each individual cell with random initial weight vectors
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    lattice[i, j] = new Cell(i, j, numberOfDimensions, random);
                }
            }

            // Initialize the unified distance matrix array - this is used for visualization
            // of a trained map but will not hold meaningful values until the map is complete
            uMatrix = new double[xSize, ySize];
            uMatrix.Initialize();
        }

        /// <name>TrainMap</name>
        /// <type>Method</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Trains the map on the provided input data by following the self-organizing map
        /// algorithm.  Exponential decay functions are used where influence needs to vary
        /// as a function of time or distance.  Each call executes one training iteration -
        /// the reason for this is an increased level of control on the interface layer.
        /// </summary>
        public void TrainMap()
        {
            // Randomly select an input vector for the set of input data
            Random random = new Random();
            int inputNumber = random.Next(input.NumberOfInstances);

            // Find the best matching unit given the selected input vector
            Cell BMU = FindBestMatchingUnit(input.Data[inputNumber]);

            // Calculate the current neighborhood radius - this is done with an exponential
            // decay function using the full map radius, the current time step and the
            // previously calculated time constant as parameters OR a straightforward
            // linear function based on user settings
            double neighborhoodRadius;
            if (exponentialRadiusDecay)
            {
                neighborhoodRadius = mapRadius * Math.Exp(-(double)epoch / timeConstant);
            }
            else
            {
                neighborhoodRadius = mapRadius * (epochLimit - epoch) / epochLimit;
            }

            // Also calculate the decayed learning rate for use in the next step - exponential
            // or linear depending on user settings
            double decayedLearningRate;
            if (exponentialLearningDecay)
            {
                decayedLearningRate = learningRate * Math.Exp(-(double)epoch / epochLimit);
            }
            else
            {
                decayedLearningRate = learningRate * (epochLimit - epoch) / epochLimit;
            }

            // Now that we have the BMU and neighborhood radius, iterate through the map
            // and update the weights of each cell that is in the BMU's radius
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    // Simple application of Pythagorean Theorem to find the cell's distance
                    double distanceFromBMU = Math.Sqrt((i - BMU.XPosition) * (i - BMU.XPosition) +
                        (j - BMU.YPosition) * (j - BMU.YPosition));


                    // Determine the influence at this node (decreases as a function
                    // of distance from the BMU) - either exponential or linear based
                    // on user input from the main interface
                    double influence;
                    if (exponentialInfluenceDecay)
                    {
                        influence = Math.Exp(-(distanceFromBMU * distanceFromBMU) / (neighborhoodRadius * neighborhoodRadius));
                    }
                    else
                    {
                        influence = (neighborhoodRadius - distanceFromBMU) / neighborhoodRadius;
                    }

                    if (influence > 0)
                    {
                        // Now iterate through each weight in the cell and perform the update
                        for (int k = 0; k < dimensionality; k++)
                        {
                            lattice[i, j].Vector[k] = lattice[i, j].Vector[k] + influence * decayedLearningRate *
                                (input.Data[inputNumber][k] - lattice[i, j].Vector[k]);
                        }
                    }
                }
            }

            // Advance the epoch counter
            epoch++;
        }

        /// <name>CalculateAQE</name>
        /// <type>Method</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Calculates the average quantization error between a trained map and its input
        /// data set.  For each instance in the input data, the BMU on the map and found
        /// and the total difference between the BMU and input vector is used.  The average
        /// of this difference across the entire data set is called the average quantization
        /// error, or AQE.
        /// </summary>
        public void CalculateAQE()
        {
            double sum = 0.0;

            for (int i = 0; i < input.NumberOfInstances; i++)
            {
                Cell BMU = FindBestMatchingUnit(input.Data[i]);
                sum += BMU.Distance(input.Data[i]);
            }

            averageQuantizationError = (sum / input.NumberOfInstances) * 100;
        }

        /// <name>CalculateUMatrix</name>
        /// <type>Method</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Calculates the average unified distance of each node in the lattice from
        /// every neighboring node.  This value is used as a visualization technique
        /// to show how "close" a node is to its surrounding nodes in the input vector
        /// space which can be used for clustering of similar data points.
        /// </summary>
        public void CalculateUMatrix()
        {
            double maxDistance = 0;

            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    // We have to account for border conditions on the map and avoid certain
                    // movements so as not to error on an array-out-of-bounds calculation - 
                    // it looks complex but it's basically saying "get the average distance
                    // of the 4 surrounding cells unless it's a border cell, then only check
                    // the cells in the directions that are applicable"
                    if (i == 0 & j == 0)
                    {
                        // Top left cell
                        uMatrix[i, j] = (lattice[i, j].Distance(lattice[i + 1, j]) +
                            lattice[i, j].Distance(lattice[i, j + 1])) / 2;
                    }
                    else if (i == 0 && j == ySize - 1)
                    {
                        // Bottom left cell
                        uMatrix[i, j] = (lattice[i, j].Distance(lattice[i + 1, j]) +
                               lattice[i, j].Distance(lattice[i, j - 1])) / 2;

                    }
                    else if (i == xSize - 1 && j == 0)
                    {
                        // Top right cell
                        uMatrix[i, j] = (lattice[i, j].Distance(lattice[i - 1, j]) +
                               lattice[i, j].Distance(lattice[i, j + 1])) / 2;

                    }
                    else if (i == xSize - 1 && j == ySize - 1)
                    {
                        // Bottom right cell
                        uMatrix[i, j] = (lattice[i, j].Distance(lattice[i - 1, j]) +
                               lattice[i, j].Distance(lattice[i, j - 1])) / 2;

                    }
                    else if (i == 0)
                    {
                        // Left border cell
                        uMatrix[i, j] = (lattice[i, j].Distance(lattice[i + 1, j]) +
                            lattice[i, j].Distance(lattice[i, j + 1]) +
                            lattice[i, j].Distance(lattice[i, j - 1])) / 3;
                    }
                    else if (j == 0)
                    {
                        // Top border cell
                        uMatrix[i, j] = (lattice[i, j].Distance(lattice[i + 1, j]) +
                               lattice[i, j].Distance(lattice[i, j + 1]) +
                               lattice[i, j].Distance(lattice[i - 1, j])) / 3;

                    }
                    else if (i == xSize - 1)
                    {
                        // Right border cell
                        uMatrix[i, j] = (lattice[i, j].Distance(lattice[i, j + 1]) +
                            lattice[i, j].Distance(lattice[i - 1, j]) +
                            lattice[i, j].Distance(lattice[i, j - 1])) / 3;
                    }
                    else if (j == ySize - 1)
                    {
                        // Bottom border cell
                        uMatrix[i, j] = (lattice[i, j].Distance(lattice[i + 1, j]) +
                            lattice[i, j].Distance(lattice[i - 1, j]) +
                            lattice[i, j].Distance(lattice[i, j - 1])) / 3;
                    }
                    else
                    {
                        // Middle cell
                        uMatrix[i, j] = (lattice[i, j].Distance(lattice[i + 1, j]) +
                            lattice[i, j].Distance(lattice[i, j + 1]) +
                            lattice[i, j].Distance(lattice[i - 1, j]) +
                            lattice[i, j].Distance(lattice[i, j - 1])) / 4;
                    }

                    if (uMatrix[i, j] > maxDistance)
                    {
                        maxDistance = uMatrix[i, j];
                    }
                }
            }

            // Normalize the unified matrix values based on the greatest recorded average - 
            // This will ensure that prominent features are visible when displayed
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    uMatrix[i, j] = uMatrix[i, j] / maxDistance;
                }
            }
        }

        /// <name>FindBestMatchingUnit</name>
        /// <type>Method</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Finds the cell in the map with the shortest distance from the input vector.
        /// </summary>
        /// <param name="inputVector">Input vector</param>
        /// <returns>Cell object representing closest match to the input vector</returns>
        private Cell FindBestMatchingUnit(double[] inputVector)
        {
            // Initialize BMU and shortest distance to the first cell in the lattice
            Cell BMU = lattice[0, 0];
            double shortestDistance = lattice[0, 0].Distance(inputVector);

            // Now iterate through the entire lattice and find the BMU
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    double distance = lattice[i, j].Distance(inputVector);

                    if (distance < shortestDistance)
                    {
                        // If a new closest cell has been found, update the shortest
                        // distance found and the best matching unit cell
                        shortestDistance = distance;
                        BMU = lattice[i, j];
                    }
                }
            }

            // Return the cell with the shorest distance from the input vector
            return BMU;
        }
        #endregion
    }
}
