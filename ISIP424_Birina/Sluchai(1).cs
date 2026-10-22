using System.Security.Cryptography;

// генератор случайных чисел (синглтон)
class Sluchai
{
    // единственный экземпляр
    private static Sluchai ekzemplyar;

    // закрытый конструктор: снаружи new Sluchai() нельзя
    private Sluchai()
    {
    }

    // доступ к единственному экземпляру
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

    // число от min до max включительно
    public int Chislo(int min, int max)
    {
        return RandomNumberGenerator.GetInt32(min, max + 1);
    }

    // true с шансом в процентах
    public bool Shans(int procent)
    {
        return Chislo(1, 100) <= procent;
    }
}
