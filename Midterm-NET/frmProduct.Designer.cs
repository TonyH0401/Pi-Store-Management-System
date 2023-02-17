namespace Midterm_NET
{
    partial class frmProduct
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtbxQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtbxPrice = new System.Windows.Forms.TextBox();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.txtbxProductID = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.richtxtbxDescription = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(523, 302);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 65;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(233, 291);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 64;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(108, 291);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 63;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(233, 250);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 62;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(108, 250);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 61;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtbxQuantity
            // 
            this.txtbxQuantity.Location = new System.Drawing.Point(110, 148);
            this.txtbxQuantity.Name = "txtbxQuantity";
            this.txtbxQuantity.Size = new System.Drawing.Size(70, 20);
            this.txtbxQuantity.TabIndex = 60;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(33, 148);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(54, 13);
            this.lblQuantity.TabIndex = 59;
            this.lblQuantity.Text = "Quantity";
            // 
            // txtbxPrice
            // 
            this.txtbxPrice.Location = new System.Drawing.Point(110, 112);
            this.txtbxPrice.Name = "txtbxPrice";
            this.txtbxPrice.Size = new System.Drawing.Size(53, 20);
            this.txtbxPrice.TabIndex = 58;
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(110, 77);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(198, 20);
            this.txtbxName.TabIndex = 56;
            // 
            // txtbxProductID
            // 
            this.txtbxProductID.Location = new System.Drawing.Point(110, 42);
            this.txtbxProductID.Name = "txtbxProductID";
            this.txtbxProductID.Size = new System.Drawing.Size(128, 20);
            this.txtbxProductID.TabIndex = 55;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(33, 112);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 54;
            this.lblPrice.Text = "Price";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(33, 184);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(71, 13);
            this.lblDescription.TabIndex = 53;
            this.lblDescription.Text = "Description";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(33, 77);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 13);
            this.lblName.TabIndex = 52;
            this.lblName.Text = "Name";
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductID.Location = new System.Drawing.Point(33, 42);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(72, 13);
            this.lblProductID.TabIndex = 51;
            this.lblProductID.Text = "Product ID:";
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.AllowUserToAddRows = false;
            this.dataGridViewProduct.AllowUserToDeleteRows = false;
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(334, 19);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProduct.Size = new System.Drawing.Size(434, 277);
            this.dataGridViewProduct.TabIndex = 50;
            this.dataGridViewProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellContentClick);
            // 
            // richtxtbxDescription
            // 
            this.richtxtbxDescription.Location = new System.Drawing.Point(110, 184);
            this.richtxtbxDescription.Name = "richtxtbxDescription";
            this.richtxtbxDescription.Size = new System.Drawing.Size(198, 50);
            this.richtxtbxDescription.TabIndex = 66;
            this.richtxtbxDescription.Text = "";
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 344);
            this.Controls.Add(this.richtxtbxDescription);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtbxQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtbxPrice);
            this.Controls.Add(this.txtbxName);
            this.Controls.Add(this.txtbxProductID);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.dataGridViewProduct);
            this.MaximizeBox = false;
            this.Name = "frmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProduct";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtbxQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtbxPrice;
        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.TextBox txtbxProductID;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.RichTextBox richtxtbxDescription;
    }
}