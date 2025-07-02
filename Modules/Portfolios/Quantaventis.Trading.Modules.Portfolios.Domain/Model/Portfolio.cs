using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Portfolios.Domain.Model
{
    internal class Portfolio
    {
        internal byte Id { get; }
        internal string Name { get; }
        internal string Mnemonic { get; }
        internal Currency Curreny { get; }
        internal IEnumerable<Position> Positions { get; }
        internal delegate void PositionUpdatedHandler(Portfolio portfolio, Position currentPosition, Position newPosition);
        internal delegate void PositionOpenedHandler(Portfolio portfolio, Position position);
        internal delegate void PositionClosedHandler(Portfolio portfolio, Position position);
        internal event PositionOpenedHandler PositionOpened;
        internal event PositionUpdatedHandler PositionUpdated;
        internal event PositionClosedHandler PositionClosed;
        internal Portfolio(byte id, string name, string mnemonic, Currency currency, IEnumerable<Position> positions)
        {
            this.Id = id;
            this.Name = name;
            this.Mnemonic = mnemonic;
            this.Curreny = currency;
            this.Positions = positions;
        }

     
        internal Portfolio Update(TradeAllocation trade)
        {
            var instrument = trade.Instrument;
            IDictionary<Instrument, Position> positionByInstrument = Positions.ToDictionary(x => x.Instrument);
            if (positionByInstrument.ContainsKey(instrument))
            {
                var currentPosition = positionByInstrument[instrument];
                var updatedPosition = currentPosition.Update(trade);
                positionByInstrument[instrument] = updatedPosition;
                if(updatedPosition.Quantity == 0)
                    PositionClosed?.Invoke(this, updatedPosition);
                else
                PositionUpdated?.Invoke(this, currentPosition, updatedPosition);
            }
            else {
               var createdPosition = Position.FromTrade(trade);
                positionByInstrument.Add(instrument, createdPosition);
                PositionOpened?.Invoke(this, createdPosition);
            }
     
            return new Portfolio(Id, Name, Mnemonic, Curreny, positionByInstrument.Values);
        }
    }
}
