using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Cart
    {
        public int List { get; set; }
        public int Item { get; set; }
        public Cart(int list, int item)
        {
            List = list;
            Item = item;
        }
    }
}
