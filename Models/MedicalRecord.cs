using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class MedicalRecord
{
    public int Id { get; set; }

    public string? Info { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
