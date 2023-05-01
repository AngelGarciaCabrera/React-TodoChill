using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using de_todo_chill.Interfaces;
using Domain.Entities.Interfaces;

namespace Domain.Entities.Models;

public class User : IEntity<int>, IDated, INamed, IEmail
{
    [Key] public int Id { get; set; }

    [Column]
    [StringLength(35)]
    public string Name { set; get; }
    
    [Column]
    [StringLength(50)]
    public string Surname { set; get; }

    [Column(TypeName = "Date")] public DateTime? Birthday { get; set; }

    [Column]
    [StringLength(60)]
    public string Email { get; set; }

    [Column]
    [StringLength(50)]
    public string Telephone { set; get; }

    public virtual ICollection<CartItem> CartProducts { get; }

    public DateTime? GetDate()
    {
        return Birthday;
    }

    public void SetDate(DateTime d)
    {
        Birthday = d;
    }
    
    public string GetEmail()
    {
        return Email;
    }

    public void SetEmail(string e)
    {
        Email = e;
    }

    public int GetId()
    {
        return Id;
    }

    public void SetId(int id)
    {
        Id = id;
    }

    public string GetName()
    {
        return Name;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}