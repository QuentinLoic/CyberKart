
using System.Collections.Generic;
    public abstract class BaseClient : IClient, IPacketHandler
{

        #region Properties
        public string ip;
        public int port;

        public int id;
        public TCP tcp;


        public delegate void PacketHandler(Packet _packet);
        public Dictionary<int, PacketHandler> packetHandlers;


        public Dictionary<int, PacketHandler> GetPacketHandlers()
        {
            return packetHandlers;
        }

        #endregion

        #region Methodes

        public TCP GetTCP()
        {
            return tcp;
        }

        public void ConnectToServer()
        {
            InitializeClientData();
            tcp.Connect(ip, port);
        }

        protected virtual void InitializeClientData()
        {

        }

        #endregion

    }