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



        static void Main(string[] args)
        {

        }
    }
}
