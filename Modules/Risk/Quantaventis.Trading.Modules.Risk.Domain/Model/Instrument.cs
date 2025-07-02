using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model
{
    internal class Instrument
    {
        internal int Id { get; }
        //internal string Symbol { get; }
        //internal Currency Currency { get; }
        //internal Country Country { get; }
        //internal Sector Sector { get; }
        //internal Industry Industry { get; }
        //internal Region Region => Country.Region;
        //internal InstrumentType InstrumentType { get; }
        //   internal Instrument(int id,
        //string symbol,
        //InstrumentType InstrumentType,
        //Currency currency,
        //Country country,
        //Sector sector,
        //Industry industry)
        //   {
        //       this.Id = id;
        //       this.Symbol = symbol;
        //       this.InstrumentType = InstrumentType;
        //       this.Currency = currency;
        //       this.Country = country;
        //       this.Sector = sector;
        //       this.Industry = industry;
        //   }
        internal Instrument(int id)
        {
            this.Id = id;
          
        }
        public override bool Equals(object? obj)
         => obj is Instrument Instrument &&
                   Id == Instrument.Id;


        public override int GetHashCode()
         => HashCode.Combine(Id);


        public override string? ToString()
         => Id.ToString();
    }
}
