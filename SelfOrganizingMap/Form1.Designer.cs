namespace SelfOrganizingMap
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.lblIterations = new System.Windows.Forms.Label();
            this.lblLearningRate = new System.Windows.Forms.Label();
            this.numLearningRate = new System.Windows.Forms.NumericUpDown();
            this.lblAttributes = new System.Windows.Forms.Label();
            this.lblInstances = new System.Windows.Forms.Label();
            this.numAttributes = new System.Windows.Forms.NumericUpDown();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.numInstances = new System.Windows.Forms.NumericUpDown();
            this.lblMapSize = new System.Windows.Forms.Label();
            this.txtXMapSize = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.txtYMapSize = new System.Windows.Forms.TextBox();
            this.radNeighborhoodLinear = new System.Windows.Forms.RadioButton();
            this.lblRadiusDecay = new System.Windows.Forms.Label();
            this.radNeighborhoodExp = new System.Windows.Forms.RadioButton();
            this.lblLearningDecay = new System.Windows.Forms.Label();
            this.radLearningLinear = new System.Windows.Forms.RadioButton();
            this.radLearningExp = new System.Windows.Forms.RadioButton();
            this.lblInfluenceDecay = new System.Windows.Forms.Label();
            this.radInfluenceLinear = new System.Windows.Forms.RadioButton();
            this.radInfluenceExp = new System.Windows.Forms.RadioButton();
            this.pnlNeighborhood = new System.Windows.Forms.Panel();
            this.pnlLearningRate = new System.Windows.Forms.Panel();
            this.pnlInfluence = new System.Windows.Forms.Panel();
            this.pnlDisplayBlend = new System.Windows.Forms.Panel();
            this.proTrainingTime = new System.Windows.Forms.ProgressBar();
            this.lblTrainingTime = new System.Windows.Forms.Label();
            this.tabVisualization = new System.Windows.Forms.TabControl();
            this.tabBlend = new System.Windows.Forms.TabPage();
            this.tabUMatrix = new System.Windows.Forms.TabPage();
            this.pnlDisplayUMatrix = new System.Windows.Forms.Panel();
            this.tabComponent = new System.Windows.Forms.TabPage();
            this.pnlDisplayComponents = new System.Windows.Forms.Panel();
            this.lblAQE = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numLearningRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInstances)).BeginInit();
            this.pnlNeighborhood.SuspendLayout();
            this.pnlLearningRate.SuspendLayout();
            this.pnlInfluence.SuspendLayout();
            this.tabVisualization.SuspendLayout();
            this.tabBlend.SuspendLayout();
            this.tabUMatrix.SuspendLayout();
            this.tabComponent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(379, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(462, 13);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(82, 15);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(291, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(12, 18);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(64, 13);
            this.lblFileName.TabIndex = 14;
            this.lblFileName.Text = "Input File:";
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "FileName";
            this.dlgOpenFile.Filter = "DATA Files (*.data)|*.data";
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIterations.Location = new System.Drawing.Point(12, 163);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(64, 13);
            this.lblIterations.TabIndex = 18;
            this.lblIterations.Text = "Iterations:";
            // 
            // lblLearningRate
            // 
            this.lblLearningRate.AutoSize = true;
            this.lblLearningRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLearningRate.Location = new System.Drawing.Point(12, 128);
            this.lblLearningRate.Name = "lblLearningRate";
            this.lblLearningRate.Size = new System.Drawing.Size(91, 13);
            this.lblLearningRate.TabIndex = 20;
            this.lblLearningRate.Text = "Learning Rate:";
            // 
            // numLearningRate
            // 
            this.numLearningRate.DecimalPlaces = 2;
            this.numLearningRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numLearningRate.Location = new System.Drawing.Point(109, 126);
            this.numLearningRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLearningRate.Name = "numLearningRate";
            this.numLearningRate.Size = new System.Drawing.Size(75, 20);
            this.numLearningRate.TabIndex = 6;
            // 
            // lblAttributes
            // 
            this.lblAttributes.AutoSize = true;
            this.lblAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttributes.Location = new System.Drawing.Point(12, 55);
            this.lblAttributes.Name = "lblAttributes";
            this.lblAttributes.Size = new System.Drawing.Size(65, 13);
            this.lblAttributes.TabIndex = 23;
            this.lblAttributes.Text = "Attributes:";
            // 
            // lblInstances
            // 
            this.lblInstances.AutoSize = true;
            this.lblInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstances.Location = new System.Drawing.Point(11, 92);
            this.lblInstances.Name = "lblInstances";
            this.lblInstances.Size = new System.Drawing.Size(66, 13);
            this.lblInstances.TabIndex = 24;
            this.lblInstances.Text = "Instances:";
            // 
            // numAttributes
            // 
            this.numAttributes.Location = new System.Drawing.Point(109, 53);
            this.numAttributes.Name = "numAttributes";
            this.numAttributes.Size = new System.Drawing.Size(75, 20);
            this.numAttributes.TabIndex = 4;
            // 
            // numIterations
            // 
            this.numIterations.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numIterations.Location = new System.Drawing.Point(109, 161);
            this.numIterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(75, 20);
            this.numIterations.TabIndex = 7;
            // 
            // numInstances
            // 
            this.numInstances.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInstances.Location = new System.Drawing.Point(109, 90);
            this.numInstances.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numInstances.Name = "numInstances";
            this.numInstances.Size = new System.Drawing.Size(75, 20);
            this.numInstances.TabIndex = 5;
            // 
            // lblMapSize
            // 
            this.lblMapSize.AutoSize = true;
            this.lblMapSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapSize.Location = new System.Drawing.Point(12, 200);
            this.lblMapSize.Name = "lblMapSize";
            this.lblMapSize.Size = new System.Drawing.Size(63, 13);
            this.lblMapSize.TabIndex = 28;
            this.lblMapSize.Text = "Map Size:";
            // 
            // txtXMapSize
            // 
            this.txtXMapSize.Location = new System.Drawing.Point(108, 197);
            this.txtXMapSize.Name = "txtXMapSize";
            this.txtXMapSize.Size = new System.Drawing.Size(26, 20);
            this.txtXMapSize.TabIndex = 8;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(140, 200);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(12, 13);
            this.lblX.TabIndex = 30;
            this.lblX.Text = "x";
            // 
            // txtYMapSize
            // 
            this.txtYMapSize.Location = new System.Drawing.Point(157, 197);
            this.txtYMapSize.Name = "txtYMapSize";
            this.txtYMapSize.Size = new System.Drawing.Size(26, 20);
            this.txtYMapSize.TabIndex = 9;
            // 
            // radNeighborhoodLinear
            // 
            this.radNeighborhoodLinear.AutoSize = true;
            this.radNeighborhoodLinear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNeighborhoodLinear.Location = new System.Drawing.Point(0, 28);
            this.radNeighborhoodLinear.Name = "radNeighborhoodLinear";
            this.radNeighborhoodLinear.Size = new System.Drawing.Size(60, 17);
            this.radNeighborhoodLinear.TabIndex = 42;
            this.radNeighborhoodLinear.Text = "Linear";
            this.radNeighborhoodLinear.UseVisualStyleBackColor = true;
            // 
            // lblRadiusDecay
            // 
            this.lblRadiusDecay.AutoSize = true;
            this.lblRadiusDecay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRadiusDecay.Location = new System.Drawing.Point(-2, 0);
            this.lblRadiusDecay.Name = "lblRadiusDecay";
            this.lblRadiusDecay.Size = new System.Drawing.Size(133, 13);
            this.lblRadiusDecay.TabIndex = 33;
            this.lblRadiusDecay.Text = "Neighborhood Radius:";
            // 
            // radNeighborhoodExp
            // 
            this.radNeighborhoodExp.AutoSize = true;
            this.radNeighborhoodExp.Checked = true;
            this.radNeighborhoodExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNeighborhoodExp.Location = new System.Drawing.Point(66, 28);
            this.radNeighborhoodExp.Name = "radNeighborhoodExp";
            this.radNeighborhoodExp.Size = new System.Drawing.Size(91, 17);
            this.radNeighborhoodExp.TabIndex = 34;
            this.radNeighborhoodExp.TabStop = true;
            this.radNeighborhoodExp.Text = "Exponential";
            this.radNeighborhoodExp.UseVisualStyleBackColor = true;
            // 
            // lblLearningDecay
            // 
            this.lblLearningDecay.AutoSize = true;
            this.lblLearningDecay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLearningDecay.Location = new System.Drawing.Point(-2, 0);
            this.lblLearningDecay.Name = "lblLearningDecay";
            this.lblLearningDecay.Size = new System.Drawing.Size(91, 13);
            this.lblLearningDecay.TabIndex = 35;
            this.lblLearningDecay.Text = "Learning Rate:";
            // 
            // radLearningLinear
            // 
            this.radLearningLinear.AutoSize = true;
            this.radLearningLinear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLearningLinear.Location = new System.Drawing.Point(0, 25);
            this.radLearningLinear.Name = "radLearningLinear";
            this.radLearningLinear.Size = new System.Drawing.Size(60, 17);
            this.radLearningLinear.TabIndex = 43;
            this.radLearningLinear.Text = "Linear";
            this.radLearningLinear.UseVisualStyleBackColor = true;
            // 
            // radLearningExp
            // 
            this.radLearningExp.AutoSize = true;
            this.radLearningExp.Checked = true;
            this.radLearningExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLearningExp.Location = new System.Drawing.Point(67, 25);
            this.radLearningExp.Name = "radLearningExp";
            this.radLearningExp.Size = new System.Drawing.Size(91, 17);
            this.radLearningExp.TabIndex = 37;
            this.radLearningExp.TabStop = true;
            this.radLearningExp.Text = "Exponential";
            this.radLearningExp.UseVisualStyleBackColor = true;
            // 
            // lblInfluenceDecay
            // 
            this.lblInfluenceDecay.AutoSize = true;
            this.lblInfluenceDecay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfluenceDecay.Location = new System.Drawing.Point(-3, 0);
            this.lblInfluenceDecay.Name = "lblInfluenceDecay";
            this.lblInfluenceDecay.Size = new System.Drawing.Size(64, 13);
            this.lblInfluenceDecay.TabIndex = 38;
            this.lblInfluenceDecay.Text = "Influence:";
            // 
            // radInfluenceLinear
            // 
            this.radInfluenceLinear.AutoSize = true;
            this.radInfluenceLinear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInfluenceLinear.Location = new System.Drawing.Point(1, 26);
            this.radInfluenceLinear.Name = "radInfluenceLinear";
            this.radInfluenceLinear.Size = new System.Drawing.Size(60, 17);
            this.radInfluenceLinear.TabIndex = 44;
            this.radInfluenceLinear.Text = "Linear";
            this.radInfluenceLinear.UseVisualStyleBackColor = true;
            // 
            // radInfluenceExp
            // 
            this.radInfluenceExp.AutoSize = true;
            this.radInfluenceExp.Checked = true;
            this.radInfluenceExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInfluenceExp.Location = new System.Drawing.Point(67, 26);
            this.radInfluenceExp.Name = "radInfluenceExp";
            this.radInfluenceExp.Size = new System.Drawing.Size(91, 17);
            this.radInfluenceExp.TabIndex = 40;
            this.radInfluenceExp.TabStop = true;
            this.radInfluenceExp.Text = "Exponential";
            this.radInfluenceExp.UseVisualStyleBackColor = true;
            // 
            // pnlNeighborhood
            // 
            this.pnlNeighborhood.Controls.Add(this.lblRadiusDecay);
            this.pnlNeighborhood.Controls.Add(this.radNeighborhoodLinear);
            this.pnlNeighborhood.Controls.Add(this.radNeighborhoodExp);
            this.pnlNeighborhood.Location = new System.Drawing.Point(15, 234);
            this.pnlNeighborhood.Name = "pnlNeighborhood";
            this.pnlNeighborhood.Size = new System.Drawing.Size(169, 57);
            this.pnlNeighborhood.TabIndex = 10;
            // 
            // pnlLearningRate
            // 
            this.pnlLearningRate.Controls.Add(this.lblLearningDecay);
            this.pnlLearningRate.Controls.Add(this.radLearningLinear);
            this.pnlLearningRate.Controls.Add(this.radLearningExp);
            this.pnlLearningRate.Location = new System.Drawing.Point(15, 306);
            this.pnlLearningRate.Name = "pnlLearningRate";
            this.pnlLearningRate.Size = new System.Drawing.Size(169, 57);
            this.pnlLearningRate.TabIndex = 11;
            // 
            // pnlInfluence
            // 
            this.pnlInfluence.Controls.Add(this.lblInfluenceDecay);
            this.pnlInfluence.Controls.Add(this.radInfluenceLinear);
            this.pnlInfluence.Controls.Add(this.radInfluenceExp);
            this.pnlInfluence.Location = new System.Drawing.Point(15, 379);
            this.pnlInfluence.Name = "pnlInfluence";
            this.pnlInfluence.Size = new System.Drawing.Size(169, 57);
            this.pnlInfluence.TabIndex = 12;
            // 
            // pnlDisplayBlend
            // 
            this.pnlDisplayBlend.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDisplayBlend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDisplayBlend.Location = new System.Drawing.Point(0, 3);
            this.pnlDisplayBlend.Name = "pnlDisplayBlend";
            this.pnlDisplayBlend.Size = new System.Drawing.Size(800, 600);
            this.pnlDisplayBlend.TabIndex = 44;
            this.pnlDisplayBlend.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDisplayBlend_Paint);
            // 
            // proTrainingTime
            // 
            this.proTrainingTime.Location = new System.Drawing.Point(700, 13);
            this.proTrainingTime.Name = "proTrainingTime";
            this.proTrainingTime.Size = new System.Drawing.Size(322, 23);
            this.proTrainingTime.TabIndex = 45;
            // 
            // lblTrainingTime
            // 
            this.lblTrainingTime.AutoSize = true;
            this.lblTrainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainingTime.Location = new System.Drawing.Point(11, 662);
            this.lblTrainingTime.Name = "lblTrainingTime";
            this.lblTrainingTime.Size = new System.Drawing.Size(88, 13);
            this.lblTrainingTime.TabIndex = 46;
            this.lblTrainingTime.Text = "Training Time:";
            // 
            // tabVisualization
            // 
            this.tabVisualization.Controls.Add(this.tabBlend);
            this.tabVisualization.Controls.Add(this.tabUMatrix);
            this.tabVisualization.Controls.Add(this.tabComponent);
            this.tabVisualization.Location = new System.Drawing.Point(214, 53);
            this.tabVisualization.Margin = new System.Windows.Forms.Padding(0);
            this.tabVisualization.Name = "tabVisualization";
            this.tabVisualization.SelectedIndex = 0;
            this.tabVisualization.Size = new System.Drawing.Size(808, 626);
            this.tabVisualization.TabIndex = 47;
            // 
            // tabBlend
            // 
            this.tabBlend.Controls.Add(this.pnlDisplayBlend);
            this.tabBlend.Location = new System.Drawing.Point(4, 22);
            this.tabBlend.Margin = new System.Windows.Forms.Padding(0);
            this.tabBlend.Name = "tabBlend";
            this.tabBlend.Size = new System.Drawing.Size(800, 600);
            this.tabBlend.TabIndex = 0;
            this.tabBlend.Text = "Blended View";
            this.tabBlend.UseVisualStyleBackColor = true;
            // 
            // tabUMatrix
            // 
            this.tabUMatrix.BackColor = System.Drawing.Color.Transparent;
            this.tabUMatrix.Controls.Add(this.pnlDisplayUMatrix);
            this.tabUMatrix.Location = new System.Drawing.Point(4, 22);
            this.tabUMatrix.Margin = new System.Windows.Forms.Padding(0);
            this.tabUMatrix.Name = "tabUMatrix";
            this.tabUMatrix.Size = new System.Drawing.Size(800, 600);
            this.tabUMatrix.TabIndex = 1;
            this.tabUMatrix.Text = "U-Matrix";
            this.tabUMatrix.UseVisualStyleBackColor = true;
            // 
            // pnlDisplayUMatrix
            // 
            this.pnlDisplayUMatrix.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDisplayUMatrix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDisplayUMatrix.Location = new System.Drawing.Point(0, 3);
            this.pnlDisplayUMatrix.Name = "pnlDisplayUMatrix";
            this.pnlDisplayUMatrix.Size = new System.Drawing.Size(800, 600);
            this.pnlDisplayUMatrix.TabIndex = 45;
            this.pnlDisplayUMatrix.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDisplayUMatrix_Paint);
            // 
            // tabComponent
            // 
            this.tabComponent.Controls.Add(this.pnlDisplayComponents);
            this.tabComponent.Location = new System.Drawing.Point(4, 22);
            this.tabComponent.Name = "tabComponent";
            this.tabComponent.Size = new System.Drawing.Size(800, 600);
            this.tabComponent.TabIndex = 2;
            this.tabComponent.Text = "Component Planes";
            this.tabComponent.UseVisualStyleBackColor = true;
            // 
            // pnlDisplayComponents
            // 
            this.pnlDisplayComponents.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDisplayComponents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDisplayComponents.Location = new System.Drawing.Point(0, 3);
            this.pnlDisplayComponents.Name = "pnlDisplayComponents";
            this.pnlDisplayComponents.Size = new System.Drawing.Size(800, 600);
            this.pnlDisplayComponents.TabIndex = 45;
            this.pnlDisplayComponents.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDisplayComponents_Paint);
            // 
            // lblAQE
            // 
            this.lblAQE.AutoSize = true;
            this.lblAQE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAQE.Location = new System.Drawing.Point(13, 634);
            this.lblAQE.Name = "lblAQE";
            this.lblAQE.Size = new System.Drawing.Size(36, 13);
            this.lblAQE.TabIndex = 48;
            this.lblAQE.Text = "AQE:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 708);
            this.Controls.Add(this.lblAQE);
            this.Controls.Add(this.tabVisualization);
            this.Controls.Add(this.lblTrainingTime);
            this.Controls.Add(this.proTrainingTime);
            this.Controls.Add(this.pnlInfluence);
            this.Controls.Add(this.pnlLearningRate);
            this.Controls.Add(this.pnlNeighborhood);
            this.Controls.Add(this.txtYMapSize);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.txtXMapSize);
            this.Controls.Add(this.lblMapSize);
            this.Controls.Add(this.numInstances);
            this.Controls.Add(this.numIterations);
            this.Controls.Add(this.numAttributes);
            this.Controls.Add(this.lblInstances);
            this.Controls.Add(this.lblAttributes);
            this.Controls.Add(this.numLearningRate);
            this.Controls.Add(this.lblLearningRate);
            this.Controls.Add(this.lblIterations);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Self-Organizing Map Demo";
            ((System.ComponentModel.ISupportInitialize)(this.numLearningRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInstances)).EndInit();
            this.pnlNeighborhood.ResumeLayout(false);
            this.pnlNeighborhood.PerformLayout();
            this.pnlLearningRate.ResumeLayout(false);
            this.pnlLearningRate.PerformLayout();
            this.pnlInfluence.ResumeLayout(false);
            this.pnlInfluence.PerformLayout();
            this.tabVisualization.ResumeLayout(false);
            this.tabBlend.ResumeLayout(false);
            this.tabUMatrix.ResumeLayout(false);
            this.tabComponent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.Label lblLearningRate;
        private System.Windows.Forms.NumericUpDown numLearningRate;
        private System.Windows.Forms.Label lblAttributes;
        private System.Windows.Forms.Label lblInstances;
        private System.Windows.Forms.NumericUpDown numAttributes;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.NumericUpDown numInstances;
        private System.Windows.Forms.Label lblMapSize;
        private System.Windows.Forms.TextBox txtXMapSize;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.TextBox txtYMapSize;
        private System.Windows.Forms.RadioButton radNeighborhoodLinear;
        private System.Windows.Forms.Label lblRadiusDecay;
        private System.Windows.Forms.RadioButton radNeighborhoodExp;
        private System.Windows.Forms.Label lblLearningDecay;
        private System.Windows.Forms.RadioButton radLearningLinear;
        private System.Windows.Forms.RadioButton radLearningExp;
        private System.Windows.Forms.Label lblInfluenceDecay;
        private System.Windows.Forms.RadioButton radInfluenceLinear;
        private System.Windows.Forms.RadioButton radInfluenceExp;
        private System.Windows.Forms.Panel pnlNeighborhood;
        private System.Windows.Forms.Panel pnlLearningRate;
        private System.Windows.Forms.Panel pnlInfluence;
        private System.Windows.Forms.Panel pnlDisplayBlend;
        private System.Windows.Forms.ProgressBar proTrainingTime;
        private System.Windows.Forms.Label lblTrainingTime;
        private System.Windows.Forms.TabControl tabVisualization;
        private System.Windows.Forms.TabPage tabBlend;
        private System.Windows.Forms.TabPage tabUMatrix;
        private System.Windows.Forms.Panel pnlDisplayUMatrix;
        private System.Windows.Forms.TabPage tabComponent;
        private System.Windows.Forms.Panel pnlDisplayComponents;
        private System.Windows.Forms.Label lblAQE;
    }
}

