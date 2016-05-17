using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using ServiceStack;
using ServiceStack.Text;
namespace ConsoleApp
{
    public class redis测试
    {
        static readonly RedisClient redis = new RedisClient("127.0.0.1",6379);
        public static void Main(string[] args)
        {
            redis.FlushAll();
            InsertTestData();
            //show_a_list_of_blogs();
            //show_rencent_posts_and_comments();
            //show_a_tag_cloud();
            //show_post_and_all_comments();
            add_comment_to_existing_post();
            Console.ReadKey();
        }
        public static void InsertTestData()
        {
            var redisUsers = redis.As<User>();
            var redisBlogs = redis.As<Blog>();
            var redisBlogPosts = redis.As<BlogPost>();

            var jason = new User {ID=redisUsers.GetNextSequence(),UserName="jason_shenwei" };
            var jane = new User {ID=redisUsers.GetNextSequence(),UserName="jane_zhangxiaomao" };

            var jasonBlog = new Blog {
                ID = redisBlogs.GetNextSequence(),
                UserID = jason.ID,
                UserName = jason.UserName,
                Tags = new List<string> {"Architecture",".Net","DataBases"}
            };

            var janeBlog = new Blog {
                ID=redisBlogs.GetNextSequence(),
                UserID=jane.ID,
                UserName=jane.UserName,
                Tags=new List<string> {"Architecture","Winform","DataBases"}
            };

            var blogPosts = new List<BlogPost> {
                new BlogPost {
                    ID=redisBlogPosts.GetNextSequence(),
                    BlogId=jasonBlog.ID,
                    Title="nosql",
                    Tags=new List<string> {"nosql","redis" },
                    Comments=new List<BlogPostComment> {
                        new BlogPostComment { Content="first comment!",CreatedDate=DateTime.Now}
                    }                  
                },
                  new BlogPost {
                    ID=redisBlogPosts.GetNextSequence(),
                    BlogId=jasonBlog.ID,
                    Title="redis learning",
                    Tags=new List<string> {"database","redis" },
                    Comments=new List<BlogPostComment> {
                        new BlogPostComment { Content="second comment!",CreatedDate=DateTime.Now}
                    }
                },
                    new BlogPost {
                    ID=redisBlogPosts.GetNextSequence(),
                    BlogId=janeBlog.ID,
                    Title="winform",
                    Tags=new List<string> {"winform" },
                    Comments=new List<BlogPostComment> {
                        new BlogPostComment { Content="first comment!",CreatedDate=DateTime.Now}
                    }
                },
                      new BlogPost {
                    ID=redisBlogPosts.GetNextSequence(),
                    BlogId=janeBlog.ID,
                    Title="wpf",
                    Tags=new List<string> {"wpf","windows" },
                    Comments=new List<BlogPostComment> {
                        new BlogPostComment { Content="second comment!",CreatedDate=DateTime.Now}
                    }
                }

            };

            //add references
            jason.BlogIds.Add(jasonBlog.ID);
            jasonBlog.BlogPostIds.AddRange(blogPosts.Where(x=>x.BlogId==jasonBlog.ID).Map(x=>x.ID));

            jane.BlogIds.Add(janeBlog.ID);
            janeBlog.BlogPostIds.AddRange(blogPosts.Where(x=>x.BlogId==janeBlog.ID).Map(x=>x.ID));

            redisUsers.Store(jane);
            redisUsers.Store(jason);

            redisBlogs.StoreAll(new[] {janeBlog,jasonBlog });
            redisBlogPosts.StoreAll(blogPosts);




        }

        public static void show_a_list_of_blogs()
        {
            var redisBlogs = redis.As<Blog>();
            var blogs = redisBlogs.GetAll();
            blogs.PrintDump();
        }

        public static void show_rencent_posts_and_comments()
        {
            var redisPosts = redis.As<BlogPost>();
            var redisComments = redis.As<BlogPostComment>();
            var incomingposts = redisPosts.GetAll();
            var recentPosts = redisPosts.Lists["urn:BlogPosts:Recent"];
            var recentComments = redisComments.Lists["urn:BlogComments:Recent"];
            foreach (var post in incomingposts)
            {
                recentPosts.Prepend(post);
                post.Comments.ForEach(recentComments.Prepend);
            }
            recentPosts.Trim(0,2);
            recentComments.Trim(0,2);
            recentPosts.GetAll().PrintDump();
            recentComments.GetAll().PrintDump();


        }

        public static void show_a_tag_cloud()
        {
            var redisBlogs = redis.As<Blog>();
            var blogs = redisBlogs.GetAll();
            foreach (var blog in blogs)
            {
                blog.Tags.ForEach(x=>redis.IncrementItemInSortedSet("urn:TagCloud",x,1));
            }
            //showtop 5 tags
            var TagClouds = redis.GetAllItemsFromSortedSetDesc("urn:TagCloud");
            TagClouds.PrintDump();
        }

        public static void show_post_and_all_comments()
        {
            var postid = 1;
            var redisblogposts = redis.As<BlogPost>();
            var selectedBlogPost = redisblogposts.GetById(postid);
            selectedBlogPost.PrintDump();

        }

        public static void add_comment_to_existing_post()
        {
            int postid = 1;
            var redisblogposts = redis.As<BlogPost>();
            var blogpost = redisblogposts.GetById(postid);
            blogpost.Comments.Add(new BlogPostComment { Content="nice you are hansome!",CreatedDate=DateTime.Now});
            redisblogposts.Store(blogpost);
            var refreshblogpost = redisblogposts.GetById(postid);
            refreshblogpost.PrintDump();
        }
        
    }

    public class User
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public List<long> BlogIds { get; set; }
        public User()
        {
            BlogIds = new List<long>();
        }
    }


    public class Blog
    {
        public Blog()
        {
            this.Tags = new List<string>();
            this.BlogPostIds = new List<long>();
        }
        public long ID { get; set; }
        public long UserID { get; set; }
        public string BlogName { get; set; }
        public string UserName { get; set; }
        public List<string> Tags { get; set; }
        public List<long> BlogPostIds { get; set; }

    }

    public class BlogPost
    {
        public BlogPost()
        {
        }
        public long ID { get; set; }
        public long BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public List<BlogPostComment> Comments { get; set; }
    }

    public class BlogPostComment
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }





}
