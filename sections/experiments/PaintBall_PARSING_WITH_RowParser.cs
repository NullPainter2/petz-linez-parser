// [Paint Ballz]

using System.Numerics;

public class PaintBall_UsingRowParserVariant
{
    //
    // https://web.archive.org/web/20240313175338/https://homebody.eu/carolyn/downloabx/tutorials/tutorialbits/LNZ2nd.txt
    //
    // ;base ball diameter(% of baseball) direction color outlinecolor fuzz outline group texture

    public int BaseBall = 0; // @todo ball index
    public float Diameter = 0;
    public Vector3 Direction = new Vector3(0, 0, 0);
    public int Color = 0;
    public int OutlineColor = 0;
    public float Fuzz = 0;
    public int Outline = 0;
    public int Group = 0;
    public int Texture = 0;

    public static PaintBall_UsingRowParserVariant FromLine(string str)
    {
        PaintBall_UsingRowParserVariant result = new PaintBall_UsingRowParserVariant();

        LnzRowParser rowParser = new LnzRowParser(str);
        rowParser.Int(ref result.BaseBall);
        rowParser.Percentage(ref result.Diameter);
        rowParser.Vector3(ref result.Direction);
        rowParser.Int(ref result.Color);
        rowParser.Int(ref result.OutlineColor);
        rowParser.Float(ref result.Fuzz);
        rowParser.Int(ref result.Outline);
        rowParser.Int(ref result.Group);
        rowParser.Int(ref result.Texture);
        if (!rowParser.isOK)
        {
            return null;
        }

        return result;
    }
};