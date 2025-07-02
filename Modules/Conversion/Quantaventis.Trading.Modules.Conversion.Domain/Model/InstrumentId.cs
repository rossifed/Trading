using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model;

internal class InstrumentId
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
