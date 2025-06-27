using System;
using System.Collections;
using System.Collections.Generic;

public class Playlist : IEnumerable<string>
{
    private List<string> _songs = new();
    private bool _random = false;
    public void Add(string song) => _songs.Add(song);
    public void SetRandom(bool random) => _random = random;
    public IEnumerator<string> GetEnumerator()
    {
        if (_random)
        {
            var rnd = new Random();
            var copy = new List<string>(_songs);
            for (int i = copy.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                (copy[i], copy[j]) = (copy[j], copy[i]);
            }
            foreach (var song in copy)
                yield return song;
        }
        else
        {
            foreach (var song in _songs)
                yield return song;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class IteratorDemo
{
    public static void Main()
    {
        var playlist = new Playlist();
        playlist.Add("Song 1");
        playlist.Add("Song 2");
        playlist.Add("Song 3");
        // playlist.SetRandom(true); // Descomente para ordem aleatória
        foreach (var song in playlist)
            Console.WriteLine(song);
    }
}
