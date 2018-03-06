using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    class Node
    {
        //Węzeł będzie zawierał następujące atrybuty:
        //- kolor
        //- lewy
        //- prawy
        //- rodzic
        //- wartosc

        public Color kolor;
        public Node lewy;
        public Node prawy;
        public Node rodzic;
        public int wartosc;

        public Node(int wartosc)
        {
            this.wartosc = wartosc;
        }

        public Node(Color kolor)
        {
            this.kolor = kolor;
        }

        public Node(int wartosc, Color kolor)
        {
            this.wartosc = wartosc;
            this.kolor = kolor;
        }

       
    }
}

