using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Pinger
{
    class Loger
    {
        string path = @"c:\Pinger\Pinger.txt";
        public void SaveToFile(string log)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    string time = DateTime.Now.ToString();
                    sw.WriteLine(time+": "+log);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    string time = DateTime.Now.ToString();
                    sw.WriteLine(time + ": " + log);
                }
            }

        }
    }
}
