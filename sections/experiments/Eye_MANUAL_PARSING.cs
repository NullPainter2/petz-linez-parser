// VARIANT: MANUAL PARSING

using main.parsing;

class Eye_ManualParsing
{
    /*
        EXAMPLE:

        [Eyes]
        12, 34			RightEye/leftEye
        28, 56 			RightIris/leftIris

        //    https://petz.miraheze.org/wiki/LNZ
    */
        
    public int X = 0;
    public int Y = 0;
    public string ID = "";
    
    public static Eye FromLine(string str)
    {
        var parts = str.Split(
            new char[] { ' ', '\t', ',' },
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
        );

        if (parts.Length != 3)
        {
            return null;
        }

        var result = new Eye();

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