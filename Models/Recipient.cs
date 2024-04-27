using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.Models;

public class Recipient
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RecipientId { get; set; }

    [Required(ErrorMessage = "Recipient name is required")]
    public string? RecipientName { get; set; }

    [Required(ErrorMessage = "Age is required")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Blood type is required")]
    public string? BloodType { get; set; }

    public string? Contact { get; set; }
       public string? MedicalCondition { get; set; }
}
