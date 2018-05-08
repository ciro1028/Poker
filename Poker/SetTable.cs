using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class SetTable
    {
        public List<int> playersList = new List<int>();
        public List<int> deck = new List<int>();
        public List<Player> listOfPlayers = new List<Player>();
        Random random = new Random();

        int countFlop = 0;

        public SetTable()
        {

        }

        public void createDeck()
        {
            for (int i = 1; i < 53; i++)
            {
                deck.Add(i);
            }
        }

        public List<int> setTable(Boolean p1, Boolean p2, Boolean p3, Boolean p4, Boolean p5, Boolean p6, Boolean p7, Boolean p8)
        {
            createDeck();

            playersList.Add(((p1) ? 1 : 0));
            playersList.Add(((p2) ? 2 : 0));
            playersList.Add(((p3) ? 3 : 0));
            playersList.Add(((p4) ? 4 : 0));
            playersList.Add(((p5) ? 5 : 0));
            playersList.Add(((p6) ? 6 : 0));
            playersList.Add(((p7) ? 7 : 0));
            playersList.Add(((p8) ? 8 : 0));

            for (int i = 0; i < 8; i++)
            {
                playersList.Remove(0);
            }

            return playersList;
        }

        public void resetTable(){
            playersList.Clear();
            listOfPlayers.Clear();
            deck.Clear();
        }

        public List<Player> dealCards()
        {
            int[] stringArrayInitializer = new int[5];
            for (int i = 0; i < playersList.Count; i++)
            {
                if (playersList[i] == 1)
                {
                    Player player1 = new Player(1, "Mark", "20000", setPlayerCards(), true, "", "", 0, stringArrayInitializer);
                    listOfPlayers.Add(player1);
                }
                if (playersList[i] == 2)
                {
                    Player player2 = new Player(2, "Paul", "20000", setPlayerCards(), true, "", "", 0, stringArrayInitializer);
                    listOfPlayers.Add(player2);
                }
                if (playersList[i] == 3)
                {
                    Player player3 = new Player(3, "Susan", "20000", setPlayerCards(), true, "", "", 0, stringArrayInitializer);
                    listOfPlayers.Add(player3);
                }
                if (playersList[i] == 4)
                {
                    Player player4 = new Player(4, "Lucas", "20000", setPlayerCards(), true, "", "", 0, stringArrayInitializer);
                    listOfPlayers.Add(player4);
                }
                if (playersList[i] == 5)
                {
                    Player player5 = new Player(5, "Juan", "20000", setPlayerCards(), true, "", "", 0, stringArrayInitializer);
                    listOfPlayers.Add(player5);
                }
                if (playersList[i] == 6)
                {
                    Player player6 = new Player(6, "Maria", "20000", setPlayerCards(), true, "", "", 0, stringArrayInitializer);
                    listOfPlayers.Add(player6);
                }
                if (playersList[i] == 7)
                {
                    Player player7 = new Player(7, "Brianna", "20000", setPlayerCards(), true, "", "", 0, stringArrayInitializer);
                    listOfPlayers.Add(player7);
                }
                if (playersList[i] == 8)
                {
                    Player player8 = new Player(8, "Bob", "20000", setPlayerCards(), true, "", "", 0, stringArrayInitializer);
                    listOfPlayers.Add(player8);
                }
            }

            return listOfPlayers;
        }

        private int[] setPlayerCards()
        {
            int[] hand = new int[7];
            int randomNumber1;
            randomNumber1 = random.Next(1, deck.Count);
            int number1 = deck[randomNumber1];
            deck.Remove(number1);

            hand[0] = number1;

            int randomNumber2;
            randomNumber2 = random.Next(1, deck.Count);
            int number2 = deck[randomNumber2];
            deck.Remove(number2);

            hand[1] = number2;

            return hand;
        }

        public int[] setFlop()
        {
            int[] flopNumbers = new int[] { 0, 0, 0, 0, 0 };
            if (countFlop == 0)
            {
                int randomNumber;
                randomNumber = random.Next(1, deck.Count);
                int number1 = deck[randomNumber];
                deck.Remove(number1);
                flopNumbers[0] = number1;

                int randomNumber2;
                randomNumber2 = random.Next(1, deck.Count);
                int number2 = deck[randomNumber2];
                deck.Remove(number2);

                flopNumbers[1] = number2;

                int randomNumber3;
                randomNumber3 = random.Next(1, deck.Count);
                int number3 = deck[randomNumber3];
                deck.Remove(number3);

                flopNumbers[2] = number3;

            } else if (countFlop == 1){
                int randomNumber;
                randomNumber = random.Next(1, deck.Count);
                int number1 = deck[randomNumber];
                deck.Remove(number1);
                flopNumbers[3] = number1;
            } else if (countFlop == 2)
            {
                int randomNumber;
                randomNumber = random.Next(1, deck.Count);
                int number1 = deck[randomNumber];
                deck.Remove(number1);
                flopNumbers[4] = number1;
            }
            countFlop++;
            if(countFlop > 2)
            {
                countFlop = 0;
            }
            return flopNumbers;
        }
        
    }
}
