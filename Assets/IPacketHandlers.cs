
using System;
using System.Collections.Generic;
using static BaseClient;

public interface IPacketHandler
{
    Dictionary<int, PacketHandler> GetPacketHandlers();
}