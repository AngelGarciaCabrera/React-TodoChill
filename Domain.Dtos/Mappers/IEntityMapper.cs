namespace de_todo_chill.Domain.us.Mappers;

public interface IEntityMapper<T, TD>
{
    /**If the entity is null, return a new one with empty default values.*/
    T MapTo(TD? e);
    
    /**If the entity is null, return a new one with empty default values.*/
    TD MapFrom(T? e);

    /**If the entity is null, return a new one with empty default values.*/
    T MapToWithOut(TD? td);
    
    /**If the entity is null, return a new one with empty default values.*/
    TD MapFromWithOut(T? t);
}