namespace KakaoMapBlazor;

public partial class KakaoMap : IKakaoMap, IDisposable
{
    private IJSRuntime JS;
    private DotNetObjectReference<KakaoMap>? _kakaoMapRef;

    private object _mapLock = new object();
    private IJSObjectReference? _map;

    private List<Func<IJSObjectReference, ValueTask>> _mapLoadedAction = new();

    public KakaoMap(IJSRuntime jsRuntime)
    {
        JS = jsRuntime;
    }

    public void Dispose()
    {
        _kakaoMapRef?.Dispose();
    }

    public async ValueTask CreateMapAsync(string mapId)
    {
        _kakaoMapRef = DotNetObjectReference.Create(this);
        var module = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/KakaoMapBlazor/js/kakaomap.js");
        var map = await module.InvokeAsync<IJSObjectReference>("createMap", mapId, _kakaoMapRef);
        lock (_mapLock)
        {
            _map = map;
        }

        foreach (var fn in _mapLoadedAction)
        {
            await fn(_map);
        }
    }

    public async ValueTask SetCenter(LatLng position)
    {
        await _map!.InvokeVoidAsync("setCenter", position);
    }

    public async ValueTask<LatLng> GetCenter()
    {
        var center = await _map!.InvokeAsync<LatLng>("getCenter");
        return center;
    }
}
