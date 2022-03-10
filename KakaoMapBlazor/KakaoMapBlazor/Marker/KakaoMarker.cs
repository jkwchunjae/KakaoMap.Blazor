namespace KakaoMapBlazor.Marker;

public partial class KakaoMarker : IKakaoMarker, IDisposable
{
    private DotNetObjectReference<KakaoMarker>? _kakaoMarkerRef;

    private IJSObjectReference _module;

    private object _markerLock = new object();
    private IJSObjectReference? _marker;

    private List<Func<IJSObjectReference, ValueTask>> _markerLoadedAction = new();

    public KakaoMarker(IJSObjectReference module)
    {
        _module = module;
    }

    public void Dispose()
    {
        _kakaoMarkerRef?.Dispose();
    }

    public async ValueTask CreateMarkerAsync(MarkerCreateOptionInMap option)
    {
        _kakaoMarkerRef = DotNetObjectReference.Create(this);
        var marker = await _module.InvokeAsync<IJSObjectReference>("createMarker", option, _kakaoMarkerRef);
        lock (_markerLock)
        {
            _marker = marker;
        }

        foreach (var fn in _markerLoadedAction)
        {
            await fn(_marker);
        }
    }

    public async ValueTask SetMap(IJSObjectReference map)
    {
        await _marker!.InvokeVoidAsync("setMap", map);
    }
}

