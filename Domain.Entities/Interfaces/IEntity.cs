namespace Domain.Entities.Interfaces;

public interface IEntity<ID>
{
    ID GetId();

    void SetId(ID id);
}