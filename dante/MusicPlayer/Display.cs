
using HttpRequest;
using MusicControl;
using Data;

namespace CLIDisplay
{
    internal class Display
    {
        Func<int, List<string>> getUpdatedListSkip12 = (i) => Info[i].Skip(posy - (consoleHeight - 12)).Take(consoleHeight - 11).ToList();
        Func<int, List<string>> getUpdatedListSkip16 = (i) => Info[i].Skip(posy - 16).Take(consoleHeight - 11).ToList();
        Func<int, List<string>> getUpdatedListSkip13 = (i) => Info[i].Skip(posy - (consoleHeight - 13)).Take(consoleHeight - 11).ToList();
        Func<int, List<string>> getUpdatedList = (i) => Info[i].Take(consoleHeight - 11).ToList();

        internal static List<Artist> artistsData = Getter.GetArtists().Result;
        internal static List<Album> albumsData = Getter.GetAlbums().Result;
        internal static List<Song> songsData = Getter.GetSongs().Result;
        internal static List<string>[] Titles = new List<string>[3];

        private static List<List<string>> Info = new List<List<string>>();
        private static int consoleHeight = Console.WindowHeight;
        private static byte posy = 0;

        public Display()
        {
            Info.Add(artistsData.Select(x => x.Name).ToList());
            Info.Add(new List<string>());
            Info.Add(new List<string>());
            InfoUpdateAlbums();
            InfoUpdateSongs();
            Titles[0] = getUpdatedList(0);
            Titles[1] = getUpdatedList(1);
            Titles[2] = getUpdatedList(2);

            while (true)
            {
                try
                {
                    MenuFunc();
                }
                catch { Console.Clear(); }
            }
        }

        private void InfoUpdateAlbums()
        {
            if (TableDrawer.posx == 1)
            {
                Artist artist = artistsData.Where(x => x.Name == Info[0][TableDrawer.posy]).First();
                Info[1] = albumsData.Where(x => artist.Albums.Contains(x.Id)).Select(x => x.Title).ToList();
            }
        }

        private void InfoUpdateSongs()
        {
            if (TableDrawer.posx == 1)
            {
                Artist artist = artistsData.Where(x => x.Name == Info[0][TableDrawer.posy]).First();
                Info[2] = songsData.Where(x => artist.Songs.Contains(x.Id)).Select(x => x.Title).ToList();
            }
            else
            if (TableDrawer.posx == 2)
            {
                Album album = albumsData.Where(x => x.Title == Info[1][TableDrawer.posy]).First();
                Info[2] = songsData.Where(x => album.Songs.Contains(x.Id)).Select(x => x.Title).ToList();
            }
        }

        private void UpdateTableOnY()
        {
            if (posy < consoleHeight - 12) TableDrawer.posy = posy;
            else if (posy > consoleHeight - 13 && posy != Info[TableDrawer.posx - 1].Count - 1) TableDrawer.posy = consoleHeight - 13;
            else TableDrawer.posy = consoleHeight - 12;

            if (TableDrawer.posx == 1)
            {
                InfoUpdateAlbums();
                InfoUpdateSongs();
                Titles[1] = getUpdatedList(1);
                Titles[2] = getUpdatedList(2);
            }
            else
            if (TableDrawer.posx == 2)
            {
                InfoUpdateSongs();
                Titles[2] = getUpdatedList(2);
            }

            Console.Clear();
            new TableDrawer(Titles[0], Titles[1], Titles[2]);
        }

        private void UpdateTableOnX()
        {
            if (TableDrawer.posy > Info[TableDrawer.posx - 1].Count - 1) TableDrawer.posy = Info[TableDrawer.posx - 1].Count - 1;
            else if (TableDrawer.posy < Info[TableDrawer.posx - 1].Count - 1 && TableDrawer.posy != posy) TableDrawer.posy = posy;
            if (posy < Info[TableDrawer.posx - 1].Count - 1) Titles[TableDrawer.posx - 1] = getUpdatedListSkip13(TableDrawer.posx - 1);
            else Titles[TableDrawer.posx - 1] = getUpdatedListSkip12(TableDrawer.posx - 1);

            if (TableDrawer.posx == 1)
            {
                InfoUpdateAlbums();
                InfoUpdateSongs();
                Titles[1] = getUpdatedList(1);
                Titles[2] = getUpdatedList(2);
            }
            else
            if (TableDrawer.posx == 2)
            {
                InfoUpdateSongs();
                Titles[2] = getUpdatedList(2);
            }

            Console.Clear();
            new TableDrawer(Titles[0], Titles[1], Titles[2]);
        }

