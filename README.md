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
@using KakaoMapBlazor.Map
@using KakaoMapBlazor.Models
@using KakaoMapBlazor.Enums
@using KakaoMapBlazor.Marker

<KakaoMapComponent
    CreateOption="mapCreateOption"
    OnMapCreated="OnMapCreated"
    Style="width: 500px; height: 400px;">
</KakaoMapComponent>

@code {
    [Inject]
    private IJSRuntime JS { get; set; }

    IKakaoMap KakaoMap;
    MapCreateOption mapCreateOption = new MapCreateOption(new LatLng(33.450701, 126.570667))
    {
        MapTypeId = MapType.RoadMap,
        Level = 4,
    };

    protected void OnMapCreated(IKakaoMap map)
    {
        KakaoMap = map;
        KakaoMap.Click += async (s, e) =>
        {
            await JS.InvokeVoidAsync("console.log", "OnClick", e);
        };
        KakaoMap.Click += async (s, e) =>
        {
            var position = e.LatLng;
            var marker = await KakaoMap.CreateMarker(new MarkerCreateOptionInMap
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

```
