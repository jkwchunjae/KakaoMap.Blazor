namespace KakaoMapBlazor;

/// <summary>
/// 카카오 지도. OnMapCreated를 등록해서 사용하면 된다.
/// </summary>
public partial class KakaoMapComponent : ComponentBase, IDisposable
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Inject] private IJSRuntime JS { get; set; }
    [Parameter] public string Style { get; set; }
    [Parameter] public MapCreateOption CreateOption { get; set; } = new MapCreateOption(new LatLng(36.55506321886859, 127.61013231891525))
    {
        MapTypeId = MapType.RoadMap,
        Level = 12,
    };
    /// <summary>
    /// Map이 생성되면 호출된다. IKakaoMap을 받아서 쓰면 된다.
    /// </summary>
    [Parameter] public EventCallback<IKakaoMap> OnMapCreated { get; set; }

    private KakaoMap _map;

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

            await _map.CreateMapAsync(_mapId, CreateOption);

            await OnMapCreated.InvokeAsync(_map);
        }
    }

}
