using System.Collections.Generic;

// создаёт случайных врагов и предметы
static class Generator
{
    static string[] nazvaniyaOruzhiya = { "кинжал", "топор", "копьё", "булава", "меч" };
    static string[] nazvaniyaDospehov = { "щит", "кольчуга", "латы", "шлем", "роба" };

    public static Vrag SluchainyiVrag()
    {
        int n = Sluchai.Chislo(1, 3);
        if (n == 1)
        {
            return new Goblin();
        }
        if (n == 2)
        {
            return new Skelet();
        }
        return new Mag();
    }

    public static Vrag SluchainyiBoss()
    {
        List<Vrag> bossy = new List<Vrag>();
        bossy.Add(new VVG());
        bossy.Add(new Kovalsky());
        bossy.Add(new ArhimagCpp());
        bossy.Add(new PestovSMinus());
        return bossy[Sluchai.Chislo(0, bossy.Count - 1)];
    }

    public static Predmet SluchainyiPredmet()
    {
        int n = Sluchai.Chislo(1, 3);
        if (n == 1)
        {
            return new Zelie();
        }
        if (n == 2)
        {
            string imya = nazvaniyaOruzhiya[Sluchai.Chislo(0, nazvaniyaOruzhiya.Length - 1)];
            return new Oruzhie(imya, Sluchai.Chislo(8, 20));
        }
        string imyaDospeha = nazvaniyaDospehov[Sluchai.Chislo(0, nazvaniyaDospehov.Length - 1)];
        return new Dospekh(imyaDospeha, Sluchai.Chislo(2, 8));
    }
}
