using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DA_Management_Endpoint.Models;

public partial class Profile
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool P1 { get; set; }

    public bool P2 { get; set; }

    public bool P3 { get; set; }

    public bool P4 { get; set; }

    public bool P5 { get; set; }

    public bool P6 { get; set; }

    public bool P7 { get; set; }

    public bool P8 { get; set; }

    public bool P9 { get; set; }

    public bool P10 { get; set; }

    public bool P11 { get; set; }

    public bool P12 { get; set; }

    public bool P13 { get; set; }

    public bool P14 { get; set; }

    public bool P15 { get; set; }

    public bool P16 { get; set; }

    public bool P17 { get; set; }

    public bool P18 { get; set; }

    public bool P19 { get; set; }

    public bool P20 { get; set; }

    public bool P21 { get; set; }

    public bool P22 { get; set; }

    public bool P23 { get; set; }

    public bool P24 { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public DateTime CreatedDate { get; set; }
    [JsonIgnore]
    public virtual ICollection<CatechistProfile> CatechistProfiles { get; set; } = new List<CatechistProfile>();
    [JsonIgnore]
    public virtual Catechist CreatedByCatechist { get; set; } = null!;
    [JsonIgnore]
    public virtual Catechist UpdatedByCatechist { get; set; } = null!;
}
