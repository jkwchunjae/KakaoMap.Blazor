import { Map } from "./kakaomap.js";
import { Marker } from "./kakaomarker.js";
export function createMap(mapId, options, instance) {
    return new Map(mapId, options, instance);
}
export function createMarker(options, instance) {
    return new Marker(options, instance);
}
//# sourceMappingURL=kakaomain.js.map