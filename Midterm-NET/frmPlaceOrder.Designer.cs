namespace Midterm_NET
{
    partial class frmPlaceOrder
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
            this.cbbxClient = new System.Windows.Forms.ComboBox();
            this.txtbxAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtbxPhone = new System.Windows.Forms.TextBox();
            this.txtbxEmail = new System.Windows.Forms.TextBox();
            this.txtbxFullname = new System.Windows.Forms.TextBox();
            this.txtbxUsername = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblFullname = new System.Windows.Forms.Label();
            this.lblClientID = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.richtxtbxDescription = new System.Windows.Forms.RichTextBox();
            this.txtbxQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dataGridViewOrder = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbxClient
            // 
            this.cbbxClient.FormattingEnabled = true;
            this.cbbxClient.Location = new System.Drawing.Point(61, 13);
            this.cbbxClient.Name = "cbbxClient";
            this.cbbxClient.Size = new System.Drawing.Size(198, 21);
            this.cbbxClient.TabIndex = 0;
            this.cbbxClient.SelectedIndexChanged += new System.EventHandler(this.cbbxClient_SelectedIndexChanged);
            // 
            // txtbxAddress
            // 
            this.txtbxAddress.Location = new System.Drawing.Point(85, 162);
            this.txtbxAddress.Name = "txtbxAddress";
            this.txtbxAddress.Size = new System.Drawing.Size(163, 20);
            this.txtbxAddress.TabIndex = 52;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(8, 162);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(52, 13);
            this.lblAddress.TabIndex = 51;
            this.lblAddress.Text = "Address";
            // 
            // txtbxPhone
            // 
            this.txtbxPhone.Location = new System.Drawing.Point(85, 126);
            this.txtbxPhone.Name = "txtbxPhone";
            this.txtbxPhone.Size = new System.Drawing.Size(116, 20);
            this.txtbxPhone.TabIndex = 50;
            // 
            // txtbxEmail
            // 
            this.txtbxEmail.Location = new System.Drawing.Point(85, 91);
            this.txtbxEmail.Name = "txtbxEmail";
            this.txtbxEmail.Size = new System.Drawing.Size(198, 20);
            this.txtbxEmail.TabIndex = 49;
            // 
            // txtbxFullname
            // 
            this.txtbxFullname.Location = new System.Drawing.Point(85, 57);
            this.txtbxFullname.Name = "txtbxFullname";
            this.txtbxFullname.Size = new System.Drawing.Size(116, 20);
            this.txtbxFullname.TabIndex = 48;
            // 
            // txtbxUsername
            // 
            this.txtbxUsername.Location = new System.Drawing.Point(85, 22);
            this.txtbxUsername.Name = "txtbxUsername";
            this.txtbxUsername.Size = new System.Drawing.Size(116, 20);
            this.txtbxUsername.TabIndex = 47;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(8, 126);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(43, 13);
            this.lblPhone.TabIndex = 46;
            this.lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(8, 91);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(37, 13);
            this.lblEmail.TabIndex = 45;
            this.lblEmail.Text = "Email";
            // 
            // lblFullname
            // 
            this.lblFullname.AutoSize = true;
            this.lblFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullname.Location = new System.Drawing.Point(8, 57);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(57, 13);
            this.lblFullname.TabIndex = 44;
            this.lblFullname.Text = "Fullname";
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientID.Location = new System.Drawing.Point(8, 22);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(60, 13);
            this.lblClientID.TabIndex = 43;
            this.lblClientID.Text = "Client ID:";
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect.Location = new System.Drawing.Point(5, 13);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(43, 13);
            this.lblSelect.TabIndex = 53;
            this.lblSelect.Text = "Select";
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(74, 41);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(75, 23);
            this.btnLock.TabIndex = 54;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(172, 41);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(75, 23);
            this.btnUnlock.TabIndex = 55;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.AllowUserToAddRows = false;
            this.dataGridViewProduct.AllowUserToDeleteRows = false;
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(378, 12);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProduct.Size = new System.Drawing.Size(449, 230);
            this.dataGridViewProduct.TabIndex = 56;
            this.dataGridViewProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProduct_CellContentClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(485, 354);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 57;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(578, 354);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 58;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // richtxtbxDescription
            // 
            this.richtxtbxDescription.Location = new System.Drawing.Point(456, 250);
            this.richtxtbxDescription.Name = "richtxtbxDescription";
            this.richtxtbxDescription.Size = new System.Drawing.Size(371, 50);
            this.richtxtbxDescription.TabIndex = 76;
            this.richtxtbxDescription.Text = "";
            // 
            // txtbxQuantity
            // 
            this.txtbxQuantity.Location = new System.Drawing.Point(559, 319);
            this.txtbxQuantity.Name = "txtbxQuantity";
            this.txtbxQuantity.Size = new System.Drawing.Size(94, 20);
            this.txtbxQuantity.TabIndex = 75;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(482, 319);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(54, 13);
            this.lblQuantity.TabIndex = 74;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(375, 250);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(71, 13);
            this.lblDescription.TabIndex = 69;
            this.lblDescription.Text = "Description";
            // 
            // dataGridViewOrder
            // 
            this.dataGridViewOrder.AllowUserToAddRows = false;
            this.dataGridViewOrder.AllowUserToDeleteRows = false;
            this.dataGridViewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrder.Location = new System.Drawing.Point(12, 319);
            this.dataGridViewOrder.Name = "dataGridViewOrder";
            this.dataGridViewOrder.ReadOnly = true;
            this.dataGridViewOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrder.Size = new System.Drawing.Size(444, 200);
            this.dataGridViewOrder.TabIndex = 77;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.btnUnlock);
            this.panel1.Controls.Add(this.cbbxClient);
            this.panel1.Controls.Add(this.lblSelect);
            this.panel1.Controls.Add(this.btnLock);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 75);
            this.panel1.TabIndex = 78;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.txtbxUsername);
            this.panel2.Controls.Add(this.lblClientID);
            this.panel2.Controls.Add(this.lblFullname);
            this.panel2.Controls.Add(this.lblEmail);
            this.panel2.Controls.Add(this.lblPhone);
            this.panel2.Controls.Add(this.txtbxFullname);
            this.panel2.Controls.Add(this.txtbxEmail);
            this.panel2.Controls.Add(this.txtbxPhone);
            this.panel2.Controls.Add(this.lblAddress);
            this.panel2.Controls.Add(this.txtbxAddress);
            this.panel2.Location = new System.Drawing.Point(13, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 200);
            this.panel2.TabIndex = 79;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(727, 424);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 80;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // frmPlaceOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 531);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewOrder);
            this.Controls.Add(this.richtxtbxDescription);
            this.Controls.Add(this.txtbxQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewProduct);
            this.MaximizeBox = false;
            this.Name = "frmPlaceOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPlaceOrder";
            this.Load += new System.EventHandler(this.frmPlaceOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbxClient;
        private System.Windows.Forms.TextBox txtbxAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtbxPhone;
        private System.Windows.Forms.TextBox txtbxEmail;
        private System.Windows.Forms.TextBox txtbxFullname;
        private System.Windows.Forms.TextBox txtbxUsername;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.RichTextBox richtxtbxDescription;
        private System.Windows.Forms.TextBox txtbxQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DataGridView dataGridViewOrder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
    }
}