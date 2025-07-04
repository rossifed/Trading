using System;
using System.Text;
using System.Text.Json;

namespace Quantaventis.Trading.Shared.Infrastructure.Modules;

internal sealed class JsonModuleSerializer : IModuleSerializer
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals,
        PropertyNameCaseInsensitive = true,
        IncludeFields= true,
    };

    public byte[] Serialize<T>(T value)
        => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, SerializerOptions));

    public T Deserialize<T>(byte[] value)
        => JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(value), SerializerOptions);
        
    public object Deserialize(byte[] value, Type type)
        => JsonSerializer.Deserialize(Encoding.UTF8.GetString(value), type, SerializerOptions);
}
