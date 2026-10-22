using System;
using System.Collections.Generic;
using System.Linq;


class Igra
{
    Igrok igrok = new Igrok();
    List<Vrag> pobezhdennye = new List<Vrag>();
    int hod = 0;

    public void Zapusk()
    {
        Console.WriteLine("рогалик");

        while (igrok.Zhiv)
        {
            hod++;
            Console.WriteLine();
            Console.WriteLine("--- ход " + hod + " ---");
            Console.WriteLine("здоровье: " + igrok.Zdorovie + "/" + igrok.MaxZdorovie);
            Console.WriteLine("оружие: " + igrok.TekushceeOruzhie);
            Console.WriteLine("доспехи: " + igrok.TekushceiDospekh);

            if (hod % 10 == 0)
            {
                Console.WriteLine("появился босс!");
                Srazhenie(Generator.SluchainyiBoss());
            }
            else if (Sluchai.Ekzemplyar.Shans(50))
            {
                Console.WriteLine("ты нашёл сундук");
                Generator.SluchainyiPredmet().Poluchit(igrok);
            }
            else
            {
                Srazhenie(Generator.SluchainyiVrag());
            }

            if (igrok.Zhiv)
            {
                Console.Write("enter - дальше");
                Console.ReadLine();
            }
        }

        Itogi();
    }

    void Srazhenie(Vrag vrag)
    {
        Boy boy = new Boy(igrok, vrag);
        if (boy.Nachat())
        {
            Console.WriteLine("победа над: " + vrag.Imya);
            pobezhdennye.Add(vrag);
        }
    }

    // итоги
    void Itogi()
    {
        Console.WriteLine();
        Console.WriteLine("ты погиб");
        Console.WriteLine("прожито ходов: " + hod);
        Console.WriteLine("побеждено врагов: " + pobezhdennye.Count());
        Console.WriteLine("из них боссов: " + pobezhdennye.Count(v => v is IBoss));

        if (pobezhdennye.Count > 0)
        {
            Console.WriteLine("побеждены:");
            foreach (Vrag vrag in pobezhdennye)
            {
                Console.WriteLine("- " + vrag.Imya);
            }
        }
    }
}
