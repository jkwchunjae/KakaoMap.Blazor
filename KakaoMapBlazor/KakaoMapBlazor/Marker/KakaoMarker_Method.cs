namespace KakaoMapBlazor.Marker;

public partial class KakaoMarker : IKakaoMarker
{
    public async ValueTask SetImage(MarkerImage image)
    {
        await _marker!.InvokeVoidAsync("setImage", image);
    }

    public ValueTask<MarkerImage> GetImage()
    {
        throw new NotImplementedException();
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
