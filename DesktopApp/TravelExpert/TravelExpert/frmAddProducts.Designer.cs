namespace TravelExpert
{
    partial class frmAddProducts
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
            button1 = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            lblPackageList = new Label();
            lbxProducts = new ListBox();
            lblTitle = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(621, 483);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(196, 88);
            button1.TabIndex = 24;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.ButtonHighlight;
            btnEdit.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.Location = new Point(344, 483);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(196, 88);
            btnEdit.TabIndex = 23;
            btnEdit.Text = "Edit Product";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ButtonHighlight;
            btnAdd.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(62, 483);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(196, 88);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "Add Product";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblPackageList
            // 
            lblPackageList.AutoSize = true;
            lblPackageList.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPackageList.Location = new Point(22, -72);
            lblPackageList.Margin = new Padding(4, 0, 4, 0);
            lblPackageList.Name = "lblPackageList";
            lblPackageList.Size = new Size(143, 37);
            lblPackageList.TabIndex = 20;
            lblPackageList.Text = "Suppliers:";
            // 
            // lbxProducts
            // 
            lbxProducts.FormattingEnabled = true;
            lbxProducts.ItemHeight = 20;
            lbxProducts.Location = new Point(62, 143);
            lbxProducts.Margin = new Padding(4);
            lbxProducts.Name = "lbxProducts";
            lbxProducts.Size = new Size(757, 304);
            lbxProducts.TabIndex = 19;
            lbxProducts.SelectedIndexChanged += lbxProducts_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(263, -132);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(192, 37);
            lblTitle.TabIndex = 18;
            lblTitle.Text = "Supplier Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(331, 38);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(225, 37);
            label2.TabIndex = 25;
            label2.Text = "Select a product";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(62, 119);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 26;
            label1.Text = "Product ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(206, 119);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 27;
            label3.Text = "Product Name";
            // 
            // frmAddProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(899, 618);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(lblPackageList);
            Controls.Add(lbxProducts);
            Controls.Add(lblTitle);
            Name = "frmAddProducts";
            Text = "frmAddProducts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnEdit;
        private Button btnAdd;
        private Label lblPackageList;
        private ListBox lbxProducts;
        private Label lblTitle;
        private Label label2;
        private Label label1;
        private Label label3;
    }
}