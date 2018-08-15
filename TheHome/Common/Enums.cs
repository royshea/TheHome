namespace TheHome.Common
{
    public class Enums
    {
        public enum LifeCycleEnum
        {
            INSTALL,
            UPDATE,
            UNINSTALL,
            EVENT,
            PING,
            CONFIGURATION,
            OAUTH_CALLBACK
        }

        public enum PhaseEnum
        {
            INITIALIZE,
            PAGE
        }

        public enum ValueTypeEnum
        {
            STRING,
            DEVICE,
            MODE
        }
    }
}
