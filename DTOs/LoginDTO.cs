using System;
using System.ComponentModel.DataAnnotations;
namespace ProjetoPABD.Dtos;
public class LoginDTO
{
    [Required]
    [MinLength(5)]
    public required string Username { get; set; }
    [Required]
    [MinLength(5)]
    public required string Password { get; set; }
}