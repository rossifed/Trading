using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Quantaventis.Trading.Shared.Infrastructure.Serialization;

public class SystemTextJsonSerializer : IJsonSerializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals,

        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = {new JsonStringEnumConverter()}
    };

    public string Serialize<T>(T value) => JsonSerializer.Serialize(value, Options);

    public T Deserialize<T>(string value) => JsonSerializer.Deserialize<T>(value, Options);

    public object Deserialize(string value, Type type) => JsonSerializer.Deserialize(value, type, Options);
}
