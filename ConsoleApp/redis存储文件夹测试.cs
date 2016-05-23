//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ServiceStack.Redis;
//using ServiceStack.Redis.Generic;
//namespace ConsoleApp
//{
//    public class redis存储文件夹测试
//    {
//        public static void Main(string[] args)
//        {
//            //经测试redis中生成文件夹的机制，完全是根据key的组成而来的。有分号就会有单独的文件夹。          
//            using (var redis=new RedisClient("127.0.0.1",6379))
//            {
//                string key1 = "chefs:key:a:b:c:d"; 
//                string key2 = "users:key";
//                string key3 = "meals:key";
//                redis.Set<string>(key1+"_1","aaaaaaaaaaa");
//                redis.Set<string>(key1+"_2","dddddddddd");
//                redis.Set<string>(key1+"_3","xxxxxx");
//                redis.Set<string>(key1+":4","yyyyyyyyy");
//                redis.Set<string>(key2,"bbbbbbbbbbb");
//                redis.Set<string>(key3,"ccccccccccc");              
//            }
//        }
//    }
//}
