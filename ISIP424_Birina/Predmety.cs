using System;


abstract class Predmet
{
    public string Nazvanie { get; private set; }

    protected Predmet(string nazvanie)
    {
        Nazvanie = nazvanie;
    }

   
    public abstract void Poluchit(Igrok igrok);
}

class Oruzhie : Predmet
{
    public int Ataka { get; private set; }

    public Oruzhie(string nazvanie, int ataka) : base(nazvanie)
    {
        Ataka = ataka;
    }

    public override string ToString()
    {
        return Nazvanie + " (атака " + Ataka + ")";
    }

    public override void Poluchit(Igrok igrok)
    {
        Console.WriteLine("найдено оружие: " + this);
        Console.WriteLine("сейчас: " + igrok.TekushceeOruzhie);
        int vybor = Vvod.Vybor("1 - взять, 2 - выбросить", 1, 2);
        if (vybor == 1)
        {
            igrok.TekushceeOruzhie = this;
            Console.WriteLine("оружие заменено");
        }
        else
        {
            Console.WriteLine("оружие выброшено");
        }
    }
}

class Dospekh : Predmet
{
    public int Zashchita { get; private set; }

    public Dospekh(string nazvanie, int zashchita) : base(nazvanie)
    {
        Zashchita = zashchita;
    }

    public override string ToString()
    {
        return Nazvanie + " (защита " + Zashchita + ")";
    }

    public override void Poluchit(Igrok igrok)
    {
        Console.WriteLine("найдены доспехи: " + this);
        Console.WriteLine("сейчас: " + igrok.TekushceiDospekh);
        int vybor = Vvod.Vybor("1 - взять, 2 - выбросить", 1, 2);
        if (vybor == 1)
        {
            igrok.TekushceiDospekh = this;
            Console.WriteLine("доспехи заменены");
        }
        else
        {
            Console.WriteLine("доспехи выброшены");
        }
    }
}

class Zelie : Predmet
{
    public Zelie() : base("лечебное зелье")
    {
    }

    public override void Poluchit(Igrok igrok)
    {
        igrok.Vylechit();
        Console.WriteLine("найдено зелье, здоровье восстановлено");
    }
}
