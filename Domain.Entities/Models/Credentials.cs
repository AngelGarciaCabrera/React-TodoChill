using System.ComponentModel.DataAnnotations;
using Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Models;

[Index(nameof(Email), IsUnique = true)]
public class Credentials : IEntity<string>, IEmail
{
    [Key] public string Id { get; set; }

    [StringLength(40)] public string Email { get; set; }
    [StringLength(25)] public string Password { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }

    public string GetId()
    {
        return Id;
    }

    public void SetId(string id)
    {
        Id = id;
    }

    public string GetEmail()
    {
        return Email;
    }

    public void SetEmail(string e)
    {
        Email = e;
    }
}