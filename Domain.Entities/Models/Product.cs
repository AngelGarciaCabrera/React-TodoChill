using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using de_todo_chill.Interfaces;
using Domain.Entities.Interfaces;

namespace de_todo_chill.Models;

public class Product : IEntity<int>, INamed, IValuable
{
    [Key] public int Id { get; set; }

    [Column]
    [StringLength(35)]
    public string Name { set; get; }

    [Column] 
    [StringLength(100)]
    public string Description { set; get; }

    [Column]
    public double Price { set; get; }

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
}