using System;
using WMPLib;
using TagLib;

namespace MusicPlayer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Player player = new Player();
            
            string PATH = $"C:\\Users\\{Environment.UserName}\\source\\repos\\MusicPlayer\\MusicPlayer\\log.txt";

            FileManager fileManager = new FileManager();
            fileManager.CreateFile(PATH);
           
            
            player.SongMenu();
        }
    }
}