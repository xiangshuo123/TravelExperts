namespace TravelExpert
{
    partial class frmAddEditPackage
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
            dtpPkgEndDate = new DateTimePicker();
            dtpPkgStartDate = new DateTimePicker();
            txtPkgAgencyCommission = new TextBox();
            txtPkgBasePrice = new TextBox();
            txtPkgDesc = new TextBox();
            txtPkgName = new TextBox();
            btnSave = new Button();
            lblPkgName = new Label();
            lblPkgDesc = new Label();
            lblBasePrice = new Label();
            lblAgencyCommision = new Label();
            lblStartDate = new Label();
            lblEndDate = new Label();
            btnCancelPackage = new Button();
            SuspendLayout();
            // 
            // dtpPkgEndDate
            // 
            dtpPkgEndDate.Location = new Point(258, 240);
            dtpPkgEndDate.Name = "dtpPkgEndDate";
            dtpPkgEndDate.Size = new Size(200, 23);
            dtpPkgEndDate.TabIndex = 15;
            // 
            // dtpPkgStartDate
            // 
            dtpPkgStartDate.Location = new Point(258, 197);
            dtpPkgStartDate.Name = "dtpPkgStartDate";
            dtpPkgStartDate.Size = new Size(200, 23);
            dtpPkgStartDate.TabIndex = 14;
            // 
            // txtPkgAgencyCommission
            // 
            txtPkgAgencyCommission.Location = new Point(258, 113);
            txtPkgAgencyCommission.Name = "txtPkgAgencyCommission";
            txtPkgAgencyCommission.Size = new Size(121, 23);
            txtPkgAgencyCommission.TabIndex = 13;
            // 
            // txtPkgBasePrice
            // 
            txtPkgBasePrice.Location = new Point(258, 73);
            txtPkgBasePrice.Name = "txtPkgBasePrice";
            txtPkgBasePrice.Size = new Size(121, 23);
            txtPkgBasePrice.TabIndex = 12;
            // 
            // txtPkgDesc
            // 
            txtPkgDesc.Location = new Point(258, 155);
            txtPkgDesc.Name = "txtPkgDesc";
            txtPkgDesc.Size = new Size(200, 23);
            txtPkgDesc.TabIndex = 11;
            // 
            // txtPkgName
            // 
            txtPkgName.Location = new Point(258, 34);
            txtPkgName.Name = "txtPkgName";
            txtPkgName.Size = new Size(121, 23);
            txtPkgName.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ButtonHighlight;
            btnSave.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(117, 295);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(124, 46);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblPkgName
            // 
            lblPkgName.AutoSize = true;
            lblPkgName.Location = new Point(115, 37);
            lblPkgName.Name = "lblPkgName";
            lblPkgName.Size = new Size(89, 15);
            lblPkgName.TabIndex = 18;
            lblPkgName.Text = "Package Name:";
            // 
            // lblPkgDesc
            // 
            lblPkgDesc.AutoSize = true;
            lblPkgDesc.Location = new Point(115, 158);
            lblPkgDesc.Name = "lblPkgDesc";
            lblPkgDesc.Size = new Size(117, 15);
            lblPkgDesc.TabIndex = 19;
            lblPkgDesc.Text = "Package Description:";
            // 
            // lblBasePrice
            // 
            lblBasePrice.AutoSize = true;
            lblBasePrice.Location = new Point(115, 76);
            lblBasePrice.Name = "lblBasePrice";
            lblBasePrice.Size = new Size(110, 15);
            lblBasePrice.TabIndex = 20;
            lblBasePrice.Text = "Package Base Price:";
            // 
            // lblAgencyCommision
            // 
            lblAgencyCommision.AutoSize = true;
            lblAgencyCommision.Location = new Point(117, 116);
            lblAgencyCommision.Name = "lblAgencyCommision";
            lblAgencyCommision.Size = new Size(115, 15);
            lblAgencyCommision.TabIndex = 21;
            lblAgencyCommision.Text = "Agency Commision:";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(115, 197);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(61, 15);
            lblStartDate.TabIndex = 22;
            lblStartDate.Text = "Start Date:";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(117, 240);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(57, 15);
            lblEndDate.TabIndex = 23;
            lblEndDate.Text = "End Date:";
            // 
            // btnCancelPackage
            // 
            btnCancelPackage.BackColor = SystemColors.ButtonHighlight;
            btnCancelPackage.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelPackage.Location = new Point(298, 295);
            btnCancelPackage.Name = "btnCancelPackage";
            btnCancelPackage.Size = new Size(124, 46);
            btnCancelPackage.TabIndex = 24;
            btnCancelPackage.Text = "Cancel";
            btnCancelPackage.UseVisualStyleBackColor = false;
            btnCancelPackage.Click += btnCancelPackage_Click;
            // 
            // frmAddEditPackage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(555, 377);
            Controls.Add(btnCancelPackage);
            Controls.Add(lblEndDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblAgencyCommision);
            Controls.Add(lblBasePrice);
            Controls.Add(lblPkgDesc);
            Controls.Add(lblPkgName);
            Controls.Add(btnSave);
            Controls.Add(dtpPkgEndDate);
            Controls.Add(dtpPkgStartDate);
            Controls.Add(txtPkgAgencyCommission);
            Controls.Add(txtPkgBasePrice);
            Controls.Add(txtPkgDesc);
            Controls.Add(txtPkgName);
            Name = "frmAddEditPackage";
            Text = "frmAddEditPackage";
            Load += frmAddEditPackage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dtpPkgEndDate;
        private DateTimePicker dtpPkgStartDate;
        private TextBox txtPkgAgencyCommission;
        private TextBox txtPkgBasePrice;
        private TextBox txtPkgDesc;
        private TextBox txtPkgName;
        private Button btnSave;
        private Label lblPkgName;
        private Label lblPkgDesc;
        private Label lblBasePrice;
        private Label lblAgencyCommision;
        private Label lblStartDate;
        private Label lblEndDate;
        private Button btnCancelPackage;
    }
}