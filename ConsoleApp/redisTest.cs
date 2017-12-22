//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ServiceStack.Redis;
//using ServiceStack.Redis.Generic;
//namespace ConsoleApp
//{
//    class redisTest
//    {
//        public static void Main(string[] args)
//        {
//            using (IRedisClient client=new RedisClient("127.0.0.1",6379))
//            {
//                client.FlushAll();
//                ////string类型的操作
//                //client.Set<string>("name","shenwei");
//                //List<string> names = new List<string> {
//                //    "shenwei",
//                //    "zhangxiaomao",
//                //    "zhanglinyi"
//                //};
//                //client.Set<List<string>>("names",names);   //这种value 还是 string类型的 只不过string是个json串而已

//                ////hashtable
//                //client.SetEntryInHash("news_100","like","137");
//                //client.SetEntryInHash("news_100","dislike","4");


//                for (int i=0;i<=10;i++)
//                {
//                    client.EnqueueItemOnList("list2",i.ToString());
//                    //client.EnqueueItemOnList("list1", i.ToString());
//                }

//                for (int i=0;i<10;i++)
//                {
//                    Console.WriteLine(client.DequeueItemFromList("list2"));
//                    //Console.WriteLine(client.PopItemFromList("list1"));
//                }
          
               

//                Console.ReadKey();
//            }
//        }
//    }
//}
