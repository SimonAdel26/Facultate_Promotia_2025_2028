namespace _6.PregatirePartial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declarare Matrice
            Random random = new Random();
            int n = 10, m = 8;
            int[,] matrix = new int[n, m];

            // Valori aleatorii
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = random.Next(1, 10);

            // Extindere + afisare
            matrix = Extindere(matrix);
            for (int i = 0; i < 2 * n - 1; i++)
            {
                for (int j = 0; j < 2 * m - 1; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(Factorial(5000));
        }

        // Calculati 5000!
        static BigNumber Factorial(int n)
        {
            if (n == 0 || n == 1)
                return new BigNumber(1);
            return new BigNumber(n) * Factorial(n - 1);
        }

        // Se da o matrice. Sa se extinda matricea, cu mediile aritmetice pe noile linii si coloane
        // Ex:
        /* 1 2
         * 3 4
         * Devine:
         * 1 1 2
         * 2 2 3
         * 3 3 4
         */
        static int[,] Extindere(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            // Cream matricea extinsa
            int[,] Matrix = new int[2 * n - 1, 2 * m - 1];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    // Adaugam valorile neschimbate
                    Matrix[2 * i, 2 * j] = matrix[i, j];
                    // si media aritmetica pe coloanele extinse
                    if (j > 0)
                    {
                        Matrix[2 * i, 2 * j - 1] = (matrix[i, j - 1] + matrix[i, j]) / 2;
                    }
                }

            // Adaugam media aritmetica pe liniile extinse
            for (int i = 1; i < 2 * n - 1; i += 2)
                for (int j = 0; j < 2 * m - 1; j++)
                {
                    Matrix[i, j] = (Matrix[i - 1, j] + Matrix[i + 1, j]) / 2;
                }
            return Matrix;
        }

        // "Patratul Magic" - creati o matrice a.i. sumele pe linii, coloane si diagonale sa fie egale

    }
}
