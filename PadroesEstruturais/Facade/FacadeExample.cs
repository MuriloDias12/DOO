using System;

public class DvdPlayer
{
    public void On() => Console.WriteLine("DVD Player ligado");
    public void Play(string movie) => Console.WriteLine($"Reproduzindo DVD: {movie}");
    public void Off() => Console.WriteLine("DVD Player desligado");
}
public class Projector
{
    public void On() => Console.WriteLine("Projetor ligado");
    public void Off() => Console.WriteLine("Projetor desligado");
}
public class Lights
{
    public void Dim() => Console.WriteLine("Luzes diminuídas");
    public void On() => Console.WriteLine("Luzes acesas");
}
public class SoundSystem
{
    public void On() => Console.WriteLine("Som ligado");
    public void Off() => Console.WriteLine("Som desligado");
}

public class HomeTheaterFacade
{
    private DvdPlayer dvd;
    private Projector projector;
    private Lights lights;
    private SoundSystem sound;
    public HomeTheaterFacade(DvdPlayer d, Projector p, Lights l, SoundSystem s)
    {
        dvd = d; projector = p; lights = l; sound = s;
    }
    public void PlayMovie(string movie)
    {
        Console.WriteLine("Preparando para assistir um filme...");
        lights.Dim();
        projector.On();
        sound.On();
        dvd.On();
        dvd.Play(movie);
    }
    public void EndMovie()
    {
        Console.WriteLine("Encerrando sessão de filme...");
        dvd.Off();
        sound.Off();
        projector.Off();
        lights.On();
    }
}

public class FacadeDemo
{
    public static void Main()
    {
        var facade = new HomeTheaterFacade(new DvdPlayer(), new Projector(), new Lights(), new SoundSystem());
        facade.PlayMovie("Matrix");
        facade.EndMovie();
    }
}
