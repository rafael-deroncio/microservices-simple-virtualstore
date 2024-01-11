namespace VirtualStore.Discount.Core.Configurations.Mappers;

public interface IObjectConverter
{
    T Map<T>(object source);
    D Map<T, D>(T source, D destination);
}
