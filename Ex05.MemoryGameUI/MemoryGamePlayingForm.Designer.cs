using System;

namespace MemoryGameUI
{
    partial class MemoryGamePlayingForm 
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
            this.currentPlayer_Label = new System.Windows.Forms.Label();
            this.firstPlayerName_Label = new System.Windows.Forms.Label();
            this.secondPlayerName_Label = new System.Windows.Forms.Label();
            this.currentPlayerShowingName_Label = new System.Windows.Forms.Label();
            this.firstPlayerScore_Label = new System.Windows.Forms.Label();
            this.secondPlayerScore_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentPlayer_Label
            // 
            this.currentPlayer_Label.AutoSize = true;
            this.currentPlayer_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.currentPlayer_Label.Location = new System.Drawing.Point(26, 367);
            this.currentPlayer_Label.Name = "currentPlayer_Label";
            this.currentPlayer_Label.Size = new System.Drawing.Size(73, 13);
            this.currentPlayer_Label.TabIndex = 0;
            this.currentPlayer_Label.Text = "CurrentPlayer:";
            // 
            // firstPlayerName_Label
            // 
            this.firstPlayerName_Label.AutoSize = true;
            this.firstPlayerName_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.firstPlayerName_Label.Location = new System.Drawing.Point(26, 389);
            this.firstPlayerName_Label.Name = "firstPlayerName_Label";
            this.firstPlayerName_Label.Size = new System.Drawing.Size(51, 13);
            this.firstPlayerName_Label.TabIndex = 1;
            this.firstPlayerName_Label.Text = "firstName";
            // 
            // secondPlayerName_Label
            // 
            this.secondPlayerName_Label.AutoSize = true;
            this.secondPlayerName_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.secondPlayerName_Label.Location = new System.Drawing.Point(26, 411);
            this.secondPlayerName_Label.Name = "secondPlayerName_Label";
            this.secondPlayerName_Label.Size = new System.Drawing.Size(73, 13);
            this.secondPlayerName_Label.TabIndex = 2;
            this.secondPlayerName_Label.Text = "second Name";
            // 
            // currentPlayerShowingName_Label
            // 
            this.currentPlayerShowingName_Label.AutoSize = true;
            this.currentPlayerShowingName_Label.BackColor = this.firstPlayerName_Label.BackColor;
            this.currentPlayerShowingName_Label.Location = new System.Drawing.Point(114, 367);
            this.currentPlayerShowingName_Label.Name = "currentPlayerShowingName_Label";
            this.currentPlayerShowingName_Label.Size = new System.Drawing.Size(0, 13);
            this.currentPlayerShowingName_Label.TabIndex = 5;
            // 
            // firstPlayerScore_Label
            // 
            this.firstPlayerScore_Label.AutoSize = true;
            this.firstPlayerScore_Label.BackColor = this.firstPlayerName_Label.BackColor;
            this.firstPlayerScore_Label.Location = new System.Drawing.Point(114, 389);
            this.firstPlayerScore_Label.Name = "firstPlayerScore_Label";
            this.firstPlayerScore_Label.Size = new System.Drawing.Size(0, 13);
            this.firstPlayerScore_Label.TabIndex = 4;
            // 
            // secondPlayerScore_Label
            // 
            this.secondPlayerScore_Label.AutoSize = true;
            this.secondPlayerScore_Label.BackColor = this.secondPlayerName_Label.BackColor;
            this.secondPlayerScore_Label.Location = new System.Drawing.Point(114, 411);
            this.secondPlayerScore_Label.Name = "secondPlayerScore_Label";
            this.secondPlayerScore_Label.Size = new System.Drawing.Size(0, 13);
            this.secondPlayerScore_Label.TabIndex = 3;
            // 
            // MemoryGamePlayingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(213, 144);
            this.Controls.Add(this.currentPlayerShowingName_Label);
            this.Controls.Add(this.firstPlayerScore_Label);
            this.Controls.Add(this.secondPlayerScore_Label);
            this.Controls.Add(this.secondPlayerName_Label);
            this.Controls.Add(this.firstPlayerName_Label);
            this.Controls.Add(this.currentPlayer_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MemoryGamePlayingForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 20, 20);
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.Label currentPlayer_Label;
        private System.Windows.Forms.Label firstPlayerName_Label;
        private System.Windows.Forms.Label secondPlayerName_Label;
        private System.Windows.Forms.Label currentPlayerShowingName_Label;
        private System.Windows.Forms.Label firstPlayerScore_Label;
        private System.Windows.Forms.Label secondPlayerScore_Label;
    }
}