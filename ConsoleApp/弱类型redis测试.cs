using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
namespace ConsoleApp
{
    public class 弱类型redis测试
    {       
        public static void Main(string[] args)
        {
            User user_shenwei = new User { ID=1,FirstName="shen",LastName="wei"};          
            user_shenwei.CreateBlog(new Blog { ID=1,BlogName="CodesHome"});
            user_shenwei.CreateBlog(new Blog { ID=2,BlogName="CodesGarden"});
           

            User user_zhangxiaomao = new User { ID=2,FirstName="zhang",LastName="xiaomao"};
            user_zhangxiaomao.WriteAPost(new Blog {ID=3,BlogName="CodesGallary" },new BlogPost {ID=1,Title="redis深度测试",Content="redis深度测试",Comments=new List<BlogComment> { } });

            Repo<User> users = new Repo<User>();
            users.add(user_shenwei);
            users.add(user_zhangxiaomao);
            Console.ReadKey();
        }
    }

    public interface IEntity
    {
        long ID { get; set; }
    }
    public class User:IEntity
    {
        public Repo<Blog> Blogs { get; set; }
        public User()
        {
            this.BlogIds = new List<long>();
            this.Blogs = new Repo<Blog>();
        }
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<long> BlogIds { get; set; }

        public void CreateBlog(Blog blog)
        {
            Blogs.add(blog);
            BlogIds.Add(blog.ID);
        }
        public void WriteAPost(Blog blog,BlogPost post)
        {
            blog.PostIds.Add(post.ID);
            blog.Posts.add(post);
        }

    }

    public class Blog:IEntity
    {
        public Repo<BlogPost> Posts { get; set; }
        public Blog()
        {
            this.PostIds = new List<long>();
            this.Posts = new Repo<BlogPost>();
        }
        public long ID { get; set; }
        public string BlogName { get; set; }
        public List<long> PostIds { get; set; }
    }

    public class BlogPost:IEntity
    {
        public BlogPost()
        {
            this.Comments = new List<BlogComment>();
        }
        public long ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<BlogComment> Comments { get; set; }
    }

    public class BlogComment
    {
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
    }

    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        void add(T entity);
        void delete(long id);

    }
    public class Repo<T> : IRepo<T> where T:IEntity
    {
        public IRedisClient redis;
        public Repo()
        {
            using (redis=new RedisClient("127.0.0.1",6379))
            {

            }
        }

        public const string UserKey = "users:";
        public const string BlogKey = "blogs:";
        public const string PostKey = "posts:";
        public const string RecentPostsKey = "posts:recentPosts";
        public const string TopTagsKey = "Tags:TopTags";

        public void add(T entity)
        {
            switch (typeof(T).Name)
            {
                case "User":
                    redis.Set<T>(UserKey+entity.ID,entity);
                    break;
                case "Blog":
                    redis.Set<T>(BlogKey+entity.ID,entity);
                    break;
                case "BlogPost":
                    redis.Set<T>(PostKey+entity.ID,entity);
                    break;
                     
            }
        }

        public void delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return null;  //这边咋搞？
        }
    }


}
