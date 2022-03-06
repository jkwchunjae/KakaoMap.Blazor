
declare var kakao: any;

class Utils {
    public removeNullProperties(obj) {
        return Object.keys(obj)
            .filter(key => obj[key] != null)
            .reduce((result, key) => ({
                ...result,
                [key]: typeof obj[key] === 'object' ? this.removeNullProperties(obj[key]) : obj[key],
            }), {});
    }

    public newLatLng(ll) {
        return new kakao.maps.LatLng(ll.latitude, ll.longitude);
    }
}

const utils = new Utils();

export function createMap(mapId, option, instance) {
    const options = utils.removeNullProperties(option);
    return new Map(mapId, options, instance);
}

class Map {
    private map: any;
    private dotnetInstance: any;

    constructor(mapId: string, options, instance) {
        this.dotnetInstance = instance;
        const container = document.getElementById(mapId);

        options.center = utils.newLatLng(options.center);

        this.map = new kakao.maps.Map(container, options);
    }

    //#region Events
    // https://apis.map.kakao.com/web/documentation/#Map_Events

    //#region CenterChanged
    onCenterChanged() {
        this.dotnetInstance.invokeMethodAsync('OnCenterChanged');
    }

    addCenterChangedEvent() {
        kakao.maps.event.addListener(this.map, 'center_changed', this.onCenterChanged.bind(this));
    }

    removeCenterChangedEvent() {
        kakao.maps.event.removeListener(this.map, 'center_changed', this.onCenterChanged.bind(this));
    }
    //#endregion

    //#region ZoomStart
    onZoomStart() {
        this.dotnetInstance.invokeMethodAsync('OnZoomStart');
    }

    addZoomStartEvent() {
        kakao.maps.event.addListener(this.map, 'zoom_start', this.onZoomStart.bind(this));
    }

    removeZoomStartEvent() {
        kakao.maps.event.removeListener(this.map, 'zoom_start', this.onZoomStart.bind(this));
    }
    //#endregion

    //#region ZoomChanged
    onZoomChanged() {
        this.dotnetInstance.invokeMethodAsync('OnZoomChanged');
    }

    addZoomChangedEvent() {
        kakao.maps.event.addListener(this.map, 'zoom_changed', this.onZoomChanged.bind(this));
    }

    removeZoomChangedEvent() {
        kakao.maps.event.removeListener(this.map, 'zoom_changed', this.onZoomChanged.bind(this));
    }
    //#endregion

    //#region BoundsChanged
    onBoundsChanged() {
        this.dotnetInstance.invokeMethodAsync('OnBoundsChanged');
    }

    addBoundsChangedEvent() {
        kakao.maps.event.addListener(this.map, 'bounds_changed', this.onBoundsChanged.bind(this));
    }

    removeBoundsChangedEvent() {
        kakao.maps.event.removeListener(this.map, 'bounds_changed', this.onBoundsChanged.bind(this));
    }
    //#endregion

    //#region Click
    onClick(mouseEvent) {
        this.dotnetInstance.invokeMethodAsync('OnClick', mouseEvent);
    }

    addClickEvent() {
        kakao.maps.event.addListener(this.map, 'click', this.onClick.bind(this));
    }

    removeClickEvent() {
        kakao.maps.event.removeListener(this.map, 'click', this.onClick.bind(this));
    }
    //#endregion

    //#region DblClick
    onDblClick(mouseEvent) {
        this.dotnetInstance.invokeMethodAsync('OnDblClick', mouseEvent);
    }

    addDblClickEvent() {
        kakao.maps.event.addListener(this.map, 'dblclick', this.onDblClick.bind(this));
    }

    removeDblClickEvent() {
        kakao.maps.event.removeListener(this.map, 'dblclick', this.onDblClick.bind(this));
    }
    //#endregion

    //#region RightClick
    onRightClick(mouseEvent) {
        this.dotnetInstance.invokeMethodAsync('OnRightClick', mouseEvent);
    }

    addRightClickEvent() {
        kakao.maps.event.addListener(this.map, 'rightclick', this.onRightClick.bind(this));
    }

    removeRightClickEvent() {
        kakao.maps.event.removeListener(this.map, 'rightclick', this.onRightClick.bind(this));
    }
    //#endregion

    //#region MouseMove
    onMouseMove(mouseEvent) {
        this.dotnetInstance.invokeMethodAsync('OnMouseMove', mouseEvent);
    }

    addMouseMoveEvent() {
        kakao.maps.event.addListener(this.map, 'mousemove', this.onMouseMove.bind(this));
    }

    removeMouseMoveEvent() {
        kakao.maps.event.removeListener(this.map, 'mousemove', this.onMouseMove.bind(this));
    }
    //#endregion

    //#region DragStart
    onDragStart() {
        this.dotnetInstance.invokeMethodAsync('OnDragStart');
    }

    addDragStartEvent() {
        kakao.maps.event.addListener(this.map, 'dragstart', this.onDragStart.bind(this));
    }

    removeDragStartEvent() {
        kakao.maps.event.removeListener(this.map, 'dragstart', this.onDragStart.bind(this));
    }
    //#endregion

    //#region Drag
    onDrag() {
        this.dotnetInstance.invokeMethodAsync('OnDrag');
    }

    addDragEvent() {
        kakao.maps.event.addListener(this.map, 'drag', this.onDrag.bind(this));
    }

    removeDragEvent() {
        kakao.maps.event.removeListener(this.map, 'drag', this.onDrag.bind(this));
    }
    //#endregion

    //#region DragEnd
    onDragEnd() {
        this.dotnetInstance.invokeMethodAsync('OnDragEnd');
    }

    addDragEndEvent() {
        kakao.maps.event.addListener(this.map, 'dragend', this.onDragEnd.bind(this));
    }

    removeDragEndEvent() {
        kakao.maps.event.removeListener(this.map, 'dragend', this.onDragEnd.bind(this));
    }
    //#endregion

    //#region Idle
    onIdle() {
        this.dotnetInstance.invokeMethodAsync('OnIdle');
    }

    addIdleEvent() {
        kakao.maps.event.addListener(this.map, 'idle', this.onIdle.bind(this));
    }

    removeIdleEvent() {
        kakao.maps.event.removeListener(this.map, 'idle', this.onIdle.bind(this));
    }
    //#endregion

    //#region TilesLoaded
    onTilesLoaded() {
        this.dotnetInstance.invokeMethodAsync('OnTilesLoaded');
    }

    addTilesLoadedEvent() {
        kakao.maps.event.addListener(this.map, 'tilesloaded', this.onTilesLoaded.bind(this));
    }

    removeTilesLoadedEvent() {
        kakao.maps.event.removeListener(this.map, 'tilesloaded', this.onTilesLoaded.bind(this));
    }
    //#endregion

    //#region MapTypeIdChanged
    onMapTypeIdChanged() {
        this.dotnetInstance.invokeMethodAsync('OnMapTypeIdChanged');
    }

    addMapTypeIdChangedEvent() {
        kakao.maps.event.addListener(this.map, 'maptypeid_changed', this.onMapTypeIdChanged.bind(this));
    }

    removeMapTypeIdChangedEvent() {
        kakao.maps.event.removeListener(this.map, 'maptypeid_changed', this.onMapTypeIdChanged.bind(this));
    }
    //#endregion

    //#endregion

    setCenter(position) {
        const center = new kakao.maps.LatLng(position.latitude, position.longitude);
        this.map.setCenter(center);
    }

    getCenter() {
        return this.map.getCenter();
    }
}

