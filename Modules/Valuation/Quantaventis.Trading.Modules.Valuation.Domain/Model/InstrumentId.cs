namespace Quantaventis.Trading.Modules.Valuation.Domain.Model;

internal struct InstrumentId
{
    private int Id { get; }
    internal InstrumentId(int id) { 
    this.Id = id;
    }


    public static implicit operator InstrumentId(int id) => new(id);

    public static implicit operator int(InstrumentId instrumentId) => instrumentId.Id;



    public override string? ToString()
     => Id.ToString();

    public override bool Equals(object? obj)
    {
        return obj is InstrumentId id &&
               Id == id.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
