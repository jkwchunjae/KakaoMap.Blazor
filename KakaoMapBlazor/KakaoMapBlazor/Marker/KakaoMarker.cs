namespace KakaoMapBlazor.Marker;

public class KakaoMarker : IKakaoMarker
{
    private DotNetObjectReference<KakaoMarker>? _kakaoMarkerRef;

    private IJSObjectReference _module;

    private object _markerLock = new object();
    private IJSObjectReference? _marker;

    public KakaoMarker(IJSObjectReference module)
    {
        _module = module;
    }

    public async ValueTask CreateMarkerAsync(MarkerCreateOptionInMap option)
    {
        _kakaoMarkerRef = DotNetObjectReference.Create(this);
        var marker = await _module.InvokeAsync<IJSObjectReference>("createMarker", option, _kakaoMarkerRef);
        lock (_markerLock)
        {
            _marker = marker;
        }
    }

    public async ValueTask SetMap(IJSObjectReference map)
    {
        await _marker!.InvokeVoidAsync("setMap", map);
    }
}

