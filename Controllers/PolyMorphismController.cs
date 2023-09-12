using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OOP.Models;
using OOP.Models.PolyMorphism;

namespace OOP.Controllers;

public class PolyMorphismController : Controller
{
    public PolyMorphismController()
    {
        
    } 

    public IActionResult PolyMorphism()
    {   
        
        return View();
    }

    [HttpPost]
    public IActionResult PolyMorphism(Lead n)
    {   
        var validationResults = new List<ValidationResult>();     
        if(n.Type == "1")
        {
            // create a list to store the validation results
            Customer x = (Customer)n;
            
            bool validate = Validator.TryValidateObject(x, new ValidationContext(x), validationResults, true);
            
            if (!validate)
            {
                 ModelState.AddModelError("Customer", "First Name is mandatory.");        	
            }  
            
        }
        else
        {
            //fluent validation
            var validator = new LeadValidator();
            var validationResult = validator.ValidateAsync(n); 
            
            if (validationResult.Result.Errors.Count > 0)
            {
                ModelState.AddModelError("Customer", "Board Id must not be empty."); 
            }
        }
       return View(n);
    }
    
}