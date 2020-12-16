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

        readonly string path = $"C:\\Users\\{Environment.UserName}\\source\\repos\\MusicPlayer\\MusicPlayer\\music\\";

        Random random = new Random();
        public string song = "";
        private int volume = 50;
        private List<string> listMp3 = new List<string>();

        public string songTitle { get; set; }
        public string songArtist { get; set; }

        public void ExtractSongData()
        {
            var liedje = TagLib.File.Create(song);

            if (liedje.Tag.Title == null)
            {
                songTitle = "Unknown";
            }
            else
            {
                songTitle = liedje.Tag.Title;
            }

            if (liedje.Tag.AlbumArtists.Length > 0)
            {
                songArtist = Convert.ToString(liedje.Tag.AlbumArtists[0]);
            }
            else
            {
                songArtist = "Unknown";
            }
        }

        public void PickSong()
        {
            Console.Clear();
            PrintBanner();
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Current Playlist:\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"╔═════╦═══════════════════════════ ═  ═   ═   -");

                foreach (string song in listMp3)
                {
                    Console.WriteLine(@"╠" + $"  { listMp3.IndexOf(song) + 1}" + @"  ║  " + $"{song}\n" + @"╠═════╬═══════════════════════════ ═  ═   ═   -");
                }
                Console.WriteLine(@"╠" + $"  0" + @"  ║  " + $"Pick a random song!\n" + @"╚═════╩═══════════════════════════ ═  ═   ═   -");

                bool tryParse;
                int temp;
                string songName;
                Console.ForegroundColor = ConsoleColor.Blue;
                do
                {
                    Console.WriteLine("\nPick a song by entering the corresponding number:");

                    tryParse = Int32.TryParse(Console.ReadLine(), out temp);
                } while (!(tryParse) || !(temp >= 0 && temp <= listMp3.Count));

                if (temp == 0)
                {
                    songName = listMp3[random.Next(0, listMp3.Count)];
                }
                else
                {
                    songName = listMp3[temp - 1];
                }

                string pathFront = path;

                song = pathFront + songName;

                ExtractSongData();
            }
            while (!File.Exists(song));
        }

        public void StartSong()
        {
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
                CreatePlaylist();
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
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("\n\n-- You entered a wrong key! --");
                        System.Threading.Thread.Sleep(2000);
                        Console.ResetColor();
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
            $"  Selected Song: {songTitle}  " + "\n\n" +
"                    ══════════════════" +
            $"  Selected Artist: {songArtist}  " + "\n" +
@"
                    ══════════════════" +
            $"  Selected Volume: {volume}%  \n\n"
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

            foreach (var dir in Directory.GetFiles(path))
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