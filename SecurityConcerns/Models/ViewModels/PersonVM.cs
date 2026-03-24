namespace SecurityConcerns.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

public class PersonVM 
{
    [Required(ErrorMessage = "The name cannot be blank!")]
    public string Name {get; set;} = String.Empty;
    [StringLength(20, MinimumLength=3, ErrorMessage="Must be at least 3 and at most 20 characters.")]
    public string Occupation {get; set;} = String.Empty;
    [Range(18, 100)]
    public int Age {get; set;}
    [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$")] 
    public string Phone {get; set;} = String.Empty;
    [Display(Name="Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth {get; set;}
    [DataType(DataType.Currency)]
    public decimal PayPerHour {get; set;}
    [EmailAddress(ErrorMessage="Invalid Email Address!")]
    public string email {get; set;} = String.Empty;
}