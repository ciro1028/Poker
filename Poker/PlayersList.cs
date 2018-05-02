using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class PlayersList
    {
        public List<Player> listOfPlayers { get; set; }

        public PlayersList()
        {
            listOfPlayers = new List<Player>();
        }

        public PlayersList(List<Player> listOfPlayers)
        {
            this.listOfPlayers = listOfPlayers;
        }
    }
}
