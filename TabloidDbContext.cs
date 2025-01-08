using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tabloid.Models;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Data;
public class TabloidDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostReaction> PostReactions { get; set; }
    public DbSet<PostSubscription> PostSubscriptions { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<Tag> Tags { get; set; }
     public DbSet<Comment> Comments { get; set; }
    


    public TabloidDbContext(DbContextOptions<TabloidDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Administrator",
                Email = "admina@strator.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                UserName = "JohnDoe",
                Email = "john@doe.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                UserName = "JaneSmith",
                Email = "jane@smith.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                UserName = "AliceJohnson",
                Email = "alice@johnson.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                UserName = "BobWilliams",
                Email = "bob@williams.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                UserName = "EveDavis",
                Email = "Eve@Davis.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },

        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
        {
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
            },

        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Admina",
                LastName = "Strator",
                ImageLocation = "https://robohash.org/numquamutut.png?size=150x150&set=set1",
                CreateDateTime = new DateTime(2022, 1, 25)
            },
             new UserProfile
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                CreateDateTime = new DateTime(2023, 2, 2),
                ImageLocation = "https://robohash.org/nisiautemet.png?size=150x150&set=set1",
                IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
            },
            new UserProfile
            {
                Id = 3,
                FirstName = "Jane",
                LastName = "Smith",
                CreateDateTime = new DateTime(2022, 3, 15),
                ImageLocation = "https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1",
                IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
            },
            new UserProfile
            {
                Id = 4,
                FirstName = "Alice",
                LastName = "Johnson",
                CreateDateTime = new DateTime(2023, 6, 10),
                ImageLocation = "https://robohash.org/deseruntutipsum.png?size=150x150&set=set1",
                IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
            },
            new UserProfile
            {
                Id = 5,
                FirstName = "Bob",
                LastName = "Williams",
                CreateDateTime = new DateTime(2023, 5, 15),
                ImageLocation = "https://robohash.org/quiundedignissimos.png?size=150x150&set=set1",
                IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
            },
            new UserProfile
            {
                Id = 6,
                FirstName = "Eve",
                LastName = "Davis",
                CreateDateTime = new DateTime(2022, 10, 18),
                ImageLocation = "https://robohash.org/hicnihilipsa.png?size=150x150&set=set1",
                IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
            }
        });

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category { Id = 1, Name = "Technology" },
            new Category { Id = 2, Name = "Writing" },
            new Category { Id = 3, Name = "Outdoor Activities" },
            new Category { Id = 4, Name = "Lifestyle" }
        });


        modelBuilder.Entity<Post>().HasData(new Post[]
        {
            new Post { Id = 1, Title = "The Rise of AI in Everyday Life", Content = "Artificial intelligence is becoming an integral part of our daily lives. From virtual assistants to self-driving cars, the future is now.", DateCreated = new DateTime(2025, 1, 1), UserProfileId = 1, CategoryId = 1, HeaderImg = "ai-future.jpg", ApprovedByAdmin = true },
            new Post { Id = 2, Title = "10 Tips for Writing Engaging Blog Posts", Content = "Creating content that grabs readers' attention is both an art and a science. Here are ten practical tips to improve your writing.", DateCreated = new DateTime(2025, 1, 2), UserProfileId = 2, CategoryId = 2, HeaderImg = "writing-tips.jpg", ApprovedByAdmin = true },
            new Post { Id = 3, Title = "Exploring the Great Outdoors: Hiking Tips for Beginners", Content = "Hiking is a great way to connect with nature and stay active. Here are some essential tips to get started.", DateCreated = new DateTime(2025, 1, 3), UserProfileId = 3, CategoryId = 3, HeaderImg = "hiking-tips.jpg", ApprovedByAdmin = true },
            new Post { Id = 4, Title = "The History of Coffee: From Bean to Brew", Content = "Ever wondered how coffee became the world's favorite beverage? Discover its fascinating journey.", DateCreated = new DateTime(2025, 1, 4), UserProfileId = 4, CategoryId = 4, HeaderImg = "coffee-history.jpg", ApprovedByAdmin = false },
            new Post { Id = 5, Title = "Mastering Mindfulness in a Busy World", Content = "Learn how to practice mindfulness and find inner peace, even in the midst of a hectic lifestyle.", DateCreated = new DateTime(2025, 1, 5), UserProfileId = 5, CategoryId = 4, HeaderImg = "mindfulness.jpg", ApprovedByAdmin = true }
        });
        
        modelBuilder.Entity<Tag>().HasData(new Tag[] 
        {
            new Tag { Id = 1, Text = "Tech" },
            new Tag { Id = 2, Text = "Programming" },
            new Tag { Id = 3, Text = "Lifestyle" },
            new Tag { Id = 4, Text = "Education" }
        });

        modelBuilder.Entity<PostTag>().HasData(new PostTag[] 
        {
            new PostTag { Id = 1, PostId = 1, TagId = 1 }, // Post 1 tagged as "Tech"
            new PostTag { Id = 2, PostId = 1, TagId = 2 }, // Post 1 tagged as "Programming"
            new PostTag { Id = 3, PostId = 2, TagId = 3 }, // Post 2 tagged as "Lifestyle"
            new PostTag { Id = 4, PostId = 3, TagId = 4 }, // Post 3 tagged as "Education"
            new PostTag { Id = 5, PostId = 4, TagId = 2 }  // Post 4 tagged as "Programming"
        });


        modelBuilder.Entity<Comment>().HasData(new Comment[]
        {
            new Comment { Id = 1, PostId = 1, UserProfileId = 1, Text = "This is such an insightful post! Thanks for sharing.", DateCreated = new DateTime(2025, 1, 5, 14, 30, 0) },
            new Comment { Id = 2, PostId = 2, UserProfileId = 2, Text = "I completely agree with your points here. Well-written!", DateCreated = new DateTime(2025, 1, 6, 10, 15, 0) },
            new Comment { Id = 3, PostId = 1, UserProfileId = 3, Text = "Could you elaborate on your second point? I’m curious to learn more.", DateCreated = new DateTime(2025, 1, 6, 18, 45, 0) },
            new Comment { Id = 4, PostId = 3, UserProfileId = 1, Text = "Great read! I’ve shared this with my friends.", DateCreated = new DateTime(2025, 1, 7, 9, 0, 0) }
        });


        modelBuilder.Entity<Reaction>().HasData(new Reaction[] 
        {
            new Reaction { Id = 1, Text = "Like", Icon = "👍" },
            new Reaction { Id = 2, Text = "Love", Icon = "❤️" },
            new Reaction { Id = 3, Text = "Laugh", Icon = "😂" }
        });


        modelBuilder.Entity<PostReaction>().HasData(new PostReaction[] 
        {
            new PostReaction { Id = 1, PostId = 1, ReactionId = 1, UserProfileId = 1 }, // User 1 "Liked" Post 1
            new PostReaction { Id = 2, PostId = 2, ReactionId = 2, UserProfileId = 2 }  // User 2 "Loved" Post 2
        });


        // PostSubscriptions
        modelBuilder.Entity<PostSubscription>().HasData(new PostSubscription[] 
        {
            new PostSubscription { Id = 1, UserProfileId = 1, PostId = 1, DateSubscribed = new DateTime(2025, 1, 1) },
            new PostSubscription { Id = 2, UserProfileId = 2, PostId = 2, DateSubscribed = new DateTime(2025, 1, 2) },
            new PostSubscription { Id = 3, UserProfileId = 3, PostId = 3, DateSubscribed = new DateTime(2025, 1, 3) }
        });












    }
}