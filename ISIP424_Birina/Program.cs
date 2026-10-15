using System;
using System.Collections.Generic;

namespace Universitet
{
    enum TipKursa
    {
        Obyazatelnyy,
        Elektivnyy
    }

    abstract class Chelovek
    {
        private string imya;
        private int vozrast;
        private string kontakt;

        public string Imya
        {
            get { return imya; }
            set
            {
                if (value == "")
                    throw new Exception("Имя не может быть пустым");
                imya = value;
            }
        }

        public int Vozrast
        {
            get { return vozrast; }
            set
            {
                if (value <= 0 || value > 120)
                    throw new Exception("Возраст должен быть от 1 до 120");
                vozrast = value;
            }
        }

        public string Kontakt
        {
            get { return kontakt; }
            set
            {
                if (value == "")
                    throw new Exception("Контакт не может быть пустым");
                kontakt = value;
            }
        }

        protected Chelovek(string imya, int vozrast, string kontakt)
        {
            Imya = imya;
            Vozrast = vozrast;
            Kontakt = kontakt;
        }

        public abstract string PoluchitInfo();
    }

    class Student : Chelovek
    {
        public List<Kurs> Kursy { get; set; }

        public Student(string imya, int vozrast, string kontakt)
            : base(imya, vozrast, kontakt)
        {
            Kursy = new List<Kurs>();
        }

        public override string PoluchitInfo()
        {
            return "Студент " + Imya + ", " + Vozrast + " лет, Контакт: " + Kontakt + ", курсов: " + Kursy.Count;
        }
    }

    class Prepodavatel : Chelovek
    {
        public List<Kurs> Kursy { get; set; }

        public Prepodavatel(string imya, int vozrast, string kontakt)
            : base(imya, vozrast, kontakt)
        {
            Kursy = new List<Kurs>();
        }

        public override string PoluchitInfo()
        {
            return "Преподаватель " + Imya + ", " + Vozrast + " лет, Контакт: " + Kontakt + ", курсов: " + Kursy.Count;
        }
    }

    class Kurs
    {
        private string nazvanie;

        public string Nazvanie
        {
            get { return nazvanie; }
            set
            {
                if (value == "")
                    throw new Exception("Название курса не может быть пустым");
                nazvanie = value;
            }
        }

        public TipKursa Tip { get; set; }
        public Prepodavatel Prepod { get; set; }
        public List<Student> Studenti { get; set; }

        public Kurs(string nazvanie, TipKursa tip)
        {
            Nazvanie = nazvanie;
            Tip = tip;
            Studenti = new List<Student>();
        }

        public string PoluchitInfo()
        {
            string imyaPrepod = "нет";
            if (Prepod != null)
            {
                imyaPrepod = Prepod.Imya;
            }

            return "Курс '" + Nazvanie + "' (" + Tip + "), препод: " + imyaPrepod + ", студентов: " + Studenti.Count;
        }
    }

    class Program
    {
        static List<Student> studenti = new List<Student>();
        static List<Prepodavatel> prepodavateli = new List<Prepodavatel>();
        static List<Kurs> kursy = new List<Kurs>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== УНИВЕРСИТЕТ ===");
                Console.WriteLine("1.  Добавить студента");
                Console.WriteLine("2.  Добавить преподавателя");
                Console.WriteLine("3.  Добавить курс");
                Console.WriteLine("4.  Назначить препода на курс");
                Console.WriteLine("5.  Записать студента на курс");
                Console.WriteLine("6.  Все студенты");
                Console.WriteLine("7.  Все преподаватели");
                Console.WriteLine("8.  Все курсы");
                Console.WriteLine("9.  Курсы студента");
                Console.WriteLine("10. Студенты курса");
                Console.WriteLine("11. Информация о курсе");
                Console.WriteLine("0.  Выход");
                Console.WriteLine();

                int vybor = ProchitatChislo("Выберите пункт меню: ");

