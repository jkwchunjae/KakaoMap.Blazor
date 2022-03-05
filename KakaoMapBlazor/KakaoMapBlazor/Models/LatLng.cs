namespace KakaoMapBlazor.Models;

public class LatLng
{
    public double Latitude
    {
        get => Ma;
        set => Ma = value;
    }
    public double Longitude
    {
        get => La;
        set => La = value;
    }
    public double La { get; set; }
    public double Ma { get; set; }
}
