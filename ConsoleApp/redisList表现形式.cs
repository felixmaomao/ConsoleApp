using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using Newtonsoft.Json;
namespace ConsoleApp
{
    class redisList表现形式
    {
        public static void Main(string[] args)
        {
            IRedisClient redis = new RedisClient("127.0.0.1", 6379);
            string UserKey = "user:";
            string AllUsersKey = "all_users";
            User user = new User { ID = 1, Name = "shenwei" };
            User user2 = new User { ID = 2, Name = "zhangxiaomao" };
            redis.Set<User>(UserKey + user.ID, user);
            redis.Set<User>(UserKey + user2.ID, user2);

            //IRedisList<User> allusers=redis.As<User>().Lists[AllUsersKey];
            //allusers.Add(user);
            //allusers.Add(user2);

            //IRedisList allusers=redis.Lists[AllUsersKey];
            //allusers.Add(JsonConvert.SerializeObject(user));    //redis本身加进去的时候就自动序列化成json了。这里就是多此一举。
            //allusers.Add(JsonConvert.SerializeObject(user2));

            //这里list加的形式依旧是一个list表的形式。依旧不是大段的json串 。(清楚了，原来平成一大串json指的是.net自带的list集合。。吐血。)

            List<User> AllUsers = new List<User>();
            AllUsers.Add(user);
            AllUsers.Add(user2);
            redis.Set<List<User>>(AllUsersKey, AllUsers);

            Console.ReadKey();
        }
    }
    public class User
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }
}
