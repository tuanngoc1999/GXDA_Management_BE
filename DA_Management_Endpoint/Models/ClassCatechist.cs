using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DA_Management_Endpoint.Models;

public partial class ClassCatechist
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public int CatechistId { get; set; }

    public bool IsMainCatechist { get; set; }
    [JsonIgnore]
    public virtual Catechist Catechist { get; set; } = null!;
    [JsonIgnore]
    public virtual Class Class { get; set; } = null!;
}
