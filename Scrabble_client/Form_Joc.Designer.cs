namespace Scrabble_v4_client
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
            this.button_Undo = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textBox_Adresa = new System.Windows.Forms.TextBox();
            this.label_Win = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label_IP = new System.Windows.Forms.Label();
            this.label_Nume = new System.Windows.Forms.Label();
            this.panel_Nume = new System.Windows.Forms.Panel();
            this.textBox_Nume = new System.Windows.Forms.TextBox();
            this.label_waiting = new System.Windows.Forms.Label();
            this.panel_Nume.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_numeJucator
            // 
            this.label_numeJucator.AutoSize = true;
            this.label_numeJucator.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numeJucator.Location = new System.Drawing.Point(0, 37);
            this.label_numeJucator.Name = "label_numeJucator";
            this.label_numeJucator.Size = new System.Drawing.Size(175, 38);
            this.label_numeJucator.TabIndex = 0;
            this.label_numeJucator.Text = "Player2(you)";
            // 
            // label_numeAdversar
            // 
            this.label_numeAdversar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_numeAdversar.AutoSize = true;
            this.label_numeAdversar.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numeAdversar.Location = new System.Drawing.Point(539, 37);
            this.label_numeAdversar.Name = "label_numeAdversar";
            this.label_numeAdversar.Size = new System.Drawing.Size(105, 38);
            this.label_numeAdversar.TabIndex = 1;
            this.label_numeAdversar.Text = "Player1";
            this.label_numeAdversar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_ScorJucator
            // 
            this.label_ScorJucator.AutoSize = true;
            this.label_ScorJucator.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ScorJucator.Location = new System.Drawing.Point(1, 75);
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
            this.label_ScorAdversar.Location = new System.Drawing.Point(540, 75);
            this.label_ScorAdversar.Name = "label_ScorAdversar";
            this.label_ScorAdversar.Size = new System.Drawing.Size(104, 38);
            this.label_ScorAdversar.TabIndex = 3;
            this.label_ScorAdversar.Text = "Scor: 0";
            // 
            // label_LitereRamase
            // 
            this.label_LitereRamase.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_LitereRamase.AutoSize = true;
            this.label_LitereRamase.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LitereRamase.Location = new System.Drawing.Point(0, 148);
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
            this.label_nr_LitereRamase.Location = new System.Drawing.Point(5, 216);
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
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(252, 197);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(108, 49);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // textBox_Adresa
            // 
            this.textBox_Adresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Adresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Adresa.Location = new System.Drawing.Point(94, 160);
            this.textBox_Adresa.Name = "textBox_Adresa";
            this.textBox_Adresa.Size = new System.Drawing.Size(131, 34);
            this.textBox_Adresa.TabIndex = 10;
            this.textBox_Adresa.Text = "127.0.0.1";
            // 
            // label_Win
            // 
            this.label_Win.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Win.AutoSize = true;
            this.label_Win.BackColor = System.Drawing.Color.Silver;
            this.label_Win.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Win.Location = new System.Drawing.Point(235, 3);
            this.label_Win.Name = "label_Win";
            this.label_Win.Size = new System.Drawing.Size(143, 32);
            this.label_Win.TabIndex = 11;
            this.label_Win.Text = "label_win";
            this.label_Win.Visible = false;
            // 
            // button_Exit
            // 
            this.button_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Exit.BackColor = System.Drawing.Color.IndianRed;
            this.button_Exit.Location = new System.Drawing.Point(701, 3);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 32);
            this.button_Exit.TabIndex = 12;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label_IP
            // 
            this.label_IP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_IP.AutoSize = true;
            this.label_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IP.Location = new System.Drawing.Point(47, 163);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(41, 29);
            this.label_IP.TabIndex = 13;
            this.label_IP.Text = "IP:";
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
            // panel_Nume
            // 
            this.panel_Nume.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel_Nume.Controls.Add(this.textBox_Nume);
            this.panel_Nume.Controls.Add(this.label_IP);
            this.panel_Nume.Controls.Add(this.label_Nume);
            this.panel_Nume.Controls.Add(this.textBox_Adresa);
            this.panel_Nume.Controls.Add(this.btnConnect);
            this.panel_Nume.Location = new System.Drawing.Point(185, 196);
            this.panel_Nume.Name = "panel_Nume";
            this.panel_Nume.Size = new System.Drawing.Size(377, 266);
            this.panel_Nume.TabIndex = 15;
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
            this.textBox_Nume.Text = "Player 2";
            // 
            // label_waiting
            // 
            this.label_waiting.AutoSize = true;
            this.label_waiting.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_waiting.Location = new System.Drawing.Point(114, 465);
            this.label_waiting.Name = "label_waiting";
            this.label_waiting.Size = new System.Drawing.Size(490, 38);
            this.label_waiting.TabIndex = 16;
            this.label_waiting.Text = "Astept ca serverul sa inceapa jocul...";
            this.label_waiting.Visible = false;
            // 
            // Form_Joc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.ControlBox = false;
            this.Controls.Add(this.label_waiting);
            this.Controls.Add(this.panel_Nume);
            this.Controls.Add(this.button_Exit);
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
            this.Text = "Scrabble-client";
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
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textBox_Adresa;
        private System.Windows.Forms.Label label_Win;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label label_Nume;
        private System.Windows.Forms.Panel panel_Nume;
        private System.Windows.Forms.TextBox textBox_Nume;
        private System.Windows.Forms.Label label_waiting;
    }
}

