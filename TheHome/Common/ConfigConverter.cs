using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using TheHome.Models;
using static TheHome.Common.Enums;

namespace TheHome.Common
{
    public class ConfigConverter : JsonListObjectConverter<ConfigEntry>
    {
        protected override ConfigEntry Create(Type objectType, JObject jObject)
        {
            ValueTypeEnum valueType = jObject.GetValue("valueType").ToObject<ValueTypeEnum>();
            switch (valueType)
            {
                case ValueTypeEnum.STRING:
                    return new StringConfig();
                case ValueTypeEnum.DEVICE:
                    return new DeviceConfig();
                case ValueTypeEnum.MODE:
                    return new ModeConfig();
                default:
                    throw new NotImplementedException("Unknown value for ValueTypeEnum");
            }
        }
    }

    public abstract class JsonListObjectConverter<Config> : JsonConverter
    {
        /// <summary>
        /// Create an instance of Config
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">
        /// contents of JSON object that will be deserialized
        /// </param>
        /// <returns></returns>
        protected abstract Config Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(Config).IsAssignableFrom(objectType);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                        object existingValue,
                                        JsonSerializer serializer)
        {
            object target;
            if (reader.TokenType == JsonToken.StartObject)
            {
                // Load JObject from stream
                JObject jObject = JObject.Load(reader);
                // Create target object based on JObject
                target = Create(objectType, jObject);
                // Populate the object properties
                serializer.Populate(jObject.CreateReader(), target);
            }
            else if (reader.TokenType == JsonToken.String)
            {
                // Load list
                target = serializer.Deserialize(reader, typeof(string));
            }
            else
            {
                throw new NotImplementedException($"JsonListObjectConverter does not handle type {reader.TokenType} objects");
            }
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
