namespace SecurityConcerns.Models.ViewModels;
using System.ComponentModel.DataAnnotations;


public class CreatePersonVM {
    public string FirstName {get; set;} = String.Empty;
    public string? MiddleName {get; set;}
    public string LastName {get; set;} = String.Empty;
    [DataType(DataType.Date)]
    public DateTime DateOfBirth {get; set;}

    public Person GetPersonInstance()
    {
        return new Person
        {
            Id = 0,
            FirstName = this.FirstName,
            MiddleName = this.MiddleName,
            LastName = this.LastName,
            DateOfBirth = this.DateOfBirth
        };
    }
}