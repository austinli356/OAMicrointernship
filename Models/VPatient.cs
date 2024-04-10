using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class VPatient
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public string? PatientAddress { get; set; }

    public string? HospitalName { get; set; }

    public string? Info { get; set; }

    public int? HospitalId { get; set; }

    public int? TransactionCount { get; set; }
}
