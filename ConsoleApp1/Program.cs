using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        public static int ActiveList = 0;
        public static int Price = 0;
        public static List<string> Carts = new List<string>();
        public static List<DateList> Catalogs = new List<DateList>()
        {
            new DateList(
                "Форма торта",new List<Item>
                {
                    new Item("Круг",500),
                    new Item("Квадрат",500),
                    new Item("Прямогульник",500),
                    new Item("Сердечко",500)
                }
            ),
            new DateList(
                "Размер торта",new List<Item>
                {
                    new Item("Маленький (Диаметр - 16 см, 8 порций)",1000),
                    new Item("Маленький (Диаметр - 18 см, 10 порций)",1200),
                    new Item("Маленький (Диаметр - 28 см, 24 порций)",2000)
                }
            ),
            new DateList(
                "Вкус коржей",new List<Item>
                {
                    new Item("Ванильный",100),
                    new Item("Шоколадный",150),
                    new Item("Карамельный",160),
                    new Item("Ягодный",200),
                    new Item("Кокосовый",250)
                }
            ),
            new DateList(
                "Количество коржей",new List<Item>
                {
                    new Item("1 корж",200),
                    new Item("2 коржа",400),
                    new Item("3 коржа",600),
                    new Item("4 коржа",800),
                }
            ),
            new DateList(
                "Глазурь",new List<Item>
                {
                    new Item("Шоколад",100),
                    new Item("Крем",150),
                    new Item("Бизе",200),
                    new Item("Драже",250),
                    new Item("Ягоды",300),
                }
            ),
            new DateList(
                "Декор",new List<Item>
                {
                    new Item("Шоколадная",150),
                    new Item("Ягодная",150),
                    new Item("Кремовая",150),
                }
            ),
            new DateList( "Конец заказа",new List<Item>() )
        };

        static void Main(string[] args)
        {
            Open();
        }
        public static void Open()
        {
            Console.Clear();
            Console.WriteLine($"Заказ тортов в ГЛАЗУРЬКА, торты на ваш выбор!");
            Console.WriteLine($"Выберите параметр торта");
            Console.WriteLine($"");

            for (int i = 0; i < Catalogs.Count; i++) Console.WriteLine($"╞  {Catalogs[i].Name}");

            Console.WriteLine("");
            Console.WriteLine($"Цена: {Price}руб.");
            Console.WriteLine($"Заказ: \n {String.Join(",\n ", Carts.ToArray())}");

            setCursor(3, ActiveList);

            ConsoleKeyInfo button = Console.ReadKey();
            ActiveList = getBind(button.Key, Catalogs.Count - 1, ActiveList);

            if (button.Key == ConsoleKey.Enter)
            {
                if (ActiveList == Catalogs.Count - 1) Save();
                Catalogs[ActiveList].Open();
            }
            else Open();
        }
        public static void Save()
        {
            Console.Clear();
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}save.txt";
            string text = $"Заказ от: {DateTime.Now}\nЦена: {Price}р\nЗаказ: \n {String.Join(",\n ", Carts.ToArray())}";
            if (File.Exists(path))
            {
                string text2 = File.ReadAllText(path);
                File.WriteAllText(path, $"{text}\n{text2}");

                Console.WriteLine("Спасибо за заказ! Если хотите сделать ещё один, нажмите на клавишу Esc");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    Carts = new List<string>();
                    Price = 0;
                    ActiveList = 0;
                    Open();
                }
            }
            else
            {
                File.Create(path);
                Save();
            }
        }
        public static void setCursor(int start, int next)
        {
            Console.SetCursorPosition(0, start + next);
            Console.WriteLine(" ╡");
        }
        public static int getBind(ConsoleKey button, int max, int next)
        {
            if (button == ConsoleKey.UpArrow)
            {
                if (next == 0) next = max;
                else next -= 1;
            }
            else if (button == ConsoleKey.DownArrow)
            {
                if (next == max) next = 0;
                else next += 1;
            }
            return next;
        }
    }
}
