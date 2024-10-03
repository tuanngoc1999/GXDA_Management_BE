using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DA_Management_Endpoint.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? HolyName { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string? Dad { get; set; }

    public string? Mom { get; set; }

    public string Address { get; set; } = null!;

    public string? Contact { get; set; }

    public string? SacramentBaptism { get; set; }

    public string? SacramentFirstConfession { get; set; }

    public string? SacramentConfirmation { get; set; }

    public int? ClassId { get; set; }

    public DateTime AddedDate { get; set; }

    public string? Note { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public int? Status { get; set; }

    public DateTime UpdatedDate { get; set; }
    [JsonIgnore]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    [JsonIgnore]
    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
    [JsonIgnore]
    public virtual ICollection<StudentRevision> StudentRevisions { get; set; } = new List<StudentRevision>();
    [JsonIgnore]
    public virtual Class Class { get; set; } = null!;
    [JsonIgnore]
    public virtual Catechist CreatedByCatechist { get; set; } = null!;
    [JsonIgnore]
    public virtual Catechist UpdatedByCatechist { get; set; } = null!;
}
