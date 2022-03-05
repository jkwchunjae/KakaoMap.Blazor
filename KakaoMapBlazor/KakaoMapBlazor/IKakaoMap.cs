namespace KakaoMapBlazor;

public interface IKakaoMap
{
    ValueTask SetCenter(LatLng position);
    ValueTask<LatLng> GetCenter();
    //ValueTask SetLevel(int level);
    //ValueTask SetLevel(int level, SetLevelOption option);
    //ValueTask<int> GetLevel();
    //ValueTask SetMapTypeId(MapType mapType);
    //ValueTask<MapType> GetMapTypeId();
    //ValueTask SetBounds(LatLngBounds bounds);
    //ValueTask SetBounds(LatLngBounds bounds, double paddingTop, double paddingRight, double paddingBottom, double paddingLeft);
    //ValueTask<LatLngBounds> GetBounds();
    //ValueTask SetMinLevel(int minLevel);
    //ValueTask SetMaxLevel(int maxLevel);
    //ValueTask PanBy(double dx, double dy);
    //ValueTask PanTo(LatLng latLng, double? padding);
    //ValueTask PanTo(LatLngBounds bounds, double? padding);
    //ValueTask AddControl(ControlType control, ControlPosition position);
    //ValueTask RemoveControl(ControlType control);
    //ValueTask SetDraggable(bool draggable);
    //ValueTask<bool> GetDraggable();
    //ValueTask SetZommable(bool zommable);
    //ValueTask<bool> GetZommable();
    //ValueTask SetProjectionId(ProjectionId projectionId);
    //ValueTask<ProjectionId> GetProjectionId();
    //ValueTask ReLayout();
    //ValueTask AddOverlayMapTypeId(MapType overlay);
    //ValueTask RemoveOverlayMapTypeId(MapType overlay);
    //ValueTask SetKeyboardShortcuts(bool active);
    //ValueTask<bool> GetKeyboardShortcuts();
    //ValueTask SetCopyrightPosition(CopyrightPosition copyrightPosition);
    //ValueTask SetCopyrightPosition(CopyrightPosition copyrightPosition, bool reserved);
    //ValueTask<MapProjection> GetProjection();
    //ValueTask SetCursor(string style);

    //event EventHandler CenterChanged;
    //event EventHandler ZoomStarted;
    //event EventHandler ZoomChanged;
    //event EventHandler BoundsChanged;
    event EventHandler<MouseEvent> Clicked;
    //event EventHandler<MouseEvent> DblClicked;
    //event EventHandler<MouseEvent> RightClicked;
    //event EventHandler<MouseEvent> MouseMoved;
    //event EventHandler DragStarted;
    //event EventHandler Drag;
    //event EventHandler DragEnd;
    //event EventHandler Idle;
    //event EventHandler TilesLoaded;
    //event EventHandler MaptypeIdChanged;

}
