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
        public RecursiveFileReader(string path, string extension)
        {
            nextDirs.Add(path);
            ext = extension;
        }

        public StreamReader GetNextFile()
        {
            if (lastFile != null)
            {
                lastFile.Dispose();
                lastFile = null;
            }

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
                        return null;
                    }
                }

                string fileName = nextFiles[0];
                nextFiles.RemoveAt(0);

                if (Path.GetExtension(fileName).Equals(ext))
                {
                    lastFile = new StreamReader(fileName);
                    return lastFile;
                }
            }
        }

        private List<string> nextFiles = new List<string>();
        private List<string> nextDirs = new List<string>();
        private string ext;
        private StreamReader lastFile = null;
    }
}
