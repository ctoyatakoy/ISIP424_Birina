using System.Security.Cryptography;

//генератор случайных чисел
class Sluchai
{

    private static Sluchai ekzemplyar;


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
        return RandomNumberGenerator.GetInt32(min, max + 1);
    }

    public bool Shans(int procent)
    {
        return Chislo(1, 100) <= procent;
    }
}
