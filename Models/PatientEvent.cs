using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class PatientEvent
{
    public int EventId { get; set; }

    public DateTime? DateTime { get; set; }

    public int? PatientId { get; set; }

    public int? NurseId { get; set; }

    public string? EventDescription { get; set; }

    public virtual MedicalCaregiver? Nurse { get; set; }

    public virtual Patient? Patient { get; set; }
}
