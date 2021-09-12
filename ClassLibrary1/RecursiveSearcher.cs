using System;
using System.IO;

namespace ClassLibrary1
{
    public class RecursiveSearcher
    {
        public FileInfo Search(DirectoryInfo directoryInfo, string fileName)
        {
            foreach (var file in directoryInfo.GetFiles())
            {
                if (fileName == file.Name)
                {
                    return file;
                }
            }

            foreach (var directory in directoryInfo.GetDirectories())
            {
                try
                {
                    return Search(directory, fileName);
                }
                catch (FileNotFoundException)
                {  
                }
            }

            throw new FileNotFoundException("File not found", fileName);
        }
    }
}
