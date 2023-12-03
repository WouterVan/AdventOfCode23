using System.Runtime.Serialization.Formatters;

namespace PuzzleSolving;

public class Day03
{
    public string getSolution(List<string> inputs)
    {
        int firstIndex = -1;
        int lastIndex = -1;
        int solution = 0;
        for (int i = 0; i < inputs.Count; i++)
        {
            for (int j = 0; j < inputs[i].Length; j++)
            {
                if (firstIndex == -1 && char.IsDigit(inputs[i][j]))
                    firstIndex = j;
                while (j < inputs[i].Length && char.IsDigit(inputs[i][j]))
                {
                    lastIndex = j;
                    j++;
                }
                if (firstIndex != -1)
                {
                    if (i >= 0 && i < inputs.Count -1)
                    {
                        
                        if (hasAdjacentBelow(i, firstIndex, lastIndex, inputs))
                            solution += int.Parse(inputs[i].Substring(firstIndex, lastIndex - firstIndex + 1));
                    }
                    if (i > 0)
                    {
                        if (hasAdjacentAbove(i, firstIndex, lastIndex, inputs))
                            solution += int.Parse(inputs[i].Substring(firstIndex, lastIndex - firstIndex + 1));
                    }
                    if (hasAdjacent(i, firstIndex, lastIndex, inputs))
                        solution += int.Parse(inputs[i].Substring(firstIndex, lastIndex - firstIndex + 1));
                }

                firstIndex = -1;
                lastIndex = -1;
            }
        }
        Console.WriteLine(solution);
        return "";
    }

    public bool hasAdjacentBelow(int i, int firstIndex, int lastIndex, List<string> inputs)
    {
        if (lastIndex < inputs[i].Length - 1)
            lastIndex += 2;
        if (firstIndex != 0)
            firstIndex -= 1;

        for (int k = firstIndex; k < lastIndex; k++)
        {
            if (!char.IsNumber(inputs[i + 1][k]) && inputs[i + 1][k] != '.')
            {
                return true;
            }
        }
        return false;
    }
    public bool hasAdjacentAbove(int i, int firstIndex, int lastIndex, List<string> inputs)
    {
        if (lastIndex < inputs[i].Length - 1)
            lastIndex += 2;
        else if (lastIndex == inputs[i].Length)
            lastIndex += 1;
            
        if (firstIndex != 0)
            firstIndex -= 1;

        for (int k = firstIndex; k < lastIndex; k++)
        {
            if (!char.IsNumber(inputs[i - 1][k]) && inputs[i - 1][k] != '.')
            {
                return true;
            }
        }
        return false;
    }
    public bool hasAdjacent(int i, int firstIndex, int lastIndex, List<string> inputs)
    {
        if (lastIndex < inputs[i].Length - 1)
            lastIndex += 2;
        if (firstIndex != 0)
            firstIndex -= 1;

        for (int k = firstIndex; k < lastIndex; k++)
        {
            if (!char.IsNumber(inputs[i][k]) && inputs[i][k] != '.')
            {
                return true;
            }
        }
        return false;
    }
}