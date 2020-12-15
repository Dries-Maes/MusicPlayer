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

            if(!File.Exists(file))
            {
                FileStream fileStream = File.Create(file);
                fileStream.Close();
            }
            

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
