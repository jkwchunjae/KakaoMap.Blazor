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

<KakaoMapComponent @ref="kakaoMapComponent" Style="width: 500px; height: 400px;"></KakaoMapComponent>

@code {
    [Inject]
    private IJSRuntime JS { get; set; }

    KakaoMapComponent kakaoMapComponent;
    IKakaoMap KakaoMap => kakaoMapComponent?.Instance;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            KakaoMap.Clicked += async (s, e) =>
            {
                await KakaoMap.SetCenter(e.LatLng);
            };
            KakaoMap.Clicked += async (s, e) =>
            {
                await JS.InvokeVoidAsync("console.log", "OnClick", e);
            };
        }
    }
}

```
