namespace TravelExpert
{
    partial class frmPackages
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
            cmbPackageList = new ComboBox();
            btnEdit = new Button();
            btnAdd = new Button();
            btnPackageBack = new Button();
            lblPackageSelect = new Label();
            label1 = new Label();
            btnAddProductSupplier = new Button();
            SuspendLayout();
            // 
            // cmbPackageList
            // 
            cmbPackageList.FormattingEnabled = true;
            cmbPackageList.Location = new Point(82, 96);
            cmbPackageList.Margin = new Padding(3, 4, 3, 4);
            cmbPackageList.Name = "cmbPackageList";
            cmbPackageList.Size = new Size(242, 28);
            cmbPackageList.TabIndex = 10;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.Location = new Point(347, 83);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(146, 56);
            btnEdit.TabIndex = 19;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(94, 224);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(386, 59);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Add New Package";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnPackageBack
            // 
            btnPackageBack.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnPackageBack.Location = new Point(94, 407);
            btnPackageBack.Margin = new Padding(3, 4, 3, 4);
            btnPackageBack.Name = "btnPackageBack";
            btnPackageBack.Size = new Size(386, 59);
            btnPackageBack.TabIndex = 20;
            btnPackageBack.Text = "Cancel";
            btnPackageBack.UseVisualStyleBackColor = true;
            btnPackageBack.Click += btnPackageBack_Click;
            // 
            // lblPackageSelect
            // 
            lblPackageSelect.AutoSize = true;
            lblPackageSelect.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPackageSelect.Location = new Point(17, 28);
            lblPackageSelect.Name = "lblPackageSelect";
            lblPackageSelect.Size = new Size(527, 23);
            lblPackageSelect.TabIndex = 21;
            lblPackageSelect.Text = "Please select the package tha you want to edit:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(183, 168);
            label1.Name = "label1";
            label1.Size = new Size(164, 23);
            label1.TabIndex = 22;
            label1.Text = "----- OR -----";
            // 
            // btnAddProductSupplier
            // 
            btnAddProductSupplier.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddProductSupplier.Location = new Point(92, 317);
            btnAddProductSupplier.Margin = new Padding(3, 4, 3, 4);
            btnAddProductSupplier.Name = "btnAddProductSupplier";
            btnAddProductSupplier.Size = new Size(388, 59);
            btnAddProductSupplier.TabIndex = 23;
            btnAddProductSupplier.Text = "Add New Product to Package";
            btnAddProductSupplier.UseVisualStyleBackColor = true;
            btnAddProductSupplier.Click += btnAddProductSupplier_Click;
            // 
            // frmPackages
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(563, 517);
            Controls.Add(btnAddProductSupplier);
            Controls.Add(label1);
            Controls.Add(lblPackageSelect);
            Controls.Add(btnPackageBack);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(cmbPackageList);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmPackages";
            Text = "frmPackages";
            Load += frmPackages_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbPackageList;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnPackageBack;
        private Label lblPackageSelect;
        private Label label1;
        private Button btnAddProductSupplier;
    }
}