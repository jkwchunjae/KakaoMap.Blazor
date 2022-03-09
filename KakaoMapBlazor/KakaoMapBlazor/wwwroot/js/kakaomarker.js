import { utils } from "./utils.js";
export class Marker {
    marker;
    dotnetInstance;
    constructor(options, instance) {
        this.dotnetInstance = instance;
        options = utils.makeKakaoObject(options);
        if (options.image) {
            options.image = this.makeMarkerImage(options.image);
        }
        this.marker = new kakao.maps.Marker(options);
    }
    makeMarkerImage(image) {
        image = utils.makeKakaoObject(image);
        if (image.options) {
            const markerImage = new kakao.maps.MarkerImage(image.src, new kakao.maps.Size(image.size.width, image.size.height), image.options);
            return markerImage;
        }
        else {
            const markerImage = new kakao.maps.MarkerImage(image.src, new kakao.maps.Size(image.size.width, image.size.height));
            return markerImage;
        }
    }
    //#region Events
    //#region Click
    onClick() {
        this.dotnetInstance.invokeMethodAsync('OnClick');
    }
    addClickEvent() {
        kakao.maps.event.addListener(this.marker, 'click', this.onClick.bind(this));
    }
    removeClickEvent() {
        kakao.maps.event.removeListener(this.marker, 'click', this.onClick.bind(this));
    }
    //#endregion
    onMouseOver() {
        this.dotnetInstance.invokeMethodAsync('OnMouseOver');
    }
    addMouseOverEvent() {
        kakao.maps.event.addListener(this.marker, 'mouseover', this.onMouseOver.bind(this));
    }
    removeMouseOverEvent() {
        kakao.maps.event.removeListener(this.marker, 'mouseover', this.onMouseOver.bind(this));
    }
    onMouseOut() {
        this.dotnetInstance.invokeMethodAsync('OnMouseOut');
    }
    addMouseOutEvent() {
        kakao.maps.event.addListener(this.marker, 'mouseout', this.onMouseOut.bind(this));
    }
    removeMouseOutEvent() {
        kakao.maps.event.removeListener(this.marker, 'mouseout', this.onMouseOut.bind(this));
    }
    onRightClick() {
        this.dotnetInstance.invokeMethodAsync('OnRightClick');
    }
    addRightClickEvent() {
        kakao.maps.event.addListener(this.marker, 'rightclick', this.onRightClick.bind(this));
    }
    removeRightClickEvent() {
        kakao.maps.event.removeListener(this.marker, 'rightclick', this.onRightClick.bind(this));
    }
    onDragStart() {
        this.dotnetInstance.invokeMethodAsync('OnDragStart');
    }
    addDragStartEvent() {
        kakao.maps.event.addListener(this.marker, 'dragstart', this.onDragStart.bind(this));
    }
    removeDragStartEvent() {
        kakao.maps.event.removeListener(this.marker, 'dragstart', this.onDragStart.bind(this));
    }
    onDragEnd() {
        this.dotnetInstance.invokeMethodAsync('OnDragEnd');
    }
    addDragEndEvent() {
        kakao.maps.event.addListener(this.marker, 'dragend', this.onDragEnd.bind(this));
    }
    removeDragEndEvent() {
        kakao.maps.event.removeListener(this.marker, 'dragend', this.onDragEnd.bind(this));
    }
    //#endregion
    //#region Methods
    setMap(map) {
        this.marker.setMap(map.getMapObject());
    }
    getMap() {
        this.marker.getMap();
    }
    setImage(image) {
        const markerImage = this.makeMarkerImage(image);
        this.marker.setImage(markerImage);
    }
    getImage() {
        const image = this.marker.getImage();
        console.log(image, JSON.stringify(image));
        return image;
    }
    setPosition(position) {
        position = utils.makeKakaoObject(position);
        this.marker.setPosition(position);
    }
    getPosition() {
        return this.marker.getPosition();
    }
    setVisible(visible) {
        this.marker.setVisible(visible);
    }
    getVisible() {
        return this.marker.getVisible();
    }
    setTitle(title) {
        this.marker.setTitle(title);
    }
    getTitle() {
        return this.marker.getTitle();
    }
    setDraggable(draggable) {
        this.marker.setDraggable(draggable);
    }
    getDraggable() {
        return this.marker.getDraggable();
    }
    setClickable(clickable) {
        this.marker.setClickable(clickable);
    }
    getClickable() {
        return this.marker.getClickable();
    }
}
//# sourceMappingURL=kakaomarker.js.map