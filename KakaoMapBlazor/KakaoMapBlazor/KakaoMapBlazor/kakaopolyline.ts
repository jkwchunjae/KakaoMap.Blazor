import { utils } from "./utils.js"
import { Map } from "./kakaomap.js"

declare var kakao: any;

export class PolyLine {
    private polyLine: any;
    private map: Map;
    private dotnetInstance: any;

    constructor(map: Map, options, instance) {
        this.map = map;
        this.dotnetInstance = instance;

        options = utils.makeKakaoObject(options);
        options['map'] = map.getMapObject();

        this.polyLine = new kakao.maps.Polyline(options);
    }

    close() {
        this.polyLine.setMap(null);
    }

    setOptions(options) {
        options = utils.makeKakaoObject(options);
        options['map'] = this.map.getMapObject();

        this.polyLine.setOptions(options);
    }

    setPath(path: any[]) {
        const newPath = utils.makeKakaoObject(path);

        this.polyLine.setPath(newPath);
    }

    pushPath(position) {
        position = utils.makeKakaoObject(position);
        var path = this.polyLine.getPath();
        path.push(position);
        this.polyLine.setPath(path);
    }

    getLength(): number {
        return this.polyLine.getLength();
    }
}