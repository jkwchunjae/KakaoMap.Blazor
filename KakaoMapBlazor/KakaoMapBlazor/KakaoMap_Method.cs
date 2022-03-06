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

    #region Level
    public async ValueTask SetLevel(int level)
    {
        await _map!.InvokeVoidAsync("setLevel", level, null);
    }

    public async ValueTask SetLevel(int level, SetLevelOption option)
    {
        await _map!.InvokeVoidAsync("setLevel", level, option);
    }

    public async ValueTask<int> GetLevel()
    {
        var level = await _map!.InvokeAsync<int>("getLevel");
        return level;
    }
    #endregion

    #region MapTypeId
    public async ValueTask SetMapTypeId(MapType mapType)
    {
        await _map!.InvokeVoidAsync("setMapTypeId", mapType.ToString().ToUpper());
    }

    public async ValueTask<MapType> GetMapTypeId()
    {
        var mapTypeId = await _map!.InvokeAsync<MapType>("getMapTypeId");
        return mapTypeId;
    }
    #endregion
}
