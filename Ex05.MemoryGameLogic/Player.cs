namespace MemoryGameLogic
{
    public class Player
    {
        private string m_PlayerName = string.Empty;
        private int m_score = 0;

        public Player(string m_ThePlayerName)
        {
            PlayerName = m_ThePlayerName;
        }
        public Player(Player io_copyConstructurPlayer)
        {
            this.PlayerName = io_copyConstructurPlayer.PlayerName;
            this.Score = io_copyConstructurPlayer.Score;
        }
        public int Score
        {
            get { return m_score; }
            set { m_score += value; }
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }
    }
}
