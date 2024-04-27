using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.Models;

public class BloodBag
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BagId { get; set; }

    [Required(ErrorMessage = "Donor ID is required")]
    public int DonorId { get; set; }

    [ForeignKey("DonorId")]
    public Donor? Donor { get; set; }

    public int? RecipientId { get; set; }

    [ForeignKey("RecipientId")]
    public Recipient? Recipient { get; set; }

    [Required(ErrorMessage = "Donation date is required")]
    [DataType(DataType.Date)]
    public DateTime DonationDate { get; set; }

    [Required(ErrorMessage = "Expiry date is required")]
    [DataType(DataType.Date)]
    public DateTime ExpiryDate { get; set; }

    [Required(ErrorMessage = "Blood type is required")]
    public string? BloodType { get; set; }

    [Required(ErrorMessage = "Volume is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Volume must be greater than 0")]
    public decimal Volume { get; set; }
}
