using System;
using WMPLib;
using TagLib;

namespace MusicPlayer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string PATH = $"C:\\Users\\{Environment.UserName}\\source\\repos\\MusicPlayer\\MusicPlayer\\log.txt";
            Player player = new Player();            
            FileManager fileManager = new FileManager();
            fileManager.CreateFile(PATH);
                       
            player.SongMenu();
        }
    }
}