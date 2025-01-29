using main.parsing;

class LNZ
{
    public List<Eye> Eyes = new List<Eye>();
    public List<PaintBall> PaintBallz = new List<PaintBall>();

    public void Parse(string fileName)
    {
        var lines = File.ReadAllLines(fileName);

        int lineIndex = 0;
        while (lineIndex < lines.Length)
        {
            var line = lines[lineIndex].Trim();

            if (line.StartsWith("[Eyes]"))
            {
                ParseList(lines, Eyes, ref lineIndex);
            }
            else if (line.StartsWith("[Paint Ballz]"))
            {
                ParseList(lines, PaintBallz, ref lineIndex);
            }
             // else if (line.StartsWith("[Paint Ballz]"))
             // {
             //     ForeachRowInSection((row) =>
             //     {
             //         var item = LnzAttributeParser.FromLine<PaintBall>(row);
             //         if (item != null)
             //         {
             //             PaintBallz.Add(item);
             //         }
             //     }, lines, ref lineIndex);
             // }
             // else if (line.StartsWith("[Eyes]"))
             // {
             //     ForeachRowInSection((row) =>
             //     {
             //         var eye = Eye.FromLine(row);
             //         if (eye != null)
             //         {
             //             Eyes.Add(eye);
             //         }
             //     }, lines, ref lineIndex);
             // }
            else
            {
                lineIndex++;
            }
        }
    }

    private void ParseList<T>(string[] lines, List<T> outList, ref int lineIndex) where T : class, new()
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
    
    void ForeachRowInSection(Action<string> LineCallback, string[] lines, ref int lineIndex)
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
};
