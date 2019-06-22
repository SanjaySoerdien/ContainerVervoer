namespace ContainerVervoer
{
    partial class ShipView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shipGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.layersBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.minWeightLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Balance = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.weightRightLabel = new System.Windows.Forms.Label();
            this.shipUsedWeightLbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.shipMaxWeigthLbl = new System.Windows.Forms.Label();
            this.weightLeftLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.balanceLbl = new System.Windows.Forms.Label();
            this.sortBtn = new System.Windows.Forms.Button();
            this.shipWidthLbl = new System.Windows.Forms.Label();
            this.shipLenghtLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.containerListWeightLbl = new System.Windows.Forms.Label();
            this.clearAllContainer = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.containerValueable = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.containerWeight = new System.Windows.Forms.NumericUpDown();
            this.containerCooled = new System.Windows.Forms.CheckBox();
            this.containersAmountInput = new System.Windows.Forms.NumericUpDown();
            this.removeBtn = new System.Windows.Forms.Button();
            this.generateContainersBtn = new System.Windows.Forms.Button();
            this.containerListBox = new System.Windows.Forms.ListBox();
            this.containersLeftListBox = new System.Windows.Forms.ListBox();
            this.containerLbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.posLbl = new System.Windows.Forms.Label();
            this.weightAllowedOnTopLbl = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.Balance.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containerWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containersAmountInput)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shipGrid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.layersBox);
            this.groupBox1.Location = new System.Drawing.Point(485, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1182, 832);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ship";
            // 
            // shipGrid
            // 
            this.shipGrid.AllowUserToAddRows = false;
            this.shipGrid.AllowUserToDeleteRows = false;
            this.shipGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shipGrid.ColumnHeadersVisible = false;
            this.shipGrid.Location = new System.Drawing.Point(26, 72);
            this.shipGrid.Name = "shipGrid";
            this.shipGrid.ReadOnly = true;
            this.shipGrid.RowHeadersVisible = false;
            this.shipGrid.RowHeadersWidth = 70;
            this.shipGrid.Size = new System.Drawing.Size(1126, 739);
            this.shipGrid.TabIndex = 27;
            this.shipGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shipGrid_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Layer:";
            // 
            // layersBox
            // 
            this.layersBox.FormattingEnabled = true;
            this.layersBox.Items.AddRange(new object[] {
            "Sort first"});
            this.layersBox.Location = new System.Drawing.Point(26, 45);
            this.layersBox.Name = "layersBox";
            this.layersBox.Size = new System.Drawing.Size(121, 21);
            this.layersBox.TabIndex = 24;
            this.layersBox.SelectedIndexChanged += new System.EventHandler(this.layersBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.minWeightLbl);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Balance);
            this.groupBox2.Controls.Add(this.sortBtn);
            this.groupBox2.Controls.Add(this.shipWidthLbl);
            this.groupBox2.Controls.Add(this.shipLenghtLbl);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 215);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ship info";
            // 
            // minWeightLbl
            // 
            this.minWeightLbl.AutoSize = true;
            this.minWeightLbl.Location = new System.Drawing.Point(138, 72);
            this.minWeightLbl.Name = "minWeightLbl";
            this.minWeightLbl.Size = new System.Drawing.Size(13, 13);
            this.minWeightLbl.TabIndex = 27;
            this.minWeightLbl.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Min weight:";
            // 
            // Balance
            // 
            this.Balance.Controls.Add(this.label10);
            this.Balance.Controls.Add(this.weightRightLabel);
            this.Balance.Controls.Add(this.shipUsedWeightLbl);
            this.Balance.Controls.Add(this.label6);
            this.Balance.Controls.Add(this.shipMaxWeigthLbl);
            this.Balance.Controls.Add(this.weightLeftLbl);
            this.Balance.Controls.Add(this.label8);
            this.Balance.Controls.Add(this.label9);
            this.Balance.Controls.Add(this.label7);
            this.Balance.Controls.Add(this.balanceLbl);
            this.Balance.Location = new System.Drawing.Point(210, 14);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(251, 181);
            this.Balance.TabIndex = 26;
            this.Balance.TabStop = false;
            this.Balance.Text = "Balance ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Weight Left: ";
            // 
            // weightRightLabel
            // 
            this.weightRightLabel.AutoSize = true;
            this.weightRightLabel.Location = new System.Drawing.Point(129, 40);
            this.weightRightLabel.Name = "weightRightLabel";
            this.weightRightLabel.Size = new System.Drawing.Size(45, 13);
            this.weightRightLabel.TabIndex = 25;
            this.weightRightLabel.Text = "Sort first";
            // 
            // shipUsedWeightLbl
            // 
            this.shipUsedWeightLbl.AutoSize = true;
            this.shipUsedWeightLbl.Location = new System.Drawing.Point(128, 156);
            this.shipUsedWeightLbl.Name = "shipUsedWeightLbl";
            this.shipUsedWeightLbl.Size = new System.Drawing.Size(45, 13);
            this.shipUsedWeightLbl.TabIndex = 19;
            this.shipUsedWeightLbl.Text = "Sort first";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Balance: ";
            // 
            // shipMaxWeigthLbl
            // 
            this.shipMaxWeigthLbl.AutoSize = true;
            this.shipMaxWeigthLbl.Location = new System.Drawing.Point(128, 134);
            this.shipMaxWeigthLbl.Name = "shipMaxWeigthLbl";
            this.shipMaxWeigthLbl.Size = new System.Drawing.Size(13, 13);
            this.shipMaxWeigthLbl.TabIndex = 18;
            this.shipMaxWeigthLbl.Text = "0";
            // 
            // weightLeftLbl
            // 
            this.weightLeftLbl.AutoSize = true;
            this.weightLeftLbl.Location = new System.Drawing.Point(129, 16);
            this.weightLeftLbl.Name = "weightLeftLbl";
            this.weightLeftLbl.Size = new System.Drawing.Size(45, 13);
            this.weightLeftLbl.TabIndex = 24;
            this.weightLeftLbl.Text = "Sort first";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Used weight:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Weight Right:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Max weight:";
            // 
            // balanceLbl
            // 
            this.balanceLbl.AutoSize = true;
            this.balanceLbl.Location = new System.Drawing.Point(129, 78);
            this.balanceLbl.Name = "balanceLbl";
            this.balanceLbl.Size = new System.Drawing.Size(45, 13);
            this.balanceLbl.TabIndex = 23;
            this.balanceLbl.Text = "Sort first";
            // 
            // sortBtn
            // 
            this.sortBtn.Location = new System.Drawing.Point(29, 183);
            this.sortBtn.Name = "sortBtn";
            this.sortBtn.Size = new System.Drawing.Size(154, 23);
            this.sortBtn.TabIndex = 1;
            this.sortBtn.Text = "Sort";
            this.sortBtn.UseVisualStyleBackColor = true;
            this.sortBtn.Click += new System.EventHandler(this.sortBtn_Click);
            // 
            // shipWidthLbl
            // 
            this.shipWidthLbl.AutoSize = true;
            this.shipWidthLbl.Location = new System.Drawing.Point(138, 45);
            this.shipWidthLbl.Name = "shipWidthLbl";
            this.shipWidthLbl.Size = new System.Drawing.Size(13, 13);
            this.shipWidthLbl.TabIndex = 14;
            this.shipWidthLbl.Text = "0";
            // 
            // shipLenghtLbl
            // 
            this.shipLenghtLbl.AutoSize = true;
            this.shipLenghtLbl.Location = new System.Drawing.Point(138, 28);
            this.shipLenghtLbl.Name = "shipLenghtLbl";
            this.shipLenghtLbl.Size = new System.Drawing.Size(13, 13);
            this.shipLenghtLbl.TabIndex = 13;
            this.shipLenghtLbl.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Length:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Width:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.containerListWeightLbl);
            this.groupBox3.Controls.Add(this.clearAllContainer);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.containersAmountInput);
            this.groupBox3.Controls.Add(this.removeBtn);
            this.groupBox3.Controls.Add(this.generateContainersBtn);
            this.groupBox3.Controls.Add(this.containerListBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(467, 393);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Containers";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(288, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Containers left over: ";
            // 
            // containerListWeightLbl
            // 
            this.containerListWeightLbl.AutoSize = true;
            this.containerListWeightLbl.Location = new System.Drawing.Point(118, 16);
            this.containerListWeightLbl.Name = "containerListWeightLbl";
            this.containerListWeightLbl.Size = new System.Drawing.Size(13, 13);
            this.containerListWeightLbl.TabIndex = 27;
            this.containerListWeightLbl.Text = "0";
            // 
            // clearAllContainer
            // 
            this.clearAllContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.clearAllContainer.Location = new System.Drawing.Point(106, 300);
            this.clearAllContainer.Name = "clearAllContainer";
            this.clearAllContainer.Size = new System.Drawing.Size(91, 37);
            this.clearAllContainer.TabIndex = 28;
            this.clearAllContainer.Text = "Remove all containers";
            this.clearAllContainer.UseVisualStyleBackColor = true;
            this.clearAllContainer.Click += new System.EventHandler(this.clearAllContainer_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Total Weight:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.containerValueable);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.addBtn);
            this.groupBox4.Controls.Add(this.containerWeight);
            this.groupBox4.Controls.Add(this.containerCooled);
            this.groupBox4.Location = new System.Drawing.Point(215, 292);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(229, 95);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Add";
            // 
            // containerValueable
            // 
            this.containerValueable.AutoSize = true;
            this.containerValueable.Location = new System.Drawing.Point(16, 19);
            this.containerValueable.Name = "containerValueable";
            this.containerValueable.Size = new System.Drawing.Size(67, 17);
            this.containerValueable.TabIndex = 25;
            this.containerValueable.Text = "Valuable";
            this.containerValueable.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Weight:";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(123, 19);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 21;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // containerWeight
            // 
            this.containerWeight.Increment = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.containerWeight.Location = new System.Drawing.Point(86, 68);
            this.containerWeight.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.containerWeight.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.containerWeight.Name = "containerWeight";
            this.containerWeight.Size = new System.Drawing.Size(103, 20);
            this.containerWeight.TabIndex = 26;
            this.containerWeight.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // containerCooled
            // 
            this.containerCooled.AutoSize = true;
            this.containerCooled.Location = new System.Drawing.Point(16, 42);
            this.containerCooled.Name = "containerCooled";
            this.containerCooled.Size = new System.Drawing.Size(59, 17);
            this.containerCooled.TabIndex = 24;
            this.containerCooled.Text = "Cooled";
            this.containerCooled.UseVisualStyleBackColor = true;
            // 
            // containersAmountInput
            // 
            this.containersAmountInput.Location = new System.Drawing.Point(141, 360);
            this.containersAmountInput.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.containersAmountInput.Name = "containersAmountInput";
            this.containersAmountInput.Size = new System.Drawing.Size(45, 20);
            this.containersAmountInput.TabIndex = 23;
            this.containersAmountInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(7, 307);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 22;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // generateContainersBtn
            // 
            this.generateContainersBtn.Location = new System.Drawing.Point(7, 350);
            this.generateContainersBtn.Name = "generateContainersBtn";
            this.generateContainersBtn.Size = new System.Drawing.Size(105, 37);
            this.generateContainersBtn.TabIndex = 20;
            this.generateContainersBtn.Text = "Generate containers";
            this.generateContainersBtn.UseVisualStyleBackColor = true;
            this.generateContainersBtn.Click += new System.EventHandler(this.generateContainersBtn_Click);
            // 
            // containerListBox
            // 
            this.containerListBox.FormattingEnabled = true;
            this.containerListBox.Location = new System.Drawing.Point(7, 35);
            this.containerListBox.Name = "containerListBox";
            this.containerListBox.Size = new System.Drawing.Size(268, 251);
            this.containerListBox.TabIndex = 0;
            // 
            // containersLeftListBox
            // 
            this.containersLeftListBox.FormattingEnabled = true;
            this.containersLeftListBox.Location = new System.Drawing.Point(303, 256);
            this.containersLeftListBox.Name = "containersLeftListBox";
            this.containersLeftListBox.Size = new System.Drawing.Size(153, 251);
            this.containersLeftListBox.TabIndex = 29;
            // 
            // containerLbl
            // 
            this.containerLbl.AutoSize = true;
            this.containerLbl.Location = new System.Drawing.Point(173, 72);
            this.containerLbl.Name = "containerLbl";
            this.containerLbl.Size = new System.Drawing.Size(10, 13);
            this.containerLbl.TabIndex = 33;
            this.containerLbl.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Container:";
            // 
            // posLbl
            // 
            this.posLbl.AutoSize = true;
            this.posLbl.Location = new System.Drawing.Point(173, 45);
            this.posLbl.Name = "posLbl";
            this.posLbl.Size = new System.Drawing.Size(10, 13);
            this.posLbl.TabIndex = 32;
            this.posLbl.Text = "-";
            // 
            // weightAllowedOnTopLbl
            // 
            this.weightAllowedOnTopLbl.AutoSize = true;
            this.weightAllowedOnTopLbl.Location = new System.Drawing.Point(173, 28);
            this.weightAllowedOnTopLbl.Name = "weightAllowedOnTopLbl";
            this.weightAllowedOnTopLbl.Size = new System.Drawing.Size(10, 13);
            this.weightAllowedOnTopLbl.TabIndex = 31;
            this.weightAllowedOnTopLbl.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(116, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "Weight allowed on top:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 30;
            this.label18.Text = "Position:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.containerLbl);
            this.groupBox5.Controls.Add(this.weightAllowedOnTopLbl);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.posLbl);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Location = new System.Drawing.Point(12, 620);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(467, 212);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Space info";
            // 
            // ShipView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1679, 878);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.containersLeftListBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShipView";
            this.Text = "SchipView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Balance.ResumeLayout(false);
            this.Balance.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containerWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containersAmountInput)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox containerListBox;
        private System.Windows.Forms.Label shipWidthLbl;
        private System.Windows.Forms.Label shipLenghtLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label shipMaxWeigthLbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button sortBtn;
        private System.Windows.Forms.Label shipUsedWeightLbl;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button generateContainersBtn;
        private System.Windows.Forms.NumericUpDown containersAmountInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox layersBox;
        private System.Windows.Forms.NumericUpDown containerWeight;
        private System.Windows.Forms.CheckBox containerValueable;
        private System.Windows.Forms.CheckBox containerCooled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button clearAllContainer;
        private System.Windows.Forms.GroupBox Balance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label weightRightLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label weightLeftLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label balanceLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView shipGrid;
        private System.Windows.Forms.Label minWeightLbl;
        private System.Windows.Forms.Label containerListWeightLbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox containersLeftListBox;
        private System.Windows.Forms.Label containerLbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label posLbl;
        private System.Windows.Forms.Label weightAllowedOnTopLbl;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}