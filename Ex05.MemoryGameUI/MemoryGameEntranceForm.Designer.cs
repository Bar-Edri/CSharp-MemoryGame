using System;

namespace MemoryGameUI
{
    partial class MemoryGameEntranceForm
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
            this.start_Btn = new System.Windows.Forms.Button();
            this.opponent_btn = new System.Windows.Forms.Button();
            this.firstPersonName_Textbox = new System.Windows.Forms.TextBox();
            this.secondPersonName_Textbox = new System.Windows.Forms.TextBox();
            this.firstPersonName_Label = new System.Windows.Forms.Label();
            this.secondPersonName_Label = new System.Windows.Forms.Label();
            this.borderSize_Label = new System.Windows.Forms.Label();
            this.borderSize_Btn = new System.Windows.Forms.Button();
            this.ComputerDifficulty = new System.Windows.Forms.ComboBox();
            this.DifficulyChoicesExplanationBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // start_Btn
            // 
            this.start_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.start_Btn.Location = new System.Drawing.Point(280, 148);
            this.start_Btn.Name = "start_Btn";
            this.start_Btn.Size = new System.Drawing.Size(75, 23);
            this.start_Btn.TabIndex = 0;
            this.start_Btn.Text = "Start!";
            this.start_Btn.UseVisualStyleBackColor = false;
            this.start_Btn.Click += new System.EventHandler(this.OnStart_Btn_Click);
            // 
            // opponent_btn
            // 
            this.opponent_btn.AutoSize = true;
            this.opponent_btn.Location = new System.Drawing.Point(241, 36);
            this.opponent_btn.Name = "opponent_btn";
            this.opponent_btn.Size = new System.Drawing.Size(114, 25);
            this.opponent_btn.TabIndex = 1;
            this.opponent_btn.Text = "Againts a Friend";
            this.opponent_btn.UseVisualStyleBackColor = true;
            this.opponent_btn.Click += new System.EventHandler(this.OnOpponent_Btn_Click);
            // 
            // firstPersonName_Textbox
            // 
            this.firstPersonName_Textbox.Location = new System.Drawing.Point(132, 11);
            this.firstPersonName_Textbox.Name = "firstPersonName_Textbox";
            this.firstPersonName_Textbox.Size = new System.Drawing.Size(100, 20);
            this.firstPersonName_Textbox.TabIndex = 2;
            // 
            // secondPersonName_Textbox
            // 
            this.secondPersonName_Textbox.Enabled = false;
            this.secondPersonName_Textbox.Location = new System.Drawing.Point(132, 37);
            this.secondPersonName_Textbox.Name = "secondPersonName_Textbox";
            this.secondPersonName_Textbox.Size = new System.Drawing.Size(100, 20);
            this.secondPersonName_Textbox.TabIndex = 3;
            this.secondPersonName_Textbox.Text = "- computer -";
            // 
            // firstPersonName_Label
            // 
            this.firstPersonName_Label.AutoSize = true;
            this.firstPersonName_Label.Location = new System.Drawing.Point(9, 14);
            this.firstPersonName_Label.Name = "firstPersonName_Label";
            this.firstPersonName_Label.Size = new System.Drawing.Size(92, 13);
            this.firstPersonName_Label.TabIndex = 4;
            this.firstPersonName_Label.Text = "First Player Name:";
            // 
            // secondPersonName_Label
            // 
            this.secondPersonName_Label.AutoSize = true;
            this.secondPersonName_Label.Location = new System.Drawing.Point(9, 42);
            this.secondPersonName_Label.Name = "secondPersonName_Label";
            this.secondPersonName_Label.Size = new System.Drawing.Size(110, 13);
            this.secondPersonName_Label.TabIndex = 5;
            this.secondPersonName_Label.Text = "Second Player Name:";
            // 
            // borderSize_Label
            // 
            this.borderSize_Label.AutoSize = true;
            this.borderSize_Label.Location = new System.Drawing.Point(9, 79);
            this.borderSize_Label.Name = "borderSize_Label";
            this.borderSize_Label.Size = new System.Drawing.Size(64, 13);
            this.borderSize_Label.TabIndex = 6;
            this.borderSize_Label.Text = "Border Size:";
            // 
            // borderSize_Btn
            // 
            this.borderSize_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.borderSize_Btn.Location = new System.Drawing.Point(12, 105);
            this.borderSize_Btn.Name = "borderSize_Btn";
            this.borderSize_Btn.Size = new System.Drawing.Size(107, 66);
            this.borderSize_Btn.TabIndex = 7;
            this.borderSize_Btn.Text = "4 x 4";
            this.borderSize_Btn.UseVisualStyleBackColor = false;
            this.borderSize_Btn.Click += new System.EventHandler(this.OnBorderSize_Btn_Click);
            // 
            // ComputerDifficulty
            // 
            this.ComputerDifficulty.FormattingEnabled = true;
            this.ComputerDifficulty.Items.AddRange(new object[] {
            "Very Easy",
            "Easy",
            "Hard"});
            this.ComputerDifficulty.Location = new System.Drawing.Point(282, 93);
            this.ComputerDifficulty.Name = "ComputerDifficulty";
            this.ComputerDifficulty.Size = new System.Drawing.Size(77, 21);
            this.ComputerDifficulty.TabIndex = 9;
            this.ComputerDifficulty.Text = "Very Easy";
            // 
            // DifficulyChoicesExplanationBox
            // 
            this.DifficulyChoicesExplanationBox.Location = new System.Drawing.Point(125, 93);
            this.DifficulyChoicesExplanationBox.Name = "richTextBox1";
            this.DifficulyChoicesExplanationBox.ReadOnly = true;
            this.DifficulyChoicesExplanationBox.Size = new System.Drawing.Size(151, 62);
            this.DifficulyChoicesExplanationBox.TabIndex = 10;
            this.DifficulyChoicesExplanationBox.Text = "Very Easy - No AI\nEasy - Remembers AI picking\nHard - Remembers everything";
            // 
            // MemoryGameEntranceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 180);
            this.Controls.Add(this.DifficulyChoicesExplanationBox);
            this.Controls.Add(this.ComputerDifficulty);
            this.Controls.Add(this.borderSize_Btn);
            this.Controls.Add(this.borderSize_Label);
            this.Controls.Add(this.secondPersonName_Label);
            this.Controls.Add(this.firstPersonName_Label);
            this.Controls.Add(this.secondPersonName_Textbox);
            this.Controls.Add(this.firstPersonName_Textbox);
            this.Controls.Add(this.opponent_btn);
            this.Controls.Add(this.start_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MemoryGameEntranceForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_Btn;
        private System.Windows.Forms.Button opponent_btn;
        private System.Windows.Forms.TextBox firstPersonName_Textbox;
        private System.Windows.Forms.TextBox secondPersonName_Textbox;
        private System.Windows.Forms.Label firstPersonName_Label;
        private System.Windows.Forms.Label secondPersonName_Label;
        private System.Windows.Forms.Label borderSize_Label;
        private System.Windows.Forms.Button borderSize_Btn;
        private System.Windows.Forms.ComboBox ComputerDifficulty;
        private System.Windows.Forms.RichTextBox DifficulyChoicesExplanationBox;
    }
}