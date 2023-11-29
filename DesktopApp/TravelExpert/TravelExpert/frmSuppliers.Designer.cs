namespace TravelExpert
{
    partial class frmSuppliers
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
            btnCancel = new Button();
            btnAdd = new Button();
            lblPackageList = new Label();
            lbxSuppliers = new ListBox();
            lblTitle = new Label();
            btnEdit = new Button();
            lblAdded = new Label();
            lblEdited = new Label();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ButtonHighlight;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.Location = new Point(1081, 730);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(242, 88);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ButtonHighlight;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(96, 730);
            btnAdd.Margin = new Padding(6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(337, 88);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add Supplier";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblPackageList
            // 
            lblPackageList.AutoSize = true;
            lblPackageList.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPackageList.Location = new Point(96, 91);
            lblPackageList.Margin = new Padding(6, 0, 6, 0);
            lblPackageList.Name = "lblPackageList";
            lblPackageList.Size = new Size(219, 57);
            lblPackageList.TabIndex = 11;
            lblPackageList.Text = "Suppliers:";
            // 
            // lbxSuppliers
            // 
            lbxSuppliers.FormattingEnabled = true;
            lbxSuppliers.ItemHeight = 32;
            lbxSuppliers.Location = new Point(96, 213);
            lbxSuppliers.Margin = new Padding(6);
            lbxSuppliers.Name = "lbxSuppliers";
            lbxSuppliers.Size = new Size(1227, 484);
            lbxSuppliers.TabIndex = 9;
            lbxSuppliers.SelectedIndexChanged += lbxSuppliers_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(488, 38);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(295, 57);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Supplier Data";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ButtonHighlight;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.Location = new Point(465, 730);
            btnEdit.Margin = new Padding(6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(318, 88);
            btnEdit.TabIndex = 16;
            btnEdit.Text = "Edit Supplier";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblAdded
            // 
            lblAdded.AutoSize = true;
            lblAdded.Location = new Point(96, 158);
            lblAdded.Name = "lblAdded";
            lblAdded.Size = new Size(302, 32);
            lblAdded.TabIndex = 17;
            lblAdded.Text = "Supplier added successfuly";
            lblAdded.Visible = false;
            // 
            // lblEdited
            // 
            lblEdited.AutoSize = true;
            lblEdited.Location = new Point(96, 158);
            lblEdited.Name = "lblEdited";
            lblEdited.Size = new Size(303, 32);
            lblEdited.TabIndex = 18;
            lblEdited.Text = "Supplier edited successfuly";
            lblEdited.Visible = false;
            // 
            // frmSuppliers
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            CancelButton = btnCancel;
            ClientSize = new Size(1410, 1049);
            Controls.Add(lblEdited);
            Controls.Add(lblAdded);
            Controls.Add(btnEdit);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(lblPackageList);
            Controls.Add(lbxSuppliers);
            Controls.Add(lblTitle);
            Name = "frmSuppliers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddModifySuppliers";
            Load += frmSuppliers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnAdd;
        private Label lblPackageList;
        private ListBox lbxSuppliers;
        private Label lblTitle;
        private Button btnEdit;
        private Label lblAdded;
        private Label lblEdited;
    }
}