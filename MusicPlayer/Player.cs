using System;
using WMPLib;

namespace MusicPlayer
{
    internal class Player
    {
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        private FileReaderWriter readerWriter = new FileReaderWriter();

        public string song = "";
        private int volume = 50;
        //public var input = null;

        public void PickSong()
        {
            Console.WriteLine("Enter the title of a song:");
            string songName = Console.ReadLine();
            string pathFront = "c:\\music\\";
            string pathEnd = ".mp3";
            song = pathFront + songName + pathEnd;
        }

        public void StartSong()
        {
            //static void PlayMusic(string file)

            player.URL = song;
            readerWriter.WriteLog(song);
        }

        public void PlayPauseSong()
        {
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
            }
            else
            {
                player.controls.play();
            }
        }

        public void ChangeVolume(int volume)
        {
            player.settings.volume = volume;
        }

        public void Mute()
        {
            if (player.settings.mute == false)
            {
                player.settings.mute = true;
            }
            else
            {
                player.settings.mute = false;
            }
        }

        
        public void StopSong()
        {
            player.controls.stop();
        }

        public void SongMenu()
        {
            if (song == "")
            {
                PrintBanner();
                PickSong();
            }
            do
            {
                Console.Clear();
                PrintBanner();
                PrintCurrentSong();
                PrintMenu();
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.F1:
                        StartSong();
                        break;

                    case ConsoleKey.F2:
                        PlayPauseSong();
                        break;

                    case ConsoleKey.F3:
                        StopSong();
                        break;

                    case ConsoleKey.F4:
                        do
                        {
                            Console.WriteLine("Enter a volume between 0-100:");
                            volume = Convert.ToInt32(Console.ReadLine());
                        }
                        while (!(volume <= 100 && volume >= 0));

                        ChangeVolume(volume);
                        break;

                    case ConsoleKey.F5:
                        Mute();
                        break;

                    case ConsoleKey.F6:
                        PickSong();
                        StopSong();
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
            while (true);
        }

        public void PrintCurrentSong()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@"
                    ══════════════════" +
            $"  Selected song: {song}  " +"\n"+
@"
                    ══════════════════" +
            $"  Selected volume: {volume}%  \n\n"
            );
            
        }

        public void PrintBanner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string banner = @"
            ███╗   ███╗███████╗██████╗ ██╗ █████╗ ██████╗ ██╗      █████╗ ██╗   ██╗███████╗██████╗
            ████╗ ████║██╔════╝██╔══██╗██║██╔══██╗██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝██╔════╝██╔══██╗
            ██╔████╔██║█████╗  ██║  ██║██║███████║██████╔╝██║     ███████║ ╚████╔╝ █████╗  ██████╔╝
            ██║╚██╔╝██║██╔══╝  ██║  ██║██║██╔══██║██╔═══╝ ██║     ██╔══██║  ╚██╔╝  ██╔══╝  ██╔══██╗
            ██║ ╚═╝ ██║███████╗██████╔╝██║██║  ██║██║     ███████╗██║  ██║   ██║   ███████╗██║  ██║
            ╚═╝     ╚═╝╚══════╝╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═╝

            ";
            Console.WriteLine(banner);
        }

        public void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string menu = @"
                    ╔════════════╦════════════╦══════╦════════╦══════════╦══════════╦══════╗
                    ║     F1     ║     F2     ║  F3  ║   F4   ║    F5    ║    F6    ║  Q   ║
                    ╠════════════╬════════════╬══════╬════════╬══════════╬══════════╬══════╣
                    ║ Start song ║ Play/Pause ║ Stop ║ Volume ║ (un)Mute ║ New Song ║ Quit ║
                    ╚════════════╩════════════╩══════╩════════╩══════════╩══════════╩══════╝
                    ";

            Console.WriteLine(menu);
        }
    }
}