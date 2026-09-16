using System;
using System.Collections.Generic;

namespace UchetTovarov
{
    enum KategoriyaTovara
    {
        Продукты,
        Электроника,
        Одежда,
        Химия
    }

    class Tovar
    {
        public int Kod { get; set; }
        public string Nazvanie { get; set; }
        public decimal Cena { get; set; }
        public int Kolichestvo { get; set; }
        public KategoriyaTovara Kategoriya { get; set; }

        public bool EstNaSklade
        {
            get { return Kolichestvo > 0; }
        } //чтение, проверка, чтобы 0 было отсутствие на складе...

        public override string ToString() //изменение родительского метода...
        {
            string daIliNet;
            if (EstNaSklade == true)
            {
                daIliNet = "Да";
            }
            else
            {
                daIliNet = "Нет";
            }
            return $"Код: {Kod}, Название: {Nazvanie}, Цена: {Cena} руб., Количество: {Kolichestvo}, На складе: {daIliNet}, Категория: {Kategoriya}";
        }
    }

    class Prodazha
    {
        public int KodTovara { get; set; }
        public string Nazvanie { get; set; }
        public int Kolichestvo { get; set; }
        public decimal Summa { get; set; }
    }

    class Program
    {
        static List<Tovar> spisokTovarov = new List<Tovar>();
        static Stack<Prodazha> istoriyaProdazh = new Stack<Prodazha>();
        static int sleduyushiyKod = 1;

        static void Main(string[] args)
        {
            ZapolnitTestovymiDannymi();

            bool rabota = true;
            while (rabota)
            {
                PokazatMenu();
                string vybor = Console.ReadLine();

                switch (vybor)
                {
                    case "1":
                        DobavitTovar();
                        break;
                    case "2":
                        UdalitTovar();
                        break;
                    case "3":
                        ZakazatPostavku();
                        break;
                    case "4":
                        ProdatTovar();
                        break;
                    case "5":
                        PoiskTovarov();
                        break;
                    case "6":
                        PokazatVseTovary();
                        break;
                    case "7":
                        OtmenitPoslednyuyuProdazhu();
                        break;
                    case "8":
                        OtchetProdazh();
                        break;
                    case "0":
                        rabota = false;
                        Console.WriteLine("все готово, босс");
                        break;
                    default:
                        Console.WriteLine("нет такого, босс");
                        break;
                }
            }
        }

        static void PokazatMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Боссоменю:");
            Console.WriteLine("1. Босс добавляет товар");
            Console.WriteLine("2. Босс удаляет товар");
            Console.WriteLine("3. Босс заказывает поставку товара");
            Console.WriteLine("4. Босс продает товар");
            Console.WriteLine("5. Босс ищет товары");
            Console.WriteLine("6. Показать все товары боссу");
            Console.WriteLine("7. Босс отменяет последнюю продажу");
            Console.WriteLine("8. Отчёт о продажах боссу на стол");
            Console.WriteLine("0. Босс займется чем-то другим");
            Console.Write("Выбирайте: ");
        }

        static void ZapolnitTestovymiDannymi()
        {
            spisokTovarov.Add(new Tovar { Kod = sleduyushiyKod++, Nazvanie = "Хлебушек", Cena = 45, Kolichestvo = 20, Kategoriya = KategoriyaTovara.Продукты });
            spisokTovarov.Add(new Tovar { Kod = sleduyushiyKod++, Nazvanie = "Молочко", Cena = 89, Kolichestvo = 15, Kategoriya = KategoriyaTovara.Продукты });
            spisokTovarov.Add(new Tovar { Kod = sleduyushiyKod++, Nazvanie = "Наушники", Cena = 2500, Kolichestvo = 7, Kategoriya = KategoriyaTovara.Электроника });
            spisokTovarov.Add(new Tovar { Kod = sleduyushiyKod++, Nazvanie = "Футболка мерч Андрея Пирокинесиза", Cena = 1200, Kolichestvo = 12, Kategoriya = KategoriyaTovara.Одежда });
            spisokTovarov.Add(new Tovar { Kod = sleduyushiyKod++, Nazvanie = "Мыло", Cena = 35, Kolichestvo = 30, Kategoriya = KategoriyaTovara.Химия });
        }

