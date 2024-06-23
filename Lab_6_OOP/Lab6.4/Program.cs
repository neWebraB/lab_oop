using System;
using System.Collections.Generic;
using System.Linq;

class InvalidSongException : Exception
{
    public InvalidSongException(string message)
        : base(message)
    {
    }
}

class InvalidArtistNameException : InvalidSongException
{
    public InvalidArtistNameException(string message)
        : base(message)
    {
    }
}

class InvalidSongNameException : InvalidSongException
{
    public InvalidSongNameException(string message)
        : base(message)
    {
    }
}

class InvalidSongLengthException : InvalidSongException
{
    public InvalidSongLengthException(string message)
        : base(message)
    {
    }
}

class InvalidSongMinutesException : InvalidSongLengthException
{
    public InvalidSongMinutesException(string message)
        : base(message)
    {
    }
}

class InvalidSongSecondsException : InvalidSongLengthException
{
    public InvalidSongSecondsException(string message)
        : base(message)
    {
    }
}

class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string ArtistName
    {
        get { return artistName; }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException("Ім'я виконавця повинно містити від 3 до 20 символів.");
            }
            artistName = value;
        }
    }

    public string SongName
    {
        get { return songName; }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException("Назва пісні повинна містити від 3 до 30 символів.");
            }
            songName = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        private set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException("Тривалість пісні повинна бути від 0 до 14 хвилин.");
            }
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        private set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException("Тривалість пісні повинна бути від 0 до 59 секунд.");
            }
            seconds = value;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть кількість пісень, які ви збираєтеся додати:");
        int n = int.Parse(Console.ReadLine());
        List<Song> playlist = new List<Song>();

        for (int i = 0; i < n; i++)
        {
            try
            {
                Console.WriteLine("Введіть інформацію про пісню у форматі <ім'я виконавця>;<назва пісні>;<хвилини:секунди>:");
                string[] input = Console.ReadLine().Split(' ');
                string artistName = input[0];
                string songName = input[1];
                string[] duration = input[2].Split(':');
                int minutes = int.Parse(duration[0]);
                int seconds = int.Parse(duration[1]);

                Song song = new Song(artistName, songName, minutes, seconds);
                playlist.Add(song);
                Console.WriteLine("Пісню додано");
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        int totalMinutes = playlist.Sum(s => s.Minutes);
        int totalSeconds = playlist.Sum(s => s.Seconds);
        int extraMinutes = totalSeconds / 60;
        totalMinutes += extraMinutes;
        totalSeconds %= 60;

        Console.WriteLine($"Пісень додано: {playlist.Count}");
        Console.WriteLine($"Тривалість списку відтворення: {totalMinutes} хв. {totalSeconds} сек.");
    }
}
