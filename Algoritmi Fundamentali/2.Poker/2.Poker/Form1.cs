namespace _2.Poker
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;

        public Form1()
        {
            InitializeComponent();
            Instance = this;
            pictureBox1.BackgroundImage = Image.FromFile("../../../Images/BackCard.png");
            Engine.Initiaize();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

            await Engine.DealAllCards();

            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Selectam cartile pentru Player1: primele 5 din cele 10 "trase" din pachet
            int index = 0;
            Card[] cards = new Card[]
            {
                Engine.cards[Engine.cardsOrder[index]],
                Engine.cards[Engine.cardsOrder[index + 1]],
                Engine.cards[Engine.cardsOrder[index + 2]],
                Engine.cards[Engine.cardsOrder[index + 3]],
                Engine.cards[Engine.cardsOrder[index + 4]],
            };

            // Calculam scorul pentru Player1: Intai apelam cea mai putin probabila combinatie
            int player1Score = Flush(cards);
            // Iar daca rezultatul e -1, stim ca acea combinatie nu s-a realizat si o incercam pe urmatoarea
            if (player1Score == -1) player1Score = Straight(cards);
            if (player1Score == -1) player1Score = ThreeOfAKind(cards);
            if (player1Score == -1) player1Score = TwoPairs(cards);
            if (player1Score == -1) player1Score = OnePair(cards);
            if (player1Score == -1) player1Score = HighCard(cards);

            // Selectam cartile pentru Player2: urmatoarele 5 carti, deci pornim de la index = 5, si putem refolosi vectorul
            index = 5;
            cards[0] = Engine.cards[Engine.cardsOrder[index]];
            cards[1] = Engine.cards[Engine.cardsOrder[index + 1]];
            cards[2] = Engine.cards[Engine.cardsOrder[index + 2]];
            cards[3] = Engine.cards[Engine.cardsOrder[index + 3]];
            cards[4] = Engine.cards[Engine.cardsOrder[index + 4]];

            // Calculam scorul pentru Player2 in acelasi mod
            int player2Score = Flush(cards);
            if (player2Score == -1) player2Score = Straight(cards);
            if (player2Score == -1) player2Score = ThreeOfAKind(cards);
            if (player2Score == -1) player2Score = TwoPairs(cards);
            if (player2Score == -1) player2Score = OnePair(cards);
            if (player2Score == -1) player2Score = HighCard(cards);

            // Verificam cine a castigat (nu avem situatie de egalitate, dar o puteti adauga daca doriti, sau
            // puteti face codul asa incat sa functionee exact ca si jocul)
            if (player1Score > player2Score)
                MessageBox.Show($"Player1: {player1Score}{Environment.NewLine}" +
                    $"Player2: {player2Score}", "Player1 has Won!");
            else
                MessageBox.Show($"Player1: {player1Score}{Environment.NewLine}" +
                    $"Player2: {player2Score}", "Player2 has Won!");
        }

        int HighCard(Card[] cards)
        {
            int max = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].Number > max)
                    max = cards[i].Number;
            }
            return max;
        }

        int OnePair(Card[] cards)
        {
            int number = 0;
            for (int i = 0; i < cards.Length - 1; i++)
                for (int j = i + 1; j < cards.Length; j++)
                {
                    if (cards[i].Number == cards[j].Number)
                    {
                        number = cards[i].Number;
                    }
                }
            if (number == 0)
                return -1;
            return 100 + number;
        }

        int TwoPairs(Card[] cards)
        {
            int max = OnePair(cards);
            if (max == -1)
                return -1;

            int number = max % 100;
            var list = cards.ToList(); // Transformam vectorul in lista (care are dimensiune dinamica)
            list.RemoveAll(c => c.Number == number); // Scoatem cartile din perechea precedenta
            number = OnePair(list.ToArray()); // Verificam daca mai exista inca o pereche

            if (number == -1)
                return -1;
            if (number > max)
                max = number;
            return 100 + max; // max e din intervalul [100, 200) => scorul e din intervalul [200, 300)
        }

        int ThreeOfAKind(Card[] cards)
        {
            int number = 0;
            for (int i = 0; i < cards.Length - 2; i++)
                for (int j = i + 1; j < cards.Length - 1; j++)
                    for (int k = j + 1; k < cards.Length; k++)
                    {
                        if (cards[i].Number == cards[j].Number && cards[i].Number == cards[k].Number)
                        {
                            number = cards[i].Number;
                        }
                    }
            if (number == 0)
                return -1;
            return 300 + number;
        }

        int Straight(Card[] cards)
        {
            // Insertion sort
            for (int i = 1; i < cards.Length; i++)
                for (int j = i; j > 0; j--)
                {
                    if (cards[j].Number < cards[j - 1].Number)
                    {
                        // Swap, folosind "cele trei pahare"
                        Card pahar3 = cards[j];
                        cards[j] = cards[j - 1];
                        cards[j - 1] = pahar3;
                    }
                }

            // In situatia in care avem as, acesta poate lua si valoare "1" in combinatie cu 2, 3, 4, 5
            if (cards[cards.Length - 1].Number == 14 && cards[0].Number == 2)
            {
                Card ace = cards[cards.Length - 1];
                for (int i = cards.Length - 1; i > 0; i--)
                {
                    cards[i] = cards[i - 1];
                }
                cards[0] = ace;
                cards[0].Number = 1;
            }

            // Verificam daca numerele sunt consecutive
            for (int i = 0; i < cards.Length - 1; i++)
                if (cards[i + 1].Number - cards[i].Number != 1)
                    return -1;
            return 400 + cards[cards.Length - 1].Number; // Scorul este dat de numarul cartii cu valoarea cea mai mare
        }

        int Flush(Card[] cards)
        {
            for (int i = 1; i < cards.Length; i++)
                if (cards[i].Suit != cards[0].Suit)
                    return -1;
            return 500 + HighCard(cards);
        }

        public PictureBox CreatePictureBoxForNewCard()
        {
            PictureBox card = new PictureBox();
            card.Parent = this;
            card.BackgroundImage = pictureBox1.BackgroundImage;
            card.Location = pictureBox1.Location;
            card.Size = pictureBox1.Size;
            card.BackgroundImageLayout = pictureBox1.BackgroundImageLayout;

            card.BringToFront();
            return card;
        }
    }
}
