
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildernessFinder.Models;

public class NationalPark
{
    public int NationalParkId {get;set;}
    public LatLng LatLng { get; set; } = null!;

    public string Name { get; set; } = string.Empty;
    public string State { get;set;} = string.Empty;
}