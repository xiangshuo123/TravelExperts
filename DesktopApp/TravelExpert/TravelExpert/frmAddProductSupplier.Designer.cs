namespace TravelExpert
{
    partial class frmAddProductSupplier
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
            lblPackage = new Label();
            cbxPackage = new ComboBox();
            cbxProduct = new ComboBox();
            lblProduct = new Label();
            cbxSupplier = new ComboBox();
            lblSupplier = new Label();
            btnAdd = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblPackage
            // 
            lblPackage.AutoSize = true;
            lblPackage.Location = new Point(105, 70);
            lblPackage.Name = "lblPackage";
            lblPackage.Size = new Size(111, 15);
            lblPackage.TabIndex = 0;
            lblPackage.Text = "Select the Package :";
            // 
            // cbxPackage
            // 
            cbxPackage.FormattingEnabled = true;
            cbxPackage.Location = new Point(333, 67);
            cbxPackage.Name = "cbxPackage";
            cbxPackage.Size = new Size(187, 23);
            cbxPackage.TabIndex = 1;
            cbxPackage.SelectedIndexChanged += cbxPackage_SelectedIndexChanged;
            // 
            // cbxProduct
            // 
            cbxProduct.FormattingEnabled = true;
            cbxProduct.Location = new Point(333, 108);
            cbxProduct.Name = "cbxProduct";
            cbxProduct.Size = new Size(187, 23);
            cbxProduct.TabIndex = 3;
            cbxProduct.SelectedIndexChanged += cbxProduct_SelectedIndexChanged;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(105, 111);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(222, 15);
            lblProduct.TabIndex = 2;
            lblProduct.Text = "Select the Product that you want to add :";
            // 
            // cbxSupplier
            // 
            cbxSupplier.FormattingEnabled = true;
            cbxSupplier.Location = new Point(333, 148);
            cbxSupplier.Name = "cbxSupplier";
            cbxSupplier.Size = new Size(187, 23);
            cbxSupplier.TabIndex = 5;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(105, 151);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(189, 15);
            lblSupplier.TabIndex = 4;
            lblSupplier.Text = "Select the Supplier of the Product :";
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(165, 206);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(129, 44);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add Product";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.Location = new Point(333, 206);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(129, 44);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAddProductSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(605, 313);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(cbxSupplier);
            Controls.Add(lblSupplier);
            Controls.Add(cbxProduct);
            Controls.Add(lblProduct);
            Controls.Add(cbxPackage);
            Controls.Add(lblPackage);
            Name = "frmAddProductSupplier";
            Text = "frmAddProductSupplier";
            Load += frmAddProductSupplier_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPackage;
        private ComboBox cbxPackage;
        private ComboBox cbxProduct;
        private Label lblProduct;
        private ComboBox cbxSupplier;
        private Label lblSupplier;
        private Button btnAdd;
        private Button btnCancel;
    }
}