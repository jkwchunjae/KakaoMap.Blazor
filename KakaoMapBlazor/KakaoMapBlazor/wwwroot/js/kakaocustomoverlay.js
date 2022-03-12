import { utils } from "./utils.js";
export class CustomOverlay {
    customOverlay;
    dotnetInstance;
    constructor(map, options, instance) {
        this.dotnetInstance = instance;
        options = utils.makeKakaoObject(options);
        options['map'] = map.getMapObject();
        this.customOverlay = new kakao.maps.CustomOverlay(options);
    }
    open() {
        this.customOverlay.setVisible(true);
    }
    close() {
        this.customOverlay.setVisible(false);
    }
    setPosition(position) {
        position = utils.makeKakaoObject(position);
        this.customOverlay.setPosition(position);
    }
    getPosition() {
        return this.customOverlay.getPosition();
    }
    setContent(content) {
        this.customOverlay.setContent(content);
    }
    getContent(content) {
        return this.customOverlay.getContent();
    }
    getVisible() {
        return this.customOverlay.getVisible();
    }
}
//# sourceMappingURL=kakaocustomoverlay.js.map