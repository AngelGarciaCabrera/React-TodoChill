namespace de_todo_chill.Interfaces;

/**Interface to handle Datetime data of an entity.*/
public interface IDated
{
    DateTime getDate();

    void setDate(DateTime d);
}