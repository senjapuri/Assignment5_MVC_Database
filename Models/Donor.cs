using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank.Models;

public class Donor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DonorId { get; set; }

    public string? DonorName { get; set; }

    public int Age { get; set; }

    [DataType(DataType.Date)]
    public DateTime RegistrationDate { get; set; }

    public string? BloodType { get; set; }

    public string? Contact { get; set; }
    public string? MedicalHistory { get; set; }
}
