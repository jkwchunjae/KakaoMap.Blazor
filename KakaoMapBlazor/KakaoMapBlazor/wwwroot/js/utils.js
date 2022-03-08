class Utils {
    removeNullProperties(obj) {
        return Object.keys(obj)
            .filter(key => obj[key] != null)
            .reduce((result, key) => ({
            ...result,
            [key]: typeof obj[key] === 'object' ? this.removeNullProperties(obj[key]) : obj[key],
        }), {});
    }
    newLatLng(ll) {
        return new kakao.maps.LatLng(ll.latitude, ll.longitude);
    }
    makeMarkerImageOption(option) {
        const options = {};
        if (option.alt) {
            options['alt'] = option.alt;
        }
        if (option.coords) {
            options['coords'] = option.coords;
        }
        if (option.offset) {
            const p = option.offset;
            options['offset'] = new kakao.maps.Point(p.x, p.y);
        }
        if (option.shape) {
            options['shape'] = option.shape;
        }
        if (option.spriteOrigin) {
            const p = option.spriteOrigin;
            options['spriteOrigin'] = new kakao.maps.Point(p.x, p.y);
        }
        if (option.spriteSize) {
            const s = option.spriteSize;
            options['spriteSize'] = new kakao.maps.Size(s.width, s.height);
        }
        return options;
    }
}
export const utils = new Utils();
//# sourceMappingURL=utils.js.map