namespace _1.IntroducereWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
        }

        Bitmap bitmap;
        Graphics graphics;

        private void button1_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            // Pentru a desena o linie, trebuie sa ii dam codului punctul initial si cel final
            graphics.DrawLine(new Pen(Color.Blue, 3), new Point(50, 50), new Point(500, 500));

            // Pentru a desena un cerc, folosim metoda "Ellipse", care defapt ne permite desenarea oricarui oval.
            // Pentru a fi cerc, dimensiunile, latime si inaltime, vor fi egale.
            // Mai trebuie atribuit si punctul din stanga-sus al "chenarului" (patratului) in care se inscrie cercul.
            graphics.DrawEllipse(new Pen(Color.Blue, 3), 100, 50, 50, 50);

            // Haideti sa incepem din centrul cercului: pentru x-ul si y-ul coltului din stanga sus,
            // scadem jumatate din dimensiune
            int size = 100;
            Point center = new Point(300, 200);
            graphics.DrawEllipse(new Pen(Color.Blue, 3), center.X - size / 2, center.Y - size / 2, size, size);

            // Desenam si centrul pentru verificare
            graphics.DrawEllipse(new Pen(Color.Red, 2), center.X - 1, center.Y - 1, 3, 3);

            // putem desena orice poligon folosind metoda DrawPolygon care primeste o lista de puncte,
            // reprezentand colturile poligonului
            graphics.DrawPolygon(new Pen(Color.DarkViolet, 3), new Point[] { new Point(300, 50), new Point(400, 150), new Point(350, 400) });

            // Fiecare metoda de "draw" are si versiunea "fill", pentru umplerea formei. Pentru aceasta, 
            // avem nevoie de Brush in loc de Pen
            graphics.FillEllipse(new SolidBrush(Color.ForestGreen), 500, 50, 200, 200);
            graphics.DrawEllipse(new Pen(Color.Brown, 3), 500, 50, 200, 200);

            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            // Next(n) da valori la intamplare intre 0 si n-1, in caul Next(3) avem 0, 1 sau 2
            int shape = random.Next(3);

            // O culoare este formata din 3 culori compo nente: rosu, verde si albastru.
            // Practic ii spunem calculatorului cat de intens este aprins beculetul component
            // de acea culoare din fiecare pixel din ecran
            Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            // Next(a, b) da valori la intamplare de la a pana la b-1, in cazul acesta, 1, 2, ..., 9
            int thickness = random.Next(1, 10);
            Pen pen = new Pen(color, thickness);

            Color fill = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            Brush brush = new SolidBrush(fill);

            int centerX, centerY;

            switch (shape)
            {
                case 0: // Desenam o Linie
                    // Dorim ca punctele sa fie alese de oriunde de pe ecran
                    Point p1 = new Point(random.Next(pictureBox1.Width), random.Next(pictureBox1.Height));
                    Point p2 = new Point(random.Next(pictureBox1.Width), random.Next(pictureBox1.Height));
                    graphics.DrawLine(pen, p1, p2);
                    break;
                case 1: // Desenam un cerc
                    int size = random.Next(50, 200);
                    // Dorim ca forma sa nu iasa din ecran, asa ca centrul cercului va depinde de size
                    centerX = random.Next(size / 2, pictureBox1.Width - size / 2);
                    centerY = random.Next(size / 2, pictureBox1.Height - size / 2);

                    graphics.FillEllipse(brush, centerX - size / 2, centerY - size / 2, size, size);
                    graphics.DrawEllipse(pen, centerX - size / 2, centerY - size / 2, size, size);
                    graphics.DrawEllipse(pen, centerX - 1, centerY - 1, 3, 3); // Desenam si punctul centrului cercului
                    break;
                case 2:
                    int n = random.Next(3, 10);
                    Point[] points = new Point[n];
                    centerX = 0;
                    centerY = 0;
                    for (int i = 0; i < n; i++)
                    {
                        points[i] = new Point(random.Next(pictureBox1.Width), random.Next(pictureBox1.Height));
                        centerX += points[i].X;
                        centerY += points[i].Y;
                    }
                    centerX /= n;
                    centerY /= n;

                    graphics.FillPolygon(brush, points);
                    graphics.DrawPolygon(pen, points);
                    // Desenam centrul de greutate al poligonului
                    graphics.DrawEllipse(pen, centerX - 1, centerY - 1, 3, 3);
                    break;
            }

            pictureBox1.Image = bitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            graphics.Clear(Color.White);

            pictureBox1.Image = bitmap;
        }
    }
}
