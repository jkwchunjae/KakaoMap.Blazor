namespace KakaoMapBlazor.Marker;

public partial class KakaoMarker : IKakaoMarker
{
    /*
     * {
    "Yj": "https://t1.daumcdn.net/mapjsapi/images/2x/marker.png",
    "lf": {
        "width": 29,
        "height": 42
    },
    "Jj": {
        "width": 29,
        "height": 42
    },
    "Qd": {
        "x": 14,
        "y": 39
    },
    "de": "poly",
    "n": "14,39,9,27,4,21,1,16,1,10,4,4,11,0,18,0,25,4,28,10,28,16,25,21,20,27",
    "Ij": {
        "x": 0,
        "y": 0
    },
    "Ih": ""
}
     */
    private MarkerImage _image = new MarkerImage("https://t1.daumcdn.net/mapjsapi/images/2x/marker.png", new Size(29, 42), new MarkerImageOption
    {
        Coords = "14,39,9,27,4,21,1,16,1,10,4,4,11,0,18,0,25,4,28,10,28,16,25,21,20,27",
        Shape = "poly",
    });

    public async ValueTask SetImage(MarkerImage image)
    {
        await _marker!.InvokeVoidAsync("setImage", image);
        _image = image;
    }

    public ValueTask<MarkerImage> GetImage()
    {
        return ValueTask.FromResult(_image);
    }

    public async ValueTask SetPosition(LatLng position)
    {
        await _marker!.InvokeVoidAsync("setPosition", position);
    }

    public async ValueTask<LatLng> GetPosition()
    {
        return await _marker!.InvokeAsync<LatLng>("getPosition");
    }

    public async ValueTask SetVisible(bool visible)
    {
        await _marker!.InvokeVoidAsync("setVisible", visible);
    }

    public async ValueTask<bool> GetVisible()
    {
        return await _marker!.InvokeAsync<bool>("getVisible");
    }

    public async ValueTask SetTitle(string title)
    {
        await _marker!.InvokeVoidAsync("setTitle", title);
    }

    public async ValueTask<string> GetTitle()
    {
        return await _marker!.InvokeAsync<string>("getTitle");
    }

    public async ValueTask SetDraggable(bool draggable)
    {
        await _marker!.InvokeVoidAsync("setDraggable", draggable);
    }

    public async ValueTask<bool> GetDraggable()
    {
        return await _marker!.InvokeAsync<bool>("getDraggable");
    }

    public async ValueTask SetClickable(bool clickable)
    {
        await _marker!.InvokeVoidAsync("setClickable", clickable);
    }

    public async ValueTask<bool> GetClickable()
    {
        return await _marker!.InvokeAsync<bool>("getClickable");
    }
}
