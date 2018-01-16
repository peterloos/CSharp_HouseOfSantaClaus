using System;
using System.Collections.Generic;

class Edge
{
    private int x;
    private int y;

    public Edge(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // properties
    public int X
    {
        get
        {
            return this.x;
        }
    }

    public int Y
    {
        get
        {
            return this.y;
        }
    }

    // class helper method
    public static List<Edge> ToEdges(int number)
    {
        List<Edge> result = new List<Edge>();
        for (int i = 0; i < 8; i++)
        {
            int rem1 = number % 10;
            number /= 10;
            int rem2 = number % 10;

            // Note:
            // 'number' is traversed from right to left, therefore
            // a) we change the order of digits when constructing an edge object
            // b) we insert edge objects at begin of list
            Edge e = new Edge(rem2, rem1);
            result.Insert(0, e);
        }
        return result;
    }

    // overrides
    public override bool Equals(Object obj)
    {
        Edge tmp = (Edge)obj;
        return
            ((this.x == tmp.x && this.y == tmp.y) ||
             (this.x == tmp.y && this.y == tmp.x)) ? true : false;
    }

    public override String ToString()
    {
        return String.Format("[{0},{1}]", this.x, this.y);
    }

    // just to prevent compiler warning
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

