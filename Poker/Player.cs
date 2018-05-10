using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Player
    {
        public int id { get; set; }
        public String name { get; set; }
        public int cash { get; set; }
        public int[] hand { get; set; }
        public String currentBet { get; set; }

        public Player()
        {
            id = 0;
            name = "";
            cash = 0;
            hand = new int[7];
            currentBet = "";
        }

        public Player(int id,  String name, int cash, int[] hand, String currentBet)
        {
            this.id = id;
            this.name = name;
            this.cash = cash;
            this.hand = hand;
            this.currentBet = currentBet;
        }
    }
}
