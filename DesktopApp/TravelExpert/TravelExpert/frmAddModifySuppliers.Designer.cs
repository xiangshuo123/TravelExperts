namespace TravelExpert
{
    partial class frmAddModifySuppliers
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
            lblTitle = new Label();
            txtSupID = new TextBox();
            txtSupName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(320, 39);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(383, 57);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "Edit Supplier Data";
            // 
            // txtSupID
            // 
            txtSupID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSupID.Location = new Point(411, 159);
            txtSupID.Name = "txtSupID";
            txtSupID.Size = new Size(540, 50);
            txtSupID.TabIndex = 10;
            // 
            // txtSupName
            // 
            txtSupName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSupName.Location = new Point(411, 255);
            txtSupName.Name = "txtSupName";
            txtSupName.Size = new Size(540, 50);
            txtSupName.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(74, 155);
            label1.Name = "label1";
            label1.Size = new Size(229, 54);
            label1.TabIndex = 12;
            label1.Text = "Supplier ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(74, 251);
            label2.Name = "label2";
            label2.Size = new Size(295, 54);
            label2.TabIndex = 13;
            label2.Text = "Supplier Name:";
            // 
            // btnAccept
            // 
            btnAccept.BackColor = SystemColors.ButtonHighlight;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAccept.Location = new Point(74, 384);
            btnAccept.Margin = new Padding(6);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(241, 78);
            btnAccept.TabIndex = 14;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ButtonHighlight;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.Location = new Point(705, 384);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(246, 78);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmAddModifySuppliers
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(1104, 575);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSupName);
            Controls.Add(txtSupID);
            Controls.Add(lblTitle);
            Name = "frmAddModifySuppliers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddModifySuppliers";
            Load += frmAddModifySuppliers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtSupID;
        private TextBox txtSupName;
        private Label label1;
        private Label label2;
        private Button btnAccept;
        private Button btnCancel;
    }
}