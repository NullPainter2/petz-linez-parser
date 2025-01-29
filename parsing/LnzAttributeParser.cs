using System.Numerics;

namespace main.parsing;

// Attribute so we know what fields to parse ... 

public class LnzItem : Attribute
{
    public LnzItem()
    {
        // @todo add validations, re-ordering, ...
    }
}

public static class LnzAttributeParser
{
    // @note  C# want's to be explicit with type handling ...  `new()` means we use `new`, class is to allow to return `null` 

    public static T FromLine<T>(string line) where T : class, new()
    {
        var result = new T();

        LnzRowParser rowParser = new LnzRowParser(line);

        // Used to have reference for parsing :
        //
        // rowParser.Percentage(ref result.Diameter);
        // rowParser.Vector3(ref result.Direction);
        // rowParser.Int(ref result.Color);
        // rowParser.Int(ref result.OutlineColor);
        // rowParser.Float(ref result.Fuzz);
        // rowParser.Int(ref result.Outline);
        // rowParser.Int(ref result.Group);
        // rowParser.Int(ref result.Texture);
        // return result;

        // iterate trough all field names of class T

        foreach (var field in result.GetType().GetFields())
        {
            var fieldName = field.Name;
            var typeName = field.FieldType.Name;

            // is line marked for parsing?

            if (Attribute.GetCustomAttribute(field, typeof(LnzItem)) != null)
            {
                // save item based on whatever type the field has

                switch (typeName)
                {
                    case "Single":
                    {
                        float value = 0;
                        rowParser.Float(ref value);
                        field.SetValue(result, value);
                    }
                        break;

                    case "Vector3":
                    {
                        Vector3 value = new Vector3(0, 0, 0);
                        rowParser.Vector3(ref value);
                        field.SetValue(result, value);
                    }
                        break;

                    case "Int32":
                    {
                        int value = 0;
                        rowParser.Int(ref value);
                        field.SetValue(result, value);
                    }
                        break;
                    case "String":
                    {
                        string value = "";
                        rowParser.String(ref value);
                        field.SetValue(result, value);
                    }
                        break;
                    default:
                        throw new NotImplementedException($"LNZ : parsing of {typeName} field is not implemented");
                        break;
                }
            }

            if (!rowParser.isOK)
            {
                ; // @debug
            }
        }

        if (!rowParser.isOK)
        {
            return null;
        }

        return result;
    }
}