public class Program
{
    public static void Main()
    {
        var FILE = "calico-petz3.lnz";

        var parsed = new LNZ();

        parsed.Parse(FILE);

        // Print the result ...

        Console.WriteLine(String.Format("EYES #{0}", parsed.eyez.Count));
        foreach (var item in parsed.eyez)
        {
            Print(item);
        }

        Console.WriteLine("PAINT BALLS #{0}", parsed.paintBallz.Count);
        foreach (var item in parsed.paintBallz)
        {
            Print(item);
        }
    }

    public static void Print<T>(T obj)
    {
        foreach (var field in obj.GetType().GetFields())
        {
            var fieldType = field.FieldType.GetType().Name;
            var fieldName = field.Name;
            var value = field.GetValue(obj);

            // @note C# handles printing of numerics.Vector3 too!

            Console.Write(String.Format("{0} = '{2}', ", fieldName, fieldType, value));
        }

        Console.WriteLine();
    }
}