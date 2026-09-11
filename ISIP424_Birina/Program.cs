using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Birina
{
    struct Expense 
    {
        public string Title;
        public double Price;
    }

    class Program
    {
        static void Main()
        {

            Console.Write("Минимум 2, максимум 40, босс --> ");
            int n = Convert.ToInt32(Console.ReadLine()); //стринг в инт...

            Expense[] expenses = new Expense[n];

            Console.WriteLine("[Название; Цена в рублях] (только так пишите, пожалуйста, босс)");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1}: "); //начинаем с 1...
                string[] parts = Console.ReadLine().Split(';');
                expenses[i] = new Expense
                {
                    Title = parts[0],
                    Price = Convert.ToDouble(parts[1])
                };
            } //чтобы красиво цифры были каждый ввод...

            while (true) //бесконечно...
            {
                Console.WriteLine("\n1 - Вывод боссданных");
                Console.WriteLine("2 - Статистика для босса");
                Console.WriteLine("3 - Сортировка по цене для босса");
                Console.WriteLine("4 - Конвертация валюты для босса");
                Console.WriteLine("5 - Поиск по названию для босса");
                Console.WriteLine("0 - Выход (нежелательно)");
           
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        for (int i = 0; i < n; i++)
                            Console.WriteLine($"{expenses[i].Title} = {expenses[i].Price} руб.");
                        break; 

                    case "2":
                        double sum = 0, min = expenses[0].Price, max = expenses[0].Price;

                        foreach (var e in expenses)
                        {
                            sum += e.Price;
                            
                            if (e.Price < min)
                            { 
                            min = e.Price;
                            }

                            if (e.Price > max)
                            {
                                max = e.Price;
                            }
                        }
                        Console.WriteLine($"Сумма {sum}");
                        Console.WriteLine($"Среднее {sum / n}");
                        Console.WriteLine($"Минимум {min}");
                        Console.WriteLine($"Максимум {max}");
                        break;

                    case "3":
                   
                        for (int i = 0; i < n - 1; i++)
                            for (int j = 0; j < n - i - 1; j++)
                                if (expenses[j].Price > expenses[j + 1].Price)
                                {
                                    var temp = expenses[j];
                                    expenses[j] = expenses[j + 1];
                                    expenses[j + 1] = temp;
                                } //многострадальная сортировка пузырьком...
                        Console.WriteLine("готово, босс");
                        break;

                    case "4":
                        Console.Write("курс: ");
                        double rate = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("конвертация выполнена, босс");

                        foreach (var e in expenses)
                            Console.WriteLine($"{e.Title}: {e.Price / rate}");
                        break;

                    case "5":
                        Console.Write("строку,босс -->");
                        string query = Console.ReadLine().ToLower(); //в нижнем регистре...

                        foreach (var e in expenses)
                            if (e.Title.ToLower().Contains(query)) //в нижнем регистре...
                                Console.WriteLine($"{e.Title} — {e.Price} руб.");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("такого нет,босс");
                        break;
                }
            }
        }
    }
}