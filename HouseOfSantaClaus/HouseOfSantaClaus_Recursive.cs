using System;
using System.Collections.Generic;

class HouseOfSantaClausRecursive : HouseOfSantaClaus
{
    private const int MaxNodes = 5;
    private const int MaxEdges = 8;

    private bool[,] adjacent;            // adjacency matrix
    private bool[,] painted;             // painted edges

    // constructing a single path
    private List<Edge> current;          // current solution
    private int paintedEdges = 0;        // edges so far painted

    public HouseOfSantaClausRecursive()
    {
        // adjacency matrix
        this.adjacent = new bool[,]
        {
            { false, true,  true,  true,  false },
            { true,  false, true,  true,  false },
            { true,  true,  false, true,  true  },
            { true,  true,  true,  false, true  },
            { false, false, true,  true,  false }
        };

        // empty trial matrix
        this.painted = new bool[MaxNodes, MaxNodes];

        this.current = new List<Edge>();
    }

    // contract with base class
    public override void Solve()
    {
        this.TryPaintingEdge(0);
    }

    // private helper methods
    private void PaintEdge(int from, int to)
    {
        this.painted[from, to] = true;
        this.painted[to, from] = true;

        Edge e = new Edge(from + 1, to + 1);
        this.current.Add(e);

        this.paintedEdges++;
    }

    private void ClearEdge(int from, int to)
    {
        this.painted[from, to] = false;
        this.painted[to, from] = false;

        int last = this.current.Count;
        this.current.RemoveAt(last - 1);

        this.paintedEdges--;
    }

    private void TryPaintingEdge(int from)
    {
        for (int to = 0; to < MaxNodes; to++)
        {
            if (this.adjacent[from, to])
            {
                if (!this.painted[from, to])
                {
                    this.PaintEdge(from, to);

                    if (!(this.paintedEdges == MaxEdges))
                    {
                        this.TryPaintingEdge(to);
                    }
                    else
                    {
                        // found solution !!!
                        List<Edge> path = new List<Edge>();
                        for (int i = 0; i < this.current.Count; i++)
                            path.Add(current[i]);
                        this.solutions.Add(path);
                    }

                    this.ClearEdge(from, to);
                }
            }
        }
    }
}
    
