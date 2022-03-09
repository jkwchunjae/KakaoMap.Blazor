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
}
//# sourceMappingURL=kakaomarker.js.map