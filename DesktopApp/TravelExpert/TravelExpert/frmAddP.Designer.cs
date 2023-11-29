namespace TravelExpert
{
    partial class frmAddP
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
            textBox2 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(214, 194);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(225, 152);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 3;
            label2.Text = "Product Name";
            // 
            // button1
            // 
            button1.Location = new Point(230, 317);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(193, 63);
            label3.Name = "label3";
            label3.Size = new Size(170, 28);
            label3.TabIndex = 5;
            label3.Text = "Enter Product Info";
            // 
            // frmAddP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(570, 450);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Name = "frmAddP";
            Text = "frmAddP";
            Load += frmAddP_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox2;
        private Label label2;
        private Button button1;
        private Label label3;
    }
}