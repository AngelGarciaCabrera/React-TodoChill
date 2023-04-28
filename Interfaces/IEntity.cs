namespace de_todo_chill.Interfaces;

public interface IEntity<ID>
{
    ID getId();

    void setId(ID id);
}