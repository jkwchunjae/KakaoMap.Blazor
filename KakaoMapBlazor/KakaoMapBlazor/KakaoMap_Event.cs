namespace KakaoMapBlazor;

// https://apis.map.kakao.com/web/documentation/#Map_Events
public partial class KakaoMap : IKakaoMap
{
    #region CenterChanged
    private int _centerChangedEventReferenceCount = 0;
    private event EventHandler? _centerChanged;
    public event EventHandler CenterChanged
    {
        add
        {
            // 대충 했음
            if (_centerChangedEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addCenterChangedEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _centerChangedEventReferenceCount++;
            _centerChanged += value;
        }
        remove
        {
            _centerChanged -= value;
            _centerChangedEventReferenceCount--;
            if (_centerChangedEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeCenterChangedEvent");
            }
        }
    }

    [JSInvokable]
    public void OnCenterChanged()
    {
        _centerChanged?.Invoke(this, new());
    }
    #endregion

    #region ZoomStart
    private int _zoomStartEventReferenceCount = 0;
    private event EventHandler? _zoomStart;
    public event EventHandler ZoomStart
    {
        add
        {
            // 대충 했음
            if (_zoomStartEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addZoomStartEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _zoomStartEventReferenceCount++;
            _zoomStart += value;
        }
        remove
        {
            _zoomStart -= value;
            _zoomStartEventReferenceCount--;
            if (_zoomStartEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeZoomStartEvent");
            }
        }
    }

    [JSInvokable]
    public void OnZoomStart()
    {
        _zoomStart?.Invoke(this, new());
    }
    #endregion

    #region ZoomChanged
    private int _zoomChangedEventReferenceCount = 0;
    private event EventHandler? _zoomChanged;
    public event EventHandler ZoomChanged
    {
        add
        {
            // 대충 했음
            if (_zoomChangedEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addZoomChangedEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _zoomChangedEventReferenceCount++;
            _zoomChanged += value;
        }
        remove
        {
            _zoomChanged -= value;
            _zoomChangedEventReferenceCount--;
            if (_zoomChangedEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeZoomChangedEvent");
            }
        }
    }

    [JSInvokable]
    public void OnZoomChanged()
    {
        _zoomChanged?.Invoke(this, new());
    }
    #endregion

    #region BoundsChanged
    private int _boundsChangedEventReferenceCount = 0;
    private event EventHandler? _boundsChanged;
    public event EventHandler BoundsChanged
    {
        add
        {
            // 대충 했음
            if (_boundsChangedEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addBoundsChangedEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _boundsChangedEventReferenceCount++;
            _boundsChanged += value;
        }
        remove
        {
            _boundsChanged -= value;
            _boundsChangedEventReferenceCount--;
            if (_boundsChangedEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeBoundsChangedEvent");
            }
        }
    }

    [JSInvokable]
    public void OnBoundsChanged()
    {
        _boundsChanged?.Invoke(this, new());
    }
    #endregion

    #region Click
    private int _clickEventReferenceCount = 0;
    private event EventHandler<MouseEvent>? _click;
    public event EventHandler<MouseEvent> Click
    {
        add
        {
            // 대충 했음
            if (_clickEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addClickEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _clickEventReferenceCount++;
            _click += value;
        }
        remove
        {
            _click -= value;
            _clickEventReferenceCount--;
            if (_clickEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeClickEvent");
            }
        }
    }

    [JSInvokable]
    public void OnClick(MouseEvent mouseEvent)
    {
        _click?.Invoke(this, mouseEvent);
    }
    #endregion

    #region DblClick
    private int _dblclickEventReferenceCount = 0;
    private event EventHandler<MouseEvent>? _dblClick;
    public event EventHandler<MouseEvent> DblClick
    {
        add
        {
            // 대충 했음
            if (_dblclickEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addDblClickEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _dblclickEventReferenceCount++;
            _dblClick += value;
        }
        remove
        {
            _dblClick -= value;
            _dblclickEventReferenceCount--;
            if (_dblclickEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeDblClickEvent");
            }
        }
    }

    [JSInvokable]
    public void OnDblClick(MouseEvent mouseEvent)
    {
        _dblClick?.Invoke(this, mouseEvent);
    }
    #endregion

    #region RightClick
    private int _rightClickEventReferenceCount = 0;
    private event EventHandler<MouseEvent>? _rightClick;
    public event EventHandler<MouseEvent> RightClick
    {
        add
        {
            // 대충 했음
            if (_rightClickEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addRightClickEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _rightClickEventReferenceCount++;
            _rightClick += value;
        }
        remove
        {
            _rightClick -= value;
            _rightClickEventReferenceCount--;
            if (_rightClickEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeRightClickEvent");
            }
        }
    }

    [JSInvokable]
    public void OnRightClick(MouseEvent mouseEvent)
    {
        _rightClick?.Invoke(this, mouseEvent);
    }
    #endregion

    #region MouseMove
    private int _mouseMoveEventReferenceCount = 0;
    private event EventHandler<MouseEvent>? _mouseMove;
    public event EventHandler<MouseEvent> MouseMove
    {
        add
        {
            // 대충 했음
            if (_mouseMoveEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addMouseMoveEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _mouseMoveEventReferenceCount++;
            _mouseMove += value;
        }
        remove
        {
            _mouseMove -= value;
            _mouseMoveEventReferenceCount--;
            if (_mouseMoveEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeMouseMoveEvent");
            }
        }
    }

    [JSInvokable]
    public void OnMouseMove(MouseEvent mouseEvent)
    {
        _mouseMove?.Invoke(this, mouseEvent);
    }
    #endregion

    #region DragStart
    private int _dragStartEventReferenceCount = 0;
    private event EventHandler? _dragStart;
    public event EventHandler DragStart
    {
        add
        {
            // 대충 했음
            if (_dragStartEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addDragStartEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _dragStartEventReferenceCount++;
            _dragStart += value;
        }
        remove
        {
            _dragStart -= value;
            _dragStartEventReferenceCount--;
            if (_dragStartEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeDragStartEvent");
            }
        }
    }

    [JSInvokable]
    public void OnDragStart()
    {
        _dragStart?.Invoke(this, new());
    }
    #endregion

    #region Drag
    private int _dragEventReferenceCount = 0;
    private event EventHandler? _drag;
    public event EventHandler Drag
    {
        add
        {
            // 대충 했음
            if (_dragEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addDragEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _dragEventReferenceCount++;
            _drag += value;
        }
        remove
        {
            _drag -= value;
            _dragEventReferenceCount--;
            if (_dragEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeDragEvent");
            }
        }
    }

    [JSInvokable]
    public void OnDrag()
    {
        _drag?.Invoke(this, new());
    }
    #endregion

    #region DragEnd
    private int _dragendEventReferenceCount = 0;
    private event EventHandler? _dragend;
    public event EventHandler DragEnd
    {
        add
        {
            // 대충 했음
            if (_dragendEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addDragEndEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _dragendEventReferenceCount++;
            _dragend += value;
        }
        remove
        {
            _dragend -= value;
            _dragendEventReferenceCount--;
            if (_dragendEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeDragEndEvent");
            }
        }
    }

    [JSInvokable]
    public void OnDragEnd()
    {
        _dragend?.Invoke(this, new());
    }
    #endregion

    #region Idle
    private int _idleEventReferenceCount = 0;
    private event EventHandler? _idle;
    public event EventHandler Idle
    {
        add
        {
            // 대충 했음
            if (_idleEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addIdleEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _idleEventReferenceCount++;
            _idle += value;
        }
        remove
        {
            _idle -= value;
            _idleEventReferenceCount--;
            if (_idleEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeIdleEvent");
            }
        }
    }

    [JSInvokable]
    public void OnIdle()
    {
        _idle?.Invoke(this, new());
    }
    #endregion

    #region TilesLoaded
    private int _tilesloadedEventReferenceCount = 0;
    private event EventHandler? _tilesloaded;
    public event EventHandler TilesLoaded
    {
        add
        {
            // 대충 했음
            if (_tilesloadedEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addTilesLoadedEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _tilesloadedEventReferenceCount++;
            _tilesloaded += value;
        }
        remove
        {
            _tilesloaded -= value;
            _tilesloadedEventReferenceCount--;
            if (_tilesloadedEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeTilesLoadedEvent");
            }
        }
    }

    [JSInvokable]
    public void OnTilesLoaded()
    {
        _tilesloaded?.Invoke(this, new());
    }
    #endregion

    #region MapTypeIdChanged
    private int _maptypeidchangedEventReferenceCount = 0;
    private event EventHandler? _maptypeidchanged;
    public event EventHandler MapTypeIdChanged
    {
        add
        {
            // 대충 했음
            if (_maptypeidchangedEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = map => map.InvokeVoidAsync("addMapTypeIdChangedEvent");
                lock (_mapLock)
                {
                    if (_map == null)
                    {
                        _mapLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_map);
                    }
                }
            }
            _maptypeidchangedEventReferenceCount++;
            _maptypeidchanged += value;
        }
        remove
        {
            _maptypeidchanged -= value;
            _maptypeidchangedEventReferenceCount--;
            if (_maptypeidchangedEventReferenceCount == 0)
            {
                _map!.InvokeVoidAsync("removeMapTypeIdChangedEvent");
            }
        }
    }

    [JSInvokable]
    public void OnMapTypeIdChanged()
    {
        _maptypeidchanged?.Invoke(this, new());
    }
    #endregion

}
