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
}

