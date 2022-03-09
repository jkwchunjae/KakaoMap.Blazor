import { utils } from "./utils.js";
export class InfoWindow {
    infoWindow;
    dotnetInstance;
    constructor(map, options, instance) {
        this.dotnetInstance = instance;
        options = utils.makeKakaoObject(options);
        options['map'] = map.getMapObject();
        this.infoWindow = new kakao.maps.InfoWindow(options);
    }
    close() {
        this.infoWindow.close();
    }
}
//# sourceMappingURL=kakaoinfowindow.js.map