namespace BDGameQuiz
{
    partial class juego
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
            this.gamePanel = new System.Windows.Forms.TableLayoutPanel();
            this.answersPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.gamePanel.SuspendLayout();
            this.answersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.ColumnCount = 1;
            this.gamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gamePanel.Controls.Add(this.answersPanel, 0, 1);
            this.gamePanel.Controls.Add(this.lblPregunta, 0, 0);
            this.gamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePanel.Location = new System.Drawing.Point(0, 0);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.RowCount = 2;
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.33333F));
            this.gamePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.66667F));
            this.gamePanel.Size = new System.Drawing.Size(800, 450);
            this.gamePanel.TabIndex = 0;
            // 
            // answersPanel
            // 
            this.answersPanel.ColumnCount = 2;
            this.answersPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.answersPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.answersPanel.Controls.Add(this.btn4, 1, 1);
            this.answersPanel.Controls.Add(this.btn3, 0, 1);
            this.answersPanel.Controls.Add(this.btn2, 1, 0);
            this.answersPanel.Controls.Add(this.btn1, 0, 0);
            this.answersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answersPanel.Location = new System.Drawing.Point(3, 179);
            this.answersPanel.Name = "answersPanel";
            this.answersPanel.RowCount = 2;
            this.answersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.answersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.answersPanel.Size = new System.Drawing.Size(794, 268);
            this.answersPanel.TabIndex = 0;
            // 
            // btn4
            // 
            this.btn4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn4.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(400, 137);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(391, 128);
            this.btn4.TabIndex = 3;
            this.btn4.Text = "button4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn3
            // 
            this.btn3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn3.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(3, 137);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(391, 128);
            this.btn3.TabIndex = 2;
            this.btn3.Text = "button3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn2
            // 
            this.btn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn2.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(400, 3);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(391, 128);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "button2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(3, 3);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(391, 128);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "button1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPregunta.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPregunta.Location = new System.Drawing.Point(3, 0);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(794, 176);
            this.lblPregunta.TabIndex = 1;
            this.lblPregunta.Text = "TEXT PREGUNTA";
            this.lblPregunta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gamePanel);
            this.Name = "juego";
            this.Text = "GAME";
            this.gamePanel.ResumeLayout(false);
            this.gamePanel.PerformLayout();
            this.answersPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel gamePanel;
        private System.Windows.Forms.TableLayoutPanel answersPanel;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label lblPregunta;
    }
}