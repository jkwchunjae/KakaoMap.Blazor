﻿import { utils } from "./utils.js"
import { Map } from "./kakaomap.js"

declare var kakao: any;

export class CustomOverlay {
    private customOverlay: any;
    private dotnetInstance: any;

    constructor(map: Map, options, instance) {
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