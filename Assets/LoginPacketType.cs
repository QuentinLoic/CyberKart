using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// <summary>Sent from server to client.</summary>
    public enum LoginServerPacketsType
    {
        welcome = 1,
    }

    /// <summary>Sent from client to server.</summary>
    public enum LoginClientPacketsType
    {
        welcomeReceived = 1,
    }
