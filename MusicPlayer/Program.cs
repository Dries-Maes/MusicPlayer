using System;
using System.Collections.Generic;
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



            
            





            
            player.SongMenu();         
                       
            
        }
        

        
    }
}
