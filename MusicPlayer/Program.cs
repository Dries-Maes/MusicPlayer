using System;
using System.IO;
using WMPLib;
namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string PATH = "C:\\Users\\dminb\\source\\repos\\MusicPlayer\\MusicPlayer\\log.txt";

            FileManager fileManager = new FileManager(); 

            fileManager.CreateFile(PATH);


            Player player = new Player();
            
            
            /*
            for (int i = 0; i < length; i++)
            {

            }
            foreach (var path in Directory.GetFiles(@"C:\music\"))
            {
                Console.WriteLine(path); // full path
                Console.WriteLine(System.IO.Path.GetFileName(path)); // file name
            }*/

            Console.ReadLine();
            player.SongMenu();         
                       
            
        }
        

        
    }
}
