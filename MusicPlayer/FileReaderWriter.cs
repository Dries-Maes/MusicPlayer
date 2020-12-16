using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MusicPlayer
{
    class FileReaderWriter
    {

        //const string PATH = "C:\\Users\\dminb\\source\\repos\\MusicPlayer\\MusicPlayer\\log.txt";
        readonly string PATH = $"C:\\Users\\{Environment.UserName}\\source\\repos\\MusicPlayer\\MusicPlayer\\log.txt";

        public void WriteLog(string song)
        {
            string dateTime = Convert.ToString(System.DateTime.Now);
            using StreamWriter writer = new StreamWriter(PATH, true);
            writer.WriteLine($"Op {dateTime} werd {song} afgespeeld.");

        }


        public void WriteSeparator()
        {
            using StreamWriter writer = new StreamWriter(PATH, true);
            writer.WriteLine("---------------------------------------------------------------------");
        }



        //public void WriteDataToFile(string textToWriteToFile, string path)
        //{
        //    using StreamWriter writer = new StreamWriter(path);
        //    writer.WriteLine(textToWriteToFile);

        //}

        //public void WriteDataToFile(string[] lines, string path)
        //{
        //    using StreamWriter writer = new StreamWriter(path, true); //true om nieuwe tekst toe te voegen ipv overschrijven.

        //    foreach (string line in lines)
        //    {
        //        writer.WriteLine(line);
        //    }

        //    //for (int i = 0; i < lines.Length; i++)
        //    //{
        //    //    writer.WriteLine(lines[i]);
        //    //}
        //}

        //public List<string> ReadDataFromFile(string path)
        //{
        //    using StreamReader reader = new StreamReader(path);
        //    string line = string.Empty;

        //    List<string> lines = new List<string>();

        //    while ((line = reader.ReadLine()) != null)
        //    {
        //        lines.Add(line);

        //    }

        //    return lines;
        //}
    }
}
