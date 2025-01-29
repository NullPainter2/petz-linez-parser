namespace main.parsing;

public interface LnzSection<T>
{
    // @note `abstract` ... inteface must be implemented, also abstract is needed for `static` otherwise C# requires to implement body
    
    abstract static T FromLine(string str);

    //
    // @note
    //
    // Having static method in interface C# requires body.
    //
    // Generic T where one does the `new` with it, C# requires that new to be explicit with new constrain.
    //
    // static T FromLine<T>(string str);
    //     where T: new()
    // {
    //     return new T();
    // }
}