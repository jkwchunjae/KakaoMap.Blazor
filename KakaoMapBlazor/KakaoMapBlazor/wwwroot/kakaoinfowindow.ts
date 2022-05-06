import { utils } from "./utils.js"
import { Map } from "./kakaomap.js"
import { Marker } from "./kakaomarker.js";

declare var kakao: any;

export class InfoWindow {
    private infoWindow: any;
    private dotnetInstance: any;
    private map: Map;

    constructor(map: Map, options, instance) {
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

    openWithMarker(marker: Marker) {
        this.infoWindow.open(this.map.getMapObject(), marker.getObject());
    }
}