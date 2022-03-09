namespace KakaoMapBlazor.InfoWindow;

public class KakaoInfoWindow : IKakaoInfoWindow, IDisposable
{
    private DotNetObjectReference<KakaoInfoWindow>? _kakaoInfoWindowRef;

    private IJSObjectReference _module;

    private object _infoWindowLock = new object();
    private IJSObjectReference? _infoWindow;

    private List<Func<IJSObjectReference, ValueTask>> _markerLoadedAction = new();

    public KakaoInfoWindow(IJSObjectReference module)
    {
        _module = module;
    }

    public void Dispose()
    {
        _kakaoInfoWindowRef?.Dispose();
    }

    public async ValueTask CreateInfoWindowAsync(IJSObjectReference map, InfoWindowCreateOption option)
    {
        _kakaoInfoWindowRef = DotNetObjectReference.Create(this);
        var infoWindow = await _module.InvokeAsync<IJSObjectReference>("createInfoWindow", map, option, _kakaoInfoWindowRef);
        lock (_infoWindowLock)
        {
            _infoWindow = infoWindow;
        }
    }

    public async ValueTask Close()
    {
        await _infoWindow!.InvokeVoidAsync("close");
    }
}
