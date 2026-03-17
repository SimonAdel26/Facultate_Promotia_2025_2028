namespace ParcurgereMatrici
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            colorDialog1 = new ColorDialog();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(14, 14);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(840, 830);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold);
            textBox1.Location = new Point(861, 14);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(863, 539);
            textBox1.TabIndex = 2;
            textBox1.Text = "1 2 3 4 5\r\n2 3 4 5 6\r\n3 4 5 6 7\r\n4 5 6 7 8\r\n5 6 7 8 9";
            // 
            // button1
            // 
            button1.BackColor = Color.Crimson;
            button1.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1586, 790);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(139, 52);
            button1.TabIndex = 3;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.CornflowerBlue;
            button2.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(861, 561);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(210, 66);
            button2.TabIndex = 4;
            button2.Text = "Cruce";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.CornflowerBlue;
            button3.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(1078, 561);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(210, 66);
            button3.TabIndex = 5;
            button3.Text = "X";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.CornflowerBlue;
            button4.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(861, 633);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(210, 66);
            button4.TabIndex = 6;
            button4.Text = "Spirala";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.CornflowerBlue;
            button5.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(1078, 633);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(210, 66);
            button5.TabIndex = 7;
            button5.Text = "NSEV";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.CornflowerBlue;
            button6.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold);
            button6.ForeColor = Color.White;
            button6.Location = new Point(1295, 561);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new Size(210, 66);
            button6.TabIndex = 8;
            button6.Text = "+ x Diagonale";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.CornflowerBlue;
            button7.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold);
            button7.ForeColor = Color.White;
            button7.Location = new Point(1295, 633);
            button7.Margin = new Padding(4, 3, 4, 3);
            button7.Name = "button7";
            button7.Size = new Size(210, 66);
            button7.TabIndex = 9;
            button7.Text = "Serpuit";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.CornflowerBlue;
            button8.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold);
            button8.ForeColor = Color.White;
            button8.Location = new Point(1512, 561);
            button8.Margin = new Padding(4, 3, 4, 3);
            button8.Name = "button8";
            button8.Size = new Size(210, 66);
            button8.TabIndex = 10;
            button8.Text = "Rotire 90";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1738, 856);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}
