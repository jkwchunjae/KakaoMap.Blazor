namespace KakaoMapBlazor.PolyLine;

public class PolyLineOption
{
    public IEnumerable<LatLng> Path { get; set; }
    public bool? EndArrow { get; set; }
    public int? StrokeWeight { get; set; }
    public string? StrokeColor { get; set; }
    public double? StrokeOpacity { get; set; }
    public string? StrokeStyle { get; set; }
    public int? ZIndex { get; set; }

    public PolyLineOption(IEnumerable<LatLng> path)
    {
        Path = path;
    }
}
