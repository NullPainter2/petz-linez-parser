public class Program
{
    class LinezEye
    {
        public int X = 0;
        public int Y = 0;
        public string ID = "";

        /*
        EXAMPLE:
        
        [Eyes]
        12, 34			RightEye/leftEye
        28, 56 			RightIris/leftIris

        */
        public static LinezEye FromLine(string str)
        {
            var parts = str.Split(
                new char[] { ' ', '\t', ',' },
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
            );

            if (parts.Length != 3)
            {
                return null;
            }

            var result = new LinezEye();
            
            if (!int.TryParse(parts[0], out result.X))
            {
                return null;
            }

            if (!int.TryParse(parts[1], out result.Y))
            {
                return null;
            }

            result.ID = parts[2];

            return result;
        }
    };
    
    class LNZ
    {
        public List<LinezEye> Eyes = new List<LinezEye>();

        public void Parse(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            int lineIndex = 0;
            while (lineIndex < lines.Length) // for (int i = 0; i < lines.Length;)
            {
                Console.WriteLine("Parsing line '" + lines[lineIndex] + '"');

                if (lines[lineIndex].Trim().Equals("[Eyes]"))
                {
                    ForEachLine((line) =>
                    {
                        var eye = LinezEye.FromLine(line);
                        if (eye != null)
                        {
                            Eyes.Add(eye);
                        }
                    }, lines, ref lineIndex);
                }
                else
                {
                    lineIndex++;
                }
            }
        }
        
        void ForEachLine(Action<string> LineCallback, string[] lines, ref int lineIndex)
        {
            // next line
            lineIndex++;

            while (lineIndex < lines.Length)
            {
                string line = lines[lineIndex].Trim();

                Console.WriteLine("Parsing item ... '" + lines[lineIndex] + '"');

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

                bool isComment = line[0] == ';';
                if (!isComment)
                {
                    LineCallback(line);
                }

                lineIndex++; // next line
            }
        }
    };

    public static void Main()
    {
        var FILE = "YellowBird.lnz";

        var parsed = new LNZ();

        parsed.Parse(FILE);

        //
        // Print the result ...
        //

        foreach (var eye in parsed.Eyes)
        {
            Console.WriteLine("eye = {0},{1},{2}",eye.X, eye.Y, eye.ID);
        }
        
        if (true) // @debug to put breakpoint
        {
        }
    }
}
