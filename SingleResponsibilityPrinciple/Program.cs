namespace Coding.Exercise
{
    public static class StringsTransformator
    {
        public static string TransformSeparators(
            string input,
            string originalSeparator,
            string targetSeparator)
        {
            return string.Join(targetSeparator, input.Split(originalSeparator));
        }
    }
    public class MainClass
    {
        public static void Main()
        {
            Console.WriteLine(StringsTransformator.TransformSeparators("this,is,some,thing", ",", "+"));
        }
    }
}