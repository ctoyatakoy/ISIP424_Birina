using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Statistika
    {
        public int KolichestvoSlov;
        public string KorotkoeSlovo;
        public string DlinnoeSlovo;
        public int KolichestvoPredlozheniy;
        public int Glasnye;
        public int Soglasnye;
        public int[] KolichestvoBukv;
    }

    class Program
    {
        static void Main()
        {
            List<Statistika> spisokStatistik = new List<Statistika>();

            string alfavit = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string glasnyeBukvy = "аеёиоуыэюя";

            bool rabota = true;

  
            while (rabota)
            {
     
                Console.WriteLine("Текст +100, босс");
                string tekst = Console.ReadLine();

                while (tekst == null || tekst.Length < 100)
                {
                    Console.WriteLine("Текст коротковат");
                    tekst = Console.ReadLine();
                }


                char[] razdelyteli = new char[]
                {
                    ' ', '.', '!', '?', ';', ':'   
                };

                string[] slova = tekst.Split(razdelyteli, StringSplitOptions.RemoveEmptyEntries);

                int kolichestvoSlov = slova.Length;

                string korotkoeSlovo = slova[0];
                string dlinnoeSlovo = slova[0];

                for (int i = 0; i < slova.Length; i++)
                {
                    if (slova[i].Length < korotkoeSlovo.Length)
                    {
                        korotkoeSlovo = slova[i];
                    }

                    if (slova[i].Length > dlinnoeSlovo.Length)
                    {
                        dlinnoeSlovo = slova[i];
                    }
                }


                int kolichestvoPredlozheniy = 0;
                int glasnye = 0;
                int soglasnye = 0;

                for (int i = 0; i < tekst.Length; i++)
                {
                    char bukva = tekst[i];

                    if (bukva == '.' || bukva == '!' || bukva == '?')
                    {
                        kolichestvoPredlozheniy++;
                    }

                    if (char.IsLetter(bukva))
                    {
                        char nizhnyaya = char.ToLower(bukva);

                        if (glasnyeBukvy.Contains(nizhnyaya))
                        {
                            glasnye++;
                        }
                        else
                        {
                            soglasnye++;
                        }
                    }
                }


                int[] kolichestvoBukv = new int[alfavit.Length];

                for (int i = 0; i < tekst.Length; i++)
                {
                    char bukva = char.ToLower(tekst[i]);

                    for (int j = 0; j < alfavit.Length; j++)
                    {
                        if (bukva == alfavit[j])
                        {
                            kolichestvoBukv[j]++;
                        }
                    }
                }


                Statistika statistika = new Statistika();

                statistika.KolichestvoSlov = kolichestvoSlov;
                statistika.KorotkoeSlovo = korotkoeSlovo;
                statistika.DlinnoeSlovo = dlinnoeSlovo;
                statistika.KolichestvoPredlozheniy = kolichestvoPredlozheniy;
                statistika.Glasnye = glasnye;
                statistika.Soglasnye = soglasnye;
                statistika.KolichestvoBukv = kolichestvoBukv;

                spisokStatistik.Add(statistika);


                Console.WriteLine();
                Console.WriteLine("Статистика текущего текста");
                Console.WriteLine("Количество символов: " + tekst.Length);
                Console.WriteLine("Количество слов: " + kolichestvoSlov);
                Console.WriteLine("Самое короткое слово: " + korotkoeSlovo);
                Console.WriteLine("Самое длинное слово: " + dlinnoeSlovo);
                Console.WriteLine("Количество предложений: " + kolichestvoPredlozheniy);
                Console.WriteLine("Количество гласных: " + glasnye);
                Console.WriteLine("Количество согласных: " + soglasnye);

                Console.WriteLine("Частота букв:");
                for (int i = 0; i < alfavit.Length; i++)
                {
                    if (kolichestvoBukv[i] > 0)
                    {
                        Console.WriteLine(alfavit[i] + " - " + kolichestvoBukv[i]);
                    }
                }


                Console.WriteLine();
                Console.WriteLine("Хотите проанализировать новый текст?");
                Console.WriteLine("1 Да");
                Console.WriteLine("2 Нет");

                string otvet = Console.ReadLine();

                if (otvet == "2")
                {
                    rabota = false;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Статистика прошлых текстов");

            for (int i = 0; i < spisokStatistik.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Текст номер " + (i + 1));

                Console.WriteLine("Количество слов: " + spisokStatistik[i].KolichestvoSlov);
                Console.WriteLine("Самое короткое слово: " + spisokStatistik[i].KorotkoeSlovo);
                Console.WriteLine("Самое длинное слово: " + spisokStatistik[i].DlinnoeSlovo);
                Console.WriteLine("Количество предложений: " + spisokStatistik[i].KolichestvoPredlozheniy);
                Console.WriteLine("Количество гласных: " + spisokStatistik[i].Glasnye);
                Console.WriteLine("Количество согласных: " + spisokStatistik[i].Soglasnye);

                Console.WriteLine("Частота букв:");
                for (int j = 0; j < alfavit.Length; j++)
                {
                    if (spisokStatistik[i].KolichestvoBukv[j] > 0)
                    {
                        Console.WriteLine(alfavit[j] + " - " + spisokStatistik[i].KolichestvoBukv[j]);
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}

