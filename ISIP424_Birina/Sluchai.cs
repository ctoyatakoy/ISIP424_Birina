using System;
using System.Security.Cryptography;


class Sluchai
{
    private static Sluchai ekzemplyar;

    private RandomNumberGenerator generator = RandomNumberGenerator.Create();

    private Sluchai()
    {
    }

    public static Sluchai Ekzemplyar
    {
        get
        {
            if (ekzemplyar == null)
            {
                ekzemplyar = new Sluchai();
            }
            return ekzemplyar;
        }
    }


    public int Chislo(int min, int max)
    {
        byte[] bayty = new byte[4];
        generator.GetBytes(bayty);
        uint sluchainoe = BitConverter.ToUInt32(bayty, 0);
        uint diapazon = (uint)(max - min + 1);
        return min + (int)(sluchainoe % diapazon);
    }

    public bool Shans(int procent)
    {
        return Chislo(1, 100) <= procent;
    }
}

