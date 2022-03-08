# KakaoMap.Blazor
Kakao map web API for Blazor

https://apis.map.kakao.com/web/guide/

## Step 1: Import kakao map sdk

`_Host.cshtml` (blazor server api)
```
<script type="text/javascript" src="//dapi.kakao.com/v2/maps/sdk.js?appkey={MY_API_KEY}"></script>
```

## Step 2: KakaoMapComponent

In `*.razor` file
```
@using KakaoMapBlazor

<KakaoMapComponent
    @ref="kakaoMapComponent"
    CreateOption="mapCreateOption"
    Style="width: 500px; height: 400px;">
</KakaoMapComponent>

@code {
    [Inject]
    private IJSRuntime JS { get; set; }

    KakaoMapComponent kakaoMapComponent;
    IKakaoMap KakaoMap => kakaoMapComponent?.Instance;
    
    MapCreateOption mapCreateOption = new MapCreateOption(new LatLng(33.450701, 126.570667))
    {
        MapTypeId = MapType.RoadMap,
        Level = 4,
    };

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            KakaoMap.Clicked += async (s, e) =>
            {
                await JS.InvokeVoidAsync("console.log", "OnClick", e);
            };
            KakaoMap.Clicked += async (s, e) =>
            {
                var position = e.LatLng;
                var marker = await KakaoMap.SetMarker(new MarkerCreateOptionInMap
                {
                    Position = position,
                });
                
                marker.Click += async (s, _) =>
                {
                    await JS.InvokeVoidAsync("console.log", "marker clicked");
                };
            };
        }
    }
}

```
