using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using de_todo_chill.Interfaces;
using Domain.Entities.Interfaces;

namespace Domain.Entities.Models;

/*Request class for payments*/
public class CartItems : IEntity<string>
{
    [Key] public string Id { set; get; }

    public int UserId { get; set; }
    public User User { get; set; }
    
    public int ProductId { get; set; }
    public virtual ICollection<Product> Products { set; get; }

    public string GetId()
    {
        return Id;
    }

    public void SetId(string id)
    {
        Id = id;
    }
}