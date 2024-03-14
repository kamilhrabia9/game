using System;
using System.IO;
using static System.Console;

namespace StarWarsFinal
{
    class Plot
    {

        public Plot(string title) { }

        public void Display(string fileName, string title)
        {
            WriteLine(title);

            LoadText(fileName);
            WriteLine();

        }


        public void LoadText(string fileName)
        {
            string path = @"C:\Users\kamil\source\repos\StarWarsFinal\StarWarsFinal\fabula\" + fileName + ".txt";

            StreamReader sr = File.OpenText(path);
            string s = "";


            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            sr.Close();
        }
    }
}
