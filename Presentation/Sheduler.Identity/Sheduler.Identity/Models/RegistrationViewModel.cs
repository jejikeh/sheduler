using System.ComponentModel.DataAnnotations;

namespace Sheduler.Identity.Models;

public class RegistrationViewModel
{
    [Required] 
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
    public string ReturnUrl { get; set; }
}