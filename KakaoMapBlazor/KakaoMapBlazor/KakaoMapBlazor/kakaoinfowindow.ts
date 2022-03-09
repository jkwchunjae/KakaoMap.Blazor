import { utils } from "./utils.js"
import { Map } from "./kakaomap.js"

declare var kakao: any;

export class InfoWindow {
    private infoWindow: any;
    private dotnetInstance: any;

    constructor(map: Map, options, instance) {
        this.dotnetInstance = instance;

        options = utils.makeKakaoObject(options);
        options['map'] = map.getMapObject();

        this.infoWindow = new kakao.maps.InfoWindow(options);
    }

    close() {
        this.infoWindow.close();
    }
}