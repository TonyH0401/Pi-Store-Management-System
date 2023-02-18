namespace Midterm_NET
{
    partial class frmSearch
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
            this.lblSearchEmployee = new System.Windows.Forms.Label();
            this.lblSEByName = new System.Windows.Forms.Label();
            this.lblSEByID = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbxSEByName = new System.Windows.Forms.TextBox();
            this.txtbxSEByID = new System.Windows.Forms.TextBox();
            this.btnSEByName = new System.Windows.Forms.Button();
            this.btnSEByID = new System.Windows.Forms.Button();
            this.dateTimePickerSE1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSE2 = new System.Windows.Forms.DateTimePicker();
            this.btnSERangeTime = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSCID = new System.Windows.Forms.Button();
            this.btnSCName = new System.Windows.Forms.Button();
            this.txtbxSCID = new System.Windows.Forms.TextBox();
            this.txtbxSCName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSPID = new System.Windows.Forms.Button();
            this.btnSPName = new System.Windows.Forms.Button();
            this.txtbxSPID = new System.Windows.Forms.TextBox();
            this.txtbxSPName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSORange = new System.Windows.Forms.Button();
            this.dateTimePickerSO2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSO1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSOID = new System.Windows.Forms.Button();
            this.txtbxSOID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSBRange = new System.Windows.Forms.Button();
            this.dateTimePickerSB2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSB1 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSBID = new System.Windows.Forms.Button();
            this.txtbxSBID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSearchEmployee
            // 
            this.lblSearchEmployee.AutoSize = true;
            this.lblSearchEmployee.BackColor = System.Drawing.Color.White;
            this.lblSearchEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchEmployee.Location = new System.Drawing.Point(3, 0);
            this.lblSearchEmployee.Name = "lblSearchEmployee";
            this.lblSearchEmployee.Size = new System.Drawing.Size(134, 17);
            this.lblSearchEmployee.TabIndex = 0;
            this.lblSearchEmployee.Text = "Search Employee";
            // 
            // lblSEByName
            // 
            this.lblSEByName.AutoSize = true;
            this.lblSEByName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEByName.Location = new System.Drawing.Point(17, 25);
            this.lblSEByName.Name = "lblSEByName";
            this.lblSEByName.Size = new System.Drawing.Size(57, 13);
            this.lblSEByName.TabIndex = 1;
            this.lblSEByName.Text = "By Name";
            // 
            // lblSEByID
            // 
            this.lblSEByID.AutoSize = true;
            this.lblSEByID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSEByID.Location = new System.Drawing.Point(17, 51);
            this.lblSEByID.Name = "lblSEByID";
            this.lblSEByID.Size = new System.Drawing.Size(38, 13);
            this.lblSEByID.TabIndex = 2;
            this.lblSEByID.Text = "By ID";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(109, 105);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(18, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "to";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSERangeTime);
            this.panel1.Controls.Add(this.dateTimePickerSE2);
            this.panel1.Controls.Add(this.dateTimePickerSE1);
            this.panel1.Controls.Add(this.lblTo);
            this.panel1.Controls.Add(this.btnSEByID);
            this.panel1.Controls.Add(this.btnSEByName);
            this.panel1.Controls.Add(this.txtbxSEByID);
            this.panel1.Controls.Add(this.txtbxSEByName);
            this.panel1.Controls.Add(this.lblSearchEmployee);
            this.panel1.Controls.Add(this.lblSEByName);
            this.panel1.Controls.Add(this.lblSEByID);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 154);
            this.panel1.TabIndex = 5;
            // 
            // txtbxSEByName
            // 
            this.txtbxSEByName.Location = new System.Drawing.Point(80, 25);
            this.txtbxSEByName.Name = "txtbxSEByName";
            this.txtbxSEByName.Size = new System.Drawing.Size(143, 20);
            this.txtbxSEByName.TabIndex = 6;
            // 
            // txtbxSEByID
            // 
            this.txtbxSEByID.Location = new System.Drawing.Point(80, 51);
            this.txtbxSEByID.Name = "txtbxSEByID";
            this.txtbxSEByID.Size = new System.Drawing.Size(84, 20);
            this.txtbxSEByID.TabIndex = 7;
            // 
            // btnSEByName
            // 
            this.btnSEByName.Location = new System.Drawing.Point(238, 25);
            this.btnSEByName.Name = "btnSEByName";
            this.btnSEByName.Size = new System.Drawing.Size(75, 23);
            this.btnSEByName.TabIndex = 8;
            this.btnSEByName.Text = "By Name";
            this.btnSEByName.UseVisualStyleBackColor = true;
            this.btnSEByName.Click += new System.EventHandler(this.btnSEByName_Click);
            // 
            // btnSEByID
            // 
            this.btnSEByID.Location = new System.Drawing.Point(238, 51);
            this.btnSEByID.Name = "btnSEByID";
            this.btnSEByID.Size = new System.Drawing.Size(75, 23);
            this.btnSEByID.TabIndex = 9;
            this.btnSEByID.Text = "by ID";
            this.btnSEByID.UseVisualStyleBackColor = true;
            this.btnSEByID.Click += new System.EventHandler(this.btnSEByID_Click);
            // 
            // dateTimePickerSE1
            // 
            this.dateTimePickerSE1.Location = new System.Drawing.Point(20, 82);
            this.dateTimePickerSE1.Name = "dateTimePickerSE1";
            this.dateTimePickerSE1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSE1.TabIndex = 10;
            // 
            // dateTimePickerSE2
            // 
            this.dateTimePickerSE2.Location = new System.Drawing.Point(20, 121);
            this.dateTimePickerSE2.Name = "dateTimePickerSE2";
            this.dateTimePickerSE2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSE2.TabIndex = 11;
            // 
            // btnSERangeTime
            // 
            this.btnSERangeTime.Location = new System.Drawing.Point(238, 100);
            this.btnSERangeTime.Name = "btnSERangeTime";
            this.btnSERangeTime.Size = new System.Drawing.Size(75, 23);
            this.btnSERangeTime.TabIndex = 12;
            this.btnSERangeTime.Text = "Range";
            this.btnSERangeTime.UseVisualStyleBackColor = true;
            this.btnSERangeTime.Click += new System.EventHandler(this.btnSERangeTime_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.YellowGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSCID);
            this.panel2.Controls.Add(this.btnSCName);
            this.panel2.Controls.Add(this.txtbxSCID);
            this.panel2.Controls.Add(this.txtbxSCName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(12, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 84);
            this.panel2.TabIndex = 13;
            // 
            // btnSCID
            // 
            this.btnSCID.Location = new System.Drawing.Point(238, 51);
            this.btnSCID.Name = "btnSCID";
            this.btnSCID.Size = new System.Drawing.Size(75, 23);
            this.btnSCID.TabIndex = 9;
            this.btnSCID.Text = "by ID";
            this.btnSCID.UseVisualStyleBackColor = true;
            this.btnSCID.Click += new System.EventHandler(this.btnSCID_Click);
            // 
            // btnSCName
            // 
            this.btnSCName.Location = new System.Drawing.Point(238, 25);
            this.btnSCName.Name = "btnSCName";
            this.btnSCName.Size = new System.Drawing.Size(75, 23);
            this.btnSCName.TabIndex = 8;
            this.btnSCName.Text = "By Name";
            this.btnSCName.UseVisualStyleBackColor = true;
            this.btnSCName.Click += new System.EventHandler(this.btnSCName_Click);
            // 
            // txtbxSCID
            // 
            this.txtbxSCID.Location = new System.Drawing.Point(80, 51);
            this.txtbxSCID.Name = "txtbxSCID";
            this.txtbxSCID.Size = new System.Drawing.Size(84, 20);
            this.txtbxSCID.TabIndex = 7;
            // 
            // txtbxSCName
            // 
            this.txtbxSCName.Location = new System.Drawing.Point(80, 25);
            this.txtbxSCName.Name = "txtbxSCName";
            this.txtbxSCName.Size = new System.Drawing.Size(143, 20);
            this.txtbxSCName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search Client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "By Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "By ID";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnSPID);
            this.panel3.Controls.Add(this.btnSPName);
            this.panel3.Controls.Add(this.txtbxSPID);
            this.panel3.Controls.Add(this.txtbxSPName);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(12, 288);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 84);
            this.panel3.TabIndex = 14;
            // 
            // btnSPID
            // 
            this.btnSPID.Location = new System.Drawing.Point(238, 51);
            this.btnSPID.Name = "btnSPID";
            this.btnSPID.Size = new System.Drawing.Size(75, 23);
            this.btnSPID.TabIndex = 9;
            this.btnSPID.Text = "by ID";
            this.btnSPID.UseVisualStyleBackColor = true;
            this.btnSPID.Click += new System.EventHandler(this.btnSPID_Click);
            // 
            // btnSPName
            // 
            this.btnSPName.Location = new System.Drawing.Point(238, 25);
            this.btnSPName.Name = "btnSPName";
            this.btnSPName.Size = new System.Drawing.Size(75, 23);
            this.btnSPName.TabIndex = 8;
            this.btnSPName.Text = "By Name";
            this.btnSPName.UseVisualStyleBackColor = true;
            this.btnSPName.Click += new System.EventHandler(this.btnSPName_Click);
            // 
            // txtbxSPID
            // 
            this.txtbxSPID.Location = new System.Drawing.Point(80, 51);
            this.txtbxSPID.Name = "txtbxSPID";
            this.txtbxSPID.Size = new System.Drawing.Size(84, 20);
            this.txtbxSPID.TabIndex = 7;
            // 
            // txtbxSPName
            // 
            this.txtbxSPName.Location = new System.Drawing.Point(80, 25);
            this.txtbxSPName.Name = "txtbxSPName";
            this.txtbxSPName.Size = new System.Drawing.Size(143, 20);
            this.txtbxSPName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Product";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "By Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "By ID";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Thistle;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnSORange);
            this.panel4.Controls.Add(this.dateTimePickerSO2);
            this.panel4.Controls.Add(this.dateTimePickerSO1);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btnSOID);
            this.panel4.Controls.Add(this.txtbxSOID);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(445, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 128);
            this.panel4.TabIndex = 13;
            // 
            // btnSORange
            // 
            this.btnSORange.Location = new System.Drawing.Point(235, 73);
            this.btnSORange.Name = "btnSORange";
            this.btnSORange.Size = new System.Drawing.Size(75, 23);
            this.btnSORange.TabIndex = 12;
            this.btnSORange.Text = "Range";
            this.btnSORange.UseVisualStyleBackColor = true;
            this.btnSORange.Click += new System.EventHandler(this.btnSORange_Click);
            // 
            // dateTimePickerSO2
            // 
            this.dateTimePickerSO2.Location = new System.Drawing.Point(17, 94);
            this.dateTimePickerSO2.Name = "dateTimePickerSO2";
            this.dateTimePickerSO2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSO2.TabIndex = 11;
            // 
            // dateTimePickerSO1
            // 
            this.dateTimePickerSO1.Location = new System.Drawing.Point(17, 55);
            this.dateTimePickerSO1.Name = "dateTimePickerSO1";
            this.dateTimePickerSO1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSO1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "to";
            // 
            // btnSOID
            // 
            this.btnSOID.Location = new System.Drawing.Point(235, 24);
            this.btnSOID.Name = "btnSOID";
            this.btnSOID.Size = new System.Drawing.Size(75, 23);
            this.btnSOID.TabIndex = 9;
            this.btnSOID.Text = "by ID";
            this.btnSOID.UseVisualStyleBackColor = true;
            this.btnSOID.Click += new System.EventHandler(this.btnSOID_Click);
            // 
            // txtbxSOID
            // 
            this.txtbxSOID.Location = new System.Drawing.Point(77, 24);
            this.txtbxSOID.Name = "txtbxSOID";
            this.txtbxSOID.Size = new System.Drawing.Size(84, 20);
            this.txtbxSOID.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Search Order";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "By ID";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Pink;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnSBRange);
            this.panel5.Controls.Add(this.dateTimePickerSB2);
            this.panel5.Controls.Add(this.dateTimePickerSB1);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.btnSBID);
            this.panel5.Controls.Add(this.txtbxSBID);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Location = new System.Drawing.Point(445, 156);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(327, 128);
            this.panel5.TabIndex = 14;
            // 
            // btnSBRange
            // 
            this.btnSBRange.Location = new System.Drawing.Point(235, 73);
            this.btnSBRange.Name = "btnSBRange";
            this.btnSBRange.Size = new System.Drawing.Size(75, 23);
            this.btnSBRange.TabIndex = 12;
            this.btnSBRange.Text = "Range";
            this.btnSBRange.UseVisualStyleBackColor = true;
            this.btnSBRange.Click += new System.EventHandler(this.btnSBRange_Click);
            // 
            // dateTimePickerSB2
            // 
            this.dateTimePickerSB2.Location = new System.Drawing.Point(17, 94);
            this.dateTimePickerSB2.Name = "dateTimePickerSB2";
            this.dateTimePickerSB2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSB2.TabIndex = 11;
            // 
            // dateTimePickerSB1
            // 
            this.dateTimePickerSB1.Location = new System.Drawing.Point(17, 55);
            this.dateTimePickerSB1.Name = "dateTimePickerSB1";
            this.dateTimePickerSB1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSB1.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(106, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "to";
            // 
            // btnSBID
            // 
            this.btnSBID.Location = new System.Drawing.Point(235, 24);
            this.btnSBID.Name = "btnSBID";
            this.btnSBID.Size = new System.Drawing.Size(75, 23);
            this.btnSBID.TabIndex = 9;
            this.btnSBID.Text = "by ID";
            this.btnSBID.UseVisualStyleBackColor = true;
            this.btnSBID.Click += new System.EventHandler(this.btnSBID_Click);
            // 
            // txtbxSBID
            // 
            this.txtbxSBID.Location = new System.Drawing.Point(77, 24);
            this.txtbxSBID.Name = "txtbxSBID";
            this.txtbxSBID.Size = new System.Drawing.Size(84, 20);
            this.txtbxSBID.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Search Bill";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "By ID";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(359, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "large to small";
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 391);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSearch";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchEmployee;
        private System.Windows.Forms.Label lblSEByName;
        private System.Windows.Forms.Label lblSEByID;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSEByID;
        private System.Windows.Forms.Button btnSEByName;
        private System.Windows.Forms.TextBox txtbxSEByID;
        private System.Windows.Forms.TextBox txtbxSEByName;
        private System.Windows.Forms.DateTimePicker dateTimePickerSE2;
        private System.Windows.Forms.DateTimePicker dateTimePickerSE1;
        private System.Windows.Forms.Button btnSERangeTime;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSCID;
        private System.Windows.Forms.Button btnSCName;
        private System.Windows.Forms.TextBox txtbxSCID;
        private System.Windows.Forms.TextBox txtbxSCName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSPID;
        private System.Windows.Forms.Button btnSPName;
        private System.Windows.Forms.TextBox txtbxSPID;
        private System.Windows.Forms.TextBox txtbxSPName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSORange;
        private System.Windows.Forms.DateTimePicker dateTimePickerSO2;
        private System.Windows.Forms.DateTimePicker dateTimePickerSO1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSOID;
        private System.Windows.Forms.TextBox txtbxSOID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSBRange;
        private System.Windows.Forms.DateTimePicker dateTimePickerSB2;
        private System.Windows.Forms.DateTimePicker dateTimePickerSB1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSBID;
        private System.Windows.Forms.TextBox txtbxSBID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}