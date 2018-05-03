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
        Boolean isRoyal = false;


        //check hand that is sent from method checkHands() on Form1 
        public String[] checkHand(int[] handToCheck)
        {
            String handString = "";
            Boolean isFlush = false;
            Boolean isStraight = false;
            String isPair = "";
            String[] handInfo = new String[7];

            isFlush = checkForFlush(handToCheck);

            isStraight = checkForStraight(handToCheck);

            int[] isPairHand = new int[5];

            handInfo = checkForPairs(handToCheck);

            // setting string that is going to be sent to Form1 with the resulted hand
            if (isFlush && isStraight && isRoyal){
                handString = "Royal Flush";
            } else if (isFlush && isStraight)
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
            isRoyal = false;

            handInfo[6] = getHandNumberStrenght(handString);

            return handInfo;
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

        // transform the hand into a number to compare the strenght of it later
        public String getHandNumberStrenght(String hand){
            String handNumberStrenght = "";
            switch (hand) {
                case "High Card":
                    handNumberStrenght = "10";
                    break;
                case "One Pair":
                    handNumberStrenght = "9";
                    break;
                case "Two Pairs":
                    handNumberStrenght = "8";
                    break;
                case "Three of a Kind":
                    handNumberStrenght = "7";
                    break;
                case "Straight":
                    handNumberStrenght = "6";
                    break;
                case "Flush":
                    handNumberStrenght = "5";
                    break;
                case "Full House":
                    handNumberStrenght = "4";
                    break;
                case "Fout of a Kind":
                    handNumberStrenght = "3";
                    break;
                case "Straight Flush":
                    handNumberStrenght = "2";
                    break;
                case "Royal Flush":
                    handNumberStrenght = "1";
                    break;
                default:
                    break;
            }
            return handNumberStrenght;
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

        // this method checks if the hand is a straight
        public Boolean checkForStraight(int[] checkStraightHand)
        {
            int[] transformedHand = new int[] { };
            transformedHand = transformHands(checkStraightHand);

            Boolean isStraight = false;
            int count = 0;
            Boolean checkStraightWithAce = false;

            Array.Sort(checkStraightHand);

            for(int i = 0; i < checkStraightHand.Length - 1; i++)
            {
                if ((checkStraightHand[i + 1] - checkStraightHand[i]) == 1)
                {
                    if (count == 0){
                        if (checkStraightHand[i] == 10 || checkStraightHand[i] == 23 || checkStraightHand[i] == 36 || checkStraightHand[i] == 49)
                        {
                            checkStraightWithAce = true;
                        }
                    }
                    count++;
                } else if (count < 4)
                {
                    count = 0;
                }
            }

            if (checkStraightWithAce){
                if (count == 3){
                    foreach(int current in transformedHand){
                        if (current == 1){
                            isStraight = true;
                            isRoyal = true;
                        }
                    } 
                }
            }

            if (count >= 4)
            {
                isStraight = true;
            }

            return isStraight;
        }

        // this method checks if the hand is a flush
        public Boolean checkForFlush(int[] checkFlushHand)
        {
            String[] transformedHandSuits = new String[7];
            transformedHandSuits = transformHandsSuits(checkFlushHand);

            Boolean flush;
            flush = false;

            for (int i = 0; i < 3; i++)
            {
                int count = 0;

                for (int j = 0; j < 7; j++)
                {
                    if (i != j)
                    {
                        if (transformedHandSuits[i] == transformedHandSuits[j])
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

        // this method checks if the hand for pairs, kinds, and full house. Also for higher card.
        public String[] checkForPairs(int[] handNumbers)
        {
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            String[] handInfo = new String[6];
            String pairsString = "";
            int[] finalHand = new int[5];

            pairs.Clear();
            pairs2.Clear();
            List<int> numberNotToCheck = new List<int> {};


            for (int i = 0; i < 7; i++)
            {
                for (int j = i; j < 7; j++)
                {
                    if (i != j)
                    {
                        if (handNumbers[i] == handNumbers[j] && handNumbers[i] != 0)
                        {
                            Boolean isMarked = false;
                            foreach(int marked in numberNotToCheck){
                                if (i == marked){
                                    isMarked = true;
                                }
                            }

                            if(!isMarked){
                                if (num1 == 0 || handNumbers[i] == num1)
                                {
                                    num1 = handNumbers[i];
                                    count1++;
                                }
                                else if (num2 == 0 || handNumbers[i] == num2)
                                {
                                    num2 = handNumbers[i];
                                    count2++;
                                }
                                else if (num3 == 0 || handNumbers[i] == num3)
                                {
                                    num3 = handNumbers[i];
                                    count3++;
                                }
                                numberNotToCheck.Add(j);
                            }
                        }
                    }
                }
            }

            //adding numbers that paired up into an array for sorting.
            int[] nums = new int[3];
            if (num1 != 0){
                nums[0] = num1;
            }
            if (num2 != 0){
                nums[1] = num2;
            }
            if (num3 != 0){
                nums[2] = num3;
            }
            // sorting array of paired numbers in reverse order
            Array.Sort(nums);
            Array.Sort<int>(nums, new Comparison<int>((i1, i2) => i2.CompareTo(i1)));
            // sortin main hand in reverse order
            Array.Sort(handNumbers);
            Array.Sort<int>(handNumbers, new Comparison<int>((i1, i2) => i2.CompareTo(i1)));

            if (count1 == 0) {
                pairsString = "High Card";
                for (int i = 0; i < 5; i++){
                    finalHand[i] = handNumbers[i];
                }

            } else if (count1 > 0 && count1 < 2 && count2 == 0) {
                pairsString = "One Pair";
                finalHand[0] = num1;
                finalHand[1] = num1;
                List<int> numbersLeft = new List<int> {};
                foreach(int current in handNumbers){
                    if (current != num1){
                        numbersLeft.Add(current);
                    }
                }
                finalHand[2] = numbersLeft[0];
                finalHand[3] = numbersLeft[1];
                finalHand[4] = numbersLeft[2];

            } else if (count1 > 1 && count1 < 3 && count2 == 0) {
                pairsString = "Three of a Kind";
                finalHand[0] = num1;
                finalHand[1] = num1;
                finalHand[2] = num1;
                List<int> numbersLeft = new List<int> { };
                foreach (int current in handNumbers)
                {
                    if (current != num1)
                    {
                        numbersLeft.Add(current);
                    }
                }
                finalHand[3] = numbersLeft[0];
                finalHand[4] = numbersLeft[1];
            } else if (count1 > 2 || count2 > 2) {
                pairsString = "Four of a Kind";
                if(count1 > count2){
                    finalHand[0] = num1;
                    finalHand[1] = num1;
                    finalHand[2] = num1;
                    finalHand[3] = num1;
                    List<int> numbersLeft = new List<int> { };
                    foreach (int current in handNumbers)
                    {
                        if (current != num1)
                        {
                            numbersLeft.Add(current);
                        }
                    }
                    finalHand[4] = numbersLeft[0];
                } else {
                    finalHand[0] = num2;
                    finalHand[1] = num2;
                    finalHand[2] = num2;
                    finalHand[3] = num2;
                    List<int> numbersLeft = new List<int> { };
                    foreach (int current in handNumbers)
                    {
                        if (current != num2)
                        {
                            numbersLeft.Add(current);
                        }
                    }
                    finalHand[4] = numbersLeft[0];
                }
            } else if (count1 == 1 && count2 == 1 || count1 == 1 && count2 == 1 && count3 ==1){
                pairsString = "Two Pair";
                finalHand[0] = nums[0];
                finalHand[1] = nums[0];
                finalHand[2] = nums[1];
                finalHand[3] = nums[1];

                List<int> numbersLeft = new List<int> { };
                foreach (int current in handNumbers)
                {
                    if (current != num1 && current != num2 && current != num3)
                    {
                        numbersLeft.Add(current);
                    }
                }
            } else {
                pairsString = "Full House";
                if(count1 > count2 && count1 > count3){
                    finalHand[0] = num1;
                    finalHand[1] = num1;
                    finalHand[2] = num1;
                    if(num2 > num3) {
                        finalHand[3] = num2;
                        finalHand[4] = num2;
                    } else {
                        finalHand[3] = num3;
                        finalHand[4] = num3;
                    }
                } else if (count2 > count1 && count2 > count3){
                    finalHand[0] = num2;
                    finalHand[1] = num2;
                    finalHand[2] = num2;
                    if (num1 > num3)
                    {
                        finalHand[3] = num1;
                        finalHand[4] = num1;
                    }
                    else
                    {
                        finalHand[3] = num3;
                        finalHand[4] = num3;
                    }
                } else {
                    finalHand[0] = num3;
                    finalHand[1] = num3;
                    finalHand[2] = num3;
                    if (num2 > num1)
                    {
                        finalHand[3] = num2;
                        finalHand[4] = num2;
                    }
                    else
                    {
                        finalHand[3] = num1;
                        finalHand[4] = num1;
                    }
                }
            }

            Array.Sort(finalHand);
            Array.Sort<int>(finalHand, new Comparison<int>((i1, i2) => i2.CompareTo(i1)));

            handInfo[0] = pairsString;

            for (int i = 1; i < 6; i++){
                handInfo[i] = (finalHand[i - 1]).ToString();
            }

            return handInfo;
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
