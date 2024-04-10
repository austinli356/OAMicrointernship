using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class Hospital
{
    public int Id { get; set; }

    public string? HospitalName { get; set; }

    public string? HospitalAddress { get; set; }

    public long? Number { get; set; }

    public int? TypeId { get; set; }

    public virtual HospitalType? Type { get; set; }
}
