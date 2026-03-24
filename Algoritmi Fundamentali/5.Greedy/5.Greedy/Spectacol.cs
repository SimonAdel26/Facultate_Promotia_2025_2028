namespace _5.Greedy
{
    public class Spectacol
    {
        public float inceput;
        public float final;

        public Spectacol(float inceput, float final)
        {
            this.inceput = inceput;
            this.final = final;
        }

        public override string ToString()
        {
            return $"({inceput}, {final}) ";
        }
    }
}
