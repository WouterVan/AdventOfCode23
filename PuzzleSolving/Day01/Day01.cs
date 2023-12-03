namespace PuzzleSolving;

public class Day01
{
    public int getNumber(List<string> inputs)
    {
        var total = 0;

        foreach (var row in inputs)
        {
            var extractednumbers = ConvertTextToNumbers(row);
            total += int.Parse(extractednumbers.First(char.IsDigit).ToString() + extractednumbers.Last(char.IsDigit).ToString());
        }
        return total;
    }

    static string ConvertTextToNumbers(string inputString)
    {
        List<DataObject> dataObjects = new List<DataObject> { };
        int index = -1;
        int lastindex = -1;
        Dictionary<string, string> stringToNumber = new Dictionary<string, string>
        {
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"}
        };

        foreach (var entry in stringToNumber)
        {
            string numberAsText = entry.Key;
            string numberAsDigit = entry.Value;

            index = inputString.IndexOf(numberAsText);
            lastindex = inputString.LastIndexOf(numberAsText);

            if (index != -1)
                dataObjects.Add(new DataObject(index, numberAsText.Length, numberAsDigit));
            if (lastindex != -1)
                dataObjects.Add(new DataObject(lastindex, numberAsText.Length, numberAsDigit));

        }
        var minIndex = dataObjects.OrderBy(obj => obj.Index).FirstOrDefault();
        var maxIndex = dataObjects.OrderByDescending(obj => obj.Index).FirstOrDefault();
        if (maxIndex != null && dataObjects.Count > 0)
        {
            inputString = inputString.Insert(maxIndex.Index, maxIndex.Digit);

            if (minIndex != null && maxIndex.Index != minIndex.Index)
            {
                inputString = inputString.Insert(minIndex.Index, minIndex.Digit);
            }
        }
        return inputString;
    }
}
public class DataObject
{
    public int Index { get; set; }
    public int Length { get; set; }
    public string Digit { get; set; }

    public DataObject(int index, int length, string digit)
    {
        Index = index;
        Length = length;
        Digit = digit;
    }
}