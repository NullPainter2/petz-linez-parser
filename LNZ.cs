using main.parsing;

class LNZ
{
    public List<Eye> Eyes = new List<Eye>();
    public List<PaintBall> PaintBallz = new List<PaintBall>();

    public void Parse(string fileName)
    {
        LnzParser parser = new LnzParser();

        parser.Init(fileName);

        string sectionName = "";
        while(parser.GetSection(ref sectionName))
        {
            if (sectionName == "[Eyes]")
            {
                parser.ParseSection(Eyes);
            }
            else if (sectionName == "[Paint Ballz]")
            {
                parser.ParseSection(PaintBallz);
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
                // ignore this section
                
                Console.WriteLine(String.Format("{0} skipped ...",sectionName));
                
                parser.NextLine();
            }
        }
    }

};
