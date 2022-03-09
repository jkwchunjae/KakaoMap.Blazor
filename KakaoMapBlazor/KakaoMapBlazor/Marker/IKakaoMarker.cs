namespace KakaoMapBlazor.Marker;

public interface IKakaoMarker
{
    ValueTask SetImage(MarkerImage image);
    ValueTask<MarkerImage> GetImage();
    ValueTask SetPosition(LatLng position);
    //ValueTask SetPosition(ViewPoint position);
    ValueTask<LatLng> GetPosition();
    //ValueTask SetZIndex(int zIndex);
    //ValueTask<int> GetZIndex();
    ValueTask SetVisible(bool visible);
    ValueTask<bool> GetVisible();
    ValueTask SetTitle(string title);
    ValueTask<string> GetTitle();
    ValueTask SetDraggable(bool draggable);
    ValueTask<bool> GetDraggable();
    ValueTask SetClickable(bool clickable);
    ValueTask<bool> GetClickable();
    //ValueTask SetAltitude(double altitude);
    //ValueTask<double> GetAltitude();
    //ValueTask SetRange(double range);
    //ValueTask<double> GetRange();
    //ValueTask SetOpacity(double opacity);
    //ValueTask<double> GetOpacity();

    event EventHandler Click;
    event EventHandler MouseOver;
    event EventHandler MouseOut;
    event EventHandler RightClick;
    event EventHandler DragStart;
    event EventHandler DragEnd;
}

