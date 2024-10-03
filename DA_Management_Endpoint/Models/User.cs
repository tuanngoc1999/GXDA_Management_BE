using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DA_Management_Endpoint.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? Status { get; set; }

    public string Role { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
    [JsonIgnore]
    public virtual Catechist Catechist { get; set; } = null!;
}
