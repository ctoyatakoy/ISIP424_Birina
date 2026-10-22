using System;

interface IBoss
{
}


abstract class Vrag
{
    public string Imya { get; private set; }
    public int Zdorovie { get; private set; }
    public int Ataka { get; private set; }
    public int Zashchita { get; private set; }

    public bool Zhiv
    {
        get { return Zdorovie > 0; }
    }

    protected Vrag(string imya, int zdorovie, int ataka, int zashchita)
    {
        Imya = imya;
        Zdorovie = zdorovie;
        Ataka = ataka;
        Zashchita = zashchita;
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

    //защита игрока учитывается
    public virtual int ZashchitaIgroka(Igrok igrok)
    {
        return igrok.TekushceiDospekh.Zashchita;
    }

    //эффект после попадания
    public virtual void Osobennost(Igrok igrok)
    {
    }
}

//гоблин крит
class Goblin : Vrag
{
    public const int BazZdorovie = 30;
    public const int BazAtaka = 8;
    public const int BazZashchita = 2;
    public const int BazShansKrita = 20;

    int shansKrita;

    public Goblin() : this("гоблин", BazZdorovie, BazAtaka, BazZashchita, BazShansKrita)
    {
    }

    protected Goblin(string imya, int zdorovie, int ataka, int zashchita, int shansKrita)
        : base(imya, zdorovie, ataka, zashchita)
    {
        this.shansKrita = shansKrita;
    }

    public override int RasschitatUron()
    {
        if (Sluchai.Shans(shansKrita))
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

    public Skelet() : this("скелет", BazZdorovie, BazAtaka, BazZashchita)
    {
    }

    protected Skelet(string imya, int zdorovie, int ataka, int zashchita)
        : base(imya, zdorovie, ataka, zashchita)
    {
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

    int shansZamorozki;

    public Mag() : this("маг", BazZdorovie, BazAtaka, BazZashchita, BazShansZamorozki)
    {
    }

    protected Mag(string imya, int zdorovie, int ataka, int zashchita, int shansZamorozki)
        : base(imya, zdorovie, ataka, zashchita)
    {
        this.shansZamorozki = shansZamorozki;
    }

    public override void Osobennost(Igrok igrok)
    {
        if (Sluchai.Shans(shansZamorozki))
        {
            igrok.Zamorozhen = true;
            Console.WriteLine("ты заморожен!");
        }
    }
}

//боссы
class VVG : Goblin, IBoss
{
    public VVG() : base("ввг",
        (int)(BazZdorovie * 2.0),
        (int)(BazAtaka * 1.5),
        (int)(BazZashchita * 1.2),
        BazShansKrita + 10)
    {
    }
}

class Kovalsky : Skelet, IBoss
{
    public Kovalsky() : base("ковальский",
        (int)(BazZdorovie * 2.5),
        (int)(BazAtaka * 1.3),
        (int)(BazZashchita * 1.4))
    {
    }
}

class ArhimagCpp : Mag, IBoss
{
    public ArhimagCpp() : base("архимаг c++",
        (int)(BazZdorovie * 1.8),
        (int)(BazAtaka * 1.6),
        (int)(BazZashchita * 1.1),
        BazShansZamorozki + 10)
    {
    }
}

class PestovSMinus : Skelet, IBoss
{
    public PestovSMinus() : base("пестов с--",
        (int)(BazZdorovie * 1.3),
        (int)(BazAtaka * 1.8),
        (int)(BazZashchita * 0.6))
    {
    }
}
