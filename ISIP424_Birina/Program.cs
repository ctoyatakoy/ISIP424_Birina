using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP424_Birina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            bool vsehorosho = false;

            Console.WriteLine("Добро пожаловать в магазин!");
            Console.WriteLine($"Привет, {name}!");

            while(!vsehorosho)
            {
                Console.Write("Введите цену: ");
                int chena = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите количество: ");
                int kolvo = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Итог: {chena * kolvo} ");



                if (!vsehorosho)
                {
                    Console.WriteLine("Вы ввели не число!");
                }
            }

        }
    }
}
