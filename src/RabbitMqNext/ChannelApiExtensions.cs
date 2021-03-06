namespace RabbitMqNext
{
	using System;
	using System.Threading.Tasks;


	public static class ChannelApiExtensions
	{
		public static Task BasicPublish(this IChannel source, 
			string exchange, string routingKey, bool mandatory, 
			BasicProperties properties, byte[] buffer)
		{
			return source.BasicPublish(exchange, routingKey, mandatory, properties, new ArraySegment<byte>(buffer));
		}

		public static Task BasicPublish(this IChannel source,
			string exchange, string routingKey, 
			BasicProperties properties, byte[] buffer)
		{
			return source.BasicPublish(exchange, routingKey, mandatory: false, 
				properties: properties, buffer: new ArraySegment<byte>(buffer));
		}

		public static void BasicPublishFast(this IChannel source,
			string exchange, string routingKey, bool mandatory, 
			BasicProperties properties, byte[] buffer)
		{
			source.BasicPublishFast(exchange, routingKey, mandatory, properties, new ArraySegment<byte>(buffer));
		}

		public static void BasicPublishFast(this IChannel source,
			string exchange, string routingKey, 
			BasicProperties properties, byte[] buffer)
		{
			source.BasicPublishFast(exchange, routingKey, mandatory: false, 
				properties: properties, buffer: new ArraySegment<byte>(buffer));
		}
	}
}