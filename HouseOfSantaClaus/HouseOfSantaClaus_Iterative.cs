using System;
using System.Collections.Generic;

class HouseOfSantaClausIterative : HouseOfSantaClaus
{
    private const int Min = 111111111;
    private const int Max = 155555552;

    private int[] digits;

    public HouseOfSantaClausIterative()
    {
        this.digits = new int[9];
    }

    // contract with base class
    public override void Solve()
    {
        for (int i = Min; i <= Max; i++)
        {
            if (!this.IsSolution(i))
                continue;

            List<Edge> edges = Edge.ToEdges(i);
            this.solutions.Add(edges);
        }
    }

    // private helper methods
    private bool IsSolution(int number)
    {
        this.NumberToDigits(number);

        // verify range of numbers (1..5)
        if (!this.CheckValidRangeOfDigits())
            return false;

        // exclude consecutive identical digits
        if (!this.CheckValidSequenceOfDigits())
            return false;

        // exclude edges between 1 and 5 or 2 and 5
        if (!this.CheckValidEdges())
            return false;

        // exclude duplicate edges
        if (!this.CheckForDuplicateEdges())
            return false;

        return true;
    }

    private bool CheckValidRangeOfDigits()
    {
        for (int i = 0; i < 9; i++)
        {
            if (digits[i] == 0 || digits[i] > 5)
                return false;
        }
        return true;
    }

    private bool CheckValidSequenceOfDigits()
    {
        for (int i = 1; i < 9; i++)
        {
            if (digits[i-1] == digits[i])
                return false;
        }
        return true;
    }

    private bool CheckValidEdges ()
    {
        for (int i = 1; i < 9; i ++)
        {
            int edge = digits[i-1] * 10 + digits[i];
            if (edge == 15 || edge == 51 || edge == 25 || edge == 52)
                return false;
        }

        return true;
    }

    private bool CheckForDuplicateEdges ()
    {
        for (int i = 1; i < 9; i ++)
        {
            int edge1 = digits[i-1] * 10 + digits[i];
            int edge2 = digits[i] * 10 + digits[i-1];

            for (int j = i; j < 8; j ++)
            {
                int edge = digits[j] * 10 + digits[j+1];
                if(edge == edge1 || edge == edge2)
                    return false;
            }
        }

        return true;
    }

    private void NumberToDigits (int number)
    {
        for (int i = 8; i >= 0; i --)
        {
            digits[i] = number % 10;
            number /= 10;
        }
    }
}
