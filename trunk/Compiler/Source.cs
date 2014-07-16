using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Compiler
{
    public class Source : IDisposable
    {
        public StreamReader reader;

        private string line;
        private int lineNum;
        private int currentPos;
        private bool closed = false;

        public static  char EOL='\n';
        public static char EOF=(char) 0;

        private List<string> lines = new List<string>();

        public Source(string path)
        {
            reader = new StreamReader(path);
            this.currentPos = -1;
            this.lineNum = -1;
            ReadLine();
        }


        private void ReadLine()
        {
            line = reader.ReadLine();
            if (line != null)
            {
                lineNum++;
                lines.Add(line);
            }
        }

        public char CurrentChar()
        {
            if (line == null) return EOF;

                currentPos++;
                if (line.Length - 1 < currentPos) {
                    currentPos = -1;
                    ReadLine();
                    return EOL;
                }
                return line[currentPos];
        }

        public char PeekNextChar() {

            var nextCharPos = currentPos + 1;
            if (line.Length - 1 < nextCharPos){
                return EOL;
            }
            return line[nextCharPos];
        }

        public String GetCurrentText() {

            var stringBuilder = new StringBuilder();
            foreach (var item in lines)
            {
                stringBuilder.AppendLine(item);
            }

            return stringBuilder.ToString();
        }

        public void Close()
        {
            reader.Close();
            closed = true;
        }

        public void Dispose()
        {
            if (!closed)
            {
                reader.Close();
            }
        }
    }
}
