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
                LnzParser.ParseList(lines, Eyes, ref lineIndex);
            }
            else if (line.StartsWith("[Paint Ballz]"))
            {
                LnzParser.ParseList(lines, PaintBallz, ref lineIndex);
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

};
