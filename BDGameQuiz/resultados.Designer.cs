namespace BDGameQuiz
{
    partial class resultados
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
            System.Windows.Forms.TableLayoutPanel resPanel;
            this.lblScore = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.ScoresView = new System.Windows.Forms.DataGridView();
            resPanel = new System.Windows.Forms.TableLayoutPanel();
            resPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScoresView)).BeginInit();
            this.SuspendLayout();
            // 
            // resPanel
            // 
            resPanel.ColumnCount = 1;
            resPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            resPanel.Controls.Add(this.lblScore, 0, 0);
            resPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            resPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            resPanel.Location = new System.Drawing.Point(0, 0);
            resPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            resPanel.Name = "resPanel";
            resPanel.RowCount = 2;
            resPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            resPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            resPanel.Size = new System.Drawing.Size(900, 562);
            resPanel.TabIndex = 0;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore.Font = new System.Drawing.Font("Times New Roman", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(3, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(894, 281);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Resultado";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.78841F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.21159F));
            this.tableLayoutPanel1.Controls.Add(this.btnMenu, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ScoresView, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 285);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.34703F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.652968F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(894, 273);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnMenu
            // 
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenu.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(644, 4);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(247, 255);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click_1);
            // 
            // ScoresView
            // 
            this.ScoresView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ScoresView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScoresView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScoresView.Location = new System.Drawing.Point(3, 4);
            this.ScoresView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScoresView.Name = "ScoresView";
            this.ScoresView.RowHeadersWidth = 51;
            this.ScoresView.RowTemplate.Height = 24;
            this.ScoresView.Size = new System.Drawing.Size(635, 255);
            this.ScoresView.TabIndex = 1;
            this.ScoresView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScoresView_CellContentClick);
            // 
            // resultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(resPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "resultados";
            this.Text = "RESULTADOS";
            resPanel.ResumeLayout(false);
            resPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScoresView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.DataGridView ScoresView;
    }
}