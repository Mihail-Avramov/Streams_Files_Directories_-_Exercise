using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create);

            archive.CreateEntryFromFile(inputFilePath, Path.GetFileName(inputFilePath));
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using ZipArchive archive = ZipFile.OpenRead(zipArchiveFilePath);

            ZipArchiveEntry archiveEntry = archive.GetEntry(fileName);

            archiveEntry.ExtractToFile(outputFilePath);
        }
    }
}
