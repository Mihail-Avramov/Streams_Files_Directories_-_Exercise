using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extensionsFiles = new SortedDictionary<string, List<FileInfo>>();

           string[] filesPaths = Directory.GetFiles(inputFolderPath);

           foreach (var filePath in filesPaths)
           {
               FileInfo fileInfo = new FileInfo(filePath);

               if (!extensionsFiles.ContainsKey(fileInfo.Extension))
               {
                    extensionsFiles.Add(fileInfo.Extension, new List<FileInfo>());
               }

               extensionsFiles[fileInfo.Extension].Add(fileInfo);
           }

           StringBuilder sb = new StringBuilder();

           foreach (var extension in extensionsFiles
                        .OrderByDescending(e => e.Value.Count))
           {
               sb.AppendLine(extension.Key);

               foreach (var file in extension.Value.OrderBy(f => f.Length))
               {
                   sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
               }
           }

           Console.WriteLine(sb.ToString());

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(filePath, textContent);
        }
    }
}
