using Newtonsoft.Json;
using RedisQueue.Core;
using StackExchange.Redis;
using System;

namespace RedisQueue.Sub1
{
    class Program
    {
        static void Main(string[] args)
        {
            var redisContext = new RedisContext();
            redisContext.Subscribe("channel1", (channel, value) =>
             {
                 Foo(value);
             }).Wait();
            Console.ReadLine();
        }

        public static void Foo(RedisValue result)
        {
            Console.WriteLine("Sub1:" + JsonConvert.SerializeObject(result, Formatting.Indented));
        }
    }
}
