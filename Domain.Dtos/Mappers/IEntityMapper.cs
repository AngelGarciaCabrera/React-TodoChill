namespace de_todo_chill.Domain.us.Mappers;

public interface IEntityMapper<T, TD>
{
    T MapTo(TD e);
    TD MapFrom(T e);
}