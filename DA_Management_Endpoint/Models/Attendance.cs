using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DA_Management_Endpoint.Models;

public partial class Attendance
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public int StudentId { get; set; }

    public string Date { get; set; } = null!;

    public int Status { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    [JsonIgnore]
    public virtual Class Class { get; set; } = null!;
    [JsonIgnore]
    public virtual Student Student { get; set; } = null!;
    [JsonIgnore]
    public virtual Catechist CreatedByCatechist { get; set; } = null!;
    [JsonIgnore]
    public virtual Catechist UpdatedByCatechist { get; set; } = null!;
}
