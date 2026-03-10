namespace _3.VectorFrecventa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Calea relativa catre fisier: mergem "inapoi" in directoare de 3 ori
            TextReader reader = new StreamReader("../../../TextLung.txt");
            // Citim tot textul din fisier intr-un string
            string text = reader.ReadToEnd();

            // Cream vectorul de frecventa pentru fiecare litera din alfabet
            string alfabet = "abcdefghijklmnopqrstuvwxyz";
            int[] frecventa = new int[alfabet.Length];

            // Parcurgem intreg textul pentru a construi vectorul de frecventa al acestuia
            for (int i = 0; i < text.Length; i++)
            {
                // Gasim indexul caracterului curent in alfabet
                // Ne asiguram ca numaram si literele mari, transformand caracterul curent in litera mica
                int index = alfabet.IndexOf(text[i].ToString().ToLower());

                // Daca este -1, inseamna ca nu s-a gasit (a fost whitespace sau punctuatie)
                if (index == -1)
                    continue;
                frecventa[index]++;
            }

            // maxBar decide care este numarul maxim de caractere '█' pentru afisarea unei bare intregi din bar chart
            int maxBar = 180;
            // maxFreq este folosit la calcul, pentru procentele fiecarei frecvente
            int maxFreq = frecventa.Max();

            for (int i = 0; i < frecventa.Length; i++)
            {
                Console.Write($"{i + 1}.\t{alfabet[i]} ->\t{frecventa[i]}\t");
                float percent = (float)frecventa[i] / maxFreq;

                // Repetam caracterul '█' folosind procentul frecventei curente, inmultit cu dimensiunea maxima a barei
                var bar = Enumerable.Repeat('█', (int)(percent * maxBar) + 1);

                // Inainte de afisare, schimbam culoarea textului (foreground, nu background) in functie de procent.
                // Acesta este un switch cu pattern matching, in care putem pune si conditii ca si in if, else if-uri
                Console.ForegroundColor = percent switch
                {
                    > 0.8f => ConsoleColor.DarkRed,
                    > 0.7f => ConsoleColor.Red,
                    > 0.5f => ConsoleColor.DarkYellow,
                    > 0.3f => ConsoleColor.Yellow,
                    > 0.2f => ConsoleColor.Green,
                    _ => ConsoleColor.DarkGreen,
                };

                // Folosind Join, lipim toate caracterele dintr-o colectie (array, lista etc) cu un separator
                // (in cazul asta, caracterul gol, pentru a fi o bara uniforma)
                Console.WriteLine(string.Join("", bar));
                Console.WriteLine();

                // La final, resetam culoarea pentru urmatoarea linie
                Console.ResetColor();
            }
            Console.WriteLine();

            // Insertion sort
            char[] characters = alfabet.ToCharArray();
            // Unul dintre for-uri trebuie sa aiba parcurgere inainte...
            for (int i = 1; i < frecventa.Length; i++)
                // Iar celalalt for trebuie sa aiba parcurgere inapoi pentru ca sortarea sa functioneze corect
                for (int j = i; j > 0; j--)
                {
                    // Dorim cele mai mari frecvente la inceput, deci comparam daca elementul de pe pozitia j
                    // este mai mare decat elementul de pe pozitia j - 1 (valorile cele mai mari trebuie pe pozitiile cele mai mici)
                    if (frecventa[j] > frecventa[j - 1])
                    {
                        // Swap pe vectorul frecventa
                        int aux = frecventa[j];
                        frecventa[j] = frecventa[j - 1];
                        frecventa[j - 1] = aux;

                        // Swap pe alfabet
                        char auxChar = characters[j];
                        characters[j] = characters[j - 1];
                        characters[j - 1] = auxChar;
                    }
                }

            // Afisam caracterele in ordinea descrescatoare a frecventei
            for (int i = 0; i < frecventa.Length; i++)
            {
                Console.WriteLine($"{i + 1}.\t{characters[i]} -> {frecventa[i]}");
            }
        }
    }
}
