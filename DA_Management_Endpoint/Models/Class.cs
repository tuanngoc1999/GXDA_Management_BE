using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DA_Management_Endpoint.Models;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AcademicYearId { get; set; }

    public int BlockId { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    [JsonIgnore]
    public virtual AcademicYear AcademicYear { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    [JsonIgnore]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    [JsonIgnore]
    public virtual Block Block { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<ClassCatechist> ClassCatechists { get; set; } = new List<ClassCatechist>();
    [JsonIgnore]
    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
    [JsonIgnore]
    public virtual ICollection<StudentRevision> StudentRevisions { get; set; } = new List<StudentRevision>();
}
