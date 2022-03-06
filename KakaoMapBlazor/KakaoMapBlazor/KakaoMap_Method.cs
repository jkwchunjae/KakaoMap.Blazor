namespace KakaoMapBlazor;

public partial class KakaoMap : IKakaoMap
{
    #region Center
    public async ValueTask SetCenter(LatLng position)
    {
        await _map!.InvokeVoidAsync("setCenter", position);
    }

    public async ValueTask<LatLng> GetCenter()
    {
        var center = await _map!.InvokeAsync<LatLng>("getCenter");
        return center;
    }
    #endregion
}