        static void DobavitTovar()
        {
            Console.WriteLine("добавление товара");

            string nazvanie = VvestiNazvanie();
            decimal cena = VvestiCenu();
            int kolichestvo = VvestiKolichestvo();
            KategoriyaTovara kategoriya = VvestiKategoriyu();

            Tovar novyyTovar = new Tovar();
            novyyTovar.Kod = sleduyushiyKod;
            sleduyushiyKod = sleduyushiyKod + 1;
            novyyTovar.Nazvanie = nazvanie;
            novyyTovar.Cena = cena;
            novyyTovar.Kolichestvo = kolichestvo;
            novyyTovar.Kategoriya = kategoriya;

            spisokTovarov.Add(novyyTovar);
            Console.WriteLine($"товар добавлен, босс. присвоен код: {novyyTovar.Kod}");
        }

        static void UdalitTovar()
        {
            Console.WriteLine("удаление товара");
            int kod = VvestiKod();

            Tovar tovar = null;
            for (int i = 0; i < spisokTovarov.Count; i++)
            {
                if (spisokTovarov[i].Kod == kod)
                {
                    tovar = spisokTovarov[i];
                    break;
                }
            }

            if (tovar == null)
            {
                Console.WriteLine("товар с таким кодом не найден...");
                return;
            }

            spisokTovarov.Remove(tovar);
            Console.WriteLine("товар удалён.");
        }

        static void ZakazatPostavku()
        {
            Console.WriteLine("заказ поставки");
            int kod = VvestiKod();

            Tovar tovar = null;
            for (int i = 0; i < spisokTovarov.Count; i++)
            {
                if (spisokTovarov[i].Kod == kod)
                {
                    tovar = spisokTovarov[i];
                    break;
                }
            }

            if (tovar == null)
            {
                Console.WriteLine("товар с таким кодом не найден...");
                return;
            }

            Console.Write("введите количество для поставки: ");
            int kolichestvo;
            while (!int.TryParse(Console.ReadLine(), out kolichestvo) || kolichestvo <= 0)
            {
                Console.Write("введите положительное целое число: ");
            }

            tovar.Kolichestvo = tovar.Kolichestvo + kolichestvo;
            Console.WriteLine($"поставка выполнена. новое количество: {tovar.Kolichestvo}");
        }

        static void ProdatTovar()
        {
            Console.WriteLine("продажа товара");
            int kod = VvestiKod();

            Tovar tovar = null;
            for (int i = 0; i < spisokTovarov.Count; i++)
            {
                if (spisokTovarov[i].Kod == kod)
                {
                    tovar = spisokTovarov[i];
                    break;
                }
            }

            if (tovar == null)
            {
                Console.WriteLine("товар с таким кодом не найден.");
                return;
            }

            Console.Write("введите количество для продажи: ");
            int kolichestvo;
            while (!int.TryParse(Console.ReadLine(), out kolichestvo) || kolichestvo <= 0)
            {
                Console.Write("введите положительное целое число: ");
            }

            if (kolichestvo > tovar.Kolichestvo)
            {
                Console.WriteLine($"недостаточно товара привезли, доступно только: {tovar.Kolichestvo}");
                return;
            }

            tovar.Kolichestvo = tovar.Kolichestvo - kolichestvo;
            decimal summa = tovar.Cena * kolichestvo;

            Prodazha novayaProdazha = new Prodazha();
            novayaProdazha.KodTovara = tovar.Kod;
            novayaProdazha.Nazvanie = tovar.Nazvanie;
            novayaProdazha.Kolichestvo = kolichestvo;
            novayaProdazha.Summa = summa;

            istoriyaProdazh.Push(novayaProdazha);  //стек

            Console.WriteLine($"сумма продажи: {summa} руб. остаток: {tovar.Kolichestvo}");
        }

