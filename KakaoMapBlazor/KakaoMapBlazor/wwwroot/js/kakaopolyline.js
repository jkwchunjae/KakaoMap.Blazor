import { utils } from "./utils.js";
export class PolyLine {
    polyLine;
    map;
    dotnetInstance;
    constructor(map, options, instance) {
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
    setPath(path) {
        const newPath = utils.makeKakaoObject(path);
        this.polyLine.setPath(newPath);
    }
    pushPath(position) {
        position = utils.makeKakaoObject(position);
        var path = this.polyLine.getPath();
        path.push(position);
        this.polyLine.setPath(path);
    }
    getLength() {
        return this.polyLine.getLength();
    }
}
//# sourceMappingURL=kakaopolyline.js.map