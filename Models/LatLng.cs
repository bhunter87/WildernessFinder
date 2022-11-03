#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildernessFinder.Models;
[NotMapped]
public class LatLng
{
    public int LatLngId {get;set;}
    
    public float Lat {get;set;}
    public float Lng {get;set;}

    public LatLng(float lat, float lng)
    {
        Lat = lat;
        Lng = lng;

    }
}