using System;

interface IBoss
{
}


abstract class Vrag
{
    public string Imya { get; protected set; }
    public int Zdorovie { get; protected set; }
    public int Ataka { get; protected set; }
    public int Zashchita { get; protected set; }

    public bool Zhiv
    {
        get { return Zdorovie > 0; }
    }

    public void PoluchitUron(int uron)
    {
        Zdorovie -= uron;
        if (Zdorovie < 0)
        {
            Zdorovie = 0;
        }
    }

  
    public virtual int RasschitatUron()
    {
        return Ataka;
    }

   
    public virtual int ZashchitaIgroka(Igrok igrok)
    {
        return igrok.TekushceiDospekh.Zashchita;
    }

  
    public virtual void Osobennost(Igrok igrok)
    {
    }
}

//гоблин крит
class Goblin : Vrag
{
    public const int BazZdorovie = 24;
    public const int BazAtaka = 6;
    public const int BazZashchita = 0;
    public const int BazShansKrita = 15;

    protected int shansKrita;

    public Goblin()
    {
        Imya = "гоблин";
        Zdorovie = BazZdorovie;
        Ataka = BazAtaka;
        Zashchita = BazZashchita;
        shansKrita = BazShansKrita;
    }

    public override int RasschitatUron()
    {
        if (Sluchai.Ekzemplyar.Shans(shansKrita))
        {
            Console.WriteLine("критический удар!");
            return Ataka * 2;
        }
        return Ataka;
    }
}

//скелет игнор защиты
class Skelet : Vrag
{
    public const int BazZdorovie = 25;
    public const int BazAtaka = 9;
    public const int BazZashchita = 1;

    public Skelet()
    {
        Imya = "скелет";
        Zdorovie = BazZdorovie;
        Ataka = BazAtaka;
        Zashchita = BazZashchita;
    }

    public override int ZashchitaIgroka(Igrok igrok)
    {
        return 0;
    }
}

//маг заморозка
class Mag : Vrag
{
    public const int BazZdorovie = 20;
    public const int BazAtaka = 10;
    public const int BazZashchita = 0;
    public const int BazShansZamorozki = 25;

    protected int shansZamorozki;

    public Mag()
    {
        Imya = "маг";
        Zdorovie = BazZdorovie;
        Ataka = BazAtaka;
        Zashchita = BazZashchita;
        shansZamorozki = BazShansZamorozki;
    }

    public override void Osobennost(Igrok igrok)
    {
        if (Sluchai.Ekzemplyar.Shans(shansZamorozki))
        {
            igrok.Zamorozhen = true;
            Console.WriteLine("ты заморожен!");
        }
    }
}

//боссы

class VVG : Goblin, IBoss
{
    public VVG()
    {
        Imya = "ввг";
        Zdorovie = (int)(Goblin.BazZdorovie * 2.0);
        Ataka = (int)(Goblin.BazAtaka * 1.5);
        Zashchita = (int)(Goblin.BazZashchita * 1.2);
        shansKrita = Goblin.BazShansKrita + 10;
    }
}

class Kovalsky : Skelet, IBoss
{
    public Kovalsky()
    {
        Imya = "ковальский";
        Zdorovie = (int)(Skelet.BazZdorovie * 2.5);
        Ataka = (int)(Skelet.BazAtaka * 1.3);
        Zashchita = (int)(Skelet.BazZashchita * 1.4);
    }
}

class ArhimagCpp : Mag, IBoss
{
    public ArhimagCpp()
    {
        Imya = "архимаг c++";
        Zdorovie = (int)(Mag.BazZdorovie * 1.8);
        Ataka = (int)(Mag.BazAtaka * 1.6);
        Zashchita = (int)(Mag.BazZashchita * 1.1);
        shansZamorozki = Mag.BazShansZamorozki + 10;
    }
}

class PestovSMinus : Skelet, IBoss
{
    public PestovSMinus()
    {
        Imya = "пестов с--";
        Zdorovie = (int)(Skelet.BazZdorovie * 1.3);
        Ataka = (int)(Skelet.BazAtaka * 1.8);
        Zashchita = (int)(Skelet.BazZashchita * 0.6);
    }
}
