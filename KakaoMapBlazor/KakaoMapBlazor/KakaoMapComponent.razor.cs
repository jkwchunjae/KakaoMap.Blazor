namespace KakaoMapBlazor;

public partial class KakaoMapComponent : ComponentBase, IDisposable
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Inject]
    private IJSRuntime JS { get; set; }

    [Parameter]
    public string Style { get; set; }

    private KakaoMap _map;

    public IKakaoMap Instance => _map;

    private string _mapId = "kakao-map";
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public void Dispose()
    {
        _map?.Dispose();
    }

    protected override void OnInitialized()
    {
        var mapRandomNumber = Guid.NewGuid().ToString().Substring(0, 10);
        _mapId = $"kakao-map-{mapRandomNumber}";
        _map = new KakaoMap(JS);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (_map == null)
                return;

            await _map.CreateMapAsync(_mapId);
        }
    }

}
