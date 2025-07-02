namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal interface IFilterCriterion
    {
        bool Evaluate(Instrument instrument);
    }
}
