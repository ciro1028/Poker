using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Player
    {
        public int id { get; set; }
        public String name { get; set; }
        public String cash { get; set; }
        public int[] hand { get; set; }
        public Boolean active { get; set; }
        public String currentBet { get; set; }
        public String currentNumberStrenght { get; set; }

        public Player()
        {
            id = 0;
            name = "";
            cash = "";
            hand = new int[7];
            active = false;
            currentBet = "";
            currentNumberStrenght = "";
        }

        public Player(int id,  String name, String cash, int[] hand, Boolean active, String currentBet, String currentNumberStrenght)
        {
            this.id = id;
            this.name = name;
            this.cash = cash;
            this.hand = hand;
            this.active = active;
            this.currentBet = currentBet;
            this.currentNumberStrenght = currentNumberStrenght;
        }
    }
}
