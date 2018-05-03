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
        int currentBettingPlayer = 0;
        int currentBettingPlayerCount = 0;

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
            
            disablePlayersBoxes();

            currentBettingPlayer = setTable.listOfPlayers[0].id;
            betTurn();
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
            }
            else
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
                    hand1Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand)[0];
                    for (int j = 0; j < 7; j++)
                    {
                        str = str + " " + setTable.listOfPlayers[0].hand[j];
                    }
                }
                if (playersList[i] == 2)
                {
                    hand2Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand)[0];
                }
                if (playersList[i] == 3)
                {
                    hand3Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand)[0];
                }
                if (playersList[i] == 4)
                {
                    hand4Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand)[0];
                }
                if (playersList[i] == 5)
                {
                    hand5Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand)[0];
                }
                if (playersList[i] == 6)
                {
                    hand6Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand)[0];
                }
                if (playersList[i] == 7)
                {
                    hand7Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand)[0];
                }
                if (playersList[i] == 8)
                {
                    hand8Lbl.Text = hand.checkHand(setTable.listOfPlayers[i].hand)[0];
                }
            }
        }

        private int correctedNumbers(int cardNumber)
        {
            if (cardNumber < 14)
            {
                suit = "spades";
            }
            else
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
            currentBettingPlayer = setTable.listOfPlayers[0].id;
            betTurn();
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
            }
            else if (countFlop == 1)
            {
                this.turnPB.Load(("../../images/png/" + correctedNumbers(flopCards[3]) + "_of_" + suit + ".png"));
                this.turnPB.BackColor = Color.White;
                this.flipBtn.Text = "Deal Turn";
                this.dealFlopLb.Text = "Deal Turn!";
            }
            else if (countFlop == 2)
            {
                this.riverPB.Load(("../../images/png/" + correctedNumbers(flopCards[4]) + "_of_" + suit + ".png"));
                this.riverPB.BackColor = Color.White;
                this.flipBtn.Text = "Deal River";
                this.dealFlopLb.Text = "Deal River!";
            }
            else if (countFlop > 2)
            {
                countFlop = 0;
                this.flipBtn.Text = "Deal Flop";
                this.dealFlopLb.Text = "Deal Flop!";
                this.flipBtn.Visible = false;
                this.dealFlopLb.Visible = false;
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

            }
            else if (countFlop == 2)
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

        // method to handle each player's turn
        public void betTurn()
        {
            if (currentBettingPlayerCount == 0 && currentBettingPlayer == 0){
                turnOffPlayers();
                currentBettingPlayer = 0;
                Console.WriteLine("Hello");
                flipBtn.Visible = true;
                dealFlopLb.Visible = true;
            } else {
                switch (currentBettingPlayer)
                {
                    case 1:
                        this.turnCK1.BackColor = Color.Lime;
                        this.firstPbetRB.Visible = true;
                        this.firstPCheckRB.Visible = true;
                        this.firstPBetBtn.Visible = true;
                        break;
                    case 2:
                        this.turnCK2.BackColor = Color.Lime;
                        this.secondPbetRB.Visible = true;
                        this.secondPCheckRB.Visible = true;
                        this.secondPBetBtn.Visible = true;
                        break;
                    case 3:
                        this.turnCK3.BackColor = Color.Lime;
                        this.thirdPbetRB.Visible = true;
                        this.thirdPCheckRB.Visible = true;
                        this.thirdPBetBtn.Visible = true;
                        break;
                    case 4:
                        this.turnCK4.BackColor = Color.Lime;
                        this.fourthPbetRB.Visible = true;
                        this.fourthPCheckRB.Visible = true;
                        this.fourthPBetBtn.Visible = true;
                        break;
                    case 5:
                        this.turnCK5.BackColor = Color.Lime;
                        this.fifthPbetRB.Visible = true;
                        this.fifthPCheckRB.Visible = true;
                        this.fifthPBetBtn.Visible = true;
                        break;
                    case 6:
                        this.turnCK6.BackColor = Color.Lime;
                        this.sixthPbetRB.Visible = true;
                        this.sixthPCheckRB.Visible = true;
                        this.sixthPBetBtn.Visible = true;
                        break;
                    case 7:
                        this.turnCK7.BackColor = Color.Lime;
                        this.seventhPbetRB.Visible = true;
                        this.seventhPCheckRB.Visible = true;
                        this.seventhPBetBtn.Visible = true;
                        break;
                    case 8:
                        this.turnCK8.BackColor = Color.Lime;
                        this.eighthPbetRB.Visible = true;
                        this.eighthPCheckRB.Visible = true;
                        this.eighthPBetBtn.Visible = true;
                        break;
                }
                if(currentBettingPlayerCount < setTable.listOfPlayers.Count - 1){
                    currentBettingPlayerCount++;
                    currentBettingPlayer = setTable.listOfPlayers[currentBettingPlayerCount].id;
                } else {
                    currentBettingPlayer = 0;
                    currentBettingPlayerCount = 0;
                }

            }
            Console.WriteLine("Current betting player: " + currentBettingPlayer);
            Console.WriteLine("Current betting player count: " + currentBettingPlayerCount);
        }

        public void betTurnListener(Object sender, EventArgs e){
            turnOffPlayers();
            betTurn();
        }

        public void turnOffPlayers(){
            this.turnCK1.BackColor = Color.Green;
            this.firstPbetRB.Visible = false;
            this.firstPCheckRB.Visible = false;
            this.firstPBetBtn.Visible = false;

            this.turnCK2.BackColor = Color.Green;
            this.secondPbetRB.Visible = false;
            this.secondPCheckRB.Visible = false;
            this.secondPBetBtn.Visible = false;

            this.turnCK3.BackColor = Color.Green;
            this.thirdPbetRB.Visible = false;
            this.thirdPCheckRB.Visible = false;
            this.thirdPBetBtn.Visible = false;

            this.turnCK4.BackColor = Color.Green;
            this.fourthPbetRB.Visible = false;
            this.fourthPCheckRB.Visible = false;
            this.fourthPBetBtn.Visible = false;

            this.turnCK5.BackColor = Color.Green;
            this.fifthPbetRB.Visible = false;
            this.fifthPCheckRB.Visible = false;
            this.fifthPBetBtn.Visible = false;

            this.turnCK6.BackColor = Color.Green;
            this.sixthPbetRB.Visible = false;
            this.sixthPCheckRB.Visible = false;
            this.sixthPBetBtn.Visible = false;

            this.turnCK7.BackColor = Color.Green;
            this.seventhPbetRB.Visible = false;
            this.seventhPCheckRB.Visible = false;
            this.seventhPBetBtn.Visible = false;

            this.turnCK8.BackColor = Color.Green;
            this.eighthPbetRB.Visible = false;
            this.eighthPCheckRB.Visible = false;
            this.eighthPBetBtn.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ////int count = 0;

            ////do
            ////{

            //    int num1 = 0;
            //    int num2 = 0;
            //    int num3 = 0;
            //    int num4 = 0;
            //    int num5 = 0;
            //    int num6 = 0;
            //    int num7 = 0;
            //    int[] testHandNums = new int[7];

            //    List<int> testDeck = new List<int>();

            //    for (int i = 1; i < 53; i++)
            //    {
            //        testDeck.Add(i);
            //    }

            //    String[] handInfo = new string[6];

            //    int randomNumber1;
            //    randomNumber1 = random.Next(1, testDeck.Count + 1) - 1;
            //    num1 = testDeck[randomNumber1];
            //    testHandNums[0] = num1;
            //    testDeck.Remove(num1);

            //    int randomNumber2;
            //    randomNumber2 = random.Next(1, testDeck.Count + 1) - 1;
            //    num2 = testDeck[randomNumber2];
            //    testHandNums[1] = num2;
            //    testDeck.Remove(num2);

            //    int randomNumber3;
            //    randomNumber3 = random.Next(1, testDeck.Count + 1) - 1;
            //    num3 = testDeck[randomNumber3];
            //    testHandNums[2] = num3;
            //    testDeck.Remove(num3);

            //    int randomNumber4;
            //    randomNumber4 = random.Next(1, testDeck.Count + 1) - 1;
            //    num4 = testDeck[randomNumber4];
            //    testHandNums[3] = num4;
            //    testDeck.Remove(num4);

            //    int randomNumber5;
            //    randomNumber5 = random.Next(1, testDeck.Count + 1) - 1;
            //    num5 = testDeck[randomNumber5];
            //    testHandNums[4] = num5;
            //    testDeck.Remove(num5);

            //    int randomNumber6;
            //    randomNumber6 = random.Next(1, testDeck.Count + 1) - 1;
            //    num6 = testDeck[randomNumber6];
            //    testHandNums[5] = num6;
            //    testDeck.Remove(num6);

            //    int randomNumber7;
            //    randomNumber7 = random.Next(1, testDeck.Count + 1) - 1;
            //    num7 = testDeck[randomNumber7];
            //    testHandNums[6] = num7;
            //    testDeck.Remove(num7);

            //    handInfo = hand.checkHand(testHandNums);

            //    testLblResult.Text = handInfo[0];

            //    testLbl1.Text = (testHandNums[0]).ToString();
            //    testLbl2.Text = (testHandNums[1]).ToString();
            //    testLbl3.Text = (testHandNums[2]).ToString();
            //    testLbl4.Text = (testHandNums[3]).ToString();
            //    testLbl5.Text = (testHandNums[4]).ToString();
            //    testLbl6.Text = (testHandNums[5]).ToString();
            //    testLbl7.Text = (testHandNums[6]).ToString();

            //    //count++;
            //    //eighthPPlayingLbl.Text = count.ToString();

            ////} while (testLblResult.Text != "Full House");
        }

        public void lblColors(String[] suits)
        {
        //    switch (suits[0])
        //    {
        //        case "spades":
        //            testLbl1.ForeColor = Color.Blue;
        //            break;
        //        case "clubs":
        //            testLbl1.ForeColor = Color.Purple;
        //            break;
        //        case "diamonds":
        //            testLbl1.ForeColor = Color.Yellow;
        //            break;
        //        case "hearts":
        //            testLbl1.ForeColor = Color.Red;
        //            break;
        //        default:
        //            break;
        //    }

        //    switch (suits[1])
        //    {
        //        case "spades":
        //            testLbl2.ForeColor = Color.Blue;
        //            break;
        //        case "clubs":
        //            testLbl2.ForeColor = Color.Purple;
        //            break;
        //        case "diamonds":
        //            testLbl2.ForeColor = Color.Yellow;
        //            break;
        //        case "hearts":
        //            testLbl2.ForeColor = Color.Red;
        //            break;
        //        default:
        //            break;
        //    }
        //    switch (suits[2])
        //    {
        //        case "spades":
        //            testLbl3.ForeColor = Color.Blue;
        //            break;
        //        case "clubs":
        //            testLbl3.ForeColor = Color.Purple;
        //            break;
        //        case "diamonds":
        //            testLbl3.ForeColor = Color.Yellow;
        //            break;
        //        case "hearts":
        //            testLbl3.ForeColor = Color.Red;
        //            break;
        //        default:
        //            break;
        //    }
        //    switch (suits[3])
        //    {
        //        case "spades":
        //            testLbl4.ForeColor = Color.Blue;
        //            break;
        //        case "clubs":
        //            testLbl4.ForeColor = Color.Purple;
        //            break;
        //        case "diamonds":
        //            testLbl4.ForeColor = Color.Yellow;
        //            break;
        //        case "hearts":
        //            testLbl4.ForeColor = Color.Red;
        //            break;
        //        default:
        //            break;
        //    }
        //    switch (suits[4])
        //    {
        //        case "spades":
        //            testLbl5.ForeColor = Color.Blue;
        //            break;
        //        case "clubs":
        //            testLbl5.ForeColor = Color.Purple;
        //            break;
        //        case "diamonds":
        //            testLbl5.ForeColor = Color.Yellow;
        //            break;
        //        case "hearts":
        //            testLbl5.ForeColor = Color.Red;
        //            break;
        //        default:
        //            break;
        //    }
        //    switch (suits[5])
        //    {
        //        case "spades":
        //            testLbl6.ForeColor = Color.Blue;
        //            break;
        //        case "clubs":
        //            testLbl6.ForeColor = Color.Purple;
        //            break;
        //        case "diamonds":
        //            testLbl6.ForeColor = Color.Yellow;
        //            break;
        //        case "hearts":
        //            testLbl6.ForeColor = Color.Red;
        //            break;
        //        default:
        //            break;
        //    }
        //    switch (suits[6])
        //    {
        //        case "spades":
        //            testLbl7.ForeColor = Color.Blue;
        //            break;
        //        case "clubs":
        //            testLbl7.ForeColor = Color.Purple;
        //            break;
        //        case "diamonds":
        //            testLbl7.ForeColor = Color.Yellow;
        //            break;
        //        case "hearts":
        //            testLbl7.ForeColor = Color.Red;
        //            break;
        //        default:
        //            break;
        //    }
        }
    }
}
