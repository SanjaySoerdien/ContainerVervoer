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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sortBtn = new System.Windows.Forms.Button();
            this.shipUsedWeightLbl = new System.Windows.Forms.Label();
            this.shipMaxWeigthLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.shipWidthLbl = new System.Windows.Forms.Label();
            this.shipLenghtLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.removeBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.generateContainersBtn = new System.Windows.Forms.Button();
            this.containerListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(683, 487);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(279, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 533);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ship";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sortBtn);
            this.groupBox2.Controls.Add(this.shipUsedWeightLbl);
            this.groupBox2.Controls.Add(this.shipMaxWeigthLbl);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.shipWidthLbl);
            this.groupBox2.Controls.Add(this.shipLenghtLbl);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 215);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ship info";
            // 
            // sortBtn
            // 
            this.sortBtn.Location = new System.Drawing.Point(29, 183);
            this.sortBtn.Name = "sortBtn";
            this.sortBtn.Size = new System.Drawing.Size(154, 23);
            this.sortBtn.TabIndex = 1;
            this.sortBtn.Text = "Sort";
            this.sortBtn.UseVisualStyleBackColor = true;
            // 
            // shipUsedWeightLbl
            // 
            this.shipUsedWeightLbl.AutoSize = true;
            this.shipUsedWeightLbl.Location = new System.Drawing.Point(138, 160);
            this.shipUsedWeightLbl.Name = "shipUsedWeightLbl";
            this.shipUsedWeightLbl.Size = new System.Drawing.Size(45, 13);
            this.shipUsedWeightLbl.TabIndex = 19;
            this.shipUsedWeightLbl.Text = "Sort first";
            // 
            // shipMaxWeigthLbl
            // 
            this.shipMaxWeigthLbl.AutoSize = true;
            this.shipMaxWeigthLbl.Location = new System.Drawing.Point(138, 138);
            this.shipMaxWeigthLbl.Name = "shipMaxWeigthLbl";
            this.shipMaxWeigthLbl.Size = new System.Drawing.Size(13, 13);
            this.shipMaxWeigthLbl.TabIndex = 18;
            this.shipMaxWeigthLbl.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Used weight:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Max weight:";
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
            this.groupBox3.Controls.Add(this.removeBtn);
            this.groupBox3.Controls.Add(this.addBtn);
            this.groupBox3.Controls.Add(this.generateContainersBtn);
            this.groupBox3.Controls.Add(this.containerListBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(261, 312);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Containers";
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(88, 279);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 22;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(7, 279);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 21;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // generateContainersBtn
            // 
            this.generateContainersBtn.Location = new System.Drawing.Point(76, 8);
            this.generateContainersBtn.Name = "generateContainersBtn";
            this.generateContainersBtn.Size = new System.Drawing.Size(153, 23);
            this.generateContainersBtn.TabIndex = 20;
            this.generateContainersBtn.Text = "Generate containers";
            this.generateContainersBtn.UseVisualStyleBackColor = true;
            // 
            // containerListBox
            // 
            this.containerListBox.FormattingEnabled = true;
            this.containerListBox.Items.AddRange(new object[] {
            "Generate containers or add on yourself"});
            this.containerListBox.Location = new System.Drawing.Point(7, 35);
            this.containerListBox.Name = "containerListBox";
            this.containerListBox.Size = new System.Drawing.Size(233, 238);
            this.containerListBox.TabIndex = 0;
            // 
            // ShipView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 538);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShipView";
            this.Text = "SchipView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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
    }
}