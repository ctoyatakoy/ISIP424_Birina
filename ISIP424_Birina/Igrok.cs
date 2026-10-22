
class Igrok
{
    public int Zdorovie { get; private set; }
    public int MaxZdorovie { get; private set; }
    public Oruzhie TekushceeOruzhie { get; set; }
    public Dospekh TekushceiDospekh { get; set; }
    public bool Zamorozhen { get; set; }

    public bool Zhiv
    {
        get { return Zdorovie > 0; }
    }

    public Igrok()
    {
        MaxZdorovie = 100;
        Zdorovie = MaxZdorovie;
        TekushceeOruzhie = new Oruzhie("меч", 10);
        TekushceiDospekh = new Dospekh("кожанка", 3);
    }

    public void PoluchitUron(int uron)
    {
        Zdorovie -= uron;
        if (Zdorovie < 0)
        {
            Zdorovie = 0;
        }
    }

    public void Vylechit()
    {
        Zdorovie = MaxZdorovie;
    }
}
