using System;
using UnityEngine;
using ProtocolMessage;
using System.Collections.Generic;
using Google.Protobuf;

namespace SFramework
{
    public class Dispatcher:Singleton<Dispatcher>
    {
        public delegate void ServiceFunction(ProtoMessage message);

        private Dictionary<int, ServiceFunction> services = new Dictionary<int, ServiceFunction>();

        public void Dispatch(ProtoMessage protocol)
        {
            try
            {
                if (protocol.ProtoId != 0)
                    services[protocol.ProtoId](protocol);
            }
            catch (Exception e)
            {
                Debug.LogError($"Wrong protocolID 0x{protocol.ProtoId:x8}, Error: {e}");
            }
        }

        public void Register(int protoId, ServiceFunction func)
        {
            if (services.ContainsKey(protoId))
                throw new Exception("Service Command Conflict");
            services[protoId] = func;
        }

        public void Unregister(int protoId)
        {
            if (services.ContainsKey(protoId))
                services.Remove(protoId);
        }

        public ProtoMessage Pack(int sid, int cid, IMessage msg)
        {
            ProtoMessage message = new ProtoMessage();
            message.ProtoId = (sid << 16) + cid;
            message.ProtoData = msg.ToByteString();
            return message;
        }
    }

}
