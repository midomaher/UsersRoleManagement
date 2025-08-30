using System.ComponentModel.DataAnnotations;

namespace JwtRoleAuthentication.Application.DTOs;

public class RegistrationRequest
{
    [Required]
    public string? Email { get; set; }
    
    [Required]
    public string? Username { get; set; }
    
    [Required]
    public string? Password { get; set; }

}