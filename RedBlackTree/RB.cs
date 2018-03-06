using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree
{
    class RB
    {
        public Node root;
        public RB() { }

        private void LewaRotacja(Node X)
        {
            Node Y = X.prawy;
            X.prawy = Y.lewy;
            if (Y.lewy != null)
            {
                Y.lewy.rodzic = X;
            }
            if (Y != null)
            {
                Y.rodzic = X.rodzic;
            }
            if (X.rodzic == null)
            {
                root = Y;
            }
            if (X == X.rodzic.lewy)
            {
                X.rodzic.lewy = Y;
            }
            else
            {
                X.rodzic.prawy = Y;
            }
            Y.lewy = X; //doczepiamy X do lewej strony Y
            if (X != null)
            {
                X.rodzic = Y;
            }

        }

        //lustrzane odbicie lewej rotacji
        private void PrawaRotacja(Node Y)
        {

            Node X = Y.lewy;
            Y.lewy = X.prawy;
            if (X.prawy != null)
            {
                X.prawy.rodzic = Y;
            }
            if (X != null)
            {
                X.rodzic = Y.rodzic;
            }
            if (Y.rodzic == null)
            {
                root = X;
            }
            if (Y == Y.rodzic.prawy)
            {
                Y.rodzic.prawy = X;
            }
            if (Y == Y.rodzic.lewy)
            {
                Y.rodzic.lewy = X;
            }

            X.prawy = Y; //doczepiamy Y do prawej strony X
            if (Y != null)
            {
                Y.rodzic = X;
            }
        }

        public void Wstaw(int element)
        {
            Node nowyElement = new Node(element);
            if (root == null)
            {
                root = nowyElement;
                root.kolor = Color.Czarny;
                return;
            }
            Node Y = null;
            Node X = root;
            while (X != null)
            {
                Y = X;
                if (nowyElement.wartosc < X.wartosc)
                {
                    X = X.lewy;
                }
                else
                {
                    X = X.prawy;
                }
            }
            nowyElement.rodzic = Y;
            if (Y == null)
            {
                root = nowyElement;
            }
            else if (nowyElement.wartosc < Y.wartosc)
            {
                Y.lewy = nowyElement;
            }
            else
            {
                Y.prawy = nowyElement;
            }
            nowyElement.lewy = null;
            nowyElement.prawy = null;
            nowyElement.kolor = Color.Czerwony; //ustawiamy na czerwony kolor nowego elementu (bo dodane tak mają)
            NaprawaDrzewa(nowyElement); //sprawdzamy czy drzewo jest poprawne
        }

        private void NaprawaDrzewa(Node element)
        {
            //Sprawdzamy podstawowe założenie kolorów (rodzic nie może być czerwony)
            while (element != root && element.rodzic.kolor == Color.Czerwony)
            {
                //Jeżeli jest to sprawdzamy, który mamy przypadek
                if (element.rodzic == element.rodzic.rodzic.lewy)
                {
                    Node Y = element.rodzic.rodzic.prawy;
                    if (Y != null && Y.kolor == Color.Czerwony) //Przypadek 1: brat rodzica jest czerwony
                    {
                        element.rodzic.kolor = Color.Czarny;
                        Y.kolor = Color.Czarny;
                        element.rodzic.rodzic.kolor = Color.Czerwony;
                        element = element.rodzic.rodzic; //Nowy X
                    }
                    else //Przypadek 2: brat rodzica jest czarny
                    {
                        if (element == element.rodzic.prawy)
                        {
                            element = element.rodzic; //Nowy X
                            LewaRotacja(element);
                        }
                       //Przypadek 3: brat rodzica jest czarny i są w tym samym kierunku
                        element.rodzic.kolor = Color.Czarny;
                        element.rodzic.rodzic.kolor = Color.Czerwony;
                        PrawaRotacja(element.rodzic.rodzic);
                    }

                }
                else
                {
                    //Odbicie lustrzane powyższego
                    Node X = null;

                    X = element.rodzic.rodzic.lewy;
                    if (X != null && X.kolor == Color.Czarny) //Przypadek 1.
                    {
                        element.rodzic.kolor = Color.Czerwony;
                        X.kolor = Color.Czerwony;
                        element.rodzic.rodzic.kolor = Color.Czarny;
                        element = element.rodzic.rodzic;
                    }
                    else //Przypadek 2.
                    {
                        if (element == element.rodzic.lewy)
                        {
                            element = element.rodzic;
                            PrawaRotacja(element);
                        }
                        //Przypadek 3.
                        element.rodzic.kolor = Color.Czarny;
                        element.rodzic.rodzic.kolor = Color.Czerwony;
                        LewaRotacja(element.rodzic.rodzic);

                    }

                }
                root.kolor = Color.Czarny; //Poprawiamy kolor korzenia gdyby się zmienił w trakcie.
            }
        }

        //Wyswietlamy w kolejności InOrder
        public void InOrder(Node aktualny)
        {
            if (aktualny != null)
            {
                InOrder(aktualny.lewy);
                Console.Write("({0}) ", aktualny.wartosc);
                Console.Write("{0} ", aktualny.kolor);
                InOrder(aktualny.prawy);
            }
        }

        public void WyswietlDrzewo()
        {
            if (root == null)
            {
                Console.WriteLine("Drzewo jest puste!");
                return;
            }
            if (root != null)
            {
                Console.WriteLine("Kolejność InOrder drzewa: ");
                InOrder(root);
            }
        }

    }
}
