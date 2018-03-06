using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    class Program
    {
        static void Main(string[] args)
        {
            RB tree = new RB();
            tree.Wstaw(5);
            tree.Wstaw(3);
            tree.Wstaw(7);
            tree.Wstaw(1);
            tree.WyswietlDrzewo();

            Console.ReadLine();
        }
    }

    enum Color
    {
        Czerwony,
        Czarny
    }
}
