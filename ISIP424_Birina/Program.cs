using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    enum Genre
    {
        Фантастика,
        Детектив,
        Роман,
        Приключения,
        Нонфикшн
    }

    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Book(int id, string title, string author, Genre genre, int year, decimal price)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            Price = price;
        }

        public void Print()
        {
            Console.WriteLine(
                $"ID: {Id}, Название: {Title}, Автор: {Author}, " + $"Жанр: {Genre}, Год: {Year}, Цена: {Price} руб.");
        }
    }

    class Program
    {
        static List<Book> books = new List<Book>();

        static int nextId = 1;

        static void Main()
        {
            AddTestBooks();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("БОССОТЕКА");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Найти по названию");
                Console.WriteLine("4. Найти по автору");
                Console.WriteLine("5. Найти по жанру");
                Console.WriteLine("6. Сортировать по названию");
                Console.WriteLine("7. Сортировать по году");
                Console.WriteLine("8. Самая дорогая книга");
                Console.WriteLine("9. Самая дешёвая книга");
                Console.WriteLine("10. Группировка по авторам");
                Console.WriteLine("0. Выход");

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;

                    case "2":
                        DeleteBook();
                        break;

                    case "3":
                        FindByTitle();
                        break;

                    case "4":
                        FindByAuthor();
                        break;

                    case "5":
                        FindByGenre();
                        break;

                    case "6":
                        SortByTitle();
                        break;

                    case "7":
                        SortByYear();
                        break;

                    case "8":
                        ShowMostExpensive();
                        break;

                    case "9":
                        ShowCheapest();
                        break;

                    case "10":
                        GroupByAuthor();
                        break;

                    case "0":
                        Console.WriteLine("Всьо.");
                        return;

                    default:
                        Console.WriteLine("Такого пункта меню нет.");
                        break;
                }
            }
        }

        //тестовых книг
        static void AddTestBooks()
        {
            books.Add(new Book(
                nextId++,
                "Мастер и Маргарита",
                "Михаил Булгаков",
                Genre.Роман,
                1967,
                800));

            books.Add(new Book(
                nextId++,
                "Преступление и наказание",
                "Фёдор Достоевский",
                Genre.Роман,
                1866,
                650));

            books.Add(new Book(
                nextId++,
                "Шерлок Холмс",
                "Артур Конан Дойл",
                Genre.Детектив,
                1892,
                900));

            books.Add(new Book(
                nextId++,
                "Марсианин",
                "Энди Вейер",
                Genre.Фантастика,
                2011,
                1000));

            books.Add(new Book(
                nextId++,
                "Вокруг света за 80 дней",
                "Жюль Верн",
                Genre.Приключения,
                1872,
                700));
        }

        //добавление
        static void AddBook()
        {
            Console.WriteLine();
            string title = ReadText("Введите название: ");
            string author = ReadText("Введите автора: ");

            Genre genre = ReadGenre();
            int year = ReadYear();
            decimal price = ReadPrice();

            Book book = new Book(
                nextId,
                title,
                author,
                genre,
                year,
                price);

            books.Add(book);

            nextId++;
        }

        //удаление 
        static void DeleteBook()
        {
            Console.WriteLine();

            int id = ReadPositiveInt("Введите ID книги: ");
            Book book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                Console.WriteLine("Книга с таким ID не найдена.");
                return;
            }

            books.Remove(book);

        }

        //поиск по названию
        static void FindByTitle()
        {
            Console.WriteLine();
            string title = ReadText("Введите название: ");
            List<Book> result = books.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
            PrintBooks(result);
        }

        //поиск по автору
        static void FindByAuthor()
        {
            Console.WriteLine();
            string author = ReadText("Введите автора: ");

            List<Book> result = books.Where( x => x.Title.ToLower().Contains(author.ToLower())).ToList();
                
            PrintBooks(result);
        }

        //поиск по жанру
        static void FindByGenre()
        {
            Console.WriteLine();
            Genre genre = ReadGenre();

            List<Book> result = books
                .Where(x => x.Genre == genre)
                .ToList();

            PrintBooks(result);
        }

        //по названию
        static void SortByTitle()
        {
            Console.WriteLine();

            List<Book> result = books
                .OrderBy(x => x.Title)
                .ToList();

            PrintBooks(result);
        }

        //по году
        static void SortByYear()
        {
            Console.WriteLine();

            List<Book> result = books
                .OrderBy(x => x.Year)
                .ToList();

            PrintBooks(result);
        }

        //дорогая
        static void ShowMostExpensive()
        {
            Console.WriteLine();

            if (books.Count == 0)
            {
                Console.WriteLine("В библиотеке нет книг.");
                return;
            }

            Book book = books
                .OrderByDescending(x => x.Price)
                .First();

            book.Print();
        }

        //дешевая
        static void ShowCheapest()
        {
            Console.WriteLine();

            if (books.Count == 0)
            {
                Console.WriteLine("В библиотеке нет книг.");
                return;
            }

            Book book = books
                .OrderBy(x => x.Price)
                .First();

            book.Print();
        }

        //по авторам
        static void GroupByAuthor()
        {
            Console.WriteLine();
            var groups = books
                .GroupBy(x => x.Author);

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} книг");
            }
        }

        //список книг
        static void PrintBooks(List<Book> booksToPrint)
        {
            if (booksToPrint.Count == 0)
            {
                Console.WriteLine("Книги не найдены.");
                return;
            }

            Console.WriteLine();

            foreach (Book book in booksToPrint)
            {
                book.Print();
            }
        }

        //тестовый ввод
        static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);

                string value = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(value))
                {
                    return value.Trim();
                }

                Console.WriteLine("Поле не может быть пустым.");
            }
        }

        //жанр
        static Genre ReadGenre()
        {
            while (true)
            {
                Console.WriteLine("Выберите жанр:");

                Genre[] genres = (Genre[])Enum.GetValues(typeof(Genre));

                for (int i = 0; i < genres.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {genres[i]}");
                }

                Console.Write("Ваш выбор: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    if (number >= 1 && number <= genres.Length)
                    {
                        return genres[number - 1];
                    }
                }

                Console.WriteLine("Выберите номер жанра из списка.");
            }
        }

        //года
        static int ReadYear()
        {
            while (true)
            {
                Console.Write("Введите год издания: ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int year))
                {
                    if (year > 0 && year <= DateTime.Now.Year)
                    {
                        return year;
                    }
                }

                Console.WriteLine("Введите корректный год.");
            }
        }

        //цена
        static decimal ReadPrice()
        {
            while (true)
            {
                Console.Write("Введите цену: ");

                string input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal price))
                {
                    if (price >= 0)
                    {
                        return price;
                    }
                }

                Console.WriteLine("Цена не может быть отрицательной.");
            }
        }

        //целое ли
        static int ReadPositiveInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    if (number > 0)
                    {
                        return number;
                    }
                }

                Console.WriteLine("Введите положительное целое число.");
            }
        }
    }
}

