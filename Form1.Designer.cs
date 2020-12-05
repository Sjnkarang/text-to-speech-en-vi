namespace Docso
{
    partial class Form1
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
            this.viBtn = new System.Windows.Forms.RadioButton();
            this.enBtn = new System.Windows.Forms.RadioButton();
            this.input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viBtn
            // 
            this.viBtn.AutoSize = true;
            this.viBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viBtn.Location = new System.Drawing.Point(385, 117);
            this.viBtn.Name = "viBtn";
            this.viBtn.Size = new System.Drawing.Size(44, 28);
            this.viBtn.TabIndex = 0;
            this.viBtn.TabStop = true;
            this.viBtn.Text = "VI";
            this.viBtn.UseVisualStyleBackColor = true;
            this.viBtn.CheckedChanged += new System.EventHandler(this.viBtn_CheckedChanged);
            // 
            // enBtn
            // 
            this.enBtn.AutoSize = true;
            this.enBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enBtn.Location = new System.Drawing.Point(486, 117);
            this.enBtn.Name = "enBtn";
            this.enBtn.Size = new System.Drawing.Size(54, 28);
            this.enBtn.TabIndex = 1;
            this.enBtn.TabStop = true;
            this.enBtn.Text = "EN";
            this.enBtn.UseVisualStyleBackColor = true;
            this.enBtn.CheckedChanged += new System.EventHandler(this.enBtn_CheckedChanged);
            // 
            // input
            // 
            this.input.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input.Location = new System.Drawing.Point(432, 178);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(399, 29);
            this.input.TabIndex = 2;
            this.input.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số cần chuyển đổi";
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.Control;
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.Location = new System.Drawing.Point(432, 241);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(399, 138);
            this.output.TabIndex = 4;
            this.output.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chữ đã được chuyển đổi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(231, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(483, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chương trình đọc từ số sang chữ";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(320, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 70);
            this.button1.TabIndex = 7;
            this.button1.Text = "Đọc thành tiếng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(948, 573);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input);
            this.Controls.Add(this.enBtn);
            this.Controls.Add(this.viBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton viBtn;
        private System.Windows.Forms.RadioButton enBtn;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

