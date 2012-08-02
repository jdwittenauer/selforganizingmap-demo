using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfOrganizingMap
{
    /// <name>Parser</name>
    /// <type>Class</type>
    /// <author>John Wittenauer</author>
    /// <summary>
    /// This class takes a comma-delimited input file and parses it into a two-dimensional
    /// array of floating-point numbers representing the training data.  The values in the
    /// array are normalized (between 0 and 1).
    /// </summary>
    public class Parser
    {
        #region Attributes
        private StreamReader input;
        private int numberOfDimensions;
        private int numberOfInstances;
        private double[][] data;
        #endregion


        #region Properties
        public int NumberOfDimensions
        {
            get { return numberOfDimensions; }
        }

        public int NumberOfInstances
        {
            get { return numberOfInstances; }
        }

        public double[][] Data
        {
            get { return data; }
        }
        #endregion


        #region Instance Methods
        /// <name>Parser</name>
        /// <type>Constructor</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Initializes the parser object with the number of attributes
        /// and number of instances in the input file.
        /// </summary>
        /// <param name="dimensions">Number of attributes in the data</param>
        /// <param name="instances">Number of instances in the data</param>
        public Parser(int dimensions, int instances)
        {
            numberOfDimensions = dimensions;
            numberOfInstances = instances;
            data = new double[instances][];

            for (int i = 0; i < instances; i++)
            {
                data[i] = new double[dimensions];
            }
        }

        /// <name>ParseInputFile</name>
        /// <type>Method</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Opens the input file and parses it into a data array that can be
        /// used by the map class to train a self-organizing map.
        /// </summary>
        /// <param name="filePath">Location of the input file</param>
        public void ParseInputFile(string filePath)
        {
            // Open the input file
            input = new StreamReader(filePath);
            int instanceNumber = 0;

            // Create arrays to keep track of the range of each
            // attribute (will be used to normalize the data)
            double[] max = new double[numberOfDimensions];
            double[] min = new double[numberOfDimensions];

            while (instanceNumber < numberOfInstances)
            {
                // Read a line from the input file and convert it to
                // an array of strings (comma delimited)
                string[] elements = input.ReadLine().Split(',');

                // For each attribute in the string array, convert to decimal
                // number and store in the data array, updating range as needed
                for (int i = 0; i < numberOfDimensions; i++)
                {
                    data[instanceNumber][i] = double.Parse(elements[i]);

                    // Initialize max and min values to the value of the first instance
                    if (instanceNumber == 0)
                    {
                        max[i] = data[instanceNumber][i];
                        min[i] = data[instanceNumber][i];
                    }
                    else if (data[instanceNumber][i] > max[i])
                    {
                        max[i] = data[instanceNumber][i];
                    }
                    else if (data[instanceNumber][i] < min[i])
                    {
                        min[i] = data[instanceNumber][i];
                    }
                }

                // Advance the counter and move to the next input line
                instanceNumber++;
            }

            // Normalize the input values based on each attribute's max range
            for (int i = 0; i < numberOfInstances; i++)
            {
                for (int j = 0; j < numberOfDimensions; j++)
                {
                    data[i][j] = (data[i][j] - min[j]) / (max[j] - min[j]);
                }
            }

            // Close connection to the input file
            input.Close();
        }
        #endregion
    }
}
