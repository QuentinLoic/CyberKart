

    public abstract class BaseClientSend
    {

        #region Properties
        protected IClient client;


        #endregion

        #region Methodes
        protected void SendTCPData(Packet _packet)
        {
            _packet.WriteLength();
            client.GetTCP().SendData(_packet);
        }

        #endregion

    }