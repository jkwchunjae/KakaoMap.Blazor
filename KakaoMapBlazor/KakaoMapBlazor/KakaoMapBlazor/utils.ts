declare var kakao: any;

class Utils {
    public removeNullProperties(obj) {
        return Object.keys(obj)
            .filter(key => obj[key] != null)
            .reduce((result, key) => ({
                ...result,
                [key]: typeof obj[key] === 'object' ? this.removeNullProperties(obj[key]) : obj[key],
            }), {});
    }

    public newLatLng(ll) {
        return new kakao.maps.LatLng(ll.latitude, ll.longitude);
    }
}

export const utils = new Utils();