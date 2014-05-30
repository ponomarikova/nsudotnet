using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponomarikova.Nsudotnet.LinesCounter
{
    class RecursiveFileReader
    {
        public static List<string> GetFileNames(string path, string ext)
        {
            List<string> nextFiles = new List<string>();
            List<string> nextDirs = new List<string>();
            nextDirs.Add(path);

            List<string> files = new List<string>();

            while (true)
            {
                while (nextFiles.Count == 0)
                {
                    if (nextDirs.Count > 0)
                    {
                        nextFiles.AddRange(Directory.GetFiles(nextDirs[0]));
                        nextDirs.AddRange(Directory.GetDirectories(nextDirs[0]));
                        nextDirs.RemoveAt(0);
                    }
                    else
                    {
                        break;
                    }
                }

                if (nextFiles.Count == 0)
                {
                    break;
                }

                string fileName = nextFiles[0];
                nextFiles.RemoveAt(0);

                if (Path.GetExtension(fileName).Equals(ext))
                {
                    files.Add(fileName);
                }
            }

            return files;
        }
    }
}
