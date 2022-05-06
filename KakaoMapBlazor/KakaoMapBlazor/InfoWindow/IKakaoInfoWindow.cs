namespace KakaoMapBlazor.InfoWindow;

public interface IKakaoInfoWindow
{
    ValueTask Open();
    ValueTask Open(IKakaoMarker marker);
    ValueTask Close();
    // GetMap();
}
