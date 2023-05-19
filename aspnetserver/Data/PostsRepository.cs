
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class PostsRepository
    {
        // We start Read Operation: get all posts

        internal async static Task<List<Post>> GetPostsAsync()
        {
            //thats make clean up by the garbage collections ?
            //Its more efficent
            using (var db = new AppDBContex())
            {
                return await db.Posts.ToListAsync();
            }
        }

        internal  async static Task<Post> GetPostByIdAsync(int PostId)
            // if there is no post we get error? if we should try catch ?
        {
            using (var db = new AppDBContex())
            {
                return await db.Posts.FirstOrDefaultAsync(post => post.PostId == PostId);
            }
        }


        internal async static Task<bool> CreatePostAsync(Post postToCreate)
        {
            using (var db = new AppDBContex())
            {
                try
                {
                    await db.Posts.AddAsync(postToCreate);
                    //if the amount of changes are more than or equal to 1, it worked
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
        }


        //How to recognize which post update?
        internal async static Task<bool> UpdatePostAsync(Post PostToUpdate)
        {
            using (var db = new AppDBContex())
            {
                try
                {
                    db.Posts.Update(PostToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {

                    return false;
                }

            }
        }


        internal async static Task<bool> DeletePostAsync(int PostId)
        {
            using (var db = new AppDBContex())
            {
                try
                {
                    Post postToDelte = await GetPostByIdAsync(PostId);
                    db.Remove(postToDelte);
                    return await db.SaveChangesAsync() >= 1;

                }
                catch (Exception e)
                {

                    return false;
                }
            }
        }



    }
}
