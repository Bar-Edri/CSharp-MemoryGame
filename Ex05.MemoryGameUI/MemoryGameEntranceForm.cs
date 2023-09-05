namespace MemoryGameUI
{
    using System;
    using System.Windows.Forms;
    using MemoryGameLogic;

    public partial class MemoryGameEntranceForm : Form
    {
        private bool m_flagForSwitchtext = false;
        private string[] m_bordersSizes = { "4 x 4", "4 x 5", "4 x 6", "5 x 4", "5 x 6", "6 x 4", "6 x 5", "6 x 6" };
        private int m_intForBorderSizes = 0;
        private MemoryGamePlayingForm m_gameForm = new MemoryGamePlayingForm();

        public MemoryGameEntranceForm()
        {
            InitializeComponent();
            m_gameForm.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            borderSize_Btn.Text = m_bordersSizes[0];
        }

        private void OnOpponent_Btn_Click(object sender, EventArgs e)
        {
            opponent_btn.Text = m_flagForSwitchtext.Equals(true) ? "Against a Player" : "Against a Computer";
            ComputerDifficulty.Enabled = opponent_btn.Text.Equals("Against a Player") ? true : false;
            secondPersonName_Textbox.Enabled = !m_flagForSwitchtext;
            secondPersonName_Textbox.Text = m_flagForSwitchtext == true ? "- computer -" : string.Empty;
            m_flagForSwitchtext = !m_flagForSwitchtext;
        }

        private void OnBorderSize_Btn_Click(object sender, EventArgs e)
        {
            m_intForBorderSizes++;
            borderSize_Btn.Text = m_bordersSizes[m_intForBorderSizes % 8];
        }

        public void OnStart_Btn_Click(object sender, EventArgs e)
        {
            if (firstPersonName_Textbox.Text.Equals(string.Empty) || secondPersonName_Textbox.Text.Equals(string.Empty))
            {
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                string message = "Player Names cannot be blank";
                string title = "Error no names input";
                DialogResult result = MessageBox.Show(message, title, buttons);
            }
            else if (firstPersonName_Textbox.Text.Equals(secondPersonName_Textbox.Text))
            {
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                string message = "Player Names have the same name";
                string title = "Error same name input";
                DialogResult result = MessageBox.Show(message, title, buttons);
            }
            else
            {
                this.Hide();
                m_gameForm.InitiateMemoryGame(firstPersonName_Textbox.Text, secondPersonName_Textbox.Text, borderSize_Btn.Text, ComputerDifficulty.Text);
            }
        }

        public void Restart_The_Game(Player i_firstPlayer, Player i_secondPlayer, string i_sizeOfBorder, string i_difficulty)
        {
            m_gameForm.InitiateMemoryGame(i_firstPlayer.PlayerName, i_secondPlayer.PlayerName, i_sizeOfBorder, i_difficulty);
        }
    }
}
