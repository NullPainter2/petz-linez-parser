using main.parsing;

class LNZ
{
    public List<Eye> Eyes = new List<Eye>();
    public List<PaintBall> PaintBallz = new List<PaintBall>();
    // public List<PaintBall_AttributesVariant> PaintBallz = new List<PaintBall_AttributesVariant>();
    // public List<PaintBall_InterfaceVariant> PaintBall_InterfaceVariants = new List<PaintBall_InterfaceVariant>();

    public void Parse(string fileName)
    {
        var lines = File.ReadAllLines(fileName);

        int lineIndex = 0;
        while (lineIndex < lines.Length)
        {
            // Console.WriteLine("Parsing line '" + lines[lineIndex] + '"');

            var line = lines[lineIndex].Trim();

            // https://homebody.eu/carolyn/downloabx/tutorials/tutorialbits/LNZ3rd.txt

            if (line.StartsWith("[Eyes]"))
            {
                ParseList(lines, Eyes, ref lineIndex);
            }
            else if (line.StartsWith("[Paint Ballz]"))
            {
                ParseList(lines, PaintBallz, ref lineIndex);
            }
//             else if (line.StartsWith("[Paint Ballz]"))
//             {
// // using attributes
//                 ForeachRowInSection((row) =>
//                 {
//                     var item = LnzAttributeParser.FromLine<PaintBall>(row);
//                     if (item != null)
//                     {
//                         pPaintBall_AttributesVariants.Add(item);
//                     }
//                 }, lines, ref lineIndex);
//             }
//             else if (line.StartsWith("[Paint Ballz]"))
//             {
// // generic way                
//                 ParseList_UsingFromLine(lines, PaintBall_InterfaceVariants, ref lineIndex);
//             }
// // manual way    
//             else if (line.StartsWith("[Paint Ballz]"))
//             {
//                 ForeachRowInSection((row) =>
//                 {
//                     var item = PaintBall_InterfaceVariant.FromLine(row);
//                     if (item != null)
//                     {
//                         PaintBall_InterfaceVariants.Add(item);
//                     }
//                 }, lines, ref lineIndex);
//             }
//             else if (line.StartsWith("[Eyes]"))
//             {
//                 ForeachRowInSection((row) =>
//                 {
//                     var eye = Eye.FromLine(row);
//                     if (eye != null)
//                     {
//                         Eyes.Add(eye);
//                     }
//                 }, lines, ref lineIndex);
//             }
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

    // private void ParseList_UsingFromLine<T>(string[] lines, List<T> outList, ref int lineIndex) where T : LnzSection<T>
    // {
    //     ForeachRowInSection((row) =>
    //     {
    //         var item = T.FromLine(row);
    //         if (item != null)
    //         {
    //             outList.Add(item);
    //         }
    //     }, lines, ref lineIndex);
    // }

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