using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Model;

internal class Symbol
{
    private string Code { get; }
    internal Symbol(string code) { 
    this.Code = code;
    }

    internal string MarketSector => Code.Split(' ').Last();
    internal bool IsExchangeCodeEqual(string exchangeCode) => Code.Contains($" {exchangeCode} ");

    internal bool IsEquity => MarketSector.ToUpper().Equals("EQUITY");
    internal Symbol ReplaceExchangeCode(string composite, string exchangeCode)
    {
        return Code.Replace($" {composite} ", $" {exchangeCode} ");
    }

    public static implicit operator Symbol(string code) => new(code);

    public static implicit operator string(Symbol Symbol) => Symbol.Code;

    public bool Contains(string str) => Code.Contains(str);
    public Symbol Replace(string str1, string? str2) => Code.Replace(str1, str2);
    public override string? ToString()
     => Code;

    public override bool Equals(object? obj)
    {
        return obj is Symbol symbol &&
               Code == symbol.Code;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Code);
    }
}
