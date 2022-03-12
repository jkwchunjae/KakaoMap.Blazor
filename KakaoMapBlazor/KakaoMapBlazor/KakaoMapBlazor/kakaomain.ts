import { Map } from "./kakaomap.js"
import { Marker } from "./kakaomarker.js"
import { InfoWindow } from "./kakaoinfowindow.js";
import { CustomOverlay } from "./kakaocustomoverlay.js";
import { PolyLine } from "./kakaopolyline.js";

export function createMap(mapId, options, instance) {
    return new Map(mapId, options, instance);
}

export function createMarker(map: Map, options, instance) {
    return new Marker(map, options, instance);
}

export function createInfoWindow(map: Map, options, instance) {
    return new InfoWindow(map, options, instance);
}

export function createCustomOverlay(map: Map, options, instance) {
    return new CustomOverlay(map, options, instance);
}

export function createPolyLine(map: Map, options, instance) {
    return new PolyLine(map, options, instance);
}