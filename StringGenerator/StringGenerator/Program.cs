namespace StringGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ScreamGenerator());
            Console.WriteLine(ScreamGenerator());
            Console.WriteLine(ScreamGenerator());
            Console.WriteLine(ScreamGenerator());
        }

        static string ScreamGenerator()
        {
            Random rnd = new();
            int rdm = rnd.Next(6, 30);
            string retour = "";

            for (int i = 0; i < rdm; i++)
            {
                retour += 'A';
            }

            retour += 'H';
            rdm /= 4;

            for (int i = 0; i < rdm; i++)
            {
                retour += '!';
            }

            return retour;
        }
    }
}