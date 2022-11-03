
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildernessFinder.Models;

public class StatePark
{
    public int StateParkId {get;set;}
    public LatLng LatLng { get; set; } = null!;
    public string Formatted_address {get;set;} = "";

    public string Name { get; set; } = string.Empty;


    public StatePark(string name, LatLng latLng, string formatted_address)
    {
        Name = name;
        LatLng = latLng;
        Formatted_address = formatted_address;
    }

}