using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DA_Management_Endpoint.Models;

public partial class Catechist
{
    public int Id { get; set; }

    public string HolyName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string? Address { get; set; }

    public string? Contact { get; set; }

    public DateTime JoinedDate { get; set; }

    public string Level { get; set; } = null!;

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    [JsonIgnore]
    public virtual ICollection<CatechistProfile> CatechistProfiles { get; set; } = new List<CatechistProfile>();

    [JsonIgnore]
    public virtual ICollection<ClassCatechist> ClassCatechists { get; set; } = new List<ClassCatechist>();

    [JsonIgnore]
    public virtual User User { get; set; } = null!;

}
