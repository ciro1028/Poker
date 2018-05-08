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
        public String[] checkHand(int[] handToCheck)
        {
            String[] handInfo = new String[7];
            String[] royalArray = new String[7];
            String[] sFArray = new String[7];
            String[] flushArray = new String[7];
            String[] straightArray = new String[7];
            String[] pairsArray = new String[7];

            String[] chooseNumbers = new String[5];

            royalArray = checkForRoyalFlush(handToCheck);
            sFArray = checkFoStraightFlush(handToCheck);
            flushArray = checkForFlush(handToCheck);
            straightArray = checkForStraight(handToCheck);
            pairsArray = checkForPairs(handToCheck);

            chooseNumbers[0] = royalArray[1];
            chooseNumbers[1] = sFArray[1];
            chooseNumbers[2] = flushArray[1];
            chooseNumbers[3] = straightArray[1];
            chooseNumbers[4] = pairsArray[1];

            Array.Sort(chooseNumbers);

            String strenghtNumber = chooseNumbers[4];

            if (strenghtNumber == "10"){
                handInfo = royalArray;
            } else if (strenghtNumber == "9"){
                handInfo = sFArray;
            } else if (strenghtNumber == "6"){
                handInfo = flushArray;
            } else if (strenghtNumber == "5"){
                handInfo = straightArray;
            } else {
                handInfo = pairsArray;
            }

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
                    handNumberStrenght = "1";
                    break;
                case "One Pair":
                    handNumberStrenght = "2";
                    break;
                case "Two Pairs":
                    handNumberStrenght = "3";
                    break;
                case "Three of a Kind":
                    handNumberStrenght = "4";
                    break;
                case "Straight":
                    handNumberStrenght = "5";
                    break;
                case "Flush":
                    handNumberStrenght = "6";
                    break;
                case "Full House":
                    handNumberStrenght = "7";
                    break;
                case "Fout of a Kind":
                    handNumberStrenght = "8";
                    break;
                case "Straight Flush":
                    handNumberStrenght = "9";
                    break;
                case "Royal Flush":
                    handNumberStrenght = "10";
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

        public String[] checkForRoyalFlush(int[] checkRFHand){
            String[] handInfo = new String[8];

            String flush = checkForFlush(checkRFHand)[1];

            int[] flushFinal = new int[6];
            flushFinal[0] = Convert.ToInt32(checkForFlush(checkRFHand)[2]);
            flushFinal[1] = Convert.ToInt32(checkForFlush(checkRFHand)[3]);
            flushFinal[2] = Convert.ToInt32(checkForFlush(checkRFHand)[4]);
            flushFinal[3] = Convert.ToInt32(checkForFlush(checkRFHand)[5]);
            flushFinal[4] = Convert.ToInt32(checkForFlush(checkRFHand)[6]);
            flushFinal[5] = 0;

            if(flush == "6"){
                if (
                    flushFinal[0] == 13 &&
                    flushFinal[1] == 12 &&
                    flushFinal[2] == 11 &&
                    flushFinal[3] == 10 &&
                    flushFinal[4] == 1
                ) {
                    handInfo[0] = "Royal Flush";
                    handInfo[1] = "10";
                    handInfo[2] = "1";
                    handInfo[3] = "13";
                    handInfo[4] = "12";
                    handInfo[5] = "11";
                    handInfo[6] = "10";
                    handInfo[7] = "true";
                }
            }

            return handInfo;
        }

        public String[] checkFoStraightFlush(int[] checkSFHand) {

            String[] handInfo = new String[8];

            String flush = checkForFlush(checkSFHand)[1];

            int[] flushFinal = new int[6];
            flushFinal[0] = Convert.ToInt32(checkForFlush(checkSFHand)[2]);
            flushFinal[1] = Convert.ToInt32(checkForFlush(checkSFHand)[3]);
            flushFinal[2] = Convert.ToInt32(checkForFlush(checkSFHand)[4]);
            flushFinal[3] = Convert.ToInt32(checkForFlush(checkSFHand)[5]);
            flushFinal[4] = Convert.ToInt32(checkForFlush(checkSFHand)[6]);
            flushFinal[5] = 0;

            if (flush == "6"){
                int count = 0;
                for (int i = 0; i < 5; i++){
                    if (flushFinal[i] - flushFinal[i + 1] == 1 && flushFinal[i + 1] != 0){
                        count++;
                    } else if (count < 4){
                        count = 0;
                    }
                }

                if (count == 4){
                    handInfo[0] = "Straight Flush";
                    handInfo[1] = "9";
                    handInfo[2] = flushFinal[0].ToString();
                    handInfo[3] = flushFinal[1].ToString();
                    handInfo[4] = flushFinal[2].ToString();
                    handInfo[5] = flushFinal[3].ToString();
                    handInfo[6] = flushFinal[4].ToString();
                    handInfo[7] = "true";
                }
            }

            return handInfo;
        }

        // this method checks if the hand is a straight
        public String[] checkForStraight(int[] checkStraightHand)
        {
            int[] transformedHand = new int[] { };
            transformedHand = transformHands(checkStraightHand);

            int count = 0;
            Boolean checkStraightWithAce = false;
            List<int> finalHand = new List<int> {};

            String[] handInfo = new String[8];

            Array.Sort(checkStraightHand);

            for (int i = 0; i < 6; i++)
            {
                //after numbers are put in order, this goes through each number of the hand and checks to see if
                // the next number is only one more. First if checks if the next number is a plus one, the next check if the number
                // is a repeated number which still allows the straight to be true, and the last if checks to see if
                // the number is an ace because the ace can form straight on the high or low ends.
                if ((checkStraightHand[i + 1] - checkStraightHand[i]) == 1 || checkStraightHand[i + 1] == checkStraightHand[i] || checkStraightHand[i] == 1)
                {
                    // this checks to see if the first number of the straight is a 10, if so the ace should also be taken in consideration.
                    if (count == 0)
                    {
                        if (checkStraightHand[i] == 10)
                        {
                            checkStraightWithAce = true;
                        }
                    }

                    // this checks if next number in the sequence is a plus one, then the number is 
                    // added to the final hand and the count goes one+.
                    if ((checkStraightHand[i + 1] - checkStraightHand[i]) == 1 && checkStraightHand[i + 1] != checkStraightHand[i])
                    {
                        finalHand.Add(checkStraightHand[i]);
                        count++;
                        // if statement to check if the next number is the last number in the hand, if so,
                        // in addition to the current number, the final number is also added to the final hand.
                        if (count >= 4)
                        {
                            finalHand.Add(checkStraightHand[i + 1]);
                        }
                    }

                    // checks to see if there is a straight starting with a 10 and if there is an ace in the hand, if so
                    // confirms that the hand is a straight
                    if (count >= 3 && checkStraightWithAce)
                    {
                        foreach (int current in checkStraightHand){
                            if (current == 1){
                                finalHand.Add(13);
                                finalHand.Add(1);
                                count++;
                            }
                        }
                    }
                } 
                // reset count if next number in the sequence is not a plus 1.
                else if (count < 4)
                {
                    count = 0;
                    finalHand.Clear();
                }

            }

            List<int> distinct = finalHand.Distinct().ToList();

            if (count >= 4 )
            {
                handInfo[0] = "Straight";
                handInfo[1] = "5";
                handInfo[6] = distinct[0].ToString();
                handInfo[5] = distinct[1].ToString();
                handInfo[4] = distinct[2].ToString();
                handInfo[3] = distinct[3].ToString();
                handInfo[2] = distinct[4].ToString();
                handInfo[7] = "true";
            }
            return handInfo;
        }

        // this method checks if the hand is a flush
        public String[] checkForFlush(int[] checkFlushHand)
        {
            String[] transformedHandSuits = new String[7];
            transformedHandSuits = transformHandsSuits(checkFlushHand);

            List<int> tempHand = new List<int> { };
            List<String> tempHandSuits = new List<String> { };

            int[] finalHand = new int[5];
            String[] finalHandSuits = new String[5];
            String[] handInfo = new string[8];

            for (int i = 0; i < 3; i++)
            {
                int count = 0;

                for (int j = i + 1; j < 7; j++)
                {
                    if (transformedHandSuits[i] == transformedHandSuits[j])
                    {
                        if (count == 0) {
                            tempHand.Add(checkFlushHand[i]);
                            tempHand.Add(checkFlushHand[j]);
                            tempHandSuits.Add(transformedHandSuits[i]);
                            tempHandSuits.Add(transformedHandSuits[j]);
                            count++;
                        } else {
                            tempHand.Add(checkFlushHand[j]);
                            tempHandSuits.Add(transformedHandSuits[j]);
                            count++;
                        }
                    }
                }
                if (count >= 4)
                {
                    
                    finalHand = transformHands(tempHand.ToArray());
                    finalHandSuits = tempHandSuits.ToArray();

                    Array.Sort(finalHand);
                    int[] tempArray = new int[5];
                    int countTemp = 4;
                    for (int j = 0; j < 5; j++)
                    {

                        tempArray[j] = finalHand[countTemp];
                        countTemp--;
                    }
                    finalHand = tempArray;

                    handInfo[0] = "Flush";
                    handInfo[1] = "6";
                    handInfo[2] = finalHand[0].ToString();
                    handInfo[3] = finalHand[1].ToString();
                    handInfo[4] = finalHand[2].ToString();
                    handInfo[5] = finalHand[3].ToString();
                    handInfo[6] = finalHand[4].ToString();

                    handInfo[7] = "true";

                    break;
                }
            }

            return handInfo;
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
            String[] handInfo = new String[8];
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
            } else if (count1 == 1 && count2 == 1 && count3 == 0 || count1 == 1 && count2 == 1 && count3 == 1){
                pairsString = "Two Pairs";
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

                finalHand[4] = numbersLeft[0];
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
            handInfo[1] = getHandNumberStrenght(handInfo[0]);

            handInfo[2] = finalHand[0].ToString();
            handInfo[3] = finalHand[1].ToString();
            handInfo[4] = finalHand[2].ToString();
            handInfo[5] = finalHand[3].ToString();
            handInfo[6] = finalHand[4].ToString();


            handInfo[7] = "true";

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
