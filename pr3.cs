using static System.StringSplitOptions

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

List<Statistika> spisokStatistik = new List<Statistika>();

Console.WriteLine("Текст не менее соточки букв, босс:");

string tekst = Console.ReadLine();

while (tekst.Length < 100)
{
    Console.WriteLine("Текст слишком короткий...");
    tekst = Console.ReadLine();
}
Console.WriteLine("Количество символов: " + tekst.Length);

string[] slova = tekst.Split(' ', StringSplitOptions);

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

string glasnyeBukvy = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";

for (int i = 0; i < tekst.Length; i++)
{
    char bukva = tekst[i];

    if (bukva == '.' || bukva == '!' || bukva == '?')
    {
        kolichestvoPredlozheniy++;
    }

    if (Char.IsLetter(bukva))
    {
        if (glasnyeBukvy.Contains(bukva))
        {
            glasnye++;
        }
        else
        {
            soglasnye++;
        }
    }
}

string alfavit = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

int[] kolichestvoBukv = new int[alfavit.Length];

for (int i = 0; i < tekst.Length; i++)
{
    char bukva = Char.ToLower(tekst[i]);

    for (int j = 0; j < alfavit.Length; j++)
    {
        if (bukva == alfavit[j])
        {
            kolichestvoBukv[j]++;
        }
    }
}

Console.WriteLine();
Console.WriteLine("Частота букв:");

for (int i = 0; i < alfavit.Length; i++)
{
    if (kolichestvoBukv[i] > 0)
    {
        Console.WriteLine(alfavit[i] + " - " + kolichestvoBukv[i]);
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
Console.WriteLine("Количество слов: " + kolichestvoSlov);
Console.WriteLine("Самое короткое слово: " + korotkoeSlovo);
Console.WriteLine("Самое длинное слово: " + dlinnoeSlovo);
Console.WriteLine("Количество предложений: " + kolichestvoPredlozheniy);
Console.WriteLine("Количество гласных: " + glasnye);
Console.WriteLine("Количество согласных: " + soglasnye);



/*
1. Приём текста и проверка на 100+ символов.
2. Подсчёт слов, поиск короткого и длинного слова.
3. Подсчёт предложений, гласных и согласных.
4. Статистика частоты букв.
5. Сохранение статистики нескольких текстов.
6. Просмотр прошлой статистики и возможность работать с новым текстом.*/

