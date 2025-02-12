using System.Numerics;

namespace main.parsing;

public class LnzItem : Attribute
{
    public LnzItem()
    {
    }
}

public static class LnzAttributeParser
{
    // @note  C# want's to be explicit with type handling of T
    // - `new()` means we use `new`
    // - `class` is to allow to return `null` 

    public static T FromLine<T>(string line) where T : class, new()
    {
        var result = new T();

        LnzRowParser rowParser = new LnzRowParser(line);
        
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
