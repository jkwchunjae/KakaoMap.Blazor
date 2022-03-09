namespace KakaoMapBlazor.Marker;

public partial class KakaoMarker : IKakaoMarker
{
    #region Click
    private int _clickEventReferenceCount = 0;
    private event EventHandler? _click;
    public event EventHandler Click
    {
        add
        {
            // 대충 했음
            if (_clickEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = marker => marker.InvokeVoidAsync("addClickEvent");
                lock (_markerLock)
                {
                    if (_marker == null)
                    {
                        _markerLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_marker);
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
                _marker!.InvokeVoidAsync("removeClickEvent");
            }
        }
    }

    [JSInvokable]
    public void OnClick()
    {
        _click?.Invoke(this, new());
    }
    #endregion
    
    #region MouseOver
    private int _mouseOverEventReferenceCount = 0;
    private event EventHandler? _mouseOver;
    public event EventHandler MouseOver
    {
        add
        {
            // 대충 했음
            if (_mouseOverEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = marker => marker.InvokeVoidAsync("addMouseOverEvent");
                lock (_markerLock)
                {
                    if (_marker == null)
                    {
                        _markerLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_marker);
                    }
                }
            }
            _mouseOverEventReferenceCount++;
            _mouseOver += value;
        }
        remove
        {
            _mouseOver -= value;
            _mouseOverEventReferenceCount--;
            if (_mouseOverEventReferenceCount == 0)
            {
                _marker!.InvokeVoidAsync("removeMouseOverEvent");
            }
        }
    }

    [JSInvokable]
    public void OnMouseOver()
    {
        _mouseOver?.Invoke(this, new());
    }
    #endregion

    #region MouseOut
    private int _mouseOutEventReferenceCount = 0;
    private event EventHandler? _mouseOut;
    public event EventHandler MouseOut
    {
        add
        {
            // 대충 했음
            if (_mouseOutEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = marker => marker.InvokeVoidAsync("addMouseOutEvent");
                lock (_markerLock)
                {
                    if (_marker == null)
                    {
                        _markerLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_marker);
                    }
                }
            }
            _mouseOutEventReferenceCount++;
            _mouseOut += value;
        }
        remove
        {
            _mouseOut -= value;
            _mouseOutEventReferenceCount--;
            if (_mouseOutEventReferenceCount == 0)
            {
                _marker!.InvokeVoidAsync("removeMouseOutEvent");
            }
        }
    }

    [JSInvokable]
    public void OnMouseOut()
    {
        _mouseOut?.Invoke(this, new());
    }
    #endregion
    
    #region RightClick
    private int _rightClickEventReferenceCount = 0;
    private event EventHandler? _rightClick;
    public event EventHandler RightClick
    {
        add
        {
            // 대충 했음
            if (_rightClickEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = marker => marker.InvokeVoidAsync("addRightClickEvent");
                lock (_markerLock)
                {
                    if (_marker == null)
                    {
                        _markerLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_marker);
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
                _marker!.InvokeVoidAsync("removeRightClickEvent");
            }
        }
    }

    [JSInvokable]
    public void OnRightClick()
    {
        _rightClick?.Invoke(this, new());
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
                Func<IJSObjectReference, ValueTask> fn = marker => marker.InvokeVoidAsync("addDragStartEvent");
                lock (_markerLock)
                {
                    if (_marker == null)
                    {
                        _markerLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_marker);
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
                _marker!.InvokeVoidAsync("removeDragStartEvent");
            }
        }
    }

    [JSInvokable]
    public void OnDragStart()
    {
        _dragStart?.Invoke(this, new());
    }
    #endregion
    
    #region DragEnd
    private int _dragEndEventReferenceCount = 0;
    private event EventHandler? _dragEnd;
    public event EventHandler DragEnd
    {
        add
        {
            // 대충 했음
            if (_dragEndEventReferenceCount == 0)
            {
                Func<IJSObjectReference, ValueTask> fn = marker => marker.InvokeVoidAsync("addDragEndEvent");
                lock (_markerLock)
                {
                    if (_marker == null)
                    {
                        _markerLoadedAction.Add(fn);
                    }
                    else
                    {
                        fn(_marker);
                    }
                }
            }
            _dragEndEventReferenceCount++;
            _dragEnd += value;
        }
        remove
        {
            _dragEnd -= value;
            _dragEndEventReferenceCount--;
            if (_dragEndEventReferenceCount == 0)
            {
                _marker!.InvokeVoidAsync("removeDragEndEvent");
            }
        }
    }

    [JSInvokable]
    public void OnDragEnd()
    {
        _dragEnd?.Invoke(this, new());
    }
    #endregion
}

