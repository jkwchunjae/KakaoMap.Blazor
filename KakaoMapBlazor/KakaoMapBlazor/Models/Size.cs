namespace KakaoMapBlazor.Models;

public class Size
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Size() { }
    public Size(double width, double height)
    {
        Width = width;
        Height = height;
    }
}
