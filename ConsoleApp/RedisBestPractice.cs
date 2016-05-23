//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ServiceStack.Redis;
//namespace ConsoleApp
//{
//    public class RedisBestPractice
//    {
//        public static void Main(string[] args)
//        {
//            IRedisClient redis = new RedisClient("127.0.0.1",6379);
//            redis.FlushAll();
//            IBlogRepository repo = new BlogRepository(redis);
//            InsertTestData(repo);
//            Console.ReadKey();
//        }
//        public static void InsertTestData(IBlogRepository repo)
//        {
//            var jason = new User {Name="shenwei"};
//            jason.Repo = repo;  //这边手动指定还是很坑爹的
//            var jane = new User {Name="zhangxiaomao" };
//            jane.Repo = repo;
//            repo.StoreUsers(jason,jane);
//            var jasonBlog=jason.CreateNewBlog(new Blog { BlogName="CodesHome"});
//            jasonBlog.Repo = repo;
//            var janeBlog=jane.CreateNewBlog(new Blog { BlogName="CodesGarden"});
//            janeBlog.Repo = repo;
//            jasonBlog.StoreNewBlogPosts(
//                 new BlogPost {
//                     Title = "Redis with C#",
//                     categories = new List<string> { "article", "nosql" },
//                     Tags = new List<string> { "redis", "nosql" },
//                     Comments = new List<BlogPostComment> {
//                         new BlogPostComment { Content="Nice post",CreatedDate=DateTime.Now}
//                     }                                         
//                 },
//                 new BlogPost {
//                     Title = "Redis with MemoryCache",
//                     categories = new List<string> { "article", "nosql" },
//                     Tags = new List<string> { "redis", "mvc","cache" },
//                     Comments = new List<BlogPostComment> {
//                         new BlogPostComment { Content="very good post for cache",CreatedDate=DateTime.Now}
//                     }
//                 }
//                );
//            //another blog
//            janeBlog.StoreNewBlogPosts(
//                 new BlogPost
//                 {
//                     Title = "WPF demo",
//                     categories = new List<string> { "wpf", "windows" },
//                     Tags = new List<string> { "winform", "wpf" },
//                     Comments = new List<BlogPostComment> {
//                         new BlogPostComment { Content="Nice post about wpf",CreatedDate=DateTime.Now}
//                     }
//                 },
//                 new BlogPost
//                 {
//                     Title = "ORM",
//                     categories = new List<string> { "DataBase", "ORM" },
//                     Tags = new List<string> { "DataBase", "OrmLite" },
//                     Comments = new List<BlogPostComment> {
//                         new BlogPostComment { Content="very good post for building own orm",CreatedDate=DateTime.Now}
//                     }
//                 }
//                );




//        }


//    }

//    #region Blog Models
  
//    public class User:IHasBlogRepository
//    {
//        public User()
//        {
//            this.BlogIds = new List<long>();           
//        }
//        public IBlogRepository Repo
//        {
//            get;
//            set;
//        }
//        public long ID { get; set; }
//        public string Name { get; set; }
//        public List<long> BlogIds { get; set; }
//        public List<Blog> GetBlogs()
//        {
//            return Repo.GetAllBlogs();
//        }
//        public Blog CreateNewBlog(Blog blog)
//        {
//            this.Repo.StoreBlogs(this,blog);
//            return blog;
//        }
//        public BlogPost WriteBlogPost(Blog blog,BlogPost post)
//        {
//            this.Repo.StoreNewBlogPosts(blog,post);
//            return post;
//        }

//    }
//    public class Blog:IHasBlogRepository
//    {
//        public Blog()
//        {
//            this.Tags = new List<string>();
//            this.BlogPostIds = new List<long>();
//        }
//        public long ID { get; set; }
//        public string BlogName { get; set; }
//        public long UserID { get; set; }
//        public string UserName { get; set;}
//        public List<string> Tags { get; set; }
//        public List<long> BlogPostIds { get; set; }
//        public IBlogRepository Repo
//        {
//            get;
//            set;
//        }
//        public List<BlogPost> GetBlogPosts()
//        {
//            return this.Repo.GetBlogPosts(this.BlogPostIds);
//        }
//        public void StoreNewBlogPosts(params BlogPost[] Posts)
//        {
//            this.Repo.StoreNewBlogPosts(this,Posts);
//        }
//    }
//    public class BlogPost
//    {
//        public BlogPost()
//        {
//            this.categories = new List<string>();
//            this.Tags = new List<string>();
//            this.Comments = new List<BlogPostComment>();
//        }
//        public long Id { get; set; }
//        public long BlogId { get; set; }
//        public string Title { get; set; }
//        public string Content { get; set; }
//        public List<string> categories { get; set; }
//        public List<string> Tags { get; set; }
//        public List<BlogPostComment> Comments { get; set; }

//    }
//    public class BlogPostComment
//    {
//        public string Content { get; set; }
//        public DateTime CreatedDate { get; set; }
//    }
//    #endregion

//    #region Blog Repositories
//    public interface IBlogRepository
//    {
//        void StoreUsers(params User[] Users);
//        List<User> GetAllUsers();

//        void StoreBlogs(User user,params Blog[] Blogs);
//        List<Blog> GetBlogs(IEnumerable<long> Blogids);
//        List<Blog> GetAllBlogs();

//        List<BlogPost> GetBlogPosts(IEnumerable<long> blogPostsIds);
//        void StoreNewBlogPosts(Blog blog,params BlogPost[] blogPosts);

