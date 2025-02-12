using main.parsing;

/*

EXAMPLE:

     LnzParser parser = new LnzParser();

    parser.Init(fileName);

    string sectionName = "";
    while(parser.GetSection(ref sectionName))
    {
        if (sectionName == "[Eyes]")
        {
            parser.ParseSection(EyesList); // stores values into the List
        }
        else if (sectionName == "[Paint Ballz]")
        {
            parser.ParseSection(PaintBallzList); // stores values into the List
        }

        // skip to next line (parser doesn't auto advance

        parser.NextLine();
 */

public class LnzParser
{
    int lineIndex = 0;
    string[] lines;

    public void Init(string fileName)
    {
        lines = File.ReadAllLines(fileName);
        lineIndex = 0;
    }

    /// /////////////////////////////////////////////////////////////
    ///
    /// lowest level api
    ///
    /////////////////////////////////////////////////////////////////
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

    /////////////////////////////////////////////////////////////////

    public void ParseSection<T>(List<T> outList) where T : class, new()
    {
        _ForeachRowInSection((row) =>
        {
            T item = LnzAttributeParser.FromLine<T>(row);
            if (item != null)
            {
                outList.Add(item);
            }
        });
    }

    public bool GetSection(ref string sectionName)
    {
        for (; lineIndex < lines.Length; lineIndex++)
        {
            string line = _GetCleanName(lines[lineIndex]);

            if (line.Length == 0)
            {
                continue;
            }

            if (line[0] == '[')
            {
                sectionName = line;

                return true;
            }
        }

        return false;
    }

    string _GetCleanName(string line)
    {
        // strip comments

        int commentIndex = -1;
        foreach (var comment in new string[] { "//", ";", "#" })
        {
            commentIndex = line.IndexOf(comment, 0, StringComparison.Ordinal);
            if (commentIndex != -1)
            {
                line = line.Substring(0, commentIndex);
                line = line.Trim();
            }
        }

        // trim whitespace

        line = line.Trim();

        return line;
    }

    void _ForeachRowInSection(Action<string> LineCallback)
    {
        // we are at section, so next line
        lineIndex++;

        while (lineIndex < lines.Length)
        {
            string line = _GetCleanName(lines[lineIndex]);

            // skip empty lines
            bool isEmptyLine = line.Length == 0;
            if (isEmptyLine)
            {
                lineIndex++;

                continue;
            }

            // is next section?
            bool nextEntry = line[0] == '[';
            if (nextEntry)
            {
                return; // all items of section are parsed, keep the current line index
            }

            LineCallback(line);

            lineIndex++; // next line
        }
    }
}
