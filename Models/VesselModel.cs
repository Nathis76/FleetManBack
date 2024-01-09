using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetMan.Models;
public class Vessel
{
    public int Id { get; set; }
    public int Imo { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool IsOperational { get; set; }
}