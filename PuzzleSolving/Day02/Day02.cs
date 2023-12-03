namespace PuzzleSolving;

public class Day02
{
    public int getSolution(List<string> inputs)
    {
        int resultP1 = 0;
        int resultP2 = 0;

        foreach (var input in inputs)
        {
            resultP1 += GetSumPossibleGames(input);
            resultP2 += GetMinCubes(input);

        }
        return resultP2;
    }
    static int GetSumPossibleGames(string input)
    {
        int maxRed = 12;
        int maxGreen = 13;
        int maxBlue = 14;

        var games = input.Split(':');
        var rounds = games[1].Split(";", StringSplitOptions.TrimEntries);
        foreach (var round in rounds)
        {
            var boxes = round.Split(",", StringSplitOptions.TrimEntries);
            foreach (var box in boxes)
            {
                var result = box.Split(" ", StringSplitOptions.TrimEntries);
                if (int.Parse(result[0]) > maxRed && result[1] == "red"
                    || int.Parse(result[0]) > maxGreen && result[1] == "green"
                        || int.Parse(result[0]) > maxBlue && result[1] == "blue")
                {
                    return 0;
                }
            }
        }
        return int.Parse(games[0].Split(' ', StringSplitOptions.TrimEntries)[1]);
    }
    static int GetMinCubes(string input)
    {
        int minRed = 0;
        int minGreen = 0;
        int minBlue = 0;

        var games = input.Split(':');
        var rounds = games[1].Split(";", StringSplitOptions.TrimEntries);
        foreach (var round in rounds)
        {
            var boxes = round.Split(",", StringSplitOptions.TrimEntries);
            foreach (var box in boxes)
            {
                var result = box.Split(" ", StringSplitOptions.TrimEntries);
                int number = int.Parse(result[0]);
                if (result[1] == "red" && number > minRed)
                    minRed = number;
                if (result[1] == "green" && number > minGreen)
                    minGreen = number;
                if (result[1] == "blue" && number > minBlue)
                    minBlue = number;
            }
        }
        return minRed * minGreen * minBlue;
    }
}








