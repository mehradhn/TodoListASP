

using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal sealed class AppDBContex:DbContext
    {

        //we only one table, so we are going to add one DbSets 
        public DbSet<Post> Posts { get; set; }


        //Now we should specify that we're going to use SQLite as our db

        // we should override the OnConfiguring (what is this?)


        // visual studio code doesn't know sqlite so we install sth called microsoft.entityframework.sqlite
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");
        //that will be placed in this directory


        //Now we add insert some data in our database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] postToSeed = new Post[6];

            for (int i = 1; i <= 6; i++)
            {
                postToSeed[i - 1] = new Post
                {
                    PostId = i,
                    Title = $"Post {i}",
                    Content = $"This is post {i}. It has some very intersting content",
                };
            }

            //Now we use Entity project
            modelBuilder.Entity<Post>().HasData(postToSeed);
        }

 

    }
}
