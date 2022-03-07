namespace KakaoMapBlazor.Options;

public class MarkerCreateOptionInRoadview
{
    public ViewPoint? Position { get; set; }
    public MarkerImage? Image { get; set; }
    public string? Title { get; set; }
    public bool? Clickable { get; set; }
    public int? ZIndex { get; set; }
    public double? Opacity { get; set; }
    public double? Altitude { get; set; }
    public double? Range { get; set; }
}
