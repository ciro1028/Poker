using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class mainForm : Form
    {
        Hands hand = new Hands();

        SetTable setTable = new SetTable();
        List<Player> listOfPlayers = new List<Player>();
        String suit = "";

        int[] firstPHand = new int[] { 0, 0, 0, 0, 0, 0, 0 };

        int[] handNumbers = new int[] { 0, 0, 0, 0, 0, 0, 0 };

        List<int> playersList = new List<int>();
        List<int> deck = new List<int>();
        List<int> cardsDealt = new List<int>();
        int countFlop = 0;
        int[] flopCards = new int[] { 0, 0, 0, 0, 0 };

        Random random = new Random();


        //choose between 1 and 13 and then between 1 and 4
        // 1 - spades, 2 - clubs, 3 - diamonds, 4 - hearts

        public mainForm()
        {
            InitializeComponent();
        }

        public void when1Checked(Object sender, EventArgs e)
        {
            firstPlayerPanel.Visible = (firstPlayerPanel.Visible) ? false : true;
        }

        public void when2Checked(Object sender, EventArgs e)
        {
            secondPlayerPanel.Visible = (secondPlayerPanel.Visible) ? false : true;
        }

        public void when3Checked(Object sender, EventArgs e)
        {
            thirdPlayerPanel.Visible = (thirdPlayerPanel.Visible) ? false : true;
        }

        public void when4Checked(Object sender, EventArgs e)
        {
            fourthPlayerPanel.Visible = (fourthPlayerPanel.Visible) ? false : true;
        }

        public void when5Checked(Object sender, EventArgs e)
        {
            fifthPlayerPanel.Visible = (fifthPlayerPanel.Visible) ? false : true;
        }

        public void when6Checked(Object sender, EventArgs e)
        {
            sixthPlayerPanel.Visible = (sixthPlayerPanel.Visible) ? false : true;
        }

        public void when7Checked(Object sender, EventArgs e)
        {
            seventhPlayerPanel.Visible = (seventhPlayerPanel.Visible) ? false : true;
        }

        public void when8Checked(Object sender, EventArgs e)
        {
            eighthPlayerPanel.Visible = (eighthPlayerPanel.Visible) ? false : true;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            playersList = setTable.setTable(firstPlayerPanel.Visible, secondPlayerPanel.Visible, thirdPlayerPanel.Visible,
                fourthPlayerPanel.Visible, fifthPlayerPanel.Visible, sixthPlayerPanel.Visible, 
                seventhPlayerPanel.Visible, eighthPlayerPanel.Visible);
            setPlayers();
            this.flipBtn.Visible = true;
            disablePlayersBoxes();
        }

        public void setPlayers()
        {
            listOfPlayers = setTable.dealCards();
            for (int i = 0; i < listOfPlayers.Count; i++)
            {
                if (listOfPlayers[i].id == 1)
                {
                    this.name1Lbl.Text = listOfPlayers[i].name;
                    this.firstPmoneyLbl.Text = listOfPlayers[i].cash;
                    this.firstPpicBox1.BackColor = Color.White;
                    this.firstPpicBox2.BackColor = Color.White;
                    this.firstPpicBox1.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[0]) + "_of_" + suit + ".png");
                    this.firstPpicBox2.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[1]) + "_of_" + suit + ".png");
                }
                if (listOfPlayers[i].id == 2)
                {
                    this.name2Lbl.Text = listOfPlayers[i].name;
                    this.secondPmoneyLbl.Text = listOfPlayers[i].cash;
                    this.secondPpicBox1.BackColor = Color.White;
                    this.secondPpicBox2.BackColor = Color.White;
                    this.secondPpicBox1.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[0]) + "_of_" + suit + ".png");
                    this.secondPpicBox2.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[1]) + "_of_" + suit + ".png");
                }
                if (listOfPlayers[i].id == 3)
                {
                    this.name3Lbl.Text = listOfPlayers[i].name;
                    this.thirdPmoneyLbl.Text = listOfPlayers[i].cash;
                    this.thirdPpicBox1.BackColor = Color.White;
                    this.thirdPpicBox2.BackColor = Color.White;
                    this.thirdPpicBox1.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[0]) + "_of_" + suit + ".png");
                    this.thirdPpicBox2.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[1]) + "_of_" + suit + ".png");
                }
                if (listOfPlayers[i].id == 4)
                {
                    this.name4Lbl.Text = listOfPlayers[i].name;
                    this.fourthPmoneyLbl.Text = listOfPlayers[i].cash;
                    this.fourthPpicBox1.BackColor = Color.White;
                    this.fourthPpicBox2.BackColor = Color.White;
                    this.fourthPpicBox1.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[0]) + "_of_" + suit + ".png");
                    this.fourthPpicBox2.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[1]) + "_of_" + suit + ".png");
                }
                if (listOfPlayers[i].id == 5)
                {
                    this.name5Lbl.Text = listOfPlayers[i].name;
                    this.fifthPmoneyLbl.Text = listOfPlayers[i].cash;
                    this.fifthPpicBox1.BackColor = Color.White;
                    this.fifthPpicBox2.BackColor = Color.White;
                    this.fifthPpicBox1.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[0]) + "_of_" + suit + ".png");
                    this.fifthPpicBox2.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[1]) + "_of_" + suit + ".png");
                }
                if (listOfPlayers[i].id == 6)
                {
                    this.name6Lbl.Text = listOfPlayers[i].name;
                    this.thirdPmoneyLbl.Text = listOfPlayers[i].cash;
                    this.sixthPpicBox1.BackColor = Color.White;
                    this.sixthPpicBox2.BackColor = Color.White;
                    this.sixthPpicBox1.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[0]) + "_of_" + suit + ".png");
                    this.sixthPpicBox2.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[1]) + "_of_" + suit + ".png");
                }
                if (listOfPlayers[i].id == 7)
                {
                    this.name7Lbl.Text = listOfPlayers[i].name;
                    this.seventhPmoneyLbl.Text = listOfPlayers[i].cash;
                    this.seventhPpicBox1.BackColor = Color.White;
                    this.seventhPpicBox2.BackColor = Color.White;
                    this.seventhPpicBox1.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[0]) + "_of_" + suit + ".png");
                    this.seventhPpicBox2.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[1]) + "_of_" + suit + ".png");
                }
                if (listOfPlayers[i].id == 8)
                {
                    this.name8Lbl.Text = listOfPlayers[i].name;
                    this.eighthPmoneyLbl.Text = listOfPlayers[i].cash;
                    this.eighthPpicBox1.BackColor = Color.White;
                    this.eighthPpicBox2.BackColor = Color.White;
                    this.eighthPpicBox1.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[0]) + "_of_" + suit + ".png");
                    this.eighthPpicBox2.Load("../../images/png/" + correctedNumbers(listOfPlayers[i].hand[1]) + "_of_" + suit + ".png");
                }
            }
        }

        public void disablePlayersBoxes()
        {
            if (startBtn.Enabled)
            {
                firstPPlayingLbl.Enabled = false;
                secondPPlayingLbl.Enabled = false;
                thirdPPlayingLbl.Enabled = false;
                fourthPPlayingLbl.Enabled = false;
                fifthPPlayingLbl.Enabled = false;
                sixthPPlayingLbl.Enabled = false;
                seventhPPlayingLbl.Enabled = false;
                eighthPPlayingLbl.Enabled = false;
                startBtn.Enabled = false;
            } else
            {
                firstPPlayingLbl.Enabled = true;
                secondPPlayingLbl.Enabled = true;
                thirdPPlayingLbl.Enabled = true;
                fourthPPlayingLbl.Enabled = true;
                fifthPPlayingLbl.Enabled = true;
                sixthPPlayingLbl.Enabled = true;
                seventhPPlayingLbl.Enabled = true;
                eighthPPlayingLbl.Enabled = true;
                startBtn.Enabled = true;
            }
        }

        public void checkHands()
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (playersList[i] == 1)
                {
                    string str = "";
                    hand1Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand);
                    for (int j = 0; j < 7; j++)
                    {
                        str = str + " " + setTable.listOfPlayers[0].hand[j];
                    }

                    Console.WriteLine("Player one hand: " + str);
                }
                if (playersList[i] == 2)
                {
                    hand2Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand);
                }
                if (playersList[i] == 3)
                {
                    hand3Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand);
                }
                if (playersList[i] == 4)
                {
                    hand4Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand);
                }
                if (playersList[i] == 5)
                {
                    hand5Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand);
                }
                if (playersList[i] == 6)
                {
                    hand6Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand);
                }
                if (playersList[i] == 7)
                {
                    hand7Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand);
                }
                if (playersList[i] == 8)
                {
                    hand8Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand);
                }
            }
        }

        private int correctedNumbers(int cardNumber)
        {
            if (cardNumber < 14)
            {
                suit = "spades";
            } else
            if (cardNumber > 13 && cardNumber < 27)
            {
                suit = "clubs";
                cardNumber = cardNumber - 13;
            }
            else if (cardNumber > 26 && cardNumber < 40)
            {
                suit = "diamonds";
                cardNumber = cardNumber - 26;
            }
            else if (cardNumber > 39)
            {
                suit = "hearts";
                cardNumber = cardNumber - 39;
            }
            return cardNumber;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            resetDeck();
            this.flipBtn.Visible = false;
            hand.resetHand();
            cleanLabels();
            disablePlayersBoxes();
        }

        public void cleanLabels()
        {
            hand1Lbl.Text = "";
            hand2Lbl.Text = "";
            hand3Lbl.Text = "";
            hand4Lbl.Text = "";
            hand5Lbl.Text = "";
            hand6Lbl.Text = "";
            hand7Lbl.Text = "";
            hand8Lbl.Text = "";

            this.firstPpicBox1.Image = null;
            this.firstPpicBox1.BackColor = Color.Transparent;
            this.firstPpicBox2.Image = null;
            this.firstPpicBox2.BackColor = Color.Transparent;
            this.secondPpicBox1.Image = null;
            this.secondPpicBox1.BackColor = Color.Transparent;
            this.secondPpicBox2.Image = null;
            this.secondPpicBox2.BackColor = Color.Transparent;
            this.thirdPpicBox1.Image = null;
            this.thirdPpicBox1.BackColor = Color.Transparent;
            this.thirdPpicBox2.Image = null;
            this.thirdPpicBox2.BackColor = Color.Transparent;
            this.fourthPpicBox1.Image = null;
            this.fourthPpicBox1.BackColor = Color.Transparent;
            this.fourthPpicBox2.Image = null;
            this.fourthPpicBox2.BackColor = Color.Transparent;
            this.fifthPpicBox1.Image = null;
            this.fifthPpicBox1.BackColor = Color.Transparent;
            this.fifthPpicBox2.Image = null;
            this.fifthPpicBox2.BackColor = Color.Transparent;
            this.sixthPpicBox1.Image = null;
            this.sixthPpicBox1.BackColor = Color.Transparent;
            this.sixthPpicBox2.Image = null;
            this.sixthPpicBox2.BackColor = Color.Transparent;
            this.seventhPpicBox1.Image = null;
            this.seventhPpicBox1.BackColor = Color.Transparent;
            this.seventhPpicBox2.Image = null;
            this.seventhPpicBox2.BackColor = Color.Transparent;
            this.eighthPpicBox1.Image = null;
            this.eighthPpicBox1.BackColor = Color.Transparent;
            this.eighthPpicBox2.Image = null;
            this.eighthPpicBox2.BackColor = Color.Transparent;
            this.firstFlopPB.Image = null;
            this.firstFlopPB.BackColor = Color.Transparent;
            this.secondFlopPB.Image = null;
            this.secondFlopPB.BackColor = Color.Transparent;
            this.thirdFlopPB.Image = null;
            this.thirdFlopPB.BackColor = Color.Transparent;
            this.turnPB.Image = null;
            this.riverPB.BackColor = Color.Transparent;
            this.riverPB.Image = null;
            this.turnPB.BackColor = Color.Transparent;
        }

        public void resetDeck()
        {
            List<int> cleanDeck = new List<int>();
            countFlop = 0;

            for (int i = 1; i < 53; i++)
            {
                cleanDeck.Add(i);
            }

            deck = cleanDeck;
        }

        private void flipBtn_Click(object sender, EventArgs e)
        {
            flipCards();
        }

        public void flipCards()
        {
            flopCards = setTable.setFlop();
            setFlopCards(flopCards);
            addToHands(flopCards);
            countFlop++;
            
        }

        public void setFlopCards(int[] flopCards)
        {
            if (countFlop == 0)
            {
                this.firstFlopPB.Load(("../../images/png/" + correctedNumbers(flopCards[0]) + "_of_" + suit + ".png"));
                this.secondFlopPB.Load(("../../images/png/" + correctedNumbers(flopCards[1]) + "_of_" + suit + ".png"));
                this.thirdFlopPB.Load(("../../images/png/" + correctedNumbers(flopCards[2]) + "_of_" + suit + ".png"));
                this.firstFlopPB.BackColor = Color.White;
                this.secondFlopPB.BackColor = Color.White;
                this.thirdFlopPB.BackColor = Color.White;
            } else if (countFlop == 1)
            {
                this.turnPB.Load(("../../images/png/" + correctedNumbers(flopCards[3]) + "_of_" + suit + ".png"));
                this.turnPB.BackColor = Color.White;
            } else if (countFlop == 2)
            {
                this.riverPB.Load(("../../images/png/" + correctedNumbers(flopCards[4]) + "_of_" + suit + ".png"));
                this.riverPB.BackColor = Color.White;
            } else if (countFlop > 2)
            {
                countFlop = 0;
            }
        }

        public void addToHands(int[] flopCards)
        {
            if (countFlop == 0)
            {
                for (int i = 0; i < playersList.Count; i++)
                {
                    if (playersList[i] == 1)
                    {
                        setTable.listOfPlayers[i].hand[2] = flopCards[0];
                        setTable.listOfPlayers[i].hand[3] = flopCards[1];
                        setTable.listOfPlayers[i].hand[4] = flopCards[2];

                        string str = "";

                        for (int j = 0; j < 7; j++)
                        {
                            str = str + " " + setTable.listOfPlayers[0].hand[j];
                        }

                        Console.WriteLine("Player one hand first flop: " + str);
                    }
                    if (playersList[i] == 2)
                    {
                        setTable.listOfPlayers[i].hand[2] = flopCards[0];
                        setTable.listOfPlayers[i].hand[3] = flopCards[1];
                        setTable.listOfPlayers[i].hand[4] = flopCards[2];
                    }
                    if (playersList[i] == 3)
                    {
                        setTable.listOfPlayers[i].hand[2] = flopCards[0];
                        setTable.listOfPlayers[i].hand[3] = flopCards[1];
                        setTable.listOfPlayers[i].hand[4] = flopCards[2];
                    }
                    if (playersList[i] == 4)
                    {
                        setTable.listOfPlayers[i].hand[2] = flopCards[0];
                        setTable.listOfPlayers[i].hand[3] = flopCards[1];
                        setTable.listOfPlayers[i].hand[4] = flopCards[2];
                    }
                    if (playersList[i] == 5)
                    {
                        setTable.listOfPlayers[i].hand[2] = flopCards[0];
                        setTable.listOfPlayers[i].hand[3] = flopCards[1];
                        setTable.listOfPlayers[i].hand[4] = flopCards[2];
                    }
                    if (playersList[i] == 6)
                    {
                        setTable.listOfPlayers[i].hand[2] = flopCards[0];
                        setTable.listOfPlayers[i].hand[3] = flopCards[1];
                        setTable.listOfPlayers[i].hand[4] = flopCards[2];
                    }
                    if (playersList[i] == 7)
                    {
                        setTable.listOfPlayers[i].hand[2] = flopCards[0];
                        setTable.listOfPlayers[i].hand[3] = flopCards[1];
                        setTable.listOfPlayers[i].hand[4] = flopCards[2];
                    }
                    if (playersList[i] == 8)
                    {
                        setTable.listOfPlayers[i].hand[2] = flopCards[0];
                        setTable.listOfPlayers[i].hand[3] = flopCards[1];
                        setTable.listOfPlayers[i].hand[4] = flopCards[2];
                    }
                }
                
            }
            else if (countFlop == 1)
            {
                for (int i = 0; i < playersList.Count; i++)
                {
                    if (playersList[i] == 1)
                    {
                        setTable.listOfPlayers[i].hand[5] = flopCards[3];

                        string str = "";

                        for (int j = 0; j < 7; j++)
                        {
                            str = str + " " + setTable.listOfPlayers[0].hand[j];
                        }

                        Console.WriteLine("Player one hand after second flop: " + str);
                    }
                    if (playersList[i] == 2)
                    {
                        setTable.listOfPlayers[i].hand[5] = flopCards[3];
                    }
                    if (playersList[i] == 3)
                    {
                        setTable.listOfPlayers[i].hand[5] = flopCards[3];
                    }
                    if (playersList[i] == 4)
                    {
                        setTable.listOfPlayers[i].hand[5] = flopCards[3];
                    }
                    if (playersList[i] == 5)
                    {
                        setTable.listOfPlayers[i].hand[5] = flopCards[3];
                    }
                    if (playersList[i] == 6)
                    {
                        setTable.listOfPlayers[i].hand[5] = flopCards[3];
                    }
                    if (playersList[i] == 7)
                    {
                        setTable.listOfPlayers[i].hand[5] = flopCards[3];
                    }
                    if (playersList[i] == 8)
                    {
                        setTable.listOfPlayers[i].hand[5] = flopCards[3];
                    }
                }
                
            } else if (countFlop == 2)
            {
                for (int i = 0; i < playersList.Count; i++)
                {
                    if (playersList[i] == 1)
                    {
                        setTable.listOfPlayers[i].hand[6] = flopCards[4];

                        string str = "";

                        for (int j = 0; j < 7; j++)
                        {
                            str = str + " " + setTable.listOfPlayers[0].hand[j];
                        }

                        Console.WriteLine("Player one hand after third flop: " + str);
                    }
                    if (playersList[i] == 2)
                    {
                        setTable.listOfPlayers[i].hand[6] = flopCards[4];
                    }
                    if (playersList[i] == 3)
                    {
                        setTable.listOfPlayers[i].hand[6] = flopCards[4];
                    }
                    if (playersList[i] == 4)
                    {
                        setTable.listOfPlayers[i].hand[6] = flopCards[4];
                    }
                    if (playersList[i] == 5)
                    {
                        setTable.listOfPlayers[i].hand[6] = flopCards[4];
                    }
                    if (playersList[i] == 6)
                    {
                        setTable.listOfPlayers[i].hand[6] = flopCards[4];
                    }
                    if (playersList[i] == 7)
                    {
                        setTable.listOfPlayers[i].hand[6] = flopCards[4];
                    }
                    if (playersList[i] == 8)
                    {
                        setTable.listOfPlayers[i].hand[6] = flopCards[4];
                    }
                }
                checkHands();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int[] testHandNums = new int[7];

            List<int> testDeck = new List<int>();

            for (int i = 1; i < 53; i++)
            {
                testDeck.Add(i);
            }


            int randomNumber1;
            randomNumber1 = random.Next(1, testDeck.Count);
            num1 = testDeck[randomNumber1];
            testHandNums[0] = num1;
            testDeck.Remove(num1);

            int randomNumber2;
            randomNumber2 = random.Next(1, testDeck.Count);
            num2 = testDeck[randomNumber1];
            testHandNums[1] = num2;
            testDeck.Remove(num2);

            int randomNumber3;
            randomNumber3 = random.Next(1, testDeck.Count);
            num3 = testDeck[randomNumber3];
            testHandNums[2] = num3;
            testDeck.Remove(num3);

            int randomNumber4;
            randomNumber4 = random.Next(1, testDeck.Count);
            num4 = testDeck[randomNumber4];
            testHandNums[3] = num4;
            testDeck.Remove(num4);

            int randomNumber5;
            randomNumber5 = random.Next(1, testDeck.Count);
            num5 = testDeck[randomNumber5];
            testHandNums[4] = num5;
            testDeck.Remove(num5);

            int randomNumber6;
            randomNumber6 = random.Next(1, testDeck.Count);
            num6 = testDeck[randomNumber6];
            testHandNums[5] = num6;
            testDeck.Remove(num6);

            int randomNumber7;
            randomNumber7 = random.Next(1, testDeck.Count);
            num7 = testDeck[randomNumber7];
            testHandNums[6] = num7;
            testDeck.Remove(num7);



            Array.Sort(testHandNums);

            String[] suits = new string[7];
            suits = hand.transformHandsSuits(testHandNums);

            lblColors(suits);

            testLblResult.Text = hand.checkHand(testHandNums);

            int[] handTransformed = new int[7];
            handTransformed = hand.transformHands(testHandNums);

            testLbl1.Text = (handTransformed[0]).ToString();
            testLbl2.Text = (handTransformed[1]).ToString();
            testLbl3.Text = (handTransformed[2]).ToString();
            testLbl4.Text = (handTransformed[3]).ToString();
            testLbl5.Text = (handTransformed[4]).ToString();
            testLbl6.Text = (handTransformed[5]).ToString();
            testLbl7.Text = (handTransformed[6]).ToString();



            //String str = "";

            //for (int i = 0; i < setTable.listOfPlayers[0].hand.Length; i++)
            //{
            //    str = str + " " + setTable.listOfPlayers[0].hand[i];
            //}

            //testLbl.Text = str;

            //Console.WriteLine("----------");
        }

        public void lblColors(String[] suits) {
            switch (suits[0])
            {
                case "spades":
                    testLbl1.ForeColor = Color.Blue;
                    break;
                case "clubs":
                    testLbl1.ForeColor = Color.Purple;
                    break;
                case "diamonds":
                    testLbl1.ForeColor = Color.Yellow;
                    break;
                case "hearts":
                    testLbl1.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }

            switch (suits[1])
            {
                case "spades":
                    testLbl2.ForeColor = Color.Blue;
                    break;
                case "clubs":
                    testLbl2.ForeColor = Color.Purple;
                    break;
                case "diamonds":
                    testLbl2.ForeColor = Color.Yellow;
                    break;
                case "hearts":
                    testLbl2.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }
            switch (suits[2])
            {
                case "spades":
                    testLbl3.ForeColor = Color.Blue;
                    break;
                case "clubs":
                    testLbl3.ForeColor = Color.Purple;
                    break;
                case "diamonds":
                    testLbl3.ForeColor = Color.Yellow;
                    break;
                case "hearts":
                    testLbl3.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }
            switch (suits[3])
            {
                case "spades":
                    testLbl4.ForeColor = Color.Blue;
                    break;
                case "clubs":
                    testLbl4.ForeColor = Color.Purple;
                    break;
                case "diamonds":
                    testLbl4.ForeColor = Color.Yellow;
                    break;
                case "hearts":
                    testLbl4.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }
            switch (suits[4])
            {
                case "spades":
                    testLbl5.ForeColor = Color.Blue;
                    break;
                case "clubs":
                    testLbl5.ForeColor = Color.Purple;
                    break;
                case "diamonds":
                    testLbl5.ForeColor = Color.Yellow;
                    break;
                case "hearts":
                    testLbl5.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }
            switch (suits[5])
            {
                case "spades":
                    testLbl6.ForeColor = Color.Blue;
                    break;
                case "clubs":
                    testLbl6.ForeColor = Color.Purple;
                    break;
                case "diamonds":
                    testLbl6.ForeColor = Color.Yellow;
                    break;
                case "hearts":
                    testLbl6.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }
            switch (suits[6])
            {
                case "spades":
                    testLbl7.ForeColor = Color.Blue;
                    break;
                case "clubs":
                    testLbl7.ForeColor = Color.Purple;
                    break;
                case "diamonds":
                    testLbl7.ForeColor = Color.Yellow;
                    break;
                case "hearts":
                    testLbl7.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }
        }
    }
}
