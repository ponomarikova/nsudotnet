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
        public RecursiveFileReader(string path, string ext)
        {
            m_nextDirs.Add(path);
            m_ext = ext;
        }

        public string[] GetNextFile()
        {
            while (true)
            {
                while (m_nextFiles.Count == 0)
                {
                    if (m_nextDirs.Count > 0)
                    {
                        m_nextFiles.AddRange(Directory.GetFiles(m_nextDirs[0]));
                        m_nextDirs.AddRange(Directory.GetDirectories(m_nextDirs[0]));
                        m_nextDirs.RemoveAt(0);
                    }
                    else
                    {
                        return null;
                    }
                }

                string fileName = m_nextFiles[0];
                m_nextFiles.RemoveAt(0);

                if (Path.GetExtension(fileName).Equals(m_ext))
                {
                    return File.ReadAllLines(fileName);
                }
            }
        }

        private List<string> m_nextFiles = new List<string>();
        private List<string> m_nextDirs = new List<string>();
        private string m_ext;
    }
}
