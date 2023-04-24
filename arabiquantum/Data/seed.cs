using arabiquantum.Models;
using Microsoft.AspNetCore.Identity;
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
                            /* new User()
                             {
                               Id = 1,
                               Role = "admin"

                             },
                             new User()
                             {
                               UserId = 2,
                               Role = "user"

                             }*/
                        });
                        context.SaveChanges();
                    }

                    if (!context.Posts.Any())
                    {
                        context.Posts.AddRange(new List<Post>()
                        {
                            new Post()
                            {
                                Id=1,
                                text = "هل يمكن للحاسوب الكمي ان يفك تشفير كلمة سر ؟",
                                DateTime = DateTime.UtcNow,
                                commentcount = 2,
                                vote = 10
                            },
                            new Post()
                            {
                                Id=2,
                                text = "  هل يمكن للحاسوب الكمي الطيران ",
                                DateTime = DateTime.UtcNow,
                                commentcount = 5,
                                 vote = 1
                            },
                            new Post()
                            {
                                Id=3,
                                text = "هل يمكن للحاسوب الكمي السياحة ",
                                DateTime = DateTime.UtcNow,
                                commentcount = 4,
                                 vote = 5
                            },
                            new Post()
                            {
                                Id=4,
                                text = "هل يمكن للحاسوب الكمي القفز ",
                                DateTime = DateTime.UtcNow,
                                commentcount = 1,
                                 vote = -5
                            }
                        }); ;
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
                              Votes=5,
                              PostId = 1,


                         },
                          new Comment()
                         {
                               CommentId =2,
                               Text ="لا لايمكنه",
                              DateTime= DateTime.UtcNow,
                             Votes = 3,
                              PostId = 2,
                         }
                    });
                        context.SaveChanges();
                    }
                }
            }


            public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    //Roles
                    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    if (!await roleManager.RoleExistsAsync(UserRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    //Users
                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    string adminUserEmail = "admin@admin.com";

                    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                    if (adminUser == null)
                    {
                        var newAdminUser = new User()
                        {
                            UserName = "admin",
                            Email = adminUserEmail,
                            EmailConfirmed = true
                        };

                        await userManager.CreateAsync(newAdminUser, "Admin@1234");
                        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    }

                    string appUserEmail = "user@user.com";

                    var appUser = await userManager.FindByEmailAsync(appUserEmail);
                    if (appUser == null)
                    {
                        var newAppUser = new User()
                        {
                            UserName = "user",
                            Email = appUserEmail,
                            EmailConfirmed = true,

                        };
                        await userManager.CreateAsync(newAppUser, "User@1234");
                        await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                    }
                }
            }

        }
    }
}
