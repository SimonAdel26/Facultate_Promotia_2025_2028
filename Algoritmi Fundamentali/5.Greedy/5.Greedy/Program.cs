namespace _5.Greedy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Transformarea unui numar intreg in numar roman
            string[] roman = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"];
            int[] value = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1];

            int number = int.Parse(Console.ReadLine());
            string result = string.Empty;   // Echivalent cu ""
            for (int i = 0; i < roman.Length; i++)
            {
                while (number >= value[i])
                {
                    result += roman[i];
                    number -= value[i];
                }
            }

            Console.WriteLine(result);
            // Transformarea unui numar roman in numar intreg
            number = 0;
            int index = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                while (index <= result.Length - roman[i].Length
                    && result.Substring(index, roman[i].Length) == roman[i])
                {
                    number += value[i];
                    index += roman[i].Length;
                }
            }

            Console.WriteLine(number);

            // Problema spectacolelor
            Spectacol[] spectacole = [
                new Spectacol(1, 4),    // 1
                new Spectacol(3, 5),
                new Spectacol(0, 6),
                new Spectacol(5, 7),    // 2
                new Spectacol(3, 9),
                new Spectacol(5, 9),
                new Spectacol(6, 10),
                new Spectacol(8, 11),   // 3
                new Spectacol(8, 12),
                new Spectacol(2, 14),
                new Spectacol(12, 16)   // 4
            ];

            // Sortam dupa final
            Array.Sort(spectacole, (a, b) => a.final.CompareTo(b.final));
            int count = 1;
            Spectacol ultimul = spectacole[0];
            Console.Write(ultimul);

            for (int i = 1; i < spectacole.Length; i++)
            {
                if (spectacole[i].inceput >= ultimul.final)
                {
                    count++;
                    ultimul = spectacole[i];
                    Console.Write(ultimul);
                }
            }

            Console.WriteLine(count);
        }
    }
}
