using System;
using ExifLib;
using WMPLib;
using TagLib;

namespace MusicPlayer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Player player = new Player();
            player.TestDries();
            Console.ReadLine();
           

            const string PATH = "C:\\Users\\dminb\\source\\repos\\MusicPlayer\\MusicPlayer\\log.txt";
            FileManager fileManager = new FileManager();
            fileManager.CreateFile(PATH);
           
            
            player.SongMenu();
        }
    }
}