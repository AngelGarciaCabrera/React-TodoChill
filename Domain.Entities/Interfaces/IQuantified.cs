namespace Domain.Entities.Interfaces;

public interface IQuantified
{
    int GetQuantity();
    void GetQuantity(int v);
}