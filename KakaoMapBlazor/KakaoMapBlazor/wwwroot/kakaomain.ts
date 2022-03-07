import { utils } from "./utils.js"
import { Map } from "./kakaomap.js"
import { Marker } from "./kakaomarker.js"

export function createMap(mapId, option, instance) {
    const options = utils.removeNullProperties(option);
    return new Map(mapId, options, instance);
}

export function createMarker(option, instance) {
    const options = utils.removeNullProperties(option);
    return new Marker(options, instance);
}
