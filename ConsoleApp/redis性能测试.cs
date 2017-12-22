//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ServiceStack.Redis;
//namespace ConsoleApp
//{
//    class redis性能测试
//    {
//        //test aborted
//        public static void Main(string[] args)
//        {
//            PooledRedisClientManager clientmanager = new PooledRedisClientManager();

//            using (IRedisClient client=new RedisClient("127.0.0.1",6379))
//            {
         
//                int flag = 1;
//                for (int i=0;i<5000;i++)
//                {
//                    client.Set("name_"+i,"shenwei_"+i);
//                }
//                //Parallel.For(1,10,x=> { client.Set("name_"+x,"shenwei_"+x); });
//                flag = 2;
//            }
//            Console.ReadKey();
//        }
       
//    }
//}
