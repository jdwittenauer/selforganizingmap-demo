using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelfOrganizingMap
{
    /// <name>Form1</name>
    /// <type>Class</type>
    /// <author>John Wittenauer</author>
    /// <summary>
    /// This class is the code file for the user iterface.  It handles events triggered by
    /// the interface and draws any map visualization being performed.
    /// </summary>
    public partial class Form1 : Form
    {
        public bool drawMap;
        public int xMapSize, yMapSize;
        public int xDrawSize, yDrawSize;
        public Map som;

        public Form1()
        {
            InitializeComponent();
            drawMap = false;
            xDrawSize = 800;
            yDrawSize = 600;
            lblTrainingTime.Text = String.Empty;
            lblAQE.Text = String.Empty;
        }


        #region Button Events
        /// <name>btnBrowse_Click</name>
        /// <type>Event</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Opens a dialog box to allow the user to select an input file.
        /// </summary>
        /// <param name="sender">Windows event parameter</param>
        /// <param name="e">Windows event parameter</param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dlgOpenFile.ShowDialog();
            txtFileName.Text = dlgOpenFile.FileName;
        }

        /// <name>btnRun_Click</name>
        /// <type>Event</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Trains the map using user-select settings and input.
        /// </summary>
        /// <param name="sender">Windows event parameter</param>
        /// <param name="e">Windows event parameter</param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            // Validate that required parameters have been specified
            bool verifiedParameters = false;
            if (txtFileName.Text.Length == 0)
            {
                MessageBox.Show("No file name was specified.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numAttributes.Value == 0 || numInstances.Value == 0)
            {
                MessageBox.Show("Number of attributes and number of instances were not properly specified.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(txtXMapSize.Text, out xMapSize) || !int.TryParse(txtYMapSize.Text, out yMapSize))
            {
                MessageBox.Show("Map size parameters were not properly specified.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                verifiedParameters = true;
            }

            if (verifiedParameters)
            {
                // Declare a parser object and parse the provided input file into a table
                Parser parser = new Parser((int)numAttributes.Value, (int)numInstances.Value);
                try
                {
                    parser.ParseInputFile(txtFileName.Text);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("File Read Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception Thrown: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Declare a new map object and initialize it appropriately
                som = new Map(xMapSize, yMapSize, parser.NumberOfDimensions, (int)numIterations.Value,
                    (double)numLearningRate.Value, parser);
                som.ExponentialRadiusDecay = radNeighborhoodExp.Checked;
                som.ExponentialLearningDecay = radLearningExp.Checked;
                som.ExponentialInfluenceDecay = radInfluenceExp.Checked;

                // Now that the map has been initialized we can draw the initial
                // version before training has started
                drawMap = true;
                proTrainingTime.Value = 0;
                pnlDisplayBlend.Refresh();

                // Timer for the overall map training time
                Stopwatch timer = new Stopwatch();
                timer.Start();

                // Each loop is one training iteration - continues until the
                // user-defined maximum is reached
                while (som.Epoch < som.EpochLimit)
                {
                    som.TrainMap();

                    if ((som.Epoch % (som.EpochLimit / 10)) == 0)
                    {
                        proTrainingTime.Value += 10;
                        pnlDisplayBlend.Refresh();
                    }
                }

                // Update the timer display
                TimeSpan elapsedTime = timer.Elapsed;
                timer.Stop();
                double timeDisplay = (double)elapsedTime.TotalMilliseconds / 1000;
                lblTrainingTime.Text = "Training Time: " + timeDisplay.ToString().Substring(0, 5) + " sec";

                // Calculate the average quantization error of the map and update the label
                som.CalculateAQE();
                //lblAQE.Text = "AQE: " + som.AverageQuantizationError.ToString().Substring(0, 8);
                lblAQE.Text = "AQE: " + som.AverageQuantizationError.ToString();

                // Do a final refresh on the blended visualization display
                pnlDisplayBlend.Refresh();

                // Calculate the unified distance matrix of the trained map and refresh the
                // display for the panel showing the U-matrix
                som.CalculateUMatrix();
                pnlDisplayUMatrix.Refresh();

                // Display the first four dimensions of the map as four component planes
                pnlDisplayComponents.Refresh();
            }
        }
        #endregion


        #region Visualization Panels
        /// <name>pnlDisplayBlend_Paint</name>
        /// <type>Event</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Overrides the panel's paint event handler to display a blended version of the
        /// map.  The color method used here reiles on the HSV (hue, saturation, value) color
        /// scheme.  Essentially, the color wheel is divided into n "slices" (where n is the
        /// number of dimensions in the data) giving us an evenly-spaced color for each
        /// attribute in the data.  The color of a cell is then computed as the "percent
        /// contribution" of each of these colors based on the weights for each dimension in
        /// the weight vector.
        /// </summary>
        /// <param name="sender">Windows event parameter</param>
        /// <param name="e">Paint event parameter</param>
        private void pnlDisplayBlend_Paint(object sender, PaintEventArgs e)
        {
            if (drawMap == true)
            {
                Graphics g = e.Graphics;

                // Compute the size of each cell as it is rendered on the screen
                int xCellSize = xDrawSize / xMapSize;
                int yCellSize = yDrawSize / yMapSize;

                // Array of colors - there will be one for each dimension
                double[,] color = new double[som.Dimensionality, 3];

                // Formula for converting from the HSV color system to RGB
                for (int i = 0; i < som.Dimensionality; i++)
                {
                    double red, green, blue;

                    double hue = ((double)i / som.Dimensionality) * 6.0;
                    double primary = 1.0;
                    double secondary = primary * (1 - Math.Abs((hue % 2) - 1));

                    if (hue >= 0.0 && hue < 1.0)
                    {
                        red = primary;
                        green = secondary;
                        blue = 0.0;
                    }
                    else if (hue >= 1.0 && hue < 2.0)
                    {
                        red = secondary;
                        green = primary;
                        blue = 0.0;
                    }
                    else if (hue >= 2.0 && hue < 3.0)
                    {
                        red = 0.0;
                        green = primary;
                        blue = secondary;
                    }
                    else if (hue >= 3.0 && hue < 4.0)
                    {
                        red = 0.0;
                        green = secondary;
                        blue = primary;
                    }
                    else if (hue >= 4.0 && hue < 5.0)
                    {
                        red = secondary;
                        green = 0.0;
                        blue = primary;
                    }
                    else
                    {
                        red = primary;
                        green = 0.0;
                        blue = secondary;
                    }

                    color[i, 0] = red;
                    color[i, 1] = green;
                    color[i, 2] = blue;
                }

                // Now determine the color at each node based on the colors calculated
                // above for each dimension in the weight vector
                for (int i = 0; i < xMapSize; i++)
                {
                    for (int j = 0; j < yMapSize; j++)
                    {
                        double red = 0.0, green = 0.0, blue = 0.0;
                        double totalRed = 0.0, totalGreen = 0.0, totalBlue = 0.0;

                        for (int k = 0; k < som.Dimensionality; k++)
                        {
                            red += color[k, 0] * som.Lattice[i, j].Vector[k];
                            green += color[k, 1] * som.Lattice[i, j].Vector[k];
                            blue += color[k, 2] * som.Lattice[i, j].Vector[k];

                            totalRed += color[k, 0];
                            totalGreen += color[k, 1];
                            totalBlue += color[k, 2];
                        }

                        red = red / totalRed;
                        green = green / totalGreen;
                        blue = blue / totalBlue;

                        Brush sBrush = new SolidBrush(Color.FromArgb((int)Math.Floor(red * 255),
                            (int)Math.Floor(green * 255), (int)Math.Floor(blue * 255)));

                        g.FillRectangle(sBrush, i * xCellSize, j * yCellSize, xCellSize, yCellSize);
                    }
                }
            }
        }

        /// <name>pnlDisplayComponents_Paint</name>
        /// <type>Event</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Overrides the panel's paint event handler to display the first four
        /// component dimensions of the data.  Colors ranges from blue (low) to
        /// red (high).
        /// </summary>
        /// <param name="sender">Windows event parameter</param>
        /// <param name="e">Paint event parameter</param>
        private void pnlDisplayComponents_Paint(object sender, PaintEventArgs e)
        {
            if (drawMap == true)
            {
                Graphics g = e.Graphics;

                // Compute the size of each cell as it is rendered on the screen
                int xCellSize = xDrawSize / (xMapSize * 2);
                int yCellSize = yDrawSize / (yMapSize * 2);

                // Since we're rendering four different maps in the same display area,
                // we need an offset value to "push" the map to the correct quadrant
                int xOffset = xCellSize * xMapSize;
                int yOffset = yCellSize * yMapSize;

                for (int i = 0; i < xMapSize; i++)
                {
                    for (int j = 0; j < yMapSize; j++)
                    {
                        // Render the top left map - this corresponds to the first data dimension
                        Brush sBrush1 = new SolidBrush(Color.FromArgb((int)Math.Floor(GetRedValue(som.Lattice[i, j].Vector[0]) * 255),
                            (int)Math.Floor(GetGreenValue(som.Lattice[i, j].Vector[0]) * 255),
                            (int)Math.Floor(GetBlueValue(som.Lattice[i, j].Vector[0]) * 255)));

                        g.FillRectangle(sBrush1, i * xCellSize, j * yCellSize, xCellSize, yCellSize);

                        // Render the top right map - this corresponds to the second data dimension
                        Brush sBrush2 = new SolidBrush(Color.FromArgb((int)Math.Floor(GetRedValue(som.Lattice[i, j].Vector[1]) * 255),
                            (int)Math.Floor(GetGreenValue(som.Lattice[i, j].Vector[1]) * 255),
                            (int)Math.Floor(GetBlueValue(som.Lattice[i, j].Vector[1]) * 255)));

                        g.FillRectangle(sBrush2, xOffset + i * xCellSize, j * yCellSize, xCellSize, yCellSize);

                        // Render the bottom left map - this corresponds to the third data dimension
                        Brush sBrush3 = new SolidBrush(Color.FromArgb((int)Math.Floor(GetRedValue(som.Lattice[i, j].Vector[2]) * 255),
                            (int)Math.Floor(GetGreenValue(som.Lattice[i, j].Vector[2]) * 255),
                            (int)Math.Floor(GetBlueValue(som.Lattice[i, j].Vector[2]) * 255)));

                        g.FillRectangle(sBrush3, i * xCellSize, yOffset + j * yCellSize, xCellSize, yCellSize);

                        // Only render the fourth map if the data has at least four dimensions to display
                        if (som.Dimensionality > 3)
                        {
                            // Render the bottom right map - this corresponds to the fourth data dimension
                            Brush sBrush4 = new SolidBrush(Color.FromArgb((int)Math.Floor(GetRedValue(som.Lattice[i, j].Vector[3]) * 255),
                                (int)Math.Floor(GetGreenValue(som.Lattice[i, j].Vector[3]) * 255),
                                (int)Math.Floor(GetBlueValue(som.Lattice[i, j].Vector[3]) * 255)));

                            g.FillRectangle(sBrush4, xOffset + i * xCellSize, yOffset + j * yCellSize, xCellSize, yCellSize);
                        }
                    }
                }
            }
        }

        /// <name>pnlDisplayUMatrix_Paint</name>
        /// <type>Event</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// Overrides the panel's paint event handler to display the unified distance
        /// matrix for the current map.  Dark areas show greater difference while light
        /// areas show greater similarity.
        /// </summary>
        /// <param name="sender">Windows event parameter</param>
        /// <param name="e">Paint event parameter</param>
        private void pnlDisplayUMatrix_Paint(object sender, PaintEventArgs e)
        {
            if (drawMap == true)
            {
                Graphics g = e.Graphics;

                // Compute the size of each cell as it is rendered on the screen
                int xCellSize = xDrawSize / xMapSize;
                int yCellSize = yDrawSize / yMapSize;

                for (int i = 0; i < xMapSize; i++)
                {
                    for (int j = 0; j < yMapSize; j++)
                    {
                        // Use the U-matrix values to calculate a greyscale value for this cell
                        Brush sBrush = new SolidBrush(Color.FromArgb((int)Math.Floor(255 - (som.UMatrix[i, j] * 255)),
                            (int)Math.Floor(255 - (som.UMatrix[i, j] * 255)),
                            (int)Math.Floor(255 - (som.UMatrix[i, j] * 255))));

                        g.FillRectangle(sBrush, i * xCellSize, j * yCellSize, xCellSize, yCellSize);
                    }
                }
            }
        }
        #endregion


        #region Private Methods
        /// <name>GetRedValue</name>
        /// <type>Method</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// This is used exclusively by the component plane visualization tab.  The purpose
        /// is to return a red "precent" color contribution which combined with green and
        /// blue components gives a smooth transition from blue to green to yellow in the display.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        private double GetRedValue(double vector)
        {
            if (vector >= 0.0 && vector < 0.5)
            {
                return 0.0;
            }
            else if (vector >= 0.5 && vector < 0.75)
            {
                return (vector - 0.5) * 4;
            }
            else
            {
                return 1.0;
            }
        }

        /// <name>GetGreenValue</name>
        /// <type>Method</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// This is used exclusively by the component plane visualization tab.  The purpose
        /// is to return a green "precent" color contribution which combined with red and
        /// blue components gives a smooth transition from blue to green to yellow in the display.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        private double GetGreenValue(double vector)
        {
            if (vector >= 0.0 && vector < 0.25)
            {
                return vector * 4;
            }
            else if (vector >= 0.25 && vector < 0.75)
            {
                return 1.0;
            }
            else
            {
                return (1 - vector) * 4;
            }
        }

        /// <name>GetBlueValue</name>
        /// <type>Method</type>
        /// <author>John Wittenauer</author>
        /// <summary>
        /// This is used exclusively by the component plane visualization tab.  The purpose
        /// is to return a blue "precent" color contribution which combined with green and
        /// red components gives a smooth transition from blue to green to yellow in the display.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        private double GetBlueValue(double vector)
        {
            if (vector >= 0.0 && vector < 0.25)
            {
                return 1.0;
            }
            else if (vector >= 0.25 && vector < 0.5)
            {
                return (0.5 - vector) * 4;
            }
            else
            {
                return 0.0;
            }
        }
        #endregion
    }
}
