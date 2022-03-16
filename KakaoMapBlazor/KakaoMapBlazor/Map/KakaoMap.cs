namespace KakaoMapBlazor.Map;

public partial class KakaoMap : IKakaoMap, IDisposable
{
    private IJSRuntime JS;
    private DotNetObjectReference<KakaoMap>? _kakaoMapRef;

    private IJSObjectReference? _module;

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
        _module = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/KakaoMapBlazor/js/kakaomain.js");
        var map = await _module.InvokeAsync<IJSObjectReference>("createMap", mapId, createOption, _kakaoMapRef);
        lock (_mapLock)
        {
            _map = map;
        }

        foreach (var fn in _mapLoadedAction)
        {
            await fn(_map);
        }
    }

    public async ValueTask<IKakaoMarker> CreateMarker(MarkerCreateOptionInMap option)
    {
        if (_module == null)
            throw new ModuleNotLoadedException();
        if (_map == null)
            throw new NullReferenceException("map is null. CreateMap first.");

        var marker = new KakaoMarker(_module);
        await marker.CreateMarkerAsync(_map, option);

        return marker;
    }

    public async ValueTask<IKakaoInfoWindow> CreateInfoWindow(InfoWindowCreateOption option)
    {
        if (_module == null)
            throw new ModuleNotLoadedException();
        if (_map == null)
            throw new NullReferenceException("map is null. CreateMap first.");

        var infoWindow = new KakaoInfoWindow(_module);
        await infoWindow.CreateInfoWindowAsync(_map, option);

        return infoWindow;
    }

    public async ValueTask<IKakaoCustomOverlay> CreateCustomOverlay(CustomOverlayCreateOption option)
    {
        if (_module == null)
            throw new ModuleNotLoadedException();
        if (_map == null)
            throw new NullReferenceException("map is null. CreateMap first.");

        var customOverlay = new KakaoCustomOverlay(_module);
        await customOverlay.CreateCustomOverlayAsync(_map, option);

        return customOverlay;
    }

    public async ValueTask<IKakaoPolyLine> CreatePolyLine(PolyLineCreateOption option)
    {
        if (_module == null)
            throw new ModuleNotLoadedException();
        if (_map == null)
            throw new NullReferenceException("map is null. CreateMap first.");

        var polyLine = new KakaoPolyLine(_module);
        await polyLine.CreatePolyLineAsync(_map, option);

        return polyLine;
    }

}