                try
                {
                    switch (vybor)
                    {
                        case 1:
                            DobavitStudenta();
                            break;
                        case 2:
                            DobavitPrepodavatelya();
                            break;
                        case 3:
                            DobavitKurs();
                            break;
                        case 4:
                            NaznachitPrepodaNaKurs();
                            break;
                        case 5:
                            ZapisatStudentaNaKurs();
                            break;
                        case 6:
                            PokazatVsehStudentov();
                            break;
                        case 7:
                            PokazatVsehPrepodavateley();
                            break;
                        case 8:
                            PokazatVseKursy();
                            break;
                        case 9:
                            PokazatKursyStudenta();
                            break;
                        case 10:
                            PokazatStudentovKursa();
                            break;
                        case 11:
                            PokazatInfoOKurse();
                            break;
                        case 0:
                            Console.WriteLine("До свидания!");
                            return;
                        default:
                            Console.WriteLine("Нет такого пункта меню.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        static int ProchitatChislo(string podskazka)
        {
            while (true)
            {
                Console.Write(podskazka);
                string vvod = Console.ReadLine();
                int chislo;

                if (int.TryParse(vvod, out chislo))
                {
                    return chislo;
                }

                Console.WriteLine("Ошибка! Нужно ввести целое число.");
            }
        }

        static Student SozdatStudenta()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите имя студента: ");
                    string imya = Console.ReadLine();

                    int vozrast = ProchitatChislo("Введите возраст: ");

                    Console.Write("Введите контакт: ");
                    string kontakt = Console.ReadLine();

                    return new Student(imya, vozrast, kontakt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        static Prepodavatel SozdatPrepoda()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите имя преподавателя: ");
                    string imya = Console.ReadLine();

                    int vozrast = ProchitatChislo("Введите возраст: ");

                    Console.Write("Введите контакт: ");
                    string kontakt = Console.ReadLine();

                    return new Prepodavatel(imya, vozrast, kontakt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        static Kurs SozdatKurs()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите название курса: ");
                    string nazvanie = Console.ReadLine();

                    Console.WriteLine("Выберите тип курса:");
                    Console.WriteLine("0 - Обязательный");
                    Console.WriteLine("1 - Элективный");
                    int tipChislo = ProchitatChislo("Ваш выбор: ");

                    if (tipChislo != 0 && tipChislo != 1)
                    {
                        Console.WriteLine("Нужно ввести 0 или 1.");
                        continue;
                    }

                    TipKursa tip = (TipKursa)tipChislo;
                    return new Kurs(nazvanie, tip);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        static void DobavitStudenta()
        {
            Student s = SozdatStudenta();
            studenti.Add(s);
            Console.WriteLine("Студент успешно добавлен.");
        }

        static void DobavitPrepodavatelya()
        {
            Prepodavatel p = SozdatPrepoda();
            prepodavateli.Add(p);
            Console.WriteLine("Преподаватель успешно добавлен.");
        }

        static void DobavitKurs()
        {
            Kurs k = SozdatKurs();
            kursy.Add(k);
            Console.WriteLine("Курс успешно добавлен.");
        }

        static void NaznachitPrepodaNaKurs()
        {
            if (prepodavateli.Count == 0)
            {
                Console.WriteLine("В системе нет преподавателей.");
                return;
            }
            if (kursy.Count == 0)
            {
                Console.WriteLine("В системе нет курсов.");
                return;
            }

            Console.WriteLine("Список преподавателей:");
            PokazatVsehPrepodavateley();
            int nomerP = ProchitatChislo("Введите номер преподавателя: ") - 1;

            if (nomerP < 0 || nomerP >= prepodavateli.Count)
            {
                Console.WriteLine("Неверный номер преподавателя.");
                return;
            }

            Console.WriteLine("Список курсов:");
            PokazatVseKursy();
            int nomerK = ProchitatChislo("Введите номер курса: ") - 1;

            if (nomerK < 0 || nomerK >= kursy.Count)
            {
                Console.WriteLine("Неверный номер курса.");
                return;
            }

            Prepodavatel p = prepodavateli[nomerP];
            Kurs k = kursy[nomerK];

            if (k.Prepod != null && k.Prepod != p)
            {
                k.Prepod.Kursy.Remove(k); // Обычное удаление из списка без LINQ
            }

            k.Prepod = p;

            if (!p.Kursy.Contains(k))
            {
                p.Kursy.Add(k);
            }

            Console.WriteLine("Преподаватель " + p.Imya + " назначен на курс '" + k.Nazvanie + "'.");
        }

        static void ZapisatStudentaNaKurs()
        {
            if (studenti.Count == 0)
            {
                Console.WriteLine("В системе нет студентов.");
                return;
            }
            if (kursy.Count == 0)
            {
                Console.WriteLine("В системе нет курсов.");
                return;
            }

            Console.WriteLine("Список студентов:");
            PokazatVsehStudentov();
            int nomerS = ProchitatChislo("Введите номер студента: ") - 1;

            if (nomerS < 0 || nomerS >= studenti.Count)
            {
                Console.WriteLine("Неверный номер студента.");
                return;
            }

            Console.WriteLine("Список курсов:");
            PokazatVseKursy();
            int nomerK = ProchitatChislo("Введите номер курса: ") - 1;

            if (nomerK < 0 || nomerK >= kursy.Count)
            {
                Console.WriteLine("Неверный номер курса.");
                return;
            }

            Student s = studenti[nomerS];
            Kurs k = kursy[nomerK];

            if (k.Studenti.Contains(s))
            {
                Console.WriteLine("Этот студент уже записан на данный курс.");
                return;
            }

            k.Studenti.Add(s);
            s.Kursy.Add(k);

            Console.WriteLine("Студент " + s.Imya + " записан на курс '" + k.Nazvanie + "'.");
        }

        static void PokazatVsehStudentov()
        {
            if (studenti.Count == 0)
            {
                Console.WriteLine("  Список студентов пуст.");
                return;
            }

            for (int i = 0; i < studenti.Count; i++)
            {
                Console.WriteLine("  " + (i + 1) + ". " + studenti[i].PoluchitInfo());
            }
        }

        static void PokazatVsehPrepodavateley()
        {
            if (prepodavateli.Count == 0)
            {
                Console.WriteLine("  Список преподавателей пуст.");
                return;
            }

            for (int i = 0; i < prepodavateli.Count; i++)
            {
                Console.WriteLine("  " + (i + 1) + ". " + prepodavateli[i].PoluchitInfo());
            }
        }

        static void PokazatVseKursy()
        {
            if (kursy.Count == 0)
            {
                Console.WriteLine("  Список курсов пуст.");
                return;
            }

            for (int i = 0; i < kursy.Count; i++)
            {
                Console.WriteLine("  " + (i + 1) + ". " + kursy[i].PoluchitInfo());
            }
        }

        static void PokazatKursyStudenta()
        {
            if (studenti.Count == 0)
            {
                Console.WriteLine("В системе нет студентов.");
                return;
            }

            Console.Write("Введите имя студента: ");
            string imya = Console.ReadLine();

            Student s = null;
            for (int i = 0; i < studenti.Count; i++)
            {
                if (studenti[i].Imya == imya)
                {
                    s = studenti[i];
                    break;
                }
            }

            if (s == null)
            {
                Console.WriteLine("Студент с таким именем не найден.");
                return;
            }

            Console.WriteLine("Курсы студента " + s.Imya + ":");
            if (s.Kursy.Count == 0)
            {
                Console.WriteLine("  Студент пока не записан ни на один курс.");
                return;
            }

            for (int i = 0; i < s.Kursy.Count; i++)
            {
                Console.WriteLine("  - " + s.Kursy[i].Nazvanie);
            }
        }

        static void PokazatStudentovKursa()
        {
            if (kursy.Count == 0)
            {
                Console.WriteLine("В системе нет курсов.");
                return;
            }

            Console.WriteLine("Список курсов:");
            PokazatVseKursy();
            int nomerK = ProchitatChislo("Введите номер курса: ") - 1;

            if (nomerK < 0 || nomerK >= kursy.Count)
            {
                Console.WriteLine("Неверный номер курса.");
                return;
            }

            Kurs k = kursy[nomerK];
            Console.WriteLine("Студенты курса '" + k.Nazvanie + "':");

            if (k.Studenti.Count == 0)
            {
                Console.WriteLine("  На этот курс пока никто не записан.");
                return;
            }

            for (int i = 0; i < k.Studenti.Count; i++)
            {
                Console.WriteLine("  - " + k.Studenti[i].Imya);
            }
        }

        static void PokazatInfoOKurse()
        {
            if (kursy.Count == 0)
            {
                Console.WriteLine("В системе нет курсов.");
                return;
            }

            Console.WriteLine("Список курсов:");
            PokazatVseKursy();
            int nomerK = ProchitatChislo("Введите номер курса: ") - 1;

            if (nomerK < 0 || nomerK >= kursy.Count)
            {
                Console.WriteLine("Неверный номер курса.");
                return;
            }

            Kurs k = kursy[nomerK];
            string imyaPrepod = "нет";
            if (k.Prepod != null)
            {
                imyaPrepod = k.Prepod.Imya;
            }

            Console.WriteLine();
            Console.WriteLine("Название курса: " + k.Nazvanie);
            Console.WriteLine("Тип курса: " + k.Tip);
            Console.WriteLine("Преподаватель: " + imyaPrepod);
            Console.WriteLine("Количество студентов: " + k.Studenti.Count);

            if (k.Studenti.Count > 0)
            {
                Console.Write("Список студентов: ");
                for (int i = 0; i < k.Studenti.Count; i++)
                {
                    Console.Write(k.Studenti[i].Imya);
                    if (i < k.Studenti.Count - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

