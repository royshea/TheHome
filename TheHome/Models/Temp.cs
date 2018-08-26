using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHome.Models
{



    public enum TimerTypeEnum
    {
        CRON,
        ONCE
    }

    public enum EventTypeEnum
    {
        DEVICE_EVENT,
        MODE_EVENT,
        TIMER_EVENT,
        DEVICE_COMMANDS_EVENT
    }

    public class Temp
    {
        public EventData EventData { get; set; }

        public UpdateData UpdateData { get; set; }

        public UninstallData UninstallData { get; set; }

        public ConfigurationData ConfigurationData { get; set; }

        public OauthCallbackData OauthCallbackData { get; set; }

        public Settings Settings { get; set; }
    }

    public class Settings
    {
    }

    public class OauthCallbackData
    {
    }

    public class UninstallData
    {
    }

    public class UpdateData
    {
    }

    public class EventData
    {
        public string AuthToken { get; set; }

        public InstalledApp InstalledApp { get; set; }

        public List<Event> Events { get; set; }
    }



    public class Event
    {
        public EventTypeEnum EventType { get; set; }

        public DeviceEvent DeviceEvent { get; set; }

        public ModeEvent ModeEvent { get; set; }

        public TimerEvent TimerEvent { get; set; }

        public DeviceCommandsEvent DeviceCommandsEvent { get; set; }
    }

    public class DeviceCommandsEvent
    {
        public string DeviceId { get; set; }

        public string ProfileId { get; set; }

        public string ExternalId { get; set; }

        public List<DeviceCommandsEventCommand> Commands { get; set; }
    }

    public class DeviceCommandsEventCommand
    {
        public string ComponentId { get; set; }

        public string Capability { get; set; }

        public string Command { get; set; }

        public List<object> Arguments { get; set; }
    }

    public class TimerEvent
    {
        public string EventId { get; set; }

        public string Name { get; set; }

        public TimerTypeEnum TimerType { get; set; }

        public DateTime Time { get; set; }

        public string Expression { get; set; }
    }

    public class ModeEvent
    {
        public string ModeId { get; set; }
    }

    public class DeviceEvent
    {
        public string SubscriptionName { get; set; }

        public string EventId { get; set; }

        public string LocationId { get; set; }

        public string DeviceId { get; set; }

        public string ComponentId { get; set; }

        public string Capability { get; set; }

        public string Attribute { get; set; }

        public object Value { get; set; }

        public bool StateChange { get; set; }
    }
}
