using System.ComponentModel.DataAnnotations;
using FluentValidation;
namespace OOP.Models.PolyMorphism;

/*public class Customer {
    public virtual string BoardId{get; set;} ="";
    public string Type{ get; set; }= string.Empty; 
    [Required] 
    public string FirstName { get; set; } = string.Empty; 
}
public class Lead:Customer {
    [Required] 
    public override string BoardId{get; set;} = "";
}*/


public class Customer
{
    public string Type { get; set; } = "";
    public string FirstName { get; set; } ="";
    public string BoardId { get; set; } = "";
}

public class Lead : Customer
{
    public new string BoardId{get; set;} = "";    
}

public class LeadValidator:AbstractValidator<Lead>
{
    public LeadValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.BoardId)
            .NotEmpty().When(x=>x.Type =="2" && (x.BoardId == "" || x.BoardId == null))
            .WithMessage("Board Id cannot be empty");
    }
}