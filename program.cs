using Projekt3;
using System.ComponentModel.Design;
using System.Drawing;


public enum typslowa
{
    slowa,
    mniejniz4,
    wszystkieSlowa
}

class Program
{
    static string krzyzacy = "krzyzacySlowa.txt";

    static string slowa = "slowa.txt";
    static string mniejniz4 = "mniejRowne4Slowa.txt";
    static string wszystkieSlowa = "wszystkieSlowa.txt";

    static int doPoliczenia = 5;

    static void Main()
    {
        Run(typslowa.slowa);
        Run(typslowa.mniejniz4);
        Run(typslowa.wszystkieSlowa);
    }

    static void Run(typslowa type)
    {
        Random rand = new Random();
        string[] words = GetWords(type);

        int[] averageDepths = new int[100];
        int[] averageInsertMoves = new int[100];
        int[] averageSearchMoves = new int[100];
        int[] averagetDeleteMoves = new int[100];

        
        for (int size = 100; size <= 10 * 1000; size += 100)
        {
            int sizeIndex = size / 100 - 1;

            int totalDepth = 0;
            int totalInsert = 0;
            int totalSearch = 0;
            int totalDelete = 0;
            
            for (int times = 0; times < doPoliczenia
    ; times++)
            {
                Tree tree = new Tree();

                //uzuplenianie drzewa
                for (int i = 0; i < size; i++)
                {
                    tree.Insert(words[GetRandomIndex(words.Length)], false);
                }
                //glebokosc kazdego drzewa
                totalDepth += tree.depth;
                //x razy do lepszego zaokralegnia
                for (int j = 0; j < doPoliczenia
         * 2; j++)
                {
                    tree.Insert(words[GetRandomIndex(words.Length)], true);
                    tree.Search(words[GetRandomIndex(words.Length)], true);
                    tree.Delete(words[GetRandomIndex(words.Length)], true);
                }
                
                totalInsert += Tree.InsertMoveCount;
                totalSearch += Tree.SearchMoveCount;
                totalDelete += Tree.DeleteMoveCount;

            }

            Console.WriteLine($"SIZE = {size} Index---({sizeIndex})");
            averageDepths[sizeIndex] = totalDepth / (doPoliczenia
    );
            averageInsertMoves[sizeIndex] = totalInsert / (doPoliczenia
     * 2);
            averageSearchMoves[sizeIndex] = totalSearch / (doPoliczenia
     * 2);
            averagetDeleteMoves[sizeIndex] = totalDelete / (doPoliczenia
     * 2);
            
    }");
            
    }");
            
    }");
            
    }");

            totalDepth = 0;
            Tree.ResetData();
        }

        Console.WriteLine();
        Console.WriteLine($"average depth:");
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"{averageDepths[i]} ");
        }

        Console.WriteLine($"average Insert Moves:");
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"{averageInsertMoves[i]} ");
        }

        Console.WriteLine($"average Search Moves:");
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"{averageSearchMoves[i]} ");
        }

        Console.WriteLine($"averaget Delete Moves:");
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"{averagetDeleteMoves[i]} ");
        }
    }

    static int GetRandomIndex(int size)
    {
        Random rand = new Random();
        return rand.Next() % size;
    }
    static string[] GetWords(typslowa type)
    {
        string[] words = new string[File.ReadAllText(krzyzacy).Length];
        switch (type)
        {
            case typslowa.slowa:
                words = File.ReadAllLines(slowa);
                break;
            case typslowa.mniejniz4:
                words = File.ReadAllLines(mniejniz4);
                break;
            case typslowa.wszystkieSlowa:
                words = File.ReadAllLines(wszystkieSlowa);
                break;
            default:
                break;
        }
        return words;
    }
}