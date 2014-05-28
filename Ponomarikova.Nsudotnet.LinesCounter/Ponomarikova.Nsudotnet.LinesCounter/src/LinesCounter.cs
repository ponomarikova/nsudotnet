using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponomarikova.Nsudotnet.LinesCounter
{
    static class LinesCounter
    {
        public static int GetLinesCount(string path, string ext)
        {
            int count = 0;

            RecursiveFileReader files = new RecursiveFileReader(path, ext);

            string[] currentFile = null;
            while ((currentFile = files.GetNextFile()) != null)
            {
                count += CountLinesInText(currentFile);
            }

            return count;
        }

        private static int CountLinesInText(string[] text)
        {
            int count = 0;

            bool isComment = false;

            foreach (string line in text)
            {
                string currentLine = line.Trim();

                if (!isComment)
                {
                    while (true)
                    {
                        int startIndex = currentLine.IndexOf(COMMENT_START_STR);
                        int endIndex = currentLine.IndexOf(COMMENT_END_STR);

                        if (startIndex >= 0 && endIndex >= 0 && startIndex < endIndex)
                        {
                            currentLine = currentLine.Remove(startIndex, endIndex - startIndex + COMMENT_END_STR.Length);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                int commentStartIndex = currentLine.IndexOf(COMMENT_START_STR);
                int commentEndIndex = currentLine.IndexOf(COMMENT_END_STR);
                int commentIndex = currentLine.IndexOf(COMMENT_STR);

                if (currentLine.Length == 0)
                {
                    continue;
                }

                if (!isComment)
                {
                    if (commentIndex >= 0 && commentStartIndex >= 0)
                    {
                        if (commentIndex < commentStartIndex)
                        {
                            if (commentIndex == 0)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            isComment = true;

                            if (commentStartIndex == 0)
                            {
                                continue;
                            }
                        }
                    }
                    else if (commentIndex == 0)
                    {
                        continue;
                    }
                    else if (commentStartIndex >= 0)
                    {
                        isComment = true;

                        if (commentStartIndex == 0)
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    if (commentEndIndex >= 0)
                    {
                        isComment = false;

                        currentLine = currentLine.Substring(commentEndIndex + COMMENT_END_STR.Length);
                        currentLine = currentLine.Trim();
                        if (currentLine.Length == 0)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                ++count;
            }

            return count;
        }

        private static string COMMENT_STR = "//";
        private static string COMMENT_START_STR = "/*";
        private static string COMMENT_END_STR = "*/";
    }
}
