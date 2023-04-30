using System.ComponentModel.DataAnnotations;
using Domain.Entities.Interfaces;

namespace Domain.Entities.Models;

/*Request class for payments*/
public class CartItem : IEntity<string>, IQuantified
{
    [Key]
    [StringLength(15)]
    public string Id { set; get; }

    public int UserId { get; set; }
    public User User { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }

    public string GetId()
    {
        return Id;
    }

    public void SetId(string id)
    {
        Id = id;
    }

    public int GetQuantity()
    {
        return Quantity;
    }

    public void GetQuantity(int v)
    {
        Quantity = v;
    }
}