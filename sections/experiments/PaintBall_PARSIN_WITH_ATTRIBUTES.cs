// [Paint Ballz]

// https://web.archive.org/web/20240313175338/https://homebody.eu/carolyn/downloabx/tutorials/tutorialbits/LNZ2nd.txt

using System.Numerics;
using main.parsing;

public class PaintBall_AttributesVariant
{
    [LnzItem]
    public int BaseBall = 0;
    [LnzItem]
    public float Diameter = 0;
    [LnzItem]
    public Vector3 Direction = new Vector3(0, 0, 0);
    [LnzItem]
    public int Color = 0;
    [LnzItem]
    public int OutlineColor = 0;
    [LnzItem]
    public float Fuzz = 0;
    [LnzItem]
    public int Outline = 0;
    [LnzItem]
    public int Group = 0;
    [LnzItem]
    public int Texture = 0;
};