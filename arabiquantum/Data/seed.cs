using arabiquantum.Models;
using System.Diagnostics;

namespace arabiquantum.Data
{
    public class seed
    {
        public class Seed
        {
            public static void SeedData(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                    context.Database.EnsureCreated();

                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(new List<User>()
                        {
                            new User()
                            {
                              UserId = 1,
                              Role = "admin"

                            },
                            new User()
                            {
                              UserId = 2,
                              Role = "user"

                            }
                        });
                        context.SaveChanges();
                    }

                    if (!context.Posts.Any())
                    {
                        context.Posts.AddRange(new List<Post>()
                        {
                            new Post()
                            {
                                PostId=1,
                                UserId=1,
                                text = "هل يمكن للحاسوب الكمي ان يفك تشفير كلمة سر ؟",
                                DateTime = DateTime.UtcNow

                            },
                            new Post()
                            {
                                PostId=2,
                                UserId=1,
                                text = "  هل يمكن للحاسوب الكمي الطيران ",
                                DateTime = DateTime.UtcNow
                            },
                            new Post()
                            {
                                PostId=3,                                
                                UserId = 2,
                                text = "هل يمكن للحاسوب الكمي السياحة ",
                                DateTime = DateTime.UtcNow
                            },
                            new Post()
                            {
                                PostId=4,                          
                                UserId = 2,
                                text = "هل يمكن للحاسوب الكمي القفز ",
                                DateTime = DateTime.UtcNow
                            }
                        }) ;
                        context.SaveChanges();
                    }

                    if (!context.Comments.Any())
                    {
                        context.Comments.AddRange(new List<Comment>()
                        {
                          new Comment()
                         {
                              CommentId=1,
                              Text ="نعم, الحاسوب الكمي يستطيع ايجاد واختراق اي كلمة سر",
                              DateTime= DateTime.UtcNow,
                              Like = 5,
                              Dislike = 1,
                              PostId = 1,
                              UserId = 1


                         },
                          new Comment()
                         {
                               CommentId =2,  
                               Text ="لا لايمكنه",
                              DateTime= DateTime.UtcNow,
                              Like = 1,
                              Dislike = 5,
                              PostId = 2,
                              UserId = 2

                         }
                    });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
