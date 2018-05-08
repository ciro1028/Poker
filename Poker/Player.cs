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
        public String cash { get; set; }
        public int[] hand { get; set; }
        public Boolean active { get; set; }
        public String currentBet { get; set; }
        public String currentHand { get; set; }
        public int currentNumberStrenght { get; set; }
        public int[] finalHand { get; set; }

        public Player()
        {
            id = 0;
            name = "";
            cash = "";
            hand = new int[7];
            active = false;
            currentBet = "";
            currentHand = "";
            currentNumberStrenght = 0;
            finalHand = new int[5];
        }

        public Player(int id,  String name, String cash, int[] hand, Boolean active, String currentBet, String currentHand, int currentNumberStrenght, int[] finalHand)
        {
            this.id = id;
            this.name = name;
            this.cash = cash;
            this.hand = hand;
            this.active = active;
            this.currentBet = currentBet;
            this.currentHand = currentHand;
            this.currentNumberStrenght = currentNumberStrenght;
            this.finalHand = finalHand;
        }
    }
}
