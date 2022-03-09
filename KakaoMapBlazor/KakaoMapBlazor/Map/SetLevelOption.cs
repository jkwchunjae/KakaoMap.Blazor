namespace KakaoMapBlazor.Map;

public class SetLevelOption
{
    public SetLevelOption_Animate? Animate { get; set; }
    public LatLng? Anchor { get; set; }
}
public class SetLevelOption_Animate
{
    public int Duration { get; set; }
}

