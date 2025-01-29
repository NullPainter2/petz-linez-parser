using main.parsing;

public class LnzParser
{
    public static void ParseLineToList<T>(string[] lines, List<T> outList, ref int lineIndex) where T : class, new()
    {
        ForeachRowInSection((row) =>
        {
            var item = LnzAttributeParser.FromLine<T>(row);
            if (item != null)
            {
                outList.Add(item);
            }
        }, lines, ref lineIndex);
    }
    
    static void ForeachRowInSection(Action<string> LineCallback, string[] lines, ref int lineIndex)
    {
        // next line
        lineIndex++;

        while (lineIndex < lines.Length)
        {
            string line = lines[lineIndex].Trim();

            // Console.WriteLine("Parsing item ... '" + lines[lineIndex] + '"');

            // skip empty lines
            bool isEmptyLine = line.Length == 0;
            if (isEmptyLine)
            {
                lineIndex++;

                continue;
            }

            bool nextEntry = line[0] == '[';
            if (nextEntry)
            {
                return; // all items are parsed, keep the current line index
            }

            bool isComment = line[0] == ';' || line[0] == '#' || line.StartsWith("//");
            if (!isComment)
            {
                LineCallback(line);
            }

            lineIndex++; // next line
        }
    }
}