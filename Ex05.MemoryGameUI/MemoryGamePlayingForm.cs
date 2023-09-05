using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MemoryGameUI
{
    using MemoryGameLogic;
    using Timer = System.Windows.Forms.Timer;

    public partial class MemoryGamePlayingForm : Form
    {
        private string m_difficulty = string.Empty;
        private int m_choosing = 0;
        private int m_timerCount = 0;
        private Random m_randChoice = new Random();
        private Player m_firstPlayer;
        private Player m_secondPlayer;
        private Player m_currentPlayer;
        private int m_borderRows = 0;
        private int m_borderColls = 0;
        private bool m_firstPickOccured = false;
        private string m_gameSize = string.Empty;
        private Cell m_firstCellPressed;
        private Cell m_secondCellPressed;
        private Cell[] m_gameCells;
        private Timer m_Timer = new Timer();
        private Timer m_PauseTimer = new Timer();
        private List<Cell> m_cellsNotToReturnClicks = new List<Cell>();

        public MemoryGamePlayingForm()
        {
            m_Timer.Interval = 1;
            m_Timer.Tick += new EventHandler(OnTimer_Start);

            m_PauseTimer.Interval = 1;
            m_PauseTimer.Tick += new EventHandler(OnPauseTimer_Start);
            InitializeComponent();
        }

        private void OnPauseTimer_Start(object sender, EventArgs e)
        {
            m_timerCount++;
            if (m_timerCount >= 50)
            {
                m_timerCount = 0;
                m_PauseTimer.Stop();
                if (m_currentPlayer.PlayerName.Equals("- computer -"))
                {
                    computerPickingMethod();
                }
            }
        }

        private void OnTimer_Start(object sender, EventArgs e)
        {
            cancelAllClick();
            m_timerCount++;
            if (m_timerCount >= 100)
            {
                m_firstCellPressed.HideCell();
                m_secondCellPressed.HideCell();
                m_timerCount = 0;
                returnClicks();
                changePlayerAndLabels();
                m_Timer.Stop();
                if (m_currentPlayer.PlayerName.Equals("- computer -"))
                {
                    computerPickingMethod();
                }
            }
        }

        private void cancelAllClick()
        {
            foreach (Cell cell in m_gameCells)
            {
                cell.Click -= new EventHandler(OnCell_Click);
            }
        }

        private void returnClicks()
        {
            foreach (Cell cell in m_gameCells)
            {
                if (!m_cellsNotToReturnClicks.Contains(cell))
                {
                    cell.Click += new EventHandler(OnCell_Click);
                }
            }
        }

        public void InitiateMemoryGame(string i_firstPName, string i_secondPName, string i_gameSize, string i_difficulty)
        {
            m_difficulty = i_difficulty;
            Text = string.Format("Memory Game - {0}", this.m_difficulty);
            this.m_firstPlayer = new Player(i_firstPName);
            this.m_secondPlayer = new Player(i_secondPName);
            if (i_secondPName.Equals("- computer -"))
            {
                m_secondPlayer = new Computer();
            }

            m_gameSize = i_gameSize;
            firstPlayerName_Label.Text = string.Format("{0}:", m_firstPlayer.PlayerName);
            currentPlayerShowingName_Label.Text = m_firstPlayer.PlayerName;
            secondPlayerName_Label.Text = string.Format("{0}:", m_secondPlayer.PlayerName);
            firstPlayerScore_Label.Text = string.Format("{0} Pairs", m_firstPlayer.Score);
            secondPlayerScore_Label.Text = string.Format("{0} Pairs", m_secondPlayer.Score);
            m_currentPlayer = m_firstPlayer;
            char rows = i_gameSize[0];
            char colls = i_gameSize[i_gameSize.Length - 1];
            m_borderRows = int.Parse(rows.ToString());
            m_borderColls = int.Parse(colls.ToString());
            m_gameCells = new Cell[m_borderRows * m_borderColls];
            tableCreation(m_gameCells);
            this.ShowDialog();
        }

        private void tableCreation(Cell[] i_gameCells)
        {
            string imagePath;
            imagePath = Directory.GetCurrentDirectory();
            int counter = 0;
            string cellName = "A";
            for (int i = 0; i < m_borderRows; i++)
            {
                for (int j = 0; j < m_borderColls; j++)
                {
                    Cell button = new Cell(string.Format("{0}{1}", i + cellName, j.ToString()));
                    button.Size = new System.Drawing.Size(70, 70);
                    button.Location = new System.Drawing.Point((20 * (i + 1)) + (i * 60), (20 * (j + 1)) + (j * 60));
                    button.HideCell();
                    button.Click += new EventHandler(this.OnCell_Click);
                    if (this.m_secondPlayer is Computer)
                    {
                        (this.m_secondPlayer as Computer).OpenedCells.Add(button);
                    }

                    this.Controls.Add(button);
                    i_gameCells[counter] = button;
                    counter++;
                }
            }

            currentPlayer_Label.Top = m_gameCells.Last().Top + 70 + 20;
            firstPlayerName_Label.Top = currentPlayer_Label.Top + 20;
            secondPlayerName_Label.Top = firstPlayerName_Label.Top + 20;
            currentPlayerShowingName_Label.Top = currentPlayer_Label.Top;
            firstPlayerScore_Label.Top = firstPlayerName_Label.Top;
            secondPlayerScore_Label.Top = secondPlayerName_Label.Top;
            this.Height = secondPlayerScore_Label.Top + secondPlayerScore_Label.Height + 20;
            assisgnRandomPicturesForTheGame();
        }

        private void OnCell_Click(object sender, EventArgs e)
        {
            Cell thisSender = sender as Cell;
            thisSender.ExposeCell();

            if (!m_firstPickOccured)
            {
                pickAssignment(ref m_firstCellPressed, ref m_firstPickOccured, thisSender);
                m_firstCellPressed.Click -= new EventHandler(OnCell_Click);
                if (m_currentPlayer.PlayerName.Equals("- computer -"))
                {
                    m_PauseTimer.Start();
                }

                return;
            }
            else
            {
                pickAssignment(ref m_secondCellPressed, ref m_firstPickOccured, thisSender);
                checkBothInputs(m_firstCellPressed, m_secondCellPressed);
            }
        }

        private void pickAssignment(ref Cell io_pressedCell, ref bool io_firstPickOccured, Cell io_thisSender)
        {
            io_firstPickOccured = !io_firstPickOccured;
            io_pressedCell = null;
            io_pressedCell = io_thisSender;
        }

        private void checkBothInputs(Cell io_firstCellPressed, Cell io_secondCellPressed)
        {
            if (io_firstCellPressed.CheckCellsImageIsSimilar(io_secondCellPressed))
            {
                io_firstCellPressed.FlatAppearance.BorderColor = currentPlayerShowingName_Label.BackColor;
                io_firstCellPressed.FlatAppearance.BorderSize = 6;
                io_secondCellPressed.FlatAppearance.BorderColor = currentPlayerShowingName_Label.BackColor;
                io_secondCellPressed.FlatAppearance.BorderSize = 6;
                io_secondCellPressed.Click -= new EventHandler(OnCell_Click);
                m_cellsNotToReturnClicks.Add(io_firstCellPressed);
                m_cellsNotToReturnClicks.Add(io_secondCellPressed);
                if (m_secondPlayer is Computer)
                {
                    (m_secondPlayer as Computer).OpenedCells.Remove(io_firstCellPressed);
                    (m_secondPlayer as Computer).OpenedCells.Remove(io_secondCellPressed);
                }

                IPlayer.CheckPlayerToIncrementScore(m_currentPlayer, m_firstPlayer, m_secondPlayer);
                firstPlayerScore_Label.Text = string.Format("{0} Pairs", m_firstPlayer.Score);
                secondPlayerScore_Label.Text = string.Format("{0} Pairs", m_secondPlayer.Score);
                if (m_firstPlayer.Score + m_secondPlayer.Score == (m_borderColls * m_borderRows) / 2)
                {
                    endGameDialog(m_firstPlayer, m_secondPlayer, m_gameSize);
                    return;
                }

                if (m_currentPlayer.PlayerName.Equals("- computer -"))
                {
                    m_PauseTimer.Start();
                    return;
                }
            }
            else
            {
                if (m_difficulty.Equals("Hard"))
                {
                    if (!(m_secondPlayer as Computer).MemoryOfCells.Contains(io_firstCellPressed))
                    {
                        (m_secondPlayer as Computer).AddToMemory = io_firstCellPressed;
                    }

                    if (!(m_secondPlayer as Computer).MemoryOfCells.Contains(io_secondCellPressed))
                    {
                        (m_secondPlayer as Computer).AddToMemory = io_secondCellPressed;
                    }
                }

                m_Timer.Start();
                cancelAllClick();
                return;
            }
        }

        private void changePlayerAndLabels()
        {
            IPlayer.SwitchCurrentPlayer(ref m_currentPlayer, m_firstPlayer, m_secondPlayer);
            currentPlayerShowingName_Label.Text = m_currentPlayer.PlayerName;
            currentPlayer_Label.BackColor = m_currentPlayer.PlayerName.Equals(m_firstPlayer.PlayerName) ? firstPlayerName_Label.BackColor : secondPlayerName_Label.BackColor;
            currentPlayerShowingName_Label.BackColor = currentPlayer_Label.BackColor;
        }

        private void endGameDialog(Player i_firstPlayer, Player i_secondPlayer, string i_gameBorderSize)
        {
            string title = "Game Over";
            string message = string.Empty;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            Player winner;
            winner = i_firstPlayer.Score > i_secondPlayer.Score ? i_firstPlayer : i_secondPlayer;
            if (i_firstPlayer.Score.Equals(i_secondPlayer.Score))
            {
                message = string.Format("The Game Has Ended With A TIE!{0}Would you like to play again?", Environment.NewLine);
            }
            else
            {
                message = string.Format("The Winner is {0} With {1} Points{2}Would you like to play again?", winner.PlayerName, winner.Score, Environment.NewLine);
            }

            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                // StartNewGame();
                this.Hide();
                MemoryGameEntranceForm form = new MemoryGameEntranceForm();
                form.Restart_The_Game(i_firstPlayer, i_secondPlayer, i_gameBorderSize, m_difficulty);
            }
            else
            {
                this.Close();
            }
        }

        private void assisgnRandomPicturesForTheGame()
        {
            int counter = 0;
            int size = (this.m_borderRows * m_borderColls) / 2;
            int[] symbolCountingArray = new int[size];
            Random rand = new Random();
            for (int i = 0; i < this.m_borderRows; i++)
            {
                for (int j = 0; j < this.m_borderColls; j++)
                {
                    int randomDigit = rand.Next('A', 'A' + size);
                    while (symbolCountingArray[randomDigit % 'A'] >= 2)
                    {
                        randomDigit = rand.Next('A', 'A' + size);
                    }

                    this.m_gameCells[counter].Tag = (char)randomDigit;
                    symbolCountingArray[randomDigit % 'A']++;
                    counter++;
                }
            }
        }

        private void computerPickingMethod()
        {
            Cell buttonClick = null;
            m_choosing = m_randChoice.Next(0, (m_secondPlayer as Computer).OpenedCells.Count());
            if (m_firstPickOccured && !m_difficulty.Equals("Very Easy"))
            {
                foreach (Cell item in (m_secondPlayer as Computer).MemoryOfCells)
                {
                    if (m_firstCellPressed.CheckCellsImageIsSimilar(item))
                    {
                        buttonClick = item;
                        (m_secondPlayer as Computer).AddToMemory = buttonClick;
                        buttonClick.PerformClick();
                        return;
                    }
                }
            }

            while (!m_firstCellPressed.CheckIfNotSameCell((m_secondPlayer as Computer).OpenedCells[m_choosing]))
            {
                m_choosing = m_randChoice.Next(0, (m_secondPlayer as Computer).OpenedCells.Count());
            }

            buttonClick = (m_secondPlayer as Computer).OpenedCells[m_choosing];
            if (!(m_secondPlayer as Computer).MemoryOfCells.Contains(buttonClick))
            {
                (m_secondPlayer as Computer).AddToMemory = buttonClick;
            }

            buttonClick.PerformClick();
        }
    }
}
