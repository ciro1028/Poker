using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Hands
    {
        public int[] hand { get; set; }

        public Hands()
        {
            hand = new int[] { 0, 0, 0, 0, 0, 0, 0 };
        }

        public Hands(int[] hand)
        {
            this.hand = hand;
        }

        List<int> pairs = new List<int>();
        List<int> pairs2 = new List<int>();
        int[] handNumbers = new int[] { 0, 0, 0, 0, 0, 0, 0 };
        String[] handSuits = new String[] { "", "", "", "", "", "", "" };

        //check hand that is sent from method checkHands() on Form1 
        public String checkHand(int[] handToCheck)
        {
            foreach(int card in handToCheck){
                Console.WriteLine("Hand to check: " + card);
            }

            String handString = "";
            Boolean isFlush = false;
            Boolean isStraight = false;
            String isPair = "";

            isFlush = checkForFlush(handToCheck);

            isStraight = checkForStraight(handToCheck);

            //isPair = checkForPairs(handToCheck);

            //Array.Sort<int>(transformedHand, new Comparison<int>(
                                    //(i1, i2) => i2.CompareTo(i1)
                                      //));

            // setting string that is going to be sent to Form1 with the resulted hand
            if (isFlush && isStraight)
            {
                handString = "Straight Flush";
            } else if (isFlush)
            {
                handString = "Flush";
            } else if (isStraight)
            {
                handString = "Straight";
            } else
            {
                handString = isPair;
            }

            foreach (int card in handToCheck)
            {
                Console.WriteLine("Hand checked: " + card);
            }

            return handString;
        }

        public Boolean checkForStraight(int[] checkStraightHand)
        {
            int[] transformedHand = new int[] { };
            transformedHand = transformHands(checkStraightHand);

            Boolean isStraight = false;
            int count = 0;

            Array.Sort(checkStraightHand);

            for(int i = 0; i < checkStraightHand.Length - 1; i++)
            {
                if ((checkStraightHand[i + 1] - checkStraightHand[i]) == 1)
                {
                    count++;
                } else if (count < 4)
                {
                    count = 0;
                }
            }

            if (count >= 4)
            {
                isStraight = true;
            }

            return isStraight;
        }

        // Transforms numbers between 1 and 52 into numbers relative to suits
        // Anything less than 14 stays the same
        // between 26 and 40 subtracts 13 and so on...
        // to have a deck (1..13, 1..13, 1..13, 1..13) (spades, clubs, dimaonds, hearts)
        public int[] transformHands(int[] hand)
        {
            handNumbers = hand;
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i] < 14)
                {
                    handNumbers[i] = hand[i];
                }
                if (hand[i] < 27 && hand[i] > 13)
                {
                    int current = hand[i] - 13;
                    handNumbers[i] = current;
                }
                if (hand[i] > 26 && hand[i] < 40)
                {
                    int current = hand[i] - 26;
                    handNumbers[i] = current;
                }
                if (hand[i] > 39)
                {
                    int current = hand[i] - 39;
                    handNumbers[i] = current;
                }
            }
            return handNumbers;
        }

        // Transforms numbers into suits
        // Anything less than 14 = spades, between 13 and 27 = clubs,
        // between 26 and 40 = diamonds, and 39 and higher = hearts.
        public String[] transformHandsSuits(int[] hand)
        {
            handNumbers = hand;
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i] < 14)
                {
                    handSuits[i] = "spades";
                }
                if (hand[i] < 27 && hand[i] > 13)
                {
                    handSuits[i] = "clubs";
                }
                if (hand[i] > 26 && hand[i] < 40)
                {
                    handSuits[i] = "diamonds";
                }
                if (hand[i] > 39)
                {
                    handSuits[i] = "hearts";
                }
            }
            return handSuits;
        }

        public Boolean checkForFlush(int[] checkFlushHand)
        {
            String[] transformedHandSuits = new String[] { };
            transformedHandSuits = transformHandsSuits(checkFlushHand);

            Boolean flush;
            flush = false;
           
            for (int i = 0; i < 3; i++)
            {
                int count = 0;
                for (int j = 0; j < checkFlushHand.Length; j++)
                {
                    if (i != j)
                    {
                        if (checkFlushHand[i] == checkFlushHand[j])
                        {
                            count++;
                        }
                    }
                }
                if (count >= 4)
                {
                    flush = true;
                }
            }
            
            return flush;
        }

        public String checkForPairs(int[] handNumbers)
        {
            int count = 0;
            int count2 = 0;
            Object[] handInfo = new Object[2];
            String pairsString = "";
            int[] finalHand = new int[5];
            pairs.Clear();
            pairs2.Clear();

            for (int i = 0; i < 7; i++)
            {
                for (int j = i; j < 7; j++)
                {
                    if (i != j)
                    {
                        if (handNumbers[i] == handNumbers[j] && handNumbers[i] != 0)
                        {
                            count++;
                            pairs.Add(handNumbers[i]);
                            pairs2.Add(handNumbers[i]);
                            handNumbers[j] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < pairs2.Count; i++)
            {
                for (int j = i; j < pairs2.Count; j++)
                {
                    if (i != j)
                    {
                        if (pairs2[i] == pairs2[j])
                        {
                            count2++;
                        }
                    }
                }
            }

            for (int i = 0; i < pairs.Count; i++)
            {
                for (int j = i; j < pairs.Count; j++)
                {
                    if (i != j)
                    {
                        if (pairs[i] == pairs[j])
                        {
                            pairs[j] = 0;
                        }
                    }
                }
                pairs.Remove(0);
            }

            if (pairs.Count == 2 && count == 2 || pairs.Count == 3 && count == 3)
            {
                pairsString = "Two Pairs";
            }
            else if (pairs.Count == 1 && count == 1)
            {
                pairsString = "One Pair";
            }
            else if (pairs.Count == 1 && count == 2)
            {
                pairsString = "Three of a kind";
            }
            else if (pairs.Count > 1 && count == 3 || count2 == 2 || pairs.Count == 3 && count == 4)
            {
                pairsString = "Full house";
            }
            else if (pairs.Count >= 1 && count >= 3 && count2 == 3)
            {
                pairsString = "Four of a kind";

            } else if (pairs.Count == 0) {
                pairsString = "High Card";
            }

            return pairsString;
        }

        public void resetHand()
        {
            for(int i = 0; i < hand.Length; i++)
            {
                hand[i] = 0;
            }
        }
    }
}
