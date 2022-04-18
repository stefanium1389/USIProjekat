using System.ComponentModel.DataAnnotations;

namespace RazorPagesAccount.Models;

public class Account
{
    public int Id { get; set; }

    [Required]
    public string? Email { get; set; }
    public string? Password { get; set; }
    public AccountType Type { get; set; }

}

public enum AccountType { Manager, Doctor, Patient, Secretary }