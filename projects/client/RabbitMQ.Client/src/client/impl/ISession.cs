// This source code is dual-licensed under the Apache License, version
// 2.0, and the Mozilla Public License, version 1.1.
//
// The APL v2.0:
//
//---------------------------------------------------------------------------
//   Copyright (c) 2007-2020 VMware, Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       https://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//---------------------------------------------------------------------------
//
// The MPL v1.1:
//
//---------------------------------------------------------------------------
//  The contents of this file are subject to the Mozilla Public License
//  Version 1.1 (the "License"); you may not use this file except in
//  compliance with the License. You may obtain a copy of the License
//  at https://www.mozilla.org/MPL/
//
//  Software distributed under the License is distributed on an "AS IS"
//  basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See
//  the License for the specific language governing rights and
//  limitations under the License.
//
//  The Original Code is RabbitMQ.
//
//  The Initial Developer of the Original Code is Pivotal Software, Inc.
//  Copyright (c) 2007-2020 VMware, Inc.  All rights reserved.
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace RabbitMQ.Client.Impl
{
    public interface ISession
    {
        /// <summary>
        /// Gets the channel number.
        /// </summary>
        int ChannelNumber { get; }

        /// <summary>
        /// Gets the close reason.
        /// </summary>
        ShutdownEventArgs CloseReason { get; }

        ///<summary>
        /// Single recipient - no need for multiple handlers to be informed of arriving commands.
        ///</summary>
        Action<ISession, Command> CommandReceived { get; set; }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        IConnection Connection { get; }

        /// <summary>
        /// Gets a value indicating whether this session is open.
        /// </summary>
        bool IsOpen { get; }

        ///<summary>
        /// Multicast session shutdown event.
        ///</summary>
        event EventHandler<ShutdownEventArgs> SessionShutdown;

        void Close(ShutdownEventArgs reason);
        void Close(ShutdownEventArgs reason, bool notify);
        void HandleFrame(InboundFrame frame);
        void Notify();
        void Transmit(Command cmd);
        void Transmit(IList<Command> cmd);
    }
}
