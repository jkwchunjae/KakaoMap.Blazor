namespace KakaoMapBlazor.Models;

public class MarkerImage
{
    public string Src { get; set; }
    public Size Size { get; set; }
    public MarkerImageOption? Options { get; set; }

    public MarkerImage(string src, Size size)
    {
        Src = src;
        Size = size;
    }

    public MarkerImage(string src, Size size, MarkerImageOption option)
        : this(src, size)
    {
        Options = option;
    }
}
