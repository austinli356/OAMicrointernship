using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class VHospital
{
    public int HositalId { get; set; }

    public string? HospitalName { get; set; }

    public int? PatientCount { get; set; }
}
