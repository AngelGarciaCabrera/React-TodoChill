using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using de_todo_chill.Interfaces;

namespace de_todo_chill.Models;

public class User : IEntity<int>, IDated, INamed, IEmail
{
    [Key] public int Id { get; set; }

    [Column] public string Name { set; get; }

    [Column] public DateTime Birthday { get; set; }

    public string Email { get; set; }

    public string Telephone { set; get; }

    public User()
    {
    }

    public int getId() => Id;

    public void setId(int id) => Id = id;

    public DateTime getDate() => Birthday;

    public void setDate(DateTime d) => Birthday = d;

    public string getName() => Name;

    public void setName(string name) => Name = name;

    public string getEmail() => Email;

    public void setEmail(string e) => Email = e;
}