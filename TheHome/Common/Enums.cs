using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
