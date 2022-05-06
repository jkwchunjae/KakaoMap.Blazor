namespace KakaoMapBlazor.InfoWindow;

public class InfoWindowCreateOption
{
    public string Content { get; set; }
    public LatLng? Position { get; set; }
    public bool? DisableAutoPan { get; set; }
    public bool? Removable { get; set; }
    public int? ZIndex { get; set; }
    public double? Altitude { get; set; }
    public double? Range { get; set; }

    public InfoWindowCreateOption(string content)
    {
        Content = content;
    }

    public InfoWindowCreateOption(string content, LatLng position)
    {
        Content = content;
        Position = position;
    }
}
