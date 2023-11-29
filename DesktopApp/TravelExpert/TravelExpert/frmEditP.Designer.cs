namespace TravelExpert
{
    partial class frmEditP
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
            label3 = new Label();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(171, 83);
            label3.Name = "label3";
            label3.Size = new Size(177, 28);
            label3.TabIndex = 11;
            label3.Text = "Edit Product Name";
            // 
            // button1
            // 
            button1.Location = new Point(171, 335);
            button1.Name = "button1";
            button1.Size = new Size(163, 29);
            button1.TabIndex = 10;
            button1.Text = "Confirm Edit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(331, 170);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 9;
            label2.Text = "Product Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 170);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 8;
            label1.Text = "Product ID";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(320, 212);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(64, 212);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 6;
            // 
            // frmEditP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(541, 460);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "frmEditP";
            Text = "frmEditP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}