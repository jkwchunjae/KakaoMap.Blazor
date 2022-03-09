import { utils } from "./utils.js"
import { Map } from "./kakaomap.js"
import { Marker } from "./kakaomarker.js"
import { InfoWindow } from "./kakaoinfowindow.js";

export function createMap(mapId, options, instance) {
    return new Map(mapId, options, instance);
}

export function createMarker(options, instance) {
    return new Marker(options, instance);
}

export function createInfoWindow(map, options, instance) {
    return new InfoWindow(map, options, instance);
}