        private void PlaySong(int pos)
        {
            Controls.PlaySong(songsData.First(x => x.Title == Info[2][pos]).Id);
            Console.Clear();
            new TableDrawer(Titles[0], Titles[1], Titles[2]);
        }

        private void MenuFunc()
        {
            Console.CursorVisible = false;
            new TableDrawer(Titles[0], Titles[1], Titles[2]);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.W)
                {
                    Titles[TableDrawer.posx - 1] = getUpdatedListSkip12(TableDrawer.posx - 1);

                    if (posy > 0)
                    {
                        posy--;
                        UpdateTableOnY();
                    }
                }
                else
                if (key.Key == ConsoleKey.S)
                {
                    if (posy + 3 <= Info[TableDrawer.posx - 1].Count) Titles[TableDrawer.posx - 1] = getUpdatedListSkip16(TableDrawer.posx - 1);

                    if (posy < Info[TableDrawer.posx - 1].Count - 1)
                    {
                        posy++;
                        UpdateTableOnY();
                    }
                }
                else
                if (key.Key == ConsoleKey.A)
                {
                    if (TableDrawer.posx > 1)
                    {
                        TableDrawer.posx--;
                        UpdateTableOnX();
                    }
                }
                else
                if (key.Key == ConsoleKey.D)
                {
                    if (TableDrawer.posx < 3)
                    {
                        TableDrawer.posx++;
                        UpdateTableOnX();
                    }
                }
                else
                if (key.Key == ConsoleKey.Enter && key.Modifiers != ConsoleModifiers.Shift)
                {
                    if (TableDrawer.posx == 3) PlaySong(TableDrawer.posy);
                    else PlaySong(0);
                }
                else
                if (key.Key == ConsoleKey.Enter && key.Modifiers == ConsoleModifiers.Shift)
                {
                    if (TableDrawer.posx < 3)
                    {
                        if (Controls.GetPlaybackState.ToString() == "Playing") Controls.QueueSong(songsData.First(x => x.Title == Info[2][0]).Id);
                        else PlaySong(0);
                    }
                    else
                    {
                        if (Controls.GetPlaybackState.ToString() == "Playing") Controls.QueueSong(songsData.First(x => x.Title == Info[2][TableDrawer.posy]).Id);
                        else PlaySong(TableDrawer.posy);
                    }
                }
                else
                if (key.Key == ConsoleKey.Spacebar)
                {
                    if (Controls.GetPlaybackState.ToString() == "Playing") Controls.PauseSong();
                    else Controls.ResumeSong();
                }
                else
                if (key.Key == ConsoleKey.LeftArrow) Controls.SeekBackward(5);
                else if (key.Key == ConsoleKey.RightArrow) Controls.SeekForward(5);
                else if (key.Key == ConsoleKey.UpArrow) Controls.VolumeUp(0.05f);
                else if (key.Key == ConsoleKey.DownArrow) Controls.VolumeDown(0.05f);
                else if (key.Key == ConsoleKey.Tab && key.Modifiers != ConsoleModifiers.Shift)
                {
                    Controls.NextSong();
                    Console.Clear();
                    new TableDrawer(Titles[0], Titles[1], Titles[2]);
                }
                else
                if (key.Key == ConsoleKey.Tab && key.Modifiers == ConsoleModifiers.Shift)
                {
                    Controls.PreviousSong();
                    Console.Clear();
                    new TableDrawer(Titles[0], Titles[1], Titles[2]);
                }
                else
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                }
            }
        }
    }
}
