namespace StudentForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textAnswer = new System.Windows.Forms.TextBox();
            this.textQuestion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(72)))), ((int)(((byte)(76)))));
            this.panelTop.Controls.Add(this.btnMinimize);
            this.panelTop.Controls.Add(this.panel7);
            this.panelTop.Controls.Add(this.label11);
            this.panelTop.Controls.Add(this.btnExit);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(488, 68);
            this.panelTop.TabIndex = 19;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("OCR A Extended", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(398, 9);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(36, 38);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(191)))), ((int)(((byte)(159)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 65);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(488, 3);
            this.panel7.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(72)))), ((int)(((byte)(76)))));
            this.label11.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(195)))), ((int)(((byte)(200)))));
            this.label11.Location = new System.Drawing.Point(190, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 24);
            this.label11.TabIndex = 15;
            this.label11.Text = "Student";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("OCR A Extended", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(440, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 38);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textAnswer);
            this.panel1.Controls.Add(this.textQuestion);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(53, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 193);
            this.panel1.TabIndex = 20;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(299, 146);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(60, 20);
            this.btnSubmit.TabIndex = 16;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(191)))), ((int)(((byte)(159)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 191);
            this.panel2.TabIndex = 12;
            // 
            // textAnswer
            // 
            this.textAnswer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textAnswer.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAnswer.Location = new System.Drawing.Point(140, 85);
            this.textAnswer.Name = "textAnswer";
            this.textAnswer.Size = new System.Drawing.Size(219, 26);
            this.textAnswer.TabIndex = 9;
            // 
            // textQuestion
            // 
            this.textQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textQuestion.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textQuestion.Location = new System.Drawing.Point(140, 52);
            this.textQuestion.Name = "textQuestion";
            this.textQuestion.Size = new System.Drawing.Size(219, 26);
            this.textQuestion.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(13, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Your answer:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Question:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(87)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(10, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(388, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Enter your answer and click Submit:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(488, 357);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textAnswer;
        private System.Windows.Forms.TextBox textQuestion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

