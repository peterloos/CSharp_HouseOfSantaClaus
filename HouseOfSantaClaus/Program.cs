using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    public static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Console.WriteLine("Starting House of Santa Claus ...");

        Test01();
        Test02();
        Test03();
        Test04();
        TestTest();

        sw.Stop();
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }

    private static void Test01()
    {
        HouseOfSantaClausIterative sc = new HouseOfSantaClausIterative();
        sc.Solve();
        Console.WriteLine("Found Solutions: {0}", sc.Count);
        Console.WriteLine("{0:Path}", sc);
        Console.WriteLine("{0:Edges}", sc);
    }

    private static void Test02()
    {
        HouseOfSantaClausIterative sc = new HouseOfSantaClausIterative();
        sc.Solve();
        Console.WriteLine("Found Solutions: {0}", sc.Count);

        foreach (List<Edge> edges in sc)
        {
            for (int j = 0; j < edges.Count; j++)
            {
                Console.Write(edges[j].ToString());
                if (j < edges.Count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }
    }

    private static void Test03()
    {
        HouseOfSantaClausRecursive sc = new HouseOfSantaClausRecursive();
        sc.Solve();
        Console.WriteLine("Found Solutions: {0}", sc.Count);
        Console.WriteLine("{0:Path}", sc);
        Console.WriteLine("{0:Edges}", sc);
    }

    private static void Test04()
    {
        HouseOfSantaClausRecursive sc = new HouseOfSantaClausRecursive();
        sc.Solve();
        Console.WriteLine("Found Solutions: {0}", sc.Count);

        foreach (List<Edge> edges in sc)
        {
            for (int j = 0; j < edges.Count; j++)
            {
                Console.Write(edges[j].ToString());
                if (j < edges.Count - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }
    }

    private static void TestTest()
    {
        HouseOfSantaClausIterative sc1 = new HouseOfSantaClausIterative();
        HouseOfSantaClausRecursive sc2 = new HouseOfSantaClausRecursive();

        sc1.Solve();
        Console.WriteLine("{0:Path}", sc1);

        sc2.Solve();
        Console.WriteLine("{0:Path}", sc2);

        List<List<Edge>> s1 = sc1.Solutions;
        List<List<Edge>> s2 = sc2.Solutions;

        for (int i = 0; i < s1.Count; i++)
        {
            List<Edge> l1 = s1[i];
            List<Edge> l2 = s2[i];

            for (int j = 0; j < l1.Count; j++)
            {
                Edge e1 = l1[j];
                Edge e2 = l2[j];

                if (! (e1.Equals(e2)))
                    Console.WriteLine("WRONG");
            }
        }
    }
}
