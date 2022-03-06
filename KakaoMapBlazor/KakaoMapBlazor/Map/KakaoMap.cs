namespace KakaoMapBlazor.Map;

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

    public async ValueTask CreateMapAsync(string mapId, MapCreateOption createOption)
    {
        _kakaoMapRef = DotNetObjectReference.Create(this);
        var module = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/KakaoMapBlazor/js/kakaomap.js");
        var map = await module.InvokeAsync<IJSObjectReference>("createMap", mapId, createOption, _kakaoMapRef);
        lock (_mapLock)
        {
            _map = map;
        }

        foreach (var fn in _mapLoadedAction)
        {
            await fn(_map);
        }
    }
}
