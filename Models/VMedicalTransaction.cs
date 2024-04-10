using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class VMedicalTransaction
{
    public string? PatientFirstName { get; set; }

    public string? PatientLastName { get; set; }

    public int? HospitalId { get; set; }

    public int? PatientId { get; set; }

    public decimal? TotalCost { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public string? NurseFirstName { get; set; }

    public string? NurseLastName { get; set; }

    public string? DoctorFirstName { get; set; }

    public string? DoctorLastName { get; set; }
}
