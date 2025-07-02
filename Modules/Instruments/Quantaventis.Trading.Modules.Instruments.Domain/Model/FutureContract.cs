using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class FutureContract
    {
        internal int Id { get; }
        internal String Symbol => Instrument.Symbol;
        internal Instrument Instrument { get; }
        internal int GenericFutureId { get; }
        internal FutureContractMonth FutureContractMonth { get; }  
        internal int Year { get; }

        internal DateOnly LastTradeDate { get; }

        internal DateOnly FirstNoticeDate { get; }

        public FutureContract(Instrument instrument,
            int genericFutureId,
            FutureContractMonth futureContractMonth, 
            int year, 
            DateOnly lastTradeDate, 
            DateOnly firstNoticeDate)
        {
            Id = instrument.Id;
            Instrument = instrument;
            GenericFutureId = genericFutureId;
            FutureContractMonth = futureContractMonth;
            Year = year;
            LastTradeDate = lastTradeDate;
            FirstNoticeDate = firstNoticeDate;
        }

        internal FutureContract WithId(int id) {
            return new FutureContract(Instrument.WithId(id), GenericFutureId, FutureContractMonth, Year, LastTradeDate, FirstNoticeDate);
        }
        internal FutureContract UpdateFieldsFrom(FutureContract futureContract)
        {
            return new FutureContract(Instrument.UpdateFieldsFrom(futureContract.Instrument), GenericFutureId, FutureContractMonth, Year, futureContract.LastTradeDate, futureContract.FirstNoticeDate );
        }

        internal bool HasSameFieldsThan(FutureContract futureContract)
        {
            return this.Instrument.HasSameFieldsThan(futureContract.Instrument)
                && LastTradeDate == futureContract.LastTradeDate
                && FirstNoticeDate == futureContract.FirstNoticeDate;
        }
    }
}
