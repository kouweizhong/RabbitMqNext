﻿namespace RabbitMqNext
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IAmqpChannel
	{
		int ChannelNumber { get; }

		/// <summary>
		/// This method requests a specific quality of service. The QoS can be specified for the
		/// current channel or for all channels on the connection. The particular properties and
		/// semantics of a qos method always depend on the content class semantics. Though the
		/// qos method could in principle apply to both peers, it is currently meaningful only
		/// for the server.
		/// </summary>
		/// <param name="prefetchSize">The client can request that messages be sent in advance so that when the client
		/// finishes processing a message, the following message is already held locally,
		/// rather than needing to be sent down the channel. Prefetching gives a performance
		/// improvement. This field specifies the prefetch window size in octets. The server
		/// will send a message in advance if it is equal to or smaller in size than the
		/// available prefetch size (and also falls into other prefetch limits). May be set
		/// to zero, meaning "no specific limit", although other prefetch limits may still
		/// apply. The prefetch-size is ignored if the no-ack option is set.</param>
		/// <param name="prefetchCount">Specifies a prefetch window in terms of whole messages. This field may be used
		/// in combination with the prefetch-size field; a message will only be sent in
		/// advance if both prefetch windows (and those at the channel and connection level)
		/// allow it. The prefetch-count is ignored if the no-ack option is set.</param>
		/// <param name="global">By default the QoS settings apply to the current channel only. 
		/// If this field is set, they are applied to the entire connection.</param>
		/// <returns></returns>
		Task BasicQos(uint prefetchSize, ushort prefetchCount, bool global);

		Task ExchangeDeclare(string exchange, string type, bool durable, bool autoDelete,
			IDictionary<string, object> arguments, bool waitConfirmation);

		Task<AmqpQueueInfo> QueueDeclare(string queue, bool passive, bool durable, bool exclusive,
			bool autoDelete, IDictionary<string, object> arguments, bool waitConfirmation);

		Task QueueBind(string queue, string exchange, string routingKey, IDictionary<string, object> arguments, bool waitConfirmation);

		Task BasicAck(ulong deliveryTag, bool multiple);

		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Dont reuse the buffer until this method returns!
		/// </remarks>
		/// <param name="exchange"></param>
		/// <param name="routingKey"></param>
		/// <param name="mandatory"></param>
		/// <param name="immediate"></param>
		/// <param name="properties"></param>
		/// <param name="buffer"></param>
		/// <returns></returns>
		Task BasicPublish(string exchange, string routingKey, bool mandatory, bool immediate,
			BasicProperties properties, ArraySegment<byte> buffer);
	}
}