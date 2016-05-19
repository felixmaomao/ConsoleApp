using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
namespace ConsoleApp
{
    public class RedisBestPractice
    {
        public static void Main(string[] args)
        {

        }
    }

    #region Blog Models
  
    public class User:IHasBlogRepository
    {
        public User()
        {
            this.BlogIds = new List<long>();           
        }
        public IBlogRepository Repo
        {
            get;
            set;
        }
        public long ID { get; set; }
        public string Name { get; set; }
        public List<long> BlogIds { get; set; }
        public List<Blog> GetBlogs()
        {
            return Repo.GetAllBlogs();
        }
        public Blog CreateNewBlog(Blog blog)
        {
            this.Repo.StoreBlogs(this,blog);
            return blog;
        }
        public BlogPost WriteBlogPost(Blog blog,BlogPost post)
        {
            this.Repo.StoreNewBlogPosts(blog,post);
            return post;
        }

    }
    public class Blog:IHasBlogRepository
    {
        public long ID { get; set; }
        public string BlogName { get; set; }
        public long UserID { get; set; }
        public string UserName { get; set;}
        public List<string> Tags { get; set; }
        public List<long> BlogPostIds { get; set; }
        public IBlogRepository Repo
        {
            get;
            set;
        }
        public List<BlogPost> GetBlogPosts()
        {
            return this.Repo.GetBlogPosts(this.BlogPostIds);
        }
        public void StoreNewBlogPosts(params BlogPost[] Posts)
        {
            this.Repo.StoreNewBlogPosts(this,Posts);
        }
    }
    public class BlogPost
    {
        public BlogPost()
        {
            this.categories = new List<string>();
            this.Tags = new List<string>();
            this.Comments = new List<BlogPostComment>();
        }
        public long Id { get; set; }
        public long BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> categories { get; set; }
        public List<string> Tags { get; set; }
        public List<BlogPostComment> Comments { get; set; }

    }
    public class BlogPostComment
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    #endregion

    #region Blog Repositories
    public interface IBlogRepository
    {
        void StoreUsers(params User[] Users);
        List<User> GetAllUsers();

        void StoreBlogs(User user,params Blog[] Blogs);
        List<Blog> GetBlogs(IEnumerable<long> Blogids);
        List<Blog> GetAllBlogs();

        List<BlogPost> GetBlogPosts(IEnumerable<long> blogPostsIds);
        void StoreNewBlogPosts(Blog blog,params BlogPost[] blogPosts);

        List<BlogPost> GetRecentBlogPosts();
        List<BlogPostComment> GetRecentBlogPostComments();
        IDictionary<string, double> GetTopTags(int take);
        HashSet<string> GetAllCategories();

        void StoreBlogPost(BlogPost blogPost);
        BlogPost GetBlogPost(params long[] postid);
        List<BlogPost> GetBlogPostByCategory(string CategoryName);

    }
    public interface IHasBlogRepository
    {
        IBlogRepository Repo { get; set; }
    }
    public class BlogRepository:IBlogRepository
    {
        private readonly IRedisClient redis;
        public BlogRepository(IRedisClient client)
        {
            this.redis = client;
        }
        public void StoreUsers(params User[] Users)
        {
            var redisUsers=redis.As<User>();
            foreach(var item in Users.Where(x=>x.ID==default(int)))
            {
                item.ID = redisUsers.GetNextSequence();
            }
            redisUsers.StoreAll(Users);           
        }

        public List<User> GetAllUsers()
        {
            var redisUsers=redis.As<User>();
            return redisUsers.GetAll().ToList();
        }

        public void StoreBlogs(User user,params Blog[] Blogs)
        {
            var redisBlogs=redis.As<Blog>();
            foreach(var blog in Blogs)
            {
                if(blog.ID==default(long))
                {
                    blog.ID = redisBlogs.GetNextSequence();
                }
                blog.UserID = user.ID;
                blog.UserName = user.Name;
                user.BlogIds.Add(blog.ID);
            }
            using(var trans=redis.CreateTransaction())
            {
                trans.QueueCommand(x=>x.Store(user));
                trans.QueueCommand(x=>x.StoreAll(Blogs));
                trans.Commit();
            }
        }

        public List<Blog> GetBlogs(IEnumerable<long> Blogids)
        {
            var redisBlogs=redis.As<Blog>();
            return redisBlogs.GetByIds(Blogids).ToList();
        }

        public List<Blog> GetAllBlogs()
        {
            var redisBlogs=redis.As<Blog>();
            return redisBlogs.GetAll().ToList();
        }

        public List<BlogPost> GetBlogPosts(IEnumerable<long> blogPostsIds)
        {
            throw new NotImplementedException();
        }

        public void StoreNewBlogPosts(Blog blog, params BlogPost[] blogPosts)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetRecentBlogPosts()
        {
            throw new NotImplementedException();
        }

        public List<BlogPostComment> GetRecentBlogPostComments()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, double> GetTopTags(int take)
        {
            throw new NotImplementedException();
        }

        public HashSet<string> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public void StoreBlogPost(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public BlogPost GetBlogPost(params long[] postid)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetBlogPostByCategory(string CategoryName)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
