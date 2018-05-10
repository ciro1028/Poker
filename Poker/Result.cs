using System;

namespace Poker
{
    public class Result
    {
        public Player player { get; set; }
        public String handType { get; set; }
        public int handStrenght { get; set; }
        public int[] finalCards { get; set; }
        public int[] finalHand { get; set; }
        public int[] pairs { get; set; }

        public Result()
        {
            player = new Player();
            handType = "";
            handStrenght = 0;
            finalCards = new int[6];
            finalHand = new int[4];
            pairs = new int[2];
        }

        public Result(Player player, int[] finalCards, String handType, int handStrenght, int[] finalHand, int[] pairs){
            this.player = player;
            this.handType = handType;
            this.handStrenght = handStrenght;
            this.finalCards = finalCards;
            this.finalHand = finalHand;
            this.pairs = pairs;
        }
    }
}
