using static System.StringSplitOptions


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

Console.WriteLine();
Console.WriteLine("Количество слов: " + kolichestvoSlov);
Console.WriteLine("Самое короткое слово: " + korotkoeSlovo);
Console.WriteLine("Самое длинное слово: " + dlinnoeSlovo);



/*
1. Приём текста и проверка на 100+ символов.
2. Подсчёт слов, поиск короткого и длинного слова.
3. Подсчёт предложений, гласных и согласных.
4. Статистика частоты букв.
5. Сохранение статистики нескольких текстов.
6. Просмотр прошлой статистики и возможность работать с новым текстом.*/

