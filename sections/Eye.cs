using main.parsing;

class Eye
{
    /*
        EXAMPLE:

        [Eyes]
        12, 34			RightEye/leftEye
        28, 56 			RightIris/leftIris

        //    https://petz.miraheze.org/wiki/LNZ
    */

    [LnzItem] public int X = 0;

    [LnzItem] public int Y = 0;

    [LnzItem] public string ID = "";
}