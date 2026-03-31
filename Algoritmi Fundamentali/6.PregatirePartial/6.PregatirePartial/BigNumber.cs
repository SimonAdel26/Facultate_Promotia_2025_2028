namespace _6.PregatirePartial
{
    // O clasa este un nou tip de date definit de programator, adica
    // in loc de "int a" vom putea spune "BigNumber n"
    // Un obiect este "o instanta a unei clase", adica valoarea unei variabile de tipul unei clase
    // Adica in momentul initializarii, se creeaza un obiect nou folosind cuvantul cheie new: "n = new BigNumber()"
    // "public" este unul dintre modificatorii de acces care permite accesarea acestei clase din orice alt cod.
    // "internal" este un alt modificator de acces care nu permite accesarea codului din alt proiect.
    // "private" este modificatorul de acces care nu permite accesarea codului decat in clasa curenta
    // O clasa poate contine campuri, proprietati, metode, si metoda speciala constructor.
    // De inceput, vom lucra doar cu campuri, dar proprietatile s-ar folosi similar, si ajuta la incapsulare
    public class BigNumber
    {
        // Daca nu punem niciun modificator de acces in fata, atunci campul va fi "private" in mod implicit
        //List<int> digits;
        private List<int> digits;
        public int length;

        // Constructorul se apeleaza automat la crearea unui obiect, adica atunci cand spunem "new BigNumber()"
        // Orice clasa are un constructor implicit fara parametri, dar acesta poate fi definit (si practic suprascris)
        // pentru a realiza initializarea corecta a obiectului. Pe langa asta, putem avea mai multi constructori,
        // pentru diferitele cazuri de initializare pe care le avem
        public BigNumber()
        {
            length = 0;
            digits = [];
        }
        public BigNumber(int original)
        {
            digits = new List<int>();
            while (original > 0)
            {
                Add(original % 10);
                original /= 10;
            }
            digits.Reverse();
        }
        // De regula, un constructor primeste direct campurile si proprietatile de care are nevoie. Cand exista
        // coincidenta de nume, pentru a deosebi variabilele, se foloseste cuvantul cheie "this"
        // "this" se refera la "this object", iar in momentul cand icem "digits", ne referim la cea mai recenta
        // declaratie a variabilei cu acest nume, adica cel din constructor direct.
        // Deci "this.digits" se refera la campul clasei, pentru "acest obiect" (this object)
        public BigNumber(List<int> digits, int length)
        {
            // operatorul [.. array] creeaza o copie a array-ului, deci nu avem probleme cu referintele
            // daca am zice pur si simplu "copy = array", si modificam copia,
            // defapt se modifica si originalul, pentru ca sunt de tip referinta
            this.digits = [.. digits];
            // Echivalent:
            // this.digits = new List<int>();
            // foreach (int digit in digits)
            //     this.digits.Add(digit);

            this.length = length;
        }

        // Daca dorim sa accesam cifrele numarului mai usor decat prin "number.digits[i]", putem defini un indexator
        // pentru a putea scurta si a scrie "number[i]"
        // "private set" inseamna ca, folosind indexatorul, putem face "set" (modificare) doar in interiorul clasei
        public int this[int index]
        {
            get { return digits[index]; }
            private set { digits[index] = value; }
        }

        // Clasele definite de programator au un numar limitat de operatori cu definitii existente,
        // de aceea se pot suprascrie operatorii pentru usurinta in scriere. De exemplu, in loc sa facem metoda Suma(),
        // vom suprascrie operatorul +
        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            BigNumber result = new BigNumber();

            // Pasul 1. Facem reverse la cele 2 numere, pentru a aduna incepand cu ultimele cifre
            a.Reverse();
            b.Reverse();

            // Pasul 2. Adunam cifrele partii comune
            int minim = Math.Min(a.length, b.length);
            for (int i = 0; i < minim; i++)
            {
                result.Add(a[i] + b[i]);
            }

            // Pasul 3. Adaugam cifrele numarului cel mai lung
            for (int i = minim; i < a.length; i++)
            {
                result.Add(a[i]);
            }
            for (int i = minim; i < b.length; i++)
            {
                result.Add(a[i]);
            }

            // Pasul 4. Ne asiguram ca fiecare digit este defapt digit
            for (int i = 0; i < result.length; i++)
            {
                if (result[i] > 10)
                {
                    int carry = result[i] / 10;
                    result[i] %= 10;
                    if (i == result.length - 1 && carry > 0)
                    {
                        result.Add(carry);
                    }
                    else
                    {
                        result[i + 1] += carry;
                    }
                }
            }

            result.Reverse();
            return result;
        }

        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            BigNumber result = new BigNumber();

            // Pasul 1. Ne asiguram ca stim care este cel mai scurt numar
            if (a.length < b.length)
            {
                BigNumber temp = a;
                a = b;
                b = temp;
            }

            // Pasul 2. Cream o lista de produse partiale
            List<BigNumber> partials = new List<BigNumber>();
            for (int i = 0; i < b.length; i++)
            {
                BigNumber copy = new BigNumber(a.digits, a.length);

                for (int j = 0; j < copy.length; j++)
                {
                    copy[j] *= b[i];
                }
                // Adaugam cate 0-uri trebuie in functie de pozitia cifrei din b
                for (int j = 0; j < b.length - i - 1; j++)
                {
                    copy.Add(0);
                }

                partials.Add(copy);
            }

            // Pasul 3. Adunam produsele partiale
            result = partials[0];
            for (int i = 1; i < partials.Count; i++)
            {
                result += partials[i];
            }

            return result;
        }

        // Helper functions
        public void Reverse()
        {
            digits.Reverse();
        }
        public void Add(int digit)
        {
            digits.Add(digit);
            length++;
        }
        public override string ToString()
        {
            string result = String.Empty;
            for (int i = 0; i < length; i++)
                result += this[i];
            return result;
        }
    }
}
