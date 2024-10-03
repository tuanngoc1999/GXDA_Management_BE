using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DA_Management_Endpoint.Models;

public partial class StudentRevision
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public int StudentId { get; set; }

    public string History { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }
    [JsonIgnore]
    public virtual Class Class { get; set; } = null!;
    [JsonIgnore]
    public virtual Student Student { get; set; } = null!;
    [JsonIgnore]
    public virtual Catechist CreatedByCatechist { get; set; } = null!;
}
