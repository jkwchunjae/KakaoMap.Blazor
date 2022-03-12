namespace KakaoMapBlazor.InfoWindow;

public interface IKakaoCustomOverlay
{
    ValueTask Open();
    ValueTask Close();
    ValueTask SetPosition(LatLng position);
    ValueTask<LatLng> GetPosition();
    ValueTask SetContent(string content);
    ValueTask<string> GetContent();
    ValueTask<bool> GetVisible();
}
