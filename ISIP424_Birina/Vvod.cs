using System;

static class Vvod
{
    public static int Vybor(string podskazka, int min, int max)
    {
        while (true)
        {
            Console.Write(podskazka + ": ");
            string tekst = Console.ReadLine();
            int chislo;
            if (int.TryParse(tekst, out chislo) && chislo >= min && chislo <= max)
            {
                return chislo;
            }
            Console.WriteLine("неверный ввод");
        }
    }
}
