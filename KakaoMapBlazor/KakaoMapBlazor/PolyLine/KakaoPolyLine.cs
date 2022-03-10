namespace KakaoMapBlazor.PolyLine;

public class KakaoPolyLine : IKakaoPolyLine
{
    private DotNetObjectReference<KakaoPolyLine>? _kakaoPolyLineRef;

    private IJSObjectReference _module;

    private object _polyLineLock = new object();
    private IJSObjectReference? _polyLine;

    private List<Func<IJSObjectReference, ValueTask>> _polylineLoadedAction = new();

    private LatLng _lastPosition;
    public LatLng LastPosition => _lastPosition;

    public KakaoPolyLine(IJSObjectReference module)
    {
        _module = module;
        _lastPosition = new();
    }

    public void Dispose()
    {
        _kakaoPolyLineRef?.Dispose();
    }

    public async ValueTask CreatePolyLineAsync(IJSObjectReference map, PolyLineCreateOption option)
    {
        _kakaoPolyLineRef = DotNetObjectReference.Create(this);
        var polyLine = await _module.InvokeAsync<IJSObjectReference>("createPolyLine", map, option, _kakaoPolyLineRef);
        lock (_polyLineLock)
        {
            _polyLine = polyLine;
        }

        foreach (var fn in _polylineLoadedAction)
        {
            await fn(_polyLine);
        }

        _lastPosition = option.Path.Last();
    }

    public async ValueTask Close()
    {
        await _polyLine!.InvokeVoidAsync("close");
    }

    public async ValueTask SetOptions(PolyLineOption option)
    {
        await _polyLine!.InvokeVoidAsync("setOptions", option);
    }

    public async ValueTask SetPath(IEnumerable<LatLng> path)
    {
        await _polyLine!.InvokeVoidAsync("setPath", path);
        _lastPosition = path.Last();
    }

    public async ValueTask PushPath(LatLng position)
    {
        await _polyLine!.InvokeVoidAsync("pushPath", position);
        _lastPosition = position;
    }

    public async ValueTask<int> GetLength()
    {
        var length = await _polyLine!.InvokeAsync<double>("getLength");
        return (int)length;
    }
}
