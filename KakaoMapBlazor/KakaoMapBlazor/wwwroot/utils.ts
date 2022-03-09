declare var kakao: any;

class Utils {
    public removeNullProperties(obj) {
        return Object.keys(obj)
            .filter(key => obj[key] != null)
            .reduce((result, key) => ({
                ...result,
                [key]: obj[key],
            }), {});
    }

    private isLatLng(obj): boolean {
        if (typeof obj !== 'object') {
            return false;
        }
        const keys = Object.keys(obj);
        if (keys.includes('latitude') && keys.includes('longitude')) {
            return true;
        }
        return false;
    }

    private isPoint(obj): boolean {
        if (typeof obj !== 'object') {
            return false;
        }
        const keys = Object.keys(obj);
        if (keys.includes('x') && keys.includes('y')) {
            return true;
        }
        return false;
    }

    private isSize(obj): boolean {
        if (typeof obj !== 'object') {
            return false;
        }
        const keys = Object.keys(obj);
        if (keys.includes('width') && keys.includes('height')) {
            return true;
        }
        return false;
    }

    public makeKakaoObject(obj): any {
        if (!obj) {
            return obj;
        }
        if (Array.isArray(obj)) {
            return obj.map(x => this.makeKakaoObject(x));
        } else if (typeof obj === 'object') {
            if (this.isPoint(obj)) {
                return new kakao.maps.Point(obj.x, obj.y);
            } else if (this.isSize(obj)) {
                return new kakao.maps.Size(obj.width, obj.height);
            } else if (this.isLatLng(obj)) {
                return new kakao.maps.LatLng(obj.latitude, obj.longitude);
            } else {
                return Object.keys(obj)
                    .filter(key => obj[key] !== null)
                    .reduce((result, key) => ({
                        ...result,
                        [key]: this.makeKakaoObject(obj[key]),
                    }), {});
            }
        } else {
            return obj;
        }
    }
}

export const utils = new Utils();