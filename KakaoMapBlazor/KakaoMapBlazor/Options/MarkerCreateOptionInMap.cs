namespace KakaoMapBlazor.Options;

public class MarkerCreateOptionInMap
{
    public LatLng? Position { get; set; }
    public MarkerImage? Image { get; set; }
    public string? Title { get; set; }
    public bool? Draggable { get; set; }
    public bool? Clickable { get; set; }
    public int? ZIndex { get; set; }
    public double? Opacity { get; set; }
}
