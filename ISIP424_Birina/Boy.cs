using System;


class Boy
{
    Igrok igrok;
    Vrag vrag;

    public Boy(Igrok igrokParam, Vrag vragParam)
    {
        igrok = igrokParam;
        vrag = vragParam;
    }

 
    public bool Nachat()
    {
        igrok.Zamorozhen = false;
        Console.WriteLine("бой: " + vrag.Imya);

        while (igrok.Zhiv && vrag.Zhiv)
        {
            Console.WriteLine("ты: " + igrok.Zdorovie + " хп, " + vrag.Imya + ": " + vrag.Zdorovie + " хп");
            bool zashchishaetsya = HodIgroka();

            if (!vrag.Zhiv)
            {
                break;
            }
            HodVraga(zashchishaetsya);
        }
        return igrok.Zhiv;
    }


    bool HodIgroka()
    {
        if (igrok.Zamorozhen)
        {
            Console.WriteLine("ты пропускаешь ход");
            igrok.Zamorozhen = false;
            return false;
        }

        int vybor = Vvod.Vybor("1 - атака, 2 - защита", 1, 2);
        if (vybor == 1)
        {
            int uron = igrok.TekushceeOruzhie.Ataka - vrag.Zashchita;
            if (uron < 1)
            {
                uron = 1;
            }
            vrag.PoluchitUron(uron);
            Console.WriteLine("ты нанёс " + uron + " урона");
            return false;
        }

        Console.WriteLine("ты в защите");
        return true;
    }

    void HodVraga(bool zashchishaetsya)
    {
        Console.WriteLine(vrag.Imya + " атакует");

        //уклонение
        if (zashchishaetsya && Sluchai.Ekzemplyar.Shans(40))
        {
            Console.WriteLine("ты уклонился");
            return;
        }

        int uron = vrag.RasschitatUron();

        //блок
        if (zashchishaetsya)
        {
            int zashchita = vrag.ZashchitaIgroka(igrok);
            int blok = zashchita * Sluchai.Ekzemplyar.Chislo(70, 100) / 100;
            uron -= blok;
            Console.WriteLine("блок: " + blok);
        }

        if (uron < 0)
        {
            uron = 0;
        }
        igrok.PoluchitUron(uron);
        Console.WriteLine("ты получил " + uron + " урона");

        vrag.Osobennost(igrok);
    }
}