        static void PoiskTovarov()
        {
            Console.WriteLine("Босс ищет товары");
            Console.WriteLine("1. По коду");
            Console.WriteLine("2. По названию");
            Console.WriteLine("3. По категории");
            Console.Write("Выберите тип поиска: ");
            string vybor = Console.ReadLine();

            List<Tovar> naydennye = new List<Tovar>();

            if (vybor == "1")
            {
                int kod = VvestiKod();
                for (int i = 0; i < spisokTovarov.Count; i++)
                {
                    if (spisokTovarov[i].Kod == kod)
                    {
                        naydennye.Add(spisokTovarov[i]);
                    }
                }
            }
            else if (vybor == "2")
            {
                Console.Write("введите часть названия: ");
                string nazvanie = (Console.ReadLine().ToLower());
                if (nazvanie == "")
                {
                    Console.WriteLine("пусто...");
                    return;
                }
                for (int i = 0; i < spisokTovarov.Count; i++)
                {
                    if (spisokTovarov[i].Nazvanie.ToLower().Contains(nazvanie))
                    {
                        naydennye.Add(spisokTovarov[i]);
                    }
                }
            }
            else if (vybor == "3")
            {
                KategoriyaTovara kategoriya = VvestiKategoriyu();
                for (int i = 0; i < spisokTovarov.Count; i++)
                {
                    if (spisokTovarov[i].Kategoriya == kategoriya)
                    {
                        naydennye.Add(spisokTovarov[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("нет, босс");
                return;
            }

            if (naydennye.Count == 0)
            {
                Console.WriteLine("нет, босс");
                return;
            }

            Console.WriteLine("нашли такое для босса:");
            foreach (var tovar in naydennye)
            {
                Console.WriteLine(tovar);
            }
        }

        static void PokazatVseTovary()
        {
            if (spisokTovarov.Count == 0)
            {
                Console.WriteLine("список пуст");
                return;
            }

            Console.WriteLine("все штуки босса");
            foreach (var tovar in spisokTovarov)
            {
                Console.WriteLine(tovar);
            }
        }

        static void OtmenitPoslednyuyuProdazhu()
        {
            Console.WriteLine("отмена последней боссопродажи");
            if (istoriyaProdazh.Count == 0)
            {
                Console.WriteLine("история продаж пустая");
                return;
            }

            Prodazha poslednyaya = istoriyaProdazh.Pop();

            Tovar tovar = null;
            for (int i = 0; i < spisokTovarov.Count; i++)
            {
                if (spisokTovarov[i].Kod == poslednyaya.KodTovara)
                {
                    tovar = spisokTovarov[i];
                    break;
                }
            }

            if (tovar != null)
            {
                tovar.Kolichestvo = tovar.Kolichestvo + poslednyaya.Kolichestvo;
                Console.WriteLine($"возвращено на склад: {poslednyaya.Kolichestvo} шт. товара \"{poslednyaya.Nazvanie}\".");
            }
            else
            {
                Console.WriteLine("нет такого, босс");
            }
        }

        static void OtchetProdazh()
        {
            Console.WriteLine("БОССООТЧЕТ");
            if (istoriyaProdazh.Count == 0)
            {
                Console.WriteLine("ничего не продали, плохо");
                return;
            }

            decimal obshayaSumma = 0;
            int obsheeKolichestvo = 0;

            foreach (var prodazha in istoriyaProdazh)
            {
                Console.WriteLine($"Код: {prodazha.KodTovara}, Название: {prodazha.Nazvanie}, Количество: {prodazha.Kolichestvo}, Сумма: {prodazha.Summa} руб.");
                obshayaSumma = obshayaSumma + prodazha.Summa;
                obsheeKolichestvo = obsheeKolichestvo + prodazha.Kolichestvo;
            }

            Console.WriteLine($"итого продано штук: {obsheeKolichestvo}");
            Console.WriteLine($"общая сумма продаж: {obshayaSumma} руб.");
        }

        static int VvestiKod()
        {
            Console.Write("введите код: ");
            int kod;
            while (!int.TryParse(Console.ReadLine(), out kod) || kod <= 0)
            {
                Console.Write("нет такого, босс");
            }
            return kod;
        }

        static string VvestiNazvanie()
        {
            Console.Write("введите название товара: ");
            string nazvanie = (Console.ReadLine());
            while (nazvanie == "")
            {
                Console.Write("нет, босс");
                nazvanie = (Console.ReadLine());
            }
            return nazvanie;
        }

        static decimal VvestiCenu()
        {
            Console.Write("босс, цена товара: ");
            decimal cena;
            while (!decimal.TryParse(Console.ReadLine(), out cena) || cena < 0)
            {
                Console.Write("введите неотрицательное число, босс ");
            }
            return cena;
        }

        static int VvestiKolichestvo()
        {
            Console.Write("босс, количество товара: ");
            int kolichestvo;
            while (!int.TryParse(Console.ReadLine(), out kolichestvo) || kolichestvo < 0)
            {
                Console.Write("введите неотрицательное число, босс ");
            }
            return kolichestvo;
        }

        static KategoriyaTovara VvestiKategoriyu()
        {
            Console.WriteLine("Боссокатегории:");
            var kategorii = Enum.GetValues(typeof(KategoriyaTovara));
            foreach (KategoriyaTovara k in kategorii)
            {
                Console.WriteLine($"{(int)k} - {k}");
            }

            Console.Write("введите номер категории, босс: ");
            int nomer;
            while (!int.TryParse(Console.ReadLine(), out nomer) || !Enum.IsDefined(typeof(KategoriyaTovara), nomer))
            {
                Console.Write("Нет, босс ");
            }
            return (KategoriyaTovara)nomer;
        }
    }
}
