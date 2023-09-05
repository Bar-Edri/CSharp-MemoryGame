using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGameLogic
{
    public class IPlayer
    {
        public static void SwitchCurrentPlayer(ref Player io_currPlayer,Player i_firstPlayer,Player i_secondPlayer)
        {
            if (io_currPlayer.PlayerName.Equals(i_firstPlayer.PlayerName))
            {
                io_currPlayer = new Player(i_secondPlayer);
                
            }
            else
            {
                io_currPlayer = new Player(i_firstPlayer);
            }
        }
        public static void CheckPlayerToIncrementScore(Player io_currPlayer, Player i_firstPlayer, Player i_secondPlayer)
        {
            if (io_currPlayer.PlayerName.Equals(i_firstPlayer.PlayerName))
            {
                i_firstPlayer.Score=1;

            }
            else
            {
                i_secondPlayer.Score = 1;
            }
        }
        public static void UpdateScore(Player i_Player)
        {
            i_Player.Score+=1;
        }
    }
}
