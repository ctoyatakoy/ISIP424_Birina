using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universitet
{

    enum TipKursa
    {
        Обязательный,
        Необязательный   
    }


    abstract class Chelovek
    {
        public string Imya { get; private set; }
        public int Vozrast { get; private set; }
        public string Kontakt { get; private set; }

        public Chelovek(string imya, int vozrast, string kontakt)
        {
            Imya = imya;
            Vozrast = vozrast;
            Kontakt = kontakt;
        }

        public abstract string PoluchitInfo();
    }

    class Student : Chelovek
    {
        public List<Kurs> Kursy { get; private set; }

        public Student(string imya, int vozrast, string kontakt): base(imya,vozrast,kontakt)
        {
            Kursy = new List<Kurs>();
        }

        public override string PoluchitInfo()
        {
            return "Студент:" + Imya + Vozrast;
        }


    }

    class Prepodavatel : Chelovek
    {

        public List<Kurs> Kursy { get; private set; }

        public Prepodavatel(string imya, int vozrast, string kontakt) : base(imya, vozrast, kontakt)
        {
            Kursy = new List<Kurs>();
        }

        public override string PoluchitInfo()
        {
            return "Учитель:" + Imya + Vozrast;
        }
    }

    class Kurs
    {
        public string Nazvanie { get; private set; }

        public TipKursa Tip { get; private set; }

        public Prepodavatel Prepod { get; set; }

        public List<Student> Studenti { get; private set; }
        public Kurs(string nazvanie, TipKursa tip)
        {
            Nazvanie = nazvanie;
            Tip = tip;
            Studenti = new List<Student>();
        }

        public string PoluchitInfo()
        {

            return "Курс: " + Nazvanie + " и преподаватель: " + Prepod;
        }

        class Program
        {
            static List<Student> studenti = new List<Student>();
            static List<Prepodavatel> prepodavateli = new List<Prepodavatel>();
            static List<Kurs> kursy = new List<Kurs>();

            static void Main()
            {

                while (true)
                {
                    Console.WriteLine("1. Добавить студента");
                    Console.WriteLine("2. Добавить преподавателя");
                    Console.WriteLine("3. Добавить курс");
                    Console.WriteLine("4. Назначить преподавателя");
                    Console.WriteLine("5. Записать студента на курс");
                    Console.WriteLine("6. Все студенты");
                    Console.WriteLine("7. Все преподаватели");
                    Console.WriteLine("8. Все курсы");
                    Console.WriteLine("9. Курсы студента");
                    Console.WriteLine("10. Студенты курса");
                    Console.WriteLine("11. Информация о курсе");
                    Console.WriteLine("0. Выход");

                    int vybor = ProchitatChislo("Ваш выбор: ");

                   
                }
            }

            static string ProchitatTekst(string podskazka)
            {
                while (true)
                {
                    Console.Write(podskazka);
                    string tekst = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(tekst))
                        return tekst.Trim();

                    Console.WriteLine("Поле не должно быть пустым.");
                }
            }

            static int ProchitatChislo(string podskazka)
            {
                while (true)
                {
                    Console.Write(podskazka);
                    string vvod = Console.ReadLine();

                    if (int.TryParse(vvod, out int chislo))
                        return chislo;

                    Console.WriteLine("Введите целое число.");
                }
            }

            static int ProchitatVozrast()
            {
                while (true)
                {
                    int vozrast = ProchitatChislo("Возраст: ");

                    if (vozrast >= 1 && vozrast <= 120)
                        return vozrast;

                    Console.WriteLine("Возраст должен быть от 1 до 120.");
                }
            }
        }
    }
}
