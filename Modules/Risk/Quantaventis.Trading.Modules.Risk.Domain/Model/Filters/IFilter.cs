namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal interface IFilter<T>
    {
        T ApplyTo(T portfolio);
    }
}
