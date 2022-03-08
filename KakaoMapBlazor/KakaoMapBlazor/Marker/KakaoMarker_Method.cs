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
        //try
        //{
        //    await _marker!.InvokeAsync<MarkerImage>("getImage");
        //}
        //catch
        //{
        //}
        //return _image;
        return ValueTask.FromResult(_image);
    }

    public ValueTask SetPosition(LatLng position)
    {
        throw new NotImplementedException();
    }

    public ValueTask<LatLng> GetPosition()
    {
        throw new NotImplementedException();
    }

    public ValueTask SetVisible(bool visible)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> GetVisible()
    {
        throw new NotImplementedException();
    }

    public ValueTask SetTitle(string title)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string> GetTitle()
    {
        throw new NotImplementedException();
    }
}
