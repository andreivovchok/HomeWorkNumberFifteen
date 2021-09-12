using ClassLibrary1;
using System;
using System.IO;
using System.IO.Compression;

namespace HomeWorkNumberFifteen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке для поиска!");
            string path = Console.ReadLine();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            Console.WriteLine("Введите название файла!");
            RecursiveSearcher searcher = new RecursiveSearcher();
            var file = searcher.Search(directoryInfo, Console.ReadLine());
            
            var archivePath = Path.Combine(file.Directory.FullName, Path.GetFileNameWithoutExtension(file.FullName) + ".zip");

            using (var fileStream = new FileStream(archivePath, FileMode.Create))
            using (ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
            {
                zipArchive.CreateEntryFromFile(file.FullName, file.Name);
            }

            Console.WriteLine(archivePath);
        }
    }
}
