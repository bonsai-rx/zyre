﻿using System;
using System.Reactive.Linq;
using NetMQ;

namespace Bonsai.Zyre
{
    /// <summary>
    /// Represents an operator that packages a <see cref="NetMQMessage"/> as a Zyre shout message.
    /// </summary>
    public class ToZyreShout : Transform<Tuple<NetMQMessage, string>, ZyreMessage>
    {
        /// <summary>
        /// Transforms and observable sequence of messages and target groups to an observable sequence of Zyre shout messages.
        /// </summary>
        /// <param name="source">
        /// A union of <see cref="NetMQMessage"/> containing the message data and a <see cref="string"/> referencing the target group of the shout.
        /// </param>
        /// <returns>
        /// An observable sequence of <see cref="ZyreMessageShout"/>.
        /// </returns>
        public override IObservable<ZyreMessage> Process(IObservable<Tuple<NetMQMessage, string>> source)
        {
            return source.Select(x => new ZyreMessageShout { CommandType = ZyreCommandType.Shout, Group = x.Item2, Message = x.Item1 });
        }
    }
}
