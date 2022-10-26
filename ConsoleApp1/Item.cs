using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
