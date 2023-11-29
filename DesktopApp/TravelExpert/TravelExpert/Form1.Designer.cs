namespace TravelExpert
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblTitle = new Label();
            lbxDetails = new ListBox();
            lbxPackages = new ListBox();
            lblPackageList = new Label();
            btnPackages = new Button();
            btnSupplier = new Button();
            btnProducts = new Button();
            btnPS = new Button();
            btnRefresh = new Button();
            btn_exit = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(178, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(633, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Travel Expert Package Management Application";
            // 
            // lbxDetails
            // 
            lbxDetails.FormattingEnabled = true;
            lbxDetails.ItemHeight = 20;
            lbxDetails.Location = new Point(1011, 125);
            lbxDetails.Margin = new Padding(3, 4, 3, 4);
            lbxDetails.Name = "lbxDetails";
            lbxDetails.Size = new Size(311, 304);
            lbxDetails.TabIndex = 2;
            // 
            // lbxPackages
            // 
            lbxPackages.FormattingEnabled = true;
            lbxPackages.ItemHeight = 20;
            lbxPackages.Location = new Point(51, 125);
            lbxPackages.Margin = new Padding(3, 4, 3, 4);
            lbxPackages.Name = "lbxPackages";
            lbxPackages.Size = new Size(938, 304);
            lbxPackages.TabIndex = 1;
            lbxPackages.SelectedIndexChanged += lbxPackages_SelectedIndexChanged;
            // 
            // lblPackageList
            // 
            lblPackageList.AutoSize = true;
            lblPackageList.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPackageList.Location = new Point(51, 81);
            lblPackageList.Name = "lblPackageList";
            lblPackageList.Size = new Size(182, 37);
            lblPackageList.TabIndex = 3;
            lblPackageList.Text = "Package List:";
            // 
            // btnPackages
            // 
            btnPackages.BackColor = SystemColors.ButtonHighlight;
            btnPackages.FlatStyle = FlatStyle.Flat;
            btnPackages.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnPackages.ForeColor = SystemColors.ActiveCaptionText;
            btnPackages.Location = new Point(51, 454);
            btnPackages.Margin = new Padding(3, 4, 3, 4);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(258, 50);
            btnPackages.TabIndex = 4;
            btnPackages.Text = "Add/Edit Packages";
            btnPackages.UseVisualStyleBackColor = false;
            btnPackages.Click += btnPackages_Click;
            // 
            // btnSupplier
            // 
            btnSupplier.BackColor = SystemColors.ButtonHighlight;
            btnSupplier.FlatStyle = FlatStyle.Flat;
            btnSupplier.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSupplier.Location = new Point(319, 454);
            btnSupplier.Margin = new Padding(3, 4, 3, 4);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(262, 50);
            btnSupplier.TabIndex = 5;
            btnSupplier.Text = "Add/Edit Suppliers";
            btnSupplier.UseVisualStyleBackColor = false;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = SystemColors.ButtonHighlight;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnProducts.Location = new Point(594, 454);
            btnProducts.Margin = new Padding(3, 4, 3, 4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(270, 50);
            btnProducts.TabIndex = 6;
            btnProducts.Text = "Add/Edit Products";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnPS
            // 
            btnPS.BackColor = SystemColors.ButtonHighlight;
            btnPS.FlatStyle = FlatStyle.Flat;
            btnPS.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnPS.Location = new Point(51, 512);
            btnPS.Margin = new Padding(3, 4, 3, 4);
            btnPS.Name = "btnPS";
            btnPS.Size = new Size(530, 50);
            btnPS.TabIndex = 7;
            btnPS.Text = "Assign Products to Supplier";
            btnPS.UseVisualStyleBackColor = false;
            btnPS.Click += btnPS_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ButtonHighlight;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnRefresh.Location = new Point(1011, 31);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(234, 50);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btn_exit
            // 
            btn_exit.BackColor = SystemColors.ButtonHighlight;
            btn_exit.FlatStyle = FlatStyle.Flat;
            btn_exit.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_exit.Location = new Point(594, 512);
            btn_exit.Margin = new Padding(3, 4, 3, 4);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(270, 50);
            btn_exit.TabIndex = 9;
            btn_exit.Text = "Exit Application";
            btn_exit.UseVisualStyleBackColor = false;
            btn_exit.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(885, 454);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(437, 108);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1334, 585);
            Controls.Add(pictureBox1);
            Controls.Add(btn_exit);
            Controls.Add(btnRefresh);
            Controls.Add(btnPS);
            Controls.Add(btnProducts);
            Controls.Add(btnSupplier);
            Controls.Add(btnPackages);
            Controls.Add(lblPackageList);
            Controls.Add(lbxDetails);
            Controls.Add(lbxPackages);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "TravelExperts";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private ListBox lbxDetails;
        private ListBox lbxPackages;
        private Label lblPackageList;
        private Button btnPackages;
        private Button btnSupplier;
        private Button btnProducts;
        private Button btnPS;
        private Button btnRefresh;
        private Button btn_exit;
        private PictureBox pictureBox1;
    }
}