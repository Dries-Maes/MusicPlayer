using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MusicPlayer
{
    class FileManager
    {
        public void CreateFile(string file)
        {

            //filestream object aanmaken om de stream te kunnen afsluiten zodat ik na het aanmaken van een bestand ik er onmiddellijk ook naar kan wegschrijven. Anders wordt deze file "bezet" door deze methode en kan je er niets aan toevoegen of geen acties op uitvoeren.
            FileStream fileStream = File.Create(file);
            fileStream.Close();

        }

        public void DeleteFile(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }

        }


        //Aanmaken van folder indien een folder nog niet bestaat

        //public void CreateFolder(string path)
        //{
        //    Directory.CreateDirectory("path");
        //}

    }
}
