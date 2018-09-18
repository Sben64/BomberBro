using System;
using System.Collections.Generic;
using System.Text;

namespace Bindings
{
    public enum ServerPackets
    {
        SLogin = 1,
        SReceiveMessage = 2,
        SFullServer = 3,
    }

    public enum ClientPackets
    {
        CLogin = 1,
        CSendMessages = 2,
        CFullServer = 3,
    }
}
