using System;
using System.Collections;
using System.Collections.Generic;

abstract class HouseOfSantaClaus : IEnumerable<List<Edge>>, IFormattable
{
    protected List<List<Edge>> solutions;  // list of all solutions

    // c'tor
    public HouseOfSantaClaus()
    {
        this.solutions = new List<List<Edge>>();
    }

    // properties
    public int Count
    {
        get
        {
            return this.solutions.Count;
        }
    }

    public List<List<Edge>> Solutions
    {
        get
        {
            // return a copy to the caller
            List<List<Edge>> copy = new List<List<Edge>>();
            for (int i = 0; i < this.solutions.Count; i++)
                copy.Add(solutions[i]);
            return copy;
        }
    }

    // abstract member
    public abstract void Solve();

    // contract with base class
    public override String ToString()
    {
        String s = "";
        for (int i = 0; i < this.solutions.Count; i++)
        {
            List<Edge> egdes = this.solutions[i];

            for (int j = 0; j < egdes.Count; j++)
            {
                s += egdes[j].ToString();
                if (j < egdes.Count - 1)
                    s += ", ";
            }
            s += Environment.NewLine;
        }
        return s;
    }

    public String ToString(String format, IFormatProvider formatProvider)
    {
        if (format == null)
            return this.ToString();

        if (format.Equals("Edges"))
        {
            return this.ToString();
        }
        else if (format.Equals("Path"))
        {
            String s = "";
            for (int i = 0; i < this.solutions.Count; i++)
            {
                List<Edge> egdes = this.solutions[i];

                Edge e = egdes[0];
                s += String.Format("{0}->{1}", e.X, e.Y);

                for (int j = 1; j < egdes.Count; j++)
                {
                    Edge e1 = egdes[j];
                    s += String.Format("->{0}", e1.Y);
                }

                s += "    ";
                if (i % 2 == 1)
                    s += Environment.NewLine;
            }
            return s;
        }
        else
            return this.ToString();
    }

    // implementation of interface 'IEnumerable<List<Edge>>'
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<List<Edge>> GetEnumerator()
    {
        return solutions.GetEnumerator();
    }   
}
