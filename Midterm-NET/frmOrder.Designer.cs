namespace Midterm_NET
{
    partial class frmOrder
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
            this.dataGridViewOrder = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrderItem = new System.Windows.Forms.DataGridView();
            this.dateTimePickerFind = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblOderID = new System.Windows.Forms.Label();
            this.lblClientID = new System.Windows.Forms.Label();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.txtbxOrderID = new System.Windows.Forms.TextBox();
            this.txtbxTotalPrice = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerOrder = new System.Windows.Forms.DateTimePicker();
            this.txtbxClientID = new System.Windows.Forms.TextBox();
            this.txtbxEmployeeID = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblOrderItem = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblFind = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItem)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOrder
            // 
            this.dataGridViewOrder.AllowUserToAddRows = false;
            this.dataGridViewOrder.AllowUserToDeleteRows = false;
            this.dataGridViewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrder.Location = new System.Drawing.Point(13, 26);
            this.dataGridViewOrder.Name = "dataGridViewOrder";
            this.dataGridViewOrder.ReadOnly = true;
            this.dataGridViewOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrder.Size = new System.Drawing.Size(247, 230);
            this.dataGridViewOrder.TabIndex = 0;
            this.dataGridViewOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrder_CellContentClick);
            // 
            // dataGridViewOrderItem
            // 
            this.dataGridViewOrderItem.AllowUserToAddRows = false;
            this.dataGridViewOrderItem.AllowUserToDeleteRows = false;
            this.dataGridViewOrderItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderItem.Location = new System.Drawing.Point(13, 26);
            this.dataGridViewOrderItem.Name = "dataGridViewOrderItem";
            this.dataGridViewOrderItem.ReadOnly = true;
            this.dataGridViewOrderItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderItem.Size = new System.Drawing.Size(579, 231);
            this.dataGridViewOrderItem.TabIndex = 1;
            // 
            // dateTimePickerFind
            // 
            this.dateTimePickerFind.Location = new System.Drawing.Point(14, 23);
            this.dateTimePickerFind.Name = "dateTimePickerFind";
            this.dateTimePickerFind.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFind.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblOrder);
            this.panel1.Controls.Add(this.dataGridViewOrder);
            this.panel1.Location = new System.Drawing.Point(42, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 268);
            this.panel1.TabIndex = 3;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.Location = new System.Drawing.Point(10, 0);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(81, 17);
            this.lblOrder.TabIndex = 4;
            this.lblOrder.Text = "Order List";
            // 
            // lblOderID
            // 
            this.lblOderID.AutoSize = true;
            this.lblOderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOderID.Location = new System.Drawing.Point(11, 16);
            this.lblOderID.Name = "lblOderID";
            this.lblOderID.Size = new System.Drawing.Size(65, 15);
            this.lblOderID.TabIndex = 4;
            this.lblOderID.Text = "Order ID:";
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientID.Location = new System.Drawing.Point(11, 54);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(66, 15);
            this.lblClientID.TabIndex = 5;
            this.lblClientID.Text = "Client ID:";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeID.Location = new System.Drawing.Point(11, 92);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(92, 15);
            this.lblEmployeeID.TabIndex = 6;
            this.lblEmployeeID.Text = "Employee ID:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(11, 162);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 15);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Date:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(11, 130);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(80, 15);
            this.lblTotalPrice.TabIndex = 8;
            this.lblTotalPrice.Text = "Total Price:";
            // 
            // txtbxOrderID
            // 
            this.txtbxOrderID.Location = new System.Drawing.Point(105, 16);
            this.txtbxOrderID.Name = "txtbxOrderID";
            this.txtbxOrderID.Size = new System.Drawing.Size(165, 20);
            this.txtbxOrderID.TabIndex = 9;
            // 
            // txtbxTotalPrice
            // 
            this.txtbxTotalPrice.Location = new System.Drawing.Point(106, 130);
            this.txtbxTotalPrice.Name = "txtbxTotalPrice";
            this.txtbxTotalPrice.Size = new System.Drawing.Size(57, 20);
            this.txtbxTotalPrice.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtbxTotalPrice);
            this.panel2.Controls.Add(this.dateTimePickerOrder);
            this.panel2.Controls.Add(this.txtbxEmployeeID);
            this.panel2.Controls.Add(this.txtbxClientID);
            this.panel2.Controls.Add(this.lblTotalPrice);
            this.panel2.Controls.Add(this.lblOderID);
            this.panel2.Controls.Add(this.txtbxOrderID);
            this.panel2.Controls.Add(this.lblClientID);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.lblEmployeeID);
            this.panel2.Location = new System.Drawing.Point(272, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 197);
            this.panel2.TabIndex = 4;
            // 
            // dateTimePickerOrder
            // 
            this.dateTimePickerOrder.Location = new System.Drawing.Point(106, 162);
            this.dateTimePickerOrder.Name = "dateTimePickerOrder";
            this.dateTimePickerOrder.Size = new System.Drawing.Size(204, 20);
            this.dateTimePickerOrder.TabIndex = 5;
            // 
            // txtbxClientID
            // 
            this.txtbxClientID.Location = new System.Drawing.Point(106, 54);
            this.txtbxClientID.Name = "txtbxClientID";
            this.txtbxClientID.Size = new System.Drawing.Size(151, 20);
            this.txtbxClientID.TabIndex = 10;
            // 
            // txtbxEmployeeID
            // 
            this.txtbxEmployeeID.Location = new System.Drawing.Point(106, 92);
            this.txtbxEmployeeID.Name = "txtbxEmployeeID";
            this.txtbxEmployeeID.Size = new System.Drawing.Size(135, 20);
            this.txtbxEmployeeID.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblOrderItem);
            this.panel3.Controls.Add(this.dataGridViewOrderItem);
            this.panel3.Location = new System.Drawing.Point(42, 371);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(607, 273);
            this.panel3.TabIndex = 4;
            // 
            // lblOrderItem
            // 
            this.lblOrderItem.AutoSize = true;
            this.lblOrderItem.BackColor = System.Drawing.Color.MintCream;
            this.lblOrderItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderItem.Location = new System.Drawing.Point(10, 0);
            this.lblOrderItem.Name = "lblOrderItem";
            this.lblOrderItem.Size = new System.Drawing.Size(95, 17);
            this.lblOrderItem.TabIndex = 5;
            this.lblOrderItem.Text = "Order Item: ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Bisque;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblFind);
            this.panel4.Controls.Add(this.btnFind);
            this.panel4.Controls.Add(this.dateTimePickerFind);
            this.panel4.Location = new System.Drawing.Point(42, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(326, 55);
            this.panel4.TabIndex = 5;
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFind.Location = new System.Drawing.Point(11, 0);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(147, 17);
            this.lblFind.TabIndex = 5;
            this.lblFind.Text = "Find Order by Date";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(231, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(482, 33);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrder";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrder;
        private System.Windows.Forms.DataGridView dataGridViewOrderItem;
        private System.Windows.Forms.DateTimePicker dateTimePickerFind;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label lblOderID;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.TextBox txtbxTotalPrice;
        private System.Windows.Forms.TextBox txtbxOrderID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrder;
        private System.Windows.Forms.TextBox txtbxEmployeeID;
        private System.Windows.Forms.TextBox txtbxClientID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblOrderItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnRefresh;
    }
}