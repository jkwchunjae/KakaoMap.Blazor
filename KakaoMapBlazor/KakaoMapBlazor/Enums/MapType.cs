namespace KakaoMapBlazor.Types;

/// <summary>
/// kakao.maps.MapTypeId 객체
/// <br/>
/// https://apis.map.kakao.com/web/documentation/#MapTypeId
/// </summary>
public enum MapType
{
    // Base type
    /// <summary> 일반 지도 </summary>
    RoadMap,
    /// <summary> 스카이뷰 </summary>
    SkyView,
    /// <summary> 하이브리드 (스카이뷰 + 레이블) </summary>
    Hybrid,

    // Overlay type
    /// <summary> 레이블 </summary>
    Overlay,
    /// <summary> 교통정보 </summary>
    Traffic,
    /// <summary> 지형도 </summary>
    Terrain,
    /// <summary> 자전거 </summary>
    Bicycle,
    /// <summary> 스카이뷰를 위한 자전거 </summary>
    BicycleHybrid,
    /// <summary> 지적편집도 </summary>
    UseDistrict,
}
