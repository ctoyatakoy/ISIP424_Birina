using System;

class Sluchai
{
    static Random r = new Random();

    public static int Chislo(int min, int max)
    {
        return r.Next(min, max + 1);
    }

    //с шансом 
    public static bool Shans(int procent)
    {
        return r.Next(100) < procent;
    }
}
