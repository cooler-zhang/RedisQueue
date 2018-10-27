using RedisQueue.Core;
using System;

namespace RedisQueue.Pub
{
    class Program
    {
        static void Main(string[] args)
        {
            var redisContext = new RedisContext();
            Console.WriteLine("Publish Queue:");
            redisContext.Publish("channel1", new Foo { Id = 1, Name = "Hello" }).Wait();
            Console.ReadLine();
        }
    }
}
