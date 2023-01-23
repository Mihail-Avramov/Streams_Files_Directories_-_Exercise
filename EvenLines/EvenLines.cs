using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            int counter = 0;
            char[] charsToReplace = new[] {'-', ',', '.', '!', '?'};
            StringBuilder sb = new StringBuilder();

            using StreamReader streamReader = new StreamReader(inputFilePath);

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();

                if (counter % 2 == 0)
                {
                    line = ReplaceSymbols(charsToReplace, line);
                    sb.AppendLine(string.Join(" ", line.Split(" ").Reverse()));
                }

                counter++;
            }

            return sb.ToString();
        }

        private static string ReplaceSymbols(char[] charsToReplace, string line)
        {
            foreach (var ch in charsToReplace)
            {
                line = line.Replace(ch, '@');
            }

            return line;
        }
    }
}
