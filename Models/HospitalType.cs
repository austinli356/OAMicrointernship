using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class HospitalType
{
    public int Id { get; set; }

    public string? HospitalType1 { get; set; }

    public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();
}
