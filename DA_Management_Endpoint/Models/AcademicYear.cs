using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DA_Management_Endpoint.Models;

public partial class AcademicYear
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? Status { get; set; }

    [JsonIgnore]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
