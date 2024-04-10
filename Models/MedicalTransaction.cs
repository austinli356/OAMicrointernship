using System;
using System.Collections.Generic;

namespace OAinternship.Models;

public partial class MedicalTransaction
{
    public int RxNumber { get; set; }

    public DateOnly? DateFilled { get; set; }

    public string? Ndc { get; set; }

    public int? DaysSupply { get; set; }

    public int? PatientId { get; set; }

    public decimal? TotalCost { get; set; }

    public decimal? TransactionFee { get; set; }

    public decimal? CopayAmount { get; set; }

    public string? PayerName { get; set; }

    public int? NurseId { get; set; }

    public int? DoctorId { get; set; }

    public virtual MedicalCaregiver? Doctor { get; set; }

    public virtual MedicalCaregiver? Nurse { get; set; }

    public virtual Patient? Patient { get; set; }
}
