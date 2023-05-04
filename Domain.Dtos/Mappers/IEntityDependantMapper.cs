namespace de_todo_chill.Domain.us.Mappers;

/*Class handle map between contains more inner related classes.*/
public interface IEntityDependantMapper<T, TD> : IEntityMapper<T, TD>
{

    /**If the entity is null, return a new one with empty default values.*/
    T MapToWithOut(TD? td);
    
    /**If the entity is null, return a new one with empty default values.*/
    TD MapFromWithOut(T? t);
}