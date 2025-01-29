// VARIANT:  WITH INTERFACE

using System.Numerics;
using main.parsing;

public class PaintBall_InterfaceVariant: LnzSection<PaintBall_InterfaceVariant>
{
    public int BaseBall = 0; // @todo ball index
    public float Diameter = 0;
    public Vector3 Direction = new Vector3(0, 0, 0);
    public int Color = 0;
    public int OutlineColor = 0;
    public float Fuzz = 0;
    public int Outline = 0;
    public int Group = 0;
    public int Texture = 0;
    
    // @note It is error not having this class -> one doesn't forget to add the parsing.

    public static PaintBall_InterfaceVariant FromLine(string str)
    {
        PaintBall_InterfaceVariant result = new PaintBall_InterfaceVariant();

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