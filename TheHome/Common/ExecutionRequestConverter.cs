using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using TheHome.Models;
using static TheHome.Common.Enums;

namespace TheHome.Common
{
    public class ExecutionRequestConverter : JsonObjectConverter<ExecutionRequest>
    {
        protected override ExecutionRequest Create(Type objectType, JObject jObject)
        {
            LifeCycleEnum lifeCycle = jObject.GetValue("lifecycle").ToObject<LifeCycleEnum>();
            switch (lifeCycle)
            {
                case Common.Enums.LifeCycleEnum.INSTALL:
                    return new InstallRequest();
                case Common.Enums.LifeCycleEnum.UPDATE:
                    throw new NotImplementedException("Update lifecycle");
                case Common.Enums.LifeCycleEnum.UNINSTALL:
                    throw new NotImplementedException("Uninstall lifecycle");
                case Common.Enums.LifeCycleEnum.EVENT:
                    throw new NotImplementedException("Event lifecycle");
                case Common.Enums.LifeCycleEnum.PING:
                    return new PingRequest();
                case Common.Enums.LifeCycleEnum.CONFIGURATION:
                    return new ConfigurationRequest();
                case Common.Enums.LifeCycleEnum.OAUTH_CALLBACK:
                    throw new NotImplementedException("OauthCallback lifecycle");
                default:
                    throw new NotImplementedException("Unknown value for LifeCycleEnum");
            }
        }
    }

    public abstract class JsonObjectConverter<T> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">
        /// contents of JSON object that will be deserialized
        /// </param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
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
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
