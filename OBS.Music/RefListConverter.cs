using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music;

public class RefListConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(ICollection).IsAssignableFrom(objectType)
            && objectType.IsGenericType
            && objectType
                .GetGenericArguments()[0]
                .GetProperties()
                .Any(p => p.GetCustomAttributes<KeyAttribute>().Any());
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        return serializer.Deserialize(reader, objectType);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var collectionType = value?.GetType() ?? typeof(object);

        if (value is not ICollection collection
            || !collectionType.IsGenericType)
        {
            serializer.Serialize(writer, value);
            return;
        }

        var genericArguments = collectionType.GetGenericArguments()!;

        if (genericArguments.Length < 1)
        {
            serializer.Serialize(writer, value);
            return;
        }

        var itemType = genericArguments[0];

        PropertyInfo[] keys
                    = itemType
                    .GetProperties()
                    .Select(p => new { Property = p, Attribute = p.GetCustomAttribute<KeyAttribute>() })
                    .Where(p => p.Attribute != null)
                    .Select(p => p.Property)
                    .ToArray();

        var array = new JArray();

        foreach (var item in collection)
        {
            var jObject = new JObject();

            foreach (var key in keys)
            {
                var keyValue = key.GetValue(item);

                var tokenValue = keyValue is not null ? JToken.FromObject(keyValue) : null;

                jObject.Add(key.Name, tokenValue);
            }

            array.Add(jObject);
        }

        array.WriteTo(writer);
    }
}
