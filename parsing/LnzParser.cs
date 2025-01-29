using main.parsing;

public class LnzParser
{
    int lineIndex = 0;
    string[] lines;

    public void Init(string fileName)
    {
        lines = File.ReadAllLines(fileName);
        lineIndex = 0;
    }
    
    public bool GetLine(ref string line)
    {
        if (lineIndex >= lines.Length)
        {
            return false;
        }
        
        line = lines[lineIndex].Trim();

        return true;
    }

    public void NextLine()
    {
        lineIndex++;
    }
        
    public void ParseSection<T>(List<T> outList) where T : class, new()
    {
        ForeachRowInSection((row) =>
        {
            var item = LnzAttributeParser.FromLine<T>(row);
            if (item != null)
            {
                outList.Add(item);
            }
        });
    }
    
    void ForeachRowInSection(Action<string> LineCallback)
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