using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class Patient
{
    public int Id { get; set; }

    public int? MedicalRecordId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public string? PatientAddress { get; set; }

    public string? Insurance { get; set; }

    public int? HospitalId { get; set; }

    public virtual MedicalRecord? MedicalRecord { get; set; }

    public virtual ICollection<MedicalTransaction> MedicalTransactions { get; set; } = new List<MedicalTransaction>();

    public virtual ICollection<PatientEvent> PatientEvents { get; set; } = new List<PatientEvent>();
}
