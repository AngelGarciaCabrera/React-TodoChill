using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using de_todo_chill.Interfaces;

namespace de_todo_chill.Models;

public class Product : IEntity<int>, INamed, IValuable
{
    [Key] private int Id { get; set; }

    [Column] private string Name { set; get; }

    [Column] private string Description { set; get; }

    [Column] public double Price { set; get; }

    public Product()
    {
    }

    public int getId() => Id;

    public void setId(int id) => Id = id;

    public string getName() => Name;

    public void setName(string name) => Name = name;

    public double getPrice() => Price;

    public void setPrice(double p) => Price = p;
}