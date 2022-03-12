namespace KakaoMapBlazor.InfoWindow;

public class CustomOverlayCreateOption
{
    public string Content { get; set; }
    public LatLng Position { get; set; }
    public bool? Clickable { get; set; }
    public double? XAnchor { get; set; }
    public double? YAnchor { get; set; }
    public int? ZIndex { get; set; }

    public CustomOverlayCreateOption(string content, LatLng position)
    {
        Content = content;
        Position = position;
    }
}
