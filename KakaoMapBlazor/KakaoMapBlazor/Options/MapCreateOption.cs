namespace KakaoMapBlazor.Options;

public class MapCreateOption
{
    public LatLng Center { get; set; }
    public int? Level { get; set; }
    public MapType? MapTypeId { get; set; }
    public bool? Draggable { get; set; }
    public bool? Scrollwheel { get; set; }
    public bool? DisableDoubleClick { get; set; }
    public bool? DisableDoubleClickZoom { get; set; }
    public string? ProjectionId { get; set; }
    public bool? TileAnimation { get; set; }

    public MapCreateOption(LatLng center)
    {
        Center = center;
    }
}
