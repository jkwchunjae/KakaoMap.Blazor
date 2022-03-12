namespace KakaoMapBlazor.InfoWindow;

public class KakaoCustomOverlay : IKakaoCustomOverlay, IDisposable
{
    private DotNetObjectReference<KakaoCustomOverlay>? _kakaoCustomOverlayRef;

    private IJSObjectReference _module;

    private object _customOverlayLock = new object();
    private IJSObjectReference? _customOverlay;

    public KakaoCustomOverlay(IJSObjectReference module)
    {
        _module = module;
    }

    public void Dispose()
    {
        _kakaoCustomOverlayRef?.Dispose();
    }

    public async ValueTask CreateCustomOverlayAsync(IJSObjectReference map, CustomOverlayCreateOption option)
    {
        _kakaoCustomOverlayRef = DotNetObjectReference.Create(this);
        var customOverlay = await _module.InvokeAsync<IJSObjectReference>("createCustomOverlay", map, option, _kakaoCustomOverlayRef);
        lock (_customOverlayLock)
        {
            _customOverlay = customOverlay;
        }
    }

    public async ValueTask Open()
    {
        await _customOverlay!.InvokeVoidAsync("open");
    }

    public async ValueTask Close()
    {
        await _customOverlay!.InvokeVoidAsync("close");
    }

    public async ValueTask SetPosition(LatLng position)
    {
        await _customOverlay!.InvokeVoidAsync("setPosition", position);
    }

    public async ValueTask<LatLng> GetPosition()
    {
        var position = await _customOverlay!.InvokeAsync<LatLng>("getPosition");
        return position;
    }

    public async ValueTask SetContent(string content)
    {
        await _customOverlay!.InvokeVoidAsync("setContent", content);
    }

    public async ValueTask<string> GetContent()
    {
        var content = await _customOverlay!.InvokeAsync<string>("getContent");
        return content;
    }

    public async ValueTask<bool> GetVisible()
    {
        var visible = await _customOverlay!.InvokeAsync<bool>("getVisible");
        return visible;
    }
}
