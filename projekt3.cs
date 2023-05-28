using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projekt3
{
    public class Tree
    {
        public static int wstawMoveCount = 0;
        public static int szukajMoveCount = 0;
        public static int DeleteMoveCount = 0;

        public Node root;
        public int depth
        {
            get
            {
                return GetDepth(root);
            }
            set
            {
                depth = wartosc;
            }
        }
        public Tree()
        {
            root = null;
        }
        public Tree(string wartosc)
        {
            root = new Node(wartosc);
        }

        #region wstaw
        public void wstaw(string wartosc, bool Policz)
        {
            root = wstawRec(root, wartosc, Policz);
        }

        public Node wstawRec(Node actualRoot, string wartosc, bool Policz)
        {
            if (Policz == false)
            {
                wstawMoveCount = 0;
            }

            if (actualRoot == null)
            {
                if (Policz)
                {
                    wstawMoveCount++;
                }

                actualRoot = new Node(wartosc);
                return actualRoot;
            }

            if (string.porownaj(actualRoot.wartosc, wartosc) > 0)
            {
                if (Policz)
                {
                    wstawMoveCount++;
                }

                actualRoot.lewy = wstawRec(actualRoot.lewy, wartosc, Policz);
            }
            else if (string.porownaj(actualRoot.wartosc, wartosc) <= 0)
            {
                if (Policz)
                {
                    wstawMoveCount++;
                }

                actualRoot.prawy = wstawRec(actualRoot.prawy, wartosc, Policz);
            }

            return actualRoot;
        }
        #endregion wstaw

        #region szukaj
        public Node szukaj(string wartosc, bool Policz)
        {
            return szukajRec(root, wartosc, Policz);
        }

        public Node szukajRec(Node actualRoot, string wartosc, bool Policz)
        {
            if (actualRoot == null || actualRoot.wartosc == wartosc)
            {
                if (Policz)
                {
                    szukajMoveCount++;
                }

                return actualRoot;
            }
            if (string.porownaj(actualRoot.wartosc, wartosc) < 0)
            {
                if (Policz)
                {
                    szukajMoveCount++;
                }

                return szukajRec(actualRoot.prawy, wartosc, Policz);
            }
            else
            {
                if (Policz)
                {
                    szukajMoveCount++;
                }

                return szukajRec(actualRoot.lewy, wartosc, Policz);
            }
        }
        #endregion szukaj

        #region delete
        public void Delete(string wartosc, bool Policz)
        {
            root = DeleteRec(root, wartosc, Policz);
        }

        public Node DeleteRec(Node actualRoot, string wartosc, bool Policz)
        {
            if (actualRoot == null)
            {
                return actualRoot;
            }

            if (string.porownaj(actualRoot.wartosc, wartosc) > 0)
            {
                if (Policz)
                {
                    DeleteMoveCount++;
                }
                actualRoot.lewy = DeleteRec(actualRoot.lewy, wartosc, Policz);
            }
            else if (string.porownaj(actualRoot.wartosc, wartosc) < 0)
            {
                if (Policz)
                {
                    DeleteMoveCount++;
                }
                actualRoot.prawy = DeleteRec(actualRoot.prawy, wartosc, Policz);
            }
            else
            {
                if (actualRoot.lewy == null)
                {
                    return actualRoot.prawy;
                }
                else if (actualRoot.prawy == null)
                {
                    return actualRoot.lewy;
                }
                else
                {
                    actualRoot.wartosc = minwartosc(actualRoot.prawy);

                    if (Policz)
                    {
                        DeleteMoveCount++;
                    }
                    actualRoot.prawy = DeleteRec(actualRoot.prawy, actualRoot.wartosc, Policz);
                }
            }
            return actualRoot;
        }

        string minwartosc(Node actualRoot)
        {
            string minv = actualRoot.wartosc;
            while (actualRoot.lewy != null)
            {
                minv = actualRoot.lewy.wartosc;
                actualRoot = actualRoot.lewy;
            }
            return minv;
        }


        #endregion delete
        #region wypisz
        public void Print()
        {
            inorder();
            Console.WriteLine();
        }

        void inorder()
        {
            inorderRec(root);
        }

        void inorderRec(Node root)
        {
            if (root != null)
            {
                inorderRec(root.lewy);
                Console.Write(root.wartosc + " ");
                inorderRec(root.prawy);
            }
        }

        #endregion wypisz

        int GetDepth(Node actualRoot)
        {
            if (actualRoot == null)
            {
                return 0;
            }

            int lewyDepth = GetDepth(actualRoot.lewy);
            int prawyDepth = GetDepth(actualRoot.prawy);

            return Math.Max(lewyDepth, prawyDepth) + 1;
        }

        public static void ResetData()
        {
            wstawMoveCount = 0;
            szukajMoveCount = 0;
            DeleteMoveCount = 0;
        }
    }

    public class Node
    {
        public string wartosc;
        public Node lewy = null;
        public Node prawy = null;

        public Node()
        {
            wartosc = "";
        }

        public Node(string wartosc)
        {
            this.wartosc = wartosc;
        }
    }
}