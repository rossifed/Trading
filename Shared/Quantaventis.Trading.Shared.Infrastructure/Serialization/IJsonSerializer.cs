using System;

namespace Quantaventis.Trading.Shared.Infrastructure.Serialization;

public interface IJsonSerializer
{
    string Serialize<T>(T value);
    T Deserialize<T>(string value);
    object Deserialize(string value, Type type);
}
