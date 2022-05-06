import { utils } from "./utils.js";
export class InfoWindow {
    infoWindow;
    dotnetInstance;
    map;
    constructor(map, options, instance) {
        this.dotnetInstance = instance;
        this.map = map;
        options = utils.makeKakaoObject(options);
        this.infoWindow = new kakao.maps.InfoWindow(options);
    }
    close() {
        this.infoWindow.close();
    }
    open() {
        this.infoWindow.open(this.map.getMapObject());
    }
    openWithMarker(marker) {
        this.infoWindow.open(this.map.getMapObject(), marker.getObject());
    }
}
//# sourceMappingURL=kakaoinfowindow.js.map