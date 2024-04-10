using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class MedicalCaregiverType
{
    public int CaregiverTypeId { get; set; }

    public string? CaregiverTypeName { get; set; }

    public virtual ICollection<MedicalCaregiver> MedicalCaregivers { get; set; } = new List<MedicalCaregiver>();
}
