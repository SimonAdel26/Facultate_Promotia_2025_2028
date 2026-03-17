namespace ParcurgereMatrici
{
    public partial class Form1 : Form
    {
        Color[] colors = [
            Color.White,
            Color.Red,
            Color.OrangeRed,
            Color.Orange,
            Color.Yellow,
            Color.YellowGreen,
            Color.Green,
            Color.Blue,
            Color.Indigo,
            Color.BlueViolet
        ];
        Point colorsStartLocation = new Point(887, 733);
        Button[] colorButtons;
        PictureBox[,] matrix = new PictureBox[0, 0];

        public Form1()
        {
            InitializeComponent();
            colorButtons = new Button[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                Button button = new Button();
                button.Parent = this;

                button.Size = new Size(50, 50);
                button.Location = new Point(colorsStartLocation.X + i * 55, colorsStartLocation.Y);
                button.BackColor = colors[i];

                button.Click += ColorButton_Click;
                colorButtons[i] = button;
            }

            Random random = new Random();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 10; j++)
                {
                    matrixRotation[i, j] = random.Next(colors.Length);
                }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                int index = Array.IndexOf(colorButtons, sender as Button);
                colors[index] = colorPicker.Color;
                (sender as Button).BackColor = colorPicker.Color;
            }
        }

        // Clear
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j].Parent = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j].Parent = null;

            string[][] textBoxText = new string[textBox1.Lines.Length][];
            for (int i = 0; i < textBox1.Lines.Length; i++)
                textBoxText[i] = textBox1.Lines[i].Split(' ');

            int n = textBoxText.Length;
            int m = textBoxText[0].Length;
            matrix = new PictureBox[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = new PictureBox();
                    matrix[i, j].Parent = pictureBox1;

                    int sizeX = pictureBox1.Width / m, sizeY = pictureBox1.Height / n;
                    matrix[i, j].Size = new Size(sizeX, sizeY);
                    matrix[i, j].Location = new Point(j * sizeX, i * sizeY);

                    int index = int.Parse(textBoxText[i][j]) % colors.Length;
                    matrix[i, j].BackColor = colors[index];
                }
        }

        private void AddMatrixToTextBox(int[,] matrix, int n, int m)
        {
            textBox1.Text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1; j++)
                    textBox1.Text += matrix[i, j] + " ";
                textBox1.Text += matrix[i, m - 1];
                if (i < n - 1)
                    textBox1.Text += Environment.NewLine;
            }
        }

        // Mijloace
        private void button2_Click(object sender, EventArgs e)
        {
            int n = 11;
            int[,] matrix = new int[n, n];

            /*for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == n / 2 || j == n / 2)
                        matrix[i, j] = 1;
                }
            */
            // Mai simplu: parcurgem doar cat este nevoie, si modificam indicii
            for (int i = 0; i < n; i++)
            {
                matrix[i, n / 2] = 1;
                matrix[n / 2, i] = 1;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        // Diagonale
        private void button3_Click(object sender, EventArgs e)
        {
            int n = 19;
            int[,] matrix = new int[n, n];

            /*for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == j || i + j == n - 1)
                        matrix[i, j] = 1;
                }
            */
            // Mai simplu: parcurgem doar cat este nevoie, si modificam indicii
            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = 1;
                matrix[i, n - i - 1] = 1;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        // Mijloace si diagonale
        private void button6_Click(object sender, EventArgs e)
        {
            int n = 19;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                matrix[i, n / 2] = 1;
                matrix[n / 2, i] = 1;
                matrix[i, i] = 1;
                matrix[i, n - i - 1] = 1;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        // NSEV
        private void button5_Click(object sender, EventArgs e)
        {
            int n = 19;
            int[,] matrix = new int[n, n];

            /*for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // Nord: deasupra diagonalei principale si deasupra celei secundare
                    if (i > j && i + j < n - 1)
                    {
                        matrix[i, j] = 1;
                    }
                    // Est: deasupra diagonalei principale si sub cea secundara
                    else if (i > j && i + j > n - 1)
                    {
                        matrix[i, j] = 4;
                    }
                    // Sud: sub diagonala principala si sub cea secundara
                    else if (i < j && i + j > n - 1)
                    {
                        matrix[i, j] = 6;
                    }
                    // Vest: sub diagonala principala si deasupra celei secundare
                    else if (i < j && i + j < n - 1)
                    {
                        matrix[i, j] = 7;
                    }
                }
            */
            // Mai simplu / scurt: parcurgem doar cat este nevoie, si folosim indicii adecvati
            for (int i = 0; i < n / 2; i++)
                for (int j = i + 1; j < n - i - 1; j++)
                {
                    matrix[i, j] = 1;           // Nord
                    matrix[j, n - i - 1] = 4;   // Est
                    matrix[n - i - 1, j] = 6;   // Sud
                    matrix[j, i] = 7;           // Vest
                }

            AddMatrixToTextBox(matrix, n, n);
        }

        // Rotire 90 grade
        int[,] matrixRotation = new int[5, 10];
        private void button8_Click(object sender, EventArgs e)
        {
            int n = 5;
            int[,] matrix = new int[2 * n, n];

            // Generam o matrice
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = i + j + 1;
                    matrix[n + i, j] = i + j + 1;
                }

            // Punem valorile rotite cu 90 de grade spre dreapta in matrixRotation
            for (int i = 0; i < 2 * n; i++)
                for (int j = 0; j < n; j++)
                {
                    // coltul din stanga sus trebuie sa ajunga in coltul din dreapta sus,
                    // cel din dreapta sus, in dreapta jos,
                    // cel din dreapta jos, in stanga jos, etc.
                    matrixRotation[j, 2 * n - i - 1] = matrix[i, j];
                }

            AddMatrixToTextBox(matrixRotation, n, 2 * n);
        }

        // Spirala
        private void button4_Click(object sender, EventArgs e)
        {
            int n = 12;
            int[,] matrix = new int[n, n];
            int value = 1;

            // Chenar: parcurgem prima linie, ultima coloana, ultima linie, prima coloana
            // Spirala: mai adaugam un for cu k de la 0 pana la n/2, iar in codul interior,
            // in loc de 0 scriem k, iar in loc de n-1 scriem n-k-1
            for (int k = 0; k < n / 2; k++)
            {
                for (int i = k; i < n - k - 1; i++)
                    matrix[k, i] = value;
                value++;

                for (int i = k; i < n - k - 1; i++)
                    matrix[i, n - k - 1] = value;
                value++;

                for (int i = k; i < n - k - 1; i++)
                    matrix[n - k - 1, n - i - 1] = value;
                value++;

                for (int i = k; i < n - k - 1; i++)
                    matrix[n - i - 1, k] = value;
                value++;
            }

            AddMatrixToTextBox(matrix, n, n);
        }

        // Serpuit
        private void button7_Click(object sender, EventArgs e)
        {
            // La curs: se ia in considerare diagonala secundara, si se aduna i si j. Daca suma lor este para,
            // atunci elementele de pe acea diagonala sunt parcurse de sus in jos, altfel, de jos in sus

            // Noi folosim un bool care isi tot inverseaza valoarea, pentru a ne asigura ca parcurgem in directia buna
            int value = 0;
            int n = 13;
            int[,] matrix = new int[n, n];
            bool upDirection = true;

            for (int diagonalSize = 1; diagonalSize <= n; diagonalSize++)
            {
                if (upDirection)
                    TraverseUpwards(matrix, diagonalSize, value);
                else
                    TraverseDownwards(matrix, diagonalSize, value);

                value++;
                upDirection = !upDirection;
            }

            for (int diagonalSize = n - 1; diagonalSize > 0; diagonalSize--)
            {
                if (upDirection)
                    TraverseUpwards(matrix, diagonalSize, value, true);
                else
                    TraverseDownwards(matrix, diagonalSize, value, true);

                value++;
                upDirection = !upDirection;
            }

            AddMatrixToTextBox(matrix, n, n);
        }
        private void TraverseUpwards(int[,] matrix, int diagonalSize, int value, bool isSecondHalf = false)
        {
            int i = diagonalSize - 1;
            int j = 0;
            if (isSecondHalf)
            {
                i = matrix.GetLength(0) - 1;
                j = matrix.GetLength(1) - diagonalSize;
            }

            while (diagonalSize > 0)
            {
                matrix[i, j] = value;
                i--; j++;
                diagonalSize--;
            }
        }
        private void TraverseDownwards(int[,] matrix, int diagonalSize, int value, bool isSecondHalf = false)
        {
            int i = 0;
            int j = diagonalSize - 1;
            if (isSecondHalf)
            {
                i = matrix.GetLength(0) - diagonalSize;
                j = matrix.GetLength(1) - 1;
            }

            while (diagonalSize > 0)
            {
                matrix[i, j] = value;
                i++; j--;
                diagonalSize--;
            }
        }
    }
}
