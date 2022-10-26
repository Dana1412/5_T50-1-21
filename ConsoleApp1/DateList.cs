using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class DateList
    {
        public int ActiveList = 0;

        public string Name { get; set; }
        public List<Item> Items { get; set; }
        public DateList(string name, List<Item> items)
        {
            Name = name;
            Items = items;
        }

        public void Open()
        {
            Console.Clear();
            Console.WriteLine($"Для выхода нажмите ESC");
            Console.WriteLine($"Выбирите пункт из меню");
            Console.WriteLine($"");

            for (int i = 0; i < Items.Count; i++) Console.WriteLine($"╞  {Items[i].Name} - {Items[i].Price}руб.");

            Program.setCursor(3, ActiveList);

            ConsoleKeyInfo button = Console.ReadKey();
            ActiveList = Program.getBind(button.Key, Items.Count - 1, ActiveList);

            if (button.Key == ConsoleKey.Enter) Add();
            else if (button.Key == ConsoleKey.Escape)
            {
                ActiveList = 0;
                Program.Open();
            }
            else Program.Catalogs[Program.ActiveList].Open();
        }
        public void Add()
        {
            Program.Carts.Add($"{Program.Catalogs[Program.ActiveList].Name}: {Items[ActiveList].Name}");
            Program.Price += Items[ActiveList].Price;
            Program.Catalogs[Program.ActiveList].Open();
        }
    }
}
