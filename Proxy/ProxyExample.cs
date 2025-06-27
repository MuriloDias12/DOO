using System;

public interface IImage
{
    void Display();
}

public class RealImage : IImage
{
    private string _filename;
    public RealImage(string filename)
    {
        _filename = filename;
        LoadFromDisk();
    }
    private void LoadFromDisk()
    {
        Console.WriteLine($"Carregando imagem: {_filename}");
    }
    public void Display()
    {
        Console.WriteLine($"Exibindo imagem: {_filename}");
    }
}

public class ProxyImage : IImage
{
    private string _filename;
    private RealImage? _realImage;
    public ProxyImage(string filename)
    {
        _filename = filename;
    }
    public void Display()
    {
        if (_realImage == null)
            _realImage = new RealImage(_filename);
        _realImage.Display();
    }
}

public class ProxyDemo
{
    public static void Main()
    {
        IImage image = new ProxyImage("foto.jpg");
        Console.WriteLine("Imagem proxy criada. Nada carregado ainda.");
        image.Display(); // Carrega e exibe
        image.Display(); // Só exibe
    }
}
