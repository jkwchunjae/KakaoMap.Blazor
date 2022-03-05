namespace KakaoMapBlazor;

public class KakaoMap : IKakaoMap, IDisposable
{
    private IJSRuntime JS;
    private DotNetObjectReference<KakaoMap>? _kakaoMapRef;

    private object _mapLock = new object();
    private IJSObjectReference? _map;

    private List<Func<IJSObjectReference, ValueTask>> _mapLoadedAction = new();

    #region event Clicked
    private int _clickEventReferenceCount = 0;
    private event EventHandler<MouseEvent>? _clicked;
    public event EventHandler<MouseEvent> Clicked
    {
        add
        {
            // 대충 했음
            if (_clickEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addClickEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _clickEventReferenceCount++;
            _clicked += value;
        }
        remove
        {
            _clicked -= value;
            _clickEventReferenceCount--;
            if (_clickEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeClickEvent");
            }
        }
    }

    [JSInvokable]
    public void OnMapClicked(MouseEvent mouseEvent)
    {
        _clicked?.Invoke(this, mouseEvent);
    }
    #endregion

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
