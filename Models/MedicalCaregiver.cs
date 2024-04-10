using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class MedicalCaregiver
{
    public int CaregiverId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? CaregiverAddress { get; set; }

    public int? CaregiverType { get; set; }

    public virtual MedicalCaregiverType? CaregiverTypeNavigation { get; set; }

    public virtual ICollection<MedicalTransaction> MedicalTransactionDoctors { get; set; } = new List<MedicalTransaction>();

    public virtual ICollection<MedicalTransaction> MedicalTransactionNurses { get; set; } = new List<MedicalTransaction>();

    public virtual ICollection<PatientEvent> PatientEvents { get; set; } = new List<PatientEvent>();
}
