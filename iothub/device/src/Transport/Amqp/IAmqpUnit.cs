﻿using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Devices.Client.Transport.Amqp
{
    internal interface IAmqpUnit : IDisposable, ILinkFactory
    {
        #region EventHandler
        event EventHandler OnUnitDisconnected;
        void OnConnectionDisconnected();
        #endregion

        #region Usability
        bool IsUsable();
        #endregion

        #region Open-Close
        Task OpenAsync(TimeSpan timeout);
        Task CloseAsync(TimeSpan timeout);
        #endregion

        #region Message
        Task<Outcome> SendMessageAsync(AmqpMessage message, TimeSpan timeout);
        Task<Message> ReceiveMessageAsync(TimeSpan timeout);
        Task<Outcome> DisposeMessageAsync(string lockToken, Outcome outcome, TimeSpan timeout);
        #endregion

        #region Event
        Task EnableEventReceiveAsync(TimeSpan timeout);

        Task<Outcome> SendEventAsync(AmqpMessage message, TimeSpan timeout);
        #endregion

        #region Method
        Task EnableMethodsAsync(TimeSpan timeout);
        Task DisableMethodsAsync(TimeSpan timeout);
        Task<Outcome> SendMethodResponseAsync(AmqpMessage message, TimeSpan timeout);
        #endregion

        #region Twin
        Task EnableTwinPatchAsync(TimeSpan timeout);
        Task DisableTwinAsync(TimeSpan timeout);
        Task<Outcome> SendTwinMessageAsync(AmqpMessage message, TimeSpan timeout);
        #endregion
    }
}
