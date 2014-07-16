﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //var source = new Source("../../Sources/File1.txt");
            string lineMessage = String.Empty;
            char c = 'x';

            using (var source = new Source("../../Sources/File1.txt"))
            {
                while ((c = source.CurrentChar()) != Source.EOF)
                {

                    if (c == Source.EOL)
                    {
                        Console.WriteLine(c);
                        lineMessage = String.Empty;
                    }
                    else
                    {
                        lineMessage += c;
                    }

                }
            }

        }
    }
}