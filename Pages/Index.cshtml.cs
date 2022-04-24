using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAccount.Models;
using RazorPagesAccount.Services;
using System.ComponentModel.DataAnnotations;

namespace USI_PROJEKAT.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    [BindProperty]
    public Credentials Cred { get; set; } = new Credentials();
    
    public Account Current { get; set; }
    public void OnGet()
    {
    
    }
    public IActionResult OnPost()
    {
        if(AccountService.LogIn(Cred.Username,Cred.Password) != -1)
        {
           Current = AccountService.Get(AccountService.LogIn(Cred.Username,Cred.Password)); //refactor this somehow, also the app should know which user is logged in via the id
           switch(Current.Type){
                case AccountType.Manager:
                    return Redirect("Manager"); 
                case AccountType.Doctor:
                    return Redirect("Doctor");
                case AccountType.Patient:
                    return Redirect("Patient");
                case AccountType.Secretary:
                    return Redirect("Secretary");
           }
        }
        return null;
    }
    public class Credentials 
    {
    [Required]
    [Display(Name ="Email address")]
    public string Username {get; set;} = "";
    [Required]
    [DataType(DataType.Password)]
    public string Password {get; set;} = "";
    }
}

