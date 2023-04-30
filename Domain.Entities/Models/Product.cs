using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using de_todo_chill.Interfaces;
using Domain.Entities.Interfaces;

namespace Domain.Entities.Models;

public class Product : IEntity<int>, INamed, IValuable, IQuantified
{
    [Key] public int Id { get; set; }

    [Column]
    [StringLength(35)]
    public string Name { set; get; }

    [Column] 
    [StringLength(100)]
    public string Description { set; get; }

    [Column]
    [Range(0D, 10_000D)]
    public double Price { set; get; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

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

    public double GetPrice()
    {
        return Price;
    }

    public void SetPrice(double p)
    {
        Price = p;
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