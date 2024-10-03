using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DA_Management_Endpoint.Models;

public partial class CatechistProfile
{
    public int Id { get; set; }

    public int CatechistId { get; set; }

    public int ProfileId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    [JsonIgnore]
    public virtual Catechist Catechist { get; set; } = null!;

    [JsonIgnore]
    public virtual Profile Profile { get; set; } = null!;
}
