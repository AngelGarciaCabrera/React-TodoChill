namespace Domain.Entities.Interfaces;

/**Interface to handle Datetime data of an entity.*/
public interface IDated
{
    DateTime? GetDate();

    void SetDate(DateTime d);
}