//        List<BlogPost> GetRecentBlogPosts();
//        List<BlogPostComment> GetRecentBlogPostComments();
//        IDictionary<string, double> GetTopTags(int take);
//        HashSet<string> GetAllCategories();

//        void StoreBlogPost(BlogPost blogPost);
//        BlogPost GetBlogPost(params long[] postid);
//        List<BlogPost> GetBlogPostByCategory(string CategoryName);

//    }
//    public interface IHasBlogRepository
//    {
//        IBlogRepository Repo { get; set; }
//    }
//    public class BlogRepository:IBlogRepository
//    {
//        private readonly IRedisClient redis;
//        const string RecentBlogPostKey = "urn:BlogPosts:RecentPosts";
//        const string RecentBlogPostCommentsKey = "urn:BlogPostComments:RecentComments";
//        const string TagsCloudKey = "urn:TagsCloud";
//        const string AllCategoryKey = "urn:AllCategories";

//        public BlogRepository(IRedisClient client)
//        {
//            this.redis = client;
//        }
//        public void StoreUsers(params User[] Users)
//        {
//            var redisUsers=redis.As<User>();
//            foreach(var item in Users.Where(x=>x.ID==default(int)))
//            {
//                item.ID = redisUsers.GetNextSequence();
//            }
//            redisUsers.StoreAll(Users);           
//        }

//        public List<User> GetAllUsers()
//        {
//            var redisUsers=redis.As<User>();
//            return redisUsers.GetAll().ToList();
//        }

//        public void StoreBlogs(User user,params Blog[] Blogs)
//        {
//            var redisBlogs=redis.As<Blog>();
//            foreach(var blog in Blogs)
//            {
//                if(blog.ID==default(long))
//                {
//                    blog.ID = redisBlogs.GetNextSequence();
//                }
//                blog.UserID = user.ID;
//                blog.UserName = user.Name;
//                user.BlogIds.Add(blog.ID);
//            }
//            using(var trans=redis.CreateTransaction())
//            {
//                trans.QueueCommand(x=>x.Store(user));
//                trans.QueueCommand(x=>x.StoreAll(Blogs));
//                trans.Commit();
//            }
//        }

//        public List<Blog> GetBlogs(IEnumerable<long> Blogids)
//        {
//            var redisBlogs=redis.As<Blog>();
//            return redisBlogs.GetByIds(Blogids).ToList();
//        }

//        public List<Blog> GetAllBlogs()
//        {
//            var redisBlogs=redis.As<Blog>();
//            return redisBlogs.GetAll().ToList();
//        }

//        public List<BlogPost> GetBlogPosts(IEnumerable<long> blogPostsIds)
//        {
//            var redisBlogPosts = redis.As<BlogPost>();
//            return redisBlogPosts.GetByIds(blogPostsIds).ToList();
//        }

//        public void StoreNewBlogPosts(Blog blog, params BlogPost[] blogPosts)
//        {
          
//            var redisBlogPosts = redis.As<BlogPost>();
//            var redisBlogComments = redis.As<BlogPostComment>();

//            var recentPosts = redisBlogPosts.Lists[RecentBlogPostKey];
//            var recentComments = redisBlogComments.Lists[RecentBlogPostCommentsKey];
//            foreach (var post in blogPosts)
//            {
//                if (post.Id==default(long))
//                {
//                    post.Id = redisBlogPosts.GetNextSequence();                   
//                }
//                post.BlogId = blog.ID;
//                blog.BlogPostIds.Add(post.Id);
//                //do more things
//                //add tag to cloud
//                post.Tags.ForEach(x=>redis.IncrementItemInSortedSet(TagsCloudKey,x,1));
//                //add recentPosts
//                recentPosts.Prepend(post);
//                //add recentComments
//                post.Comments.ForEach(recentComments.Prepend);
//                //add categories
//                post.categories.ForEach(x=>redis.AddItemToSet(AllCategoryKey,x));
//            }
//            //取前5作为最近
//            recentPosts.Trim(0,4);
//            recentComments.Trim(0,4);
//            using (var trans=redis.CreateTransaction())
//            {
//                trans.QueueCommand(x=>x.Store(blog));
//                trans.QueueCommand(x=>x.StoreAll(blogPosts));
//                trans.Commit();
//            }
//        }

//        public List<BlogPost> GetRecentBlogPosts()
//        {
//            var redisBlogPosts = redis.As<BlogPost>();
//            return redisBlogPosts.Lists[RecentBlogPostKey].GetAll();
//        }

//        public List<BlogPostComment> GetRecentBlogPostComments()
//        {
//            var redisBlogPostComments = redis.As<BlogPostComment>();
//            return redisBlogPostComments.Lists[RecentBlogPostCommentsKey].GetAll();
//        }

//        public IDictionary<string, double> GetTopTags(int take)
//        {
//            //excellent
//            return redis.GetRangeWithScoresFromSortedSetDesc(TagsCloudKey,0,take-1);
//        }

//        public HashSet<string> GetAllCategories()
//        {
//            return redis.GetAllItemsFromSet(AllCategoryKey);
//        }

//        public void StoreBlogPost(BlogPost blogPost)
//        {
            
//        }

//        public BlogPost GetBlogPost(params long[] postid)
//        {
//            throw new NotImplementedException();
//        }

//        public List<BlogPost> GetBlogPostByCategory(string CategoryName)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    #endregion
//}
