using System;
using System.IO;
using WMPLib;
namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            foreach (var path in Directory.GetFiles(@"C:\music\"))
            {
                Console.WriteLine(path); // full path
                Console.WriteLine(System.IO.Path.GetFileName(path)); // file name
            }

            Console.ReadLine();
            player.SongMenu();         
                       
            
        }
        

        
    }
}
