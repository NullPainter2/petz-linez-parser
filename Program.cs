public class Program
{

    public static void Print<T>(T obj)
    {
        foreach (var field in obj.GetType().GetFields())
        {
            var fieldType = field.FieldType.GetType().Name;
            var fieldName = field.Name;
            var value = field.GetValue(obj);
        
            Console.Write(String.Format("{0} = '{2}', ", fieldName, fieldType, value));
        }

        Console.WriteLine();
    }


    public static void Main()
    {
        var FILE = "calico-petz3.lnz";//"YellowBird.lnz";

        var parsed = new LNZ();

        parsed.Parse(FILE);

        //
        // Print the result ...
        //

        Console.WriteLine("EYES");
        foreach (var item in parsed.Eyes)
        {
            Print(item);
            // Console.WriteLine("eye = {0},{1},{2}", eye.X, eye.Y, eye.ID);
        }

        Console.WriteLine("PAINT BALLS");
        foreach (var item in parsed.PaintBallz)
        {
            Print(item);
            //Console.WriteLine("eye = {0},{1},{2}", eye.X, eye.Y, eye.ID);
        }

        // foreach (var item in parsed.PaintBall_InterfaceVariants)
        // {
        //     Print(item);
        //     //Console.WriteLine("eye = {0},{1},{2}", eye.X, eye.Y, eye.ID);
        // }
    }
}