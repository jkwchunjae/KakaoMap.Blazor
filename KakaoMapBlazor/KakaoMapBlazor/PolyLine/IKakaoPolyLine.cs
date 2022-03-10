namespace KakaoMapBlazor.PolyLine;

public interface IKakaoPolyLine
{
    LatLng LastPosition { get; }
    ValueTask Close();
    ValueTask SetOptions(PolyLineOption option);
    ValueTask SetPath(IEnumerable<LatLng> path);
    ValueTask PushPath(LatLng position);
    ValueTask<int> GetLength();
}
