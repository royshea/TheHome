using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using TheHome.RequestModels;
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
                    return new UpdateRequest();
                case Common.Enums.LifeCycleEnum.UNINSTALL:
                    return new UninstallRequest();
                case Common.Enums.LifeCycleEnum.EVENT:
                    return new EventRequest();
                case Common.Enums.LifeCycleEnum.PING:
                    return new PingRequest();
                case Common.Enums.LifeCycleEnum.CONFIGURATION:
                    return new ConfigurationRequest();
                case Common.Enums.LifeCycleEnum.OAUTH_CALLBACK:
                    return new OAuthCallbackRequest();
                default:
                    throw new NotImplementedException("Unknown value for LifeCycleEnum");
            }
        }
    }

    public class ConfigConverter : JsonObjectConverter<ConfigEntry>
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

    public class EventConverter : JsonObjectConverter<Event>
    {
        protected override Event Create(Type objectType, JObject jObject)
        {
            EventTypeEnum eventType = jObject.GetValue("eventType").ToObject<EventTypeEnum>();
            switch (eventType)
            {
                case EventTypeEnum.DEVICE_EVENT:
                    return new DeviceEvent();
                case EventTypeEnum.MODE_EVENT:
                    return new ModeEvent();
                case EventTypeEnum.TIMER_EVENT:
                    return new TimerEvent();
                case EventTypeEnum.DEVICE_COMMANDS_EVENT:
                    return new DeviceCommandsEvent();
                default:
                    throw new NotImplementedException("Unknown value for EventTypeEnum");
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
