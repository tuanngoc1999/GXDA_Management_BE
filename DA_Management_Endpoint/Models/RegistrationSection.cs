using System;
using System.Collections.Generic;

namespace DA_Management_Endpoint.Models;

public partial class RegistrationSection
{
    public string Guid { get; set; } = null!;

    public DateTime InitDate { get; set; }

    public bool? Status { get; set; }
}
