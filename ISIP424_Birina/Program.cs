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
            

            Console.WriteLine("Добро пожаловать в магазин!");
            Console.WriteLine($"Привет, {name}!");

            
            Console.Write("Введите цену: ");
            string chena = Console.ReadLine();
            int n1;
            bool vsekruto = int.TryParse(chena, out n1);
            if (!vsekruto)
            {
                Console.WriteLine("Ты дурак.");
            }
                

            Console.Write("Введите количество: ");
            int kolvo = Convert.ToInt32(Console.ReadLine());

            //Console.Write($"Итог: {chena * kolvo} ");

            

        }
    }
}
