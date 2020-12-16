using System;
using System.Collections.Generic;
using System.IO;
using WMPLib;

namespace MusicPlayer
{
    internal class Player
    {
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        private FileReaderWriter readerWriter = new FileReaderWriter();

        public string song = "";
        private int volume = 50;
        private List<string> listMp3 = new List<string>();
        //public var input = null;

        public void TestDries()
        {
            var liedje = TagLib.File.Create(@"C:\music\PrayForYou.mp3");

            string title = liedje.Tag.Title;
            string artist = Convert.ToString(liedje.Tag.AlbumArtists[0]);
            string prefs = liedje.Tag.Performers[0];

            Console.WriteLine($"titel: {title} \nartist: {artist} \nprefs: {prefs}");
        }

        public void PickSong()
        {
            do
            {
                Console.WriteLine("Enter the title of a song:");
                string songName = Console.ReadLine();
                string pathFront = "c:\\music\\";
                string pathEnd = ".mp3";
                song = pathFront + songName + pathEnd;
            }
            while (!File.Exists(song));
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
                player.settings.volume = volume;
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
                        readerWriter.WriteSeparator();
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
            $"  Selected song: {song}  " + "\n" +
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

        //////////// playlist methoden

        public void CreatePlaylist()
        {
            List<string> list = new List<string>();

            foreach (var dir in Directory.GetFiles(@"C:\music\"))
            {
                list.Add(System.IO.Path.GetFileName(dir));
            }

            foreach (string liedje in list)
            {
                char lastChar = liedje[liedje.Length - 1];
                if (lastChar == '3')
                {
                    listMp3.Add(liedje);
                }
            }
        }
    }
}