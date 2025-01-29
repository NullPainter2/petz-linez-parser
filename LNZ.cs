using main.parsing;

class LNZ
{
    public List<Eye> eyez = new List<Eye>();
    public List<PaintBall> paintBallz = new List<PaintBall>();

    public void Parse(string fileName)
    {
        LnzParser parser = new LnzParser();

        parser.Init(fileName);

        string sectionName = "";
        while (parser.GetSection(ref sectionName))
        {
            if (sectionName == "[Eyes]")
            {
                parser.ParseSection(eyez);
            }
            else if (sectionName == "[Paint Ballz]")
            {
                parser.ParseSection(paintBallz);
            }
            else
            {
                // section is ignored ...

                Console.WriteLine(String.Format("{0} skipped ...", sectionName));
            }

            // parser doesn't auto advance
            parser.NextLine();
        }
    }
}