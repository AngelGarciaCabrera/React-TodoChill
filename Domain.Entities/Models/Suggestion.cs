using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using de_todo_chill.Interfaces;
using Domain.Entities.Interfaces;
using Domain.Entities.Models;

namespace de_todo_chill.Models;

/*Sugerencias*/
public class Suggestion : IEntity<int>, IDescription
{
    [Key] public int Id { set; get; }

    [Column]
    [StringLength(50)]
    public string Description { set; get; }

    public virtual User User { set; get; }

    public string GetDescription()
    {
        return Description;
    }

    public void GetDescription(string d)
    {
        Description = d;
    }

    public int GetId()
    {
        return Id;
    }

    public void SetId(int id)
    {
        Id = id;
    }
}