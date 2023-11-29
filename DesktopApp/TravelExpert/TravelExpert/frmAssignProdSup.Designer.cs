namespace TravelExpert
{
    partial class frmAssignProdSup
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
            cboProducts = new ComboBox();
            cboSuppliers = new ComboBox();
            lstProduct_Suppliers = new ListBox();
            btnApply = new Button();
            button2 = new Button();
            lblPackageList = new Label();
            label1 = new Label();
            lblSuccess = new Label();
            SuspendLayout();
            // 
            // cboProducts
            // 
            cboProducts.DropDownHeight = 200;
            cboProducts.FormattingEnabled = true;
            cboProducts.IntegralHeight = false;
            cboProducts.Location = new Point(43, 62);
            cboProducts.Name = "cboProducts";
            cboProducts.Size = new Size(216, 28);
            cboProducts.TabIndex = 0;
            cboProducts.SelectedIndexChanged += cboProducts_SelectedIndexChanged;
            // 
            // cboSuppliers
            // 
            cboSuppliers.DropDownHeight = 200;
            cboSuppliers.FormattingEnabled = true;
            cboSuppliers.IntegralHeight = false;
            cboSuppliers.Location = new Point(379, 62);
            cboSuppliers.Name = "cboSuppliers";
            cboSuppliers.Size = new Size(216, 28);
            cboSuppliers.TabIndex = 2;
            // 
            // lstProduct_Suppliers
            // 
            lstProduct_Suppliers.FormattingEnabled = true;
            lstProduct_Suppliers.ItemHeight = 20;
            lstProduct_Suppliers.Location = new Point(43, 138);
            lstProduct_Suppliers.Name = "lstProduct_Suppliers";
            lstProduct_Suppliers.Size = new Size(573, 344);
            lstProduct_Suppliers.TabIndex = 5;
            // 
            // btnApply
            // 
            btnApply.BackColor = SystemColors.ButtonHighlight;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnApply.ForeColor = SystemColors.ActiveCaptionText;
            btnApply.Location = new Point(47, 509);
            btnApply.Margin = new Padding(3, 4, 3, 4);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(121, 50);
            btnApply.TabIndex = 7;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(247, 509);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(121, 50);
            button2.TabIndex = 8;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = false;
            // 
            // lblPackageList
            // 
            lblPackageList.AutoSize = true;
            lblPackageList.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPackageList.Location = new Point(43, 22);
            lblPackageList.Name = "lblPackageList";
            lblPackageList.Size = new Size(95, 28);
            lblPackageList.TabIndex = 9;
            lblPackageList.Text = "Products";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(379, 22);
            label1.Name = "label1";
            label1.Size = new Size(99, 28);
            label1.TabIndex = 10;
            label1.Text = "Suppliers";
            // 
            // lblSuccess
            // 
            lblSuccess.AutoSize = true;
            lblSuccess.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblSuccess.ForeColor = Color.Lime;
            lblSuccess.Location = new Point(43, 102);
            lblSuccess.Name = "lblSuccess";
            lblSuccess.Size = new Size(339, 23);
            lblSuccess.TabIndex = 11;
            lblSuccess.Text = "Product assigned to Supplier successfully";
            // 
            // frmAssignProdSup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            CancelButton = button2;
            ClientSize = new Size(668, 607);
            Controls.Add(lblSuccess);
            Controls.Add(label1);
            Controls.Add(lblPackageList);
            Controls.Add(button2);
            Controls.Add(btnApply);
            Controls.Add(lstProduct_Suppliers);
            Controls.Add(cboSuppliers);
            Controls.Add(cboProducts);
            Name = "frmAssignProdSup";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Assign Products to Supplier";
            Load += frmAssignProdSup_Load;
            Click += frmAssignProdSup_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboProducts;
        private ComboBox cboSuppliers;
        private ListBox lstProduct_Suppliers;
        private Button btnApply;
        private Button button2;
        private Label lblPackageList;
        private Label label1;
        private Label lblSuccess;
    }
}