import { utils } from "./utils.js"
import { Map } from "./kakaomap.js"

declare var kakao: any;

export class Marker {
    private marker: any;
    private dotnetInstance: any;

    constructor(options, instance) {
        this.dotnetInstance = instance;

        if (options.position) {
            options.position = utils.newLatLng(options.position);
        }

        this.marker = new kakao.maps.Marker(options);
    }

    setMap(map: Map) {
        this.marker.setMap(map.getMapObject());
    }

    getMap() {
        this.marker.getMap();
    }

    setImage(image) {
        this.marker.setImage(image);
    }

    getImage() {
        this.marker.getImage();
    }

    setPosition(position) {
        position = utils.newLatLng(position);
        this.marker.setPosition(position);
    }

    getPosition() {
        this.marker.getPosition();
    }
}
