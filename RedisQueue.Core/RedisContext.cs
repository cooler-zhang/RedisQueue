using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace RedisQueue.Core
{
    public class RedisContext
    {
        private SocketManager _mgr;
        private ConnectionMultiplexer _connection;
        private IDatabase _db;

        public RedisContext()
        {
            var options = ConfigurationOptions.Parse("127.0.0.1:6379");
            _connection = ConnectionMultiplexer.Connect(options);
            _db = _connection.GetDatabase(3);
        }

        public async Task Publish(string channel, object t)
        {
            await _db.PublishAsync(channel, JsonConvert.SerializeObject(t), CommandFlags.None);
        }

        public async Task Subscribe(string channel, Action<RedisChannel, RedisValue> handler)
        {
            await _connection.GetSubscriber().SubscribeAsync(channel, handler);
        }
    }
}
