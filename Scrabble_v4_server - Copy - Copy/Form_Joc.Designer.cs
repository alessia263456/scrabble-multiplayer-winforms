namespace Scrabble_v4_server
{
    partial class Form_Joc
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
            this.label_numeJucator = new System.Windows.Forms.Label();
            this.label_numeAdversar = new System.Windows.Forms.Label();
            this.label_ScorJucator = new System.Windows.Forms.Label();
            this.label_ScorAdversar = new System.Windows.Forms.Label();
            this.label_LitereRamase = new System.Windows.Forms.Label();
            this.label_nr_LitereRamase = new System.Windows.Forms.Label();
            this.button_EnterCuvant = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Undo = new System.Windows.Forms.Button();
            this.label_Win = new System.Windows.Forms.Label();
            this.panel_Nume = new System.Windows.Forms.Panel();
            this.label_client_conectat = new System.Windows.Forms.Label();
            this.textBox_Nume = new System.Windows.Forms.TextBox();
            this.label_Nume = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.panel_Nume.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_numeJucator
            // 
            this.label_numeJucator.AutoSize = true;
            this.label_numeJucator.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numeJucator.Location = new System.Drawing.Point(0, 35);
            this.label_numeJucator.Name = "label_numeJucator";
            this.label_numeJucator.Size = new System.Drawing.Size(170, 38);
            this.label_numeJucator.TabIndex = 0;
            this.label_numeJucator.Text = "Player1(you)";
            // 
            // label_numeAdversar
            // 
            this.label_numeAdversar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_numeAdversar.AutoSize = true;
            this.label_numeAdversar.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numeAdversar.Location = new System.Drawing.Point(546, 35);
            this.label_numeAdversar.Name = "label_numeAdversar";
            this.label_numeAdversar.Size = new System.Drawing.Size(110, 38);
            this.label_numeAdversar.TabIndex = 1;
            this.label_numeAdversar.Text = "Player2";
            this.label_numeAdversar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_ScorJucator
            // 
            this.label_ScorJucator.AutoSize = true;
            this.label_ScorJucator.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ScorJucator.Location = new System.Drawing.Point(1, 73);
            this.label_ScorJucator.Name = "label_ScorJucator";
            this.label_ScorJucator.Size = new System.Drawing.Size(104, 38);
            this.label_ScorJucator.TabIndex = 2;
            this.label_ScorJucator.Text = "Scor: 0";
            // 
            // label_ScorAdversar
            // 
            this.label_ScorAdversar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ScorAdversar.AutoSize = true;
            this.label_ScorAdversar.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ScorAdversar.Location = new System.Drawing.Point(546, 73);
            this.label_ScorAdversar.Name = "label_ScorAdversar";
            this.label_ScorAdversar.Size = new System.Drawing.Size(104, 38);
            this.label_ScorAdversar.TabIndex = 3;
            this.label_ScorAdversar.Text = "Scor: 0";
            this.label_ScorAdversar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_LitereRamase
            // 
            this.label_LitereRamase.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_LitereRamase.AutoSize = true;
            this.label_LitereRamase.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LitereRamase.Location = new System.Drawing.Point(5, 137);
            this.label_LitereRamase.Name = "label_LitereRamase";
            this.label_LitereRamase.Size = new System.Drawing.Size(123, 76);
            this.label_LitereRamase.TabIndex = 4;
            this.label_LitereRamase.Text = "Litere\r\nRamase:";
            // 
            // label_nr_LitereRamase
            // 
            this.label_nr_LitereRamase.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_nr_LitereRamase.AutoSize = true;
            this.label_nr_LitereRamase.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nr_LitereRamase.Location = new System.Drawing.Point(5, 208);
            this.label_nr_LitereRamase.Name = "label_nr_LitereRamase";
            this.label_nr_LitereRamase.Size = new System.Drawing.Size(33, 38);
            this.label_nr_LitereRamase.TabIndex = 5;
            this.label_nr_LitereRamase.Text = "0";
            this.label_nr_LitereRamase.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button_EnterCuvant
            // 
            this.button_EnterCuvant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_EnterCuvant.Location = new System.Drawing.Point(670, 672);
            this.button_EnterCuvant.Name = "button_EnterCuvant";
            this.button_EnterCuvant.Size = new System.Drawing.Size(75, 23);
            this.button_EnterCuvant.TabIndex = 6;
            this.button_EnterCuvant.Text = "Enter!";
            this.button_EnterCuvant.UseVisualStyleBackColor = true;
            this.button_EnterCuvant.Click += new System.EventHandler(this.button_EnterCuvant_Click);
            // 
            // button_Start
            // 
            this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Start.Location = new System.Drawing.Point(136, 160);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(103, 68);
            this.button_Start.TabIndex = 7;
            this.button_Start.Text = "Start Game!";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Undo
            // 
            this.button_Undo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Undo.Location = new System.Drawing.Point(12, 672);
            this.button_Undo.Name = "button_Undo";
            this.button_Undo.Size = new System.Drawing.Size(75, 23);
            this.button_Undo.TabIndex = 8;
            this.button_Undo.Text = "Undo";
            this.button_Undo.UseVisualStyleBackColor = true;
            this.button_Undo.Click += new System.EventHandler(this.button_Undo_Click);
            // 
            // label_Win
            // 
            this.label_Win.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Win.AutoSize = true;
            this.label_Win.BackColor = System.Drawing.Color.Silver;
            this.label_Win.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Win.Location = new System.Drawing.Point(252, 0);
            this.label_Win.Name = "label_Win";
            this.label_Win.Size = new System.Drawing.Size(143, 32);
            this.label_Win.TabIndex = 9;
            this.label_Win.Text = "label_win";
            this.label_Win.Visible = false;
            // 
            // panel_Nume
            // 
            this.panel_Nume.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel_Nume.Controls.Add(this.label_client_conectat);
            this.panel_Nume.Controls.Add(this.textBox_Nume);
            this.panel_Nume.Controls.Add(this.label_Nume);
            this.panel_Nume.Controls.Add(this.button_Start);
            this.panel_Nume.Location = new System.Drawing.Point(185, 196);
            this.panel_Nume.Name = "panel_Nume";
            this.panel_Nume.Size = new System.Drawing.Size(377, 266);
            this.panel_Nume.TabIndex = 16;
            // 
            // label_client_conectat
            // 
            this.label_client_conectat.AutoSize = true;
            this.label_client_conectat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_client_conectat.Location = new System.Drawing.Point(67, 240);
            this.label_client_conectat.Name = "label_client_conectat";
            this.label_client_conectat.Size = new System.Drawing.Size(241, 22);
            this.label_client_conectat.TabIndex = 16;
            this.label_client_conectat.Text = "Clientul nu s-a conectat inca!";
            // 
            // textBox_Nume
            // 
            this.textBox_Nume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Nume.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.textBox_Nume.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Nume.Location = new System.Drawing.Point(52, 85);
            this.textBox_Nume.Name = "textBox_Nume";
            this.textBox_Nume.Size = new System.Drawing.Size(270, 38);
            this.textBox_Nume.TabIndex = 15;
            this.textBox_Nume.Text = "Player 1";
            // 
            // label_Nume
            // 
            this.label_Nume.AutoSize = true;
            this.label_Nume.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nume.Location = new System.Drawing.Point(49, 20);
            this.label_Nume.Name = "label_Nume";
            this.label_Nume.Size = new System.Drawing.Size(277, 38);
            this.label_Nume.TabIndex = 14;
            this.label_Nume.Text = "Introduceti numele:";
            // 
            // button_Exit
            // 
            this.button_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Exit.BackColor = System.Drawing.Color.IndianRed;
            this.button_Exit.Location = new System.Drawing.Point(695, 5);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 32);
            this.button_Exit.TabIndex = 17;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // Form_Joc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.ControlBox = false;
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.panel_Nume);
            this.Controls.Add(this.label_Win);
            this.Controls.Add(this.button_Undo);
            this.Controls.Add(this.button_EnterCuvant);
            this.Controls.Add(this.label_nr_LitereRamase);
            this.Controls.Add(this.label_LitereRamase);
            this.Controls.Add(this.label_ScorAdversar);
            this.Controls.Add(this.label_ScorJucator);
            this.Controls.Add(this.label_numeAdversar);
            this.Controls.Add(this.label_numeJucator);
            this.Name = "Form_Joc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scrabble-server";
            this.Resize += new System.EventHandler(this.Form_Joc_Resize);
            this.panel_Nume.ResumeLayout(false);
            this.panel_Nume.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_numeJucator;
        private System.Windows.Forms.Label label_numeAdversar;
        private System.Windows.Forms.Label label_ScorJucator;
        private System.Windows.Forms.Label label_ScorAdversar;
        private System.Windows.Forms.Label label_LitereRamase;
        private System.Windows.Forms.Label label_nr_LitereRamase;
        private System.Windows.Forms.Button button_EnterCuvant;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.Label label_Win;
        private System.Windows.Forms.Panel panel_Nume;
        private System.Windows.Forms.TextBox textBox_Nume;
        private System.Windows.Forms.Label label_Nume;
        private System.Windows.Forms.Label label_client_conectat;
        private System.Windows.Forms.Button button_Exit;
    }
}

