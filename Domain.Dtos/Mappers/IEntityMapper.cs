namespace de_todo_chill.Domain.us.Mappers;

public interface IEntityMapper<T, TD>
{
    T MapTo(TD e);
    TD MapFrom(T e);

    T MapToWithOut(TD td);
    TD MapFromWithOut(T t);
}