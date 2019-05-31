using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestORM.File
{
    public class WriteToFile
    {

        public void Write(string text)
        {
            string path = @"C:\Rodrigo\DatabaseTests.txt";

            if (!System.IO.File.Exists(path))
            {
                System.IO.File.Create(path);
            }


            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine($"{text}");
            }
            
        }

    }
}
