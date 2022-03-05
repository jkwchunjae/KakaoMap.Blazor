
declare var kakao: any;

export function createMap(mapId, instance) {
    return new Map(mapId, instance);
}

class Map {
    private map: any;
    private dotnetInstance: any;

    constructor(mapId: string, instance) {
        this.dotnetInstance = instance;
        const container = document.getElementById(mapId);
        const options = {
            center: new kakao.maps.LatLng(33.450701, 126.570667), //지도의 중심좌표.
            level: 3 //지도의 레벨(확대, 축소 정도)
        };

        this.map = new kakao.maps.Map(container, options);
    }

    onMapClicked(mouseEvent) {
        this.dotnetInstance.invokeMethodAsync('OnMapClicked', mouseEvent);
    }

    addClickEvent() {
        kakao.maps.event.addListener(this.map, 'click', this.onMapClicked.bind(this));
    }

    removeClickEvent() {
        kakao.maps.event.removeListener(this.map, 'click', this.onMapClicked.bind(this));
    }

    setCenter(position) {
        const center = new kakao.maps.LatLng(position.latitude, position.longitude);
        this.map.setCenter(center);
    }

    getCenter() {
        return this.map.getCenter();
    }
}

