using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WildernessFinder.Models;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace WildernessFinder.Controllers;

[Route("api")]
[ApiController]
public class AdventureController : Controller
{
    private MyContext _context;
    public AdventureController(MyContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public StatePark Get()
    {
        LatLng latLng = new LatLng( (float) 42.4573166, (float) -76.512653);
        string name = "Allan H. Treman State Marine Park";
        string formatted_address = "805 Taughannock Blvd, Ithaca, NY 14850, United States";
        Console.WriteLine("HEY");
        
        return  new StatePark(name, latLng, formatted_address);
    }

}

