using System;

namespace Coding.Exercise
{
    public class MainClass
    {
        public static void  Main(string[] args)
        {
            List<string> processedStrings = Exercise.ProcessAll(["bobcat", "gladiator", "rupology"]);
            foreach(var str in processedStrings)
            {   
                Console.WriteLine(str);
            }
        }
    }

    public class Exercise
    {
        public static List<string> ProcessAll(List<string> words)
        {
            var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };
    
            List<string> result = words;
            foreach (var stringsProcessor in stringsProcessors)
            {
                result = stringsProcessor.Process(result);
            }
            return result;
        }
    }
    
    class StringsProcessor
    {
        public List<string> Process(List<string> words)
        {
            List<string> result = [];
            foreach (var word in words)
            {
                result.Add(ProcessString(word));
            }
            return result;
        }

        protected virtual string ProcessString(string text) => text;
    }
    class StringsTrimmingProcessor : StringsProcessor
    {
        protected override string ProcessString(string text) => text[..(text.Length / 2)];
    }

    class StringsUppercaseProcessor : StringsProcessor
    {
        protected override string ProcessString(string text) => text.ToUpper();
    }
}
