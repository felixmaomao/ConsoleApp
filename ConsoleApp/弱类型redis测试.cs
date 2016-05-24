//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ServiceStack.Redis;
//using ServiceStack.Redis.Generic;
//using ServiceStack.Text;
//namespace ConsoleApp
//{
//    public class 弱类型redis测试
//    {       
//        public static void Main(string[] args)
//        {
//            User user_shenwei = new User { ID=1,FirstName="shen",LastName="wei"};          
//            user_shenwei.CreateBlog(new Blog { ID=1,BlogName="CodesHome"});
//            user_shenwei.CreateBlog(new Blog { ID=2,BlogName="CodesGarden"});
           
//            User user_zhangxiaomao = new User { ID=2,FirstName="zhang",LastName="xiaomao"};
//            user_zhangxiaomao.WriteAPost(new Blog {ID=3,BlogName="CodesGallary" },new BlogPost {ID=1,Title="redis深度测试",Content="redis深度测试",Comments=new List<BlogComment> { } });

//            Repo<User> users = new Repo<User>();
//            users.add(user_shenwei);
//            users.add(user_zhangxiaomao);
                     
//            Console.ReadKey();
//        }
//    }

//    public interface IEntity
//    {
//        long ID { get; set; }
//    }
//    public class User:IEntity
//    {
//        public Repo<Blog> Blogs { get; set; }
//        public User()
//        {
//            this.BlogIds = new List<long>();
//            this.Blogs = new Repo<Blog>();
//        }
//        public long ID { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public List<long> BlogIds { get; set; }

//        public void CreateBlog(Blog blog)
//        {
//            Blogs.add(blog);
//            BlogIds.Add(blog.ID);
//        }
//        public void WriteAPost(Blog blog,BlogPost post)
//        {
//            blog.PostIds.Add(post.ID);
//            blog.Posts.add(post);
//        }

//    }

//    public class Blog:IEntity
//    {
//        public Repo<BlogPost> Posts { get; set; }
//        public Blog()
//        {
//            this.PostIds = new List<long>();
//            this.Posts = new Repo<BlogPost>();
//        }
//        public long ID { get; set; }
//        public string BlogName { get; set; }
//        public List<long> PostIds { get; set; }
//    }

//    public class BlogPost:IEntity
//    {
//        public BlogPost()
//        {
//            this.Comments = new List<BlogComment>();
//        }
//        public long ID { get; set; }
//        public string Title { get; set; }
//        public string Content { get; set; }
//        public List<BlogComment> Comments { get; set; }
//    }

//    public class BlogComment
//    {
//        public string Comment { get; set; }
//        public DateTime CommentDate { get; set; }
//    }

//    public interface IRepo<T>
//    {
//        IEnumerable<T> GetAll(string key_all);
//        void add(T entity);
//        void delete(long id);

//    }
//    public class Repo<T> : IRepo<T> where T:IEntity
//    {
//        public IRedisClient redis;
//        public Repo()
//        {
//            using (redis=new RedisClient("127.0.0.1",6379))
//            {

//            }
//        }

//        public const string UserKey = "users:";
//        public const string BlogKey = "blogs:";
//        public const string PostKey = "posts:";
//        public const string RecentPostsKey = "posts:recentPosts";
//        public const string TopTagsKey = "Tags:TopTags";

//        public void add(T entity)
//        {
//            switch (typeof(T).Name)
//            {
//                case "User":
//                    redis.Set<T>(UserKey+entity.ID,entity);
//                    break;
//                case "Blog":
//                    redis.Set<T>(BlogKey+entity.ID,entity);
//                    break;
//                case "BlogPost":
//                    redis.Set<T>(PostKey+entity.ID,entity);
//                    break;
                     
//            }
//        }

//        public void delete(long id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<T> GetAll(string key_all)
//        {
//            //有一种做法是 有一个专门的key_all来指向一个值， 这个值是所有东西拼成的json串，每添加一个东西的时候，不但要单独添加，然后还要手动拼接json串。。。
//            //为验证是否拼接成功，还要再json反序列化一次。。 这样真的好么。。。。。 想到一个好处，就是 前端取得时候取得就直接是json串了。
//            //实际上这边在项目里是采用list实现的。
//            //redisTypedClient强类型的好处可能在于可以对其进行linq操作，取得我们想要的值。（json虽然借助newtonsoft也可以，但应该没这么方便。这大概是使用强类型的好处。
//            //但是使用强类型的坏处。rediskey不怎么好直接指定啊。。）
            


                               
//            return redis.Get<List<T>>(key_all);    
//        }

     

//    }

//}
