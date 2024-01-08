using MesDoigtsDeFees.Areas.Identity.Data;
using MesDoigtsDeFees.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Utilities;
using System.Reflection.Emit;

namespace MesDoigtsDeFees.Data;

public class MyDBContext : IdentityDbContext<MesDoigtsDeFeesUser>
{
    public MyDBContext(DbContextOptions<MyDBContext> options)
        : base(options)
    {
    }

    public static async Task DataInitializer(MyDBContext context, UserManager<MesDoigtsDeFeesUser> userManager)
    {
        if (!context.Users.Any())
        {
            MesDoigtsDeFeesUser user = new MesDoigtsDeFeesUser
            {
                Id = "User",
                UserName = "User",
                FirstName = "User",
                LastName = "User",
                Email = "User@user.com",
                PasswordHash = "Abc123!"

            };

            context.Users.Add(user);
            context.SaveChanges();

            MesDoigtsDeFeesUser admin = new MesDoigtsDeFeesUser
            {
                Id = "Admin",
                UserName = "Admin",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "aron.mw12@gmail.com"
            };
            var result = await userManager.CreateAsync(admin, "Abc!12345");



        }

        MesDoigtsDeFeesUser dummyUser = context.Users.FirstOrDefault(g => g.UserName == "User");
        MesDoigtsDeFeesUser dummyAdmin = context.Users.FirstOrDefault(g => g.UserName == "Admin");
        AddParameters(context, dummyAdmin);

        Globals.GlobalUser = dummyUser;  // Make sure the dummy user is always available


        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new IdentityRole
                {
                    Id = "User",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "SystemAdministrator",
                    Name = "SystemAdministrator",
                    NormalizedName = "SYSTEMADMINISTRATOR"
                });

            context.UserRoles.Add(
                new IdentityUserRole<string>
                {
                    UserId = dummyUser.Id,
                    RoleId = "User"
                });
            context.UserRoles.Add(
                 new IdentityUserRole<string>
                 {
                     UserId = dummyAdmin.Id,
                     RoleId = "SystemAdministrator"
                 });
            context.SaveChanges();
        }

        Group group = new Group();
        if (!context.Groups.Any())
        {
            context.Groups.AddRange(
                                   new Group
                                   {
                                       Name = "Dummy",
                                       Description = "DummyGroup",
                                       Categorie = group.CategorieList[0]
                                   },
                                   new Group
                                   {
                                       Name = "Dummy2",
                                       Description = "DummyGroup2",
                                       Categorie = group.CategorieList[1]
                                   });

            context.SaveChanges();
        }

        Group dummyGroup = context.Groups.FirstOrDefault(g => g.Name == "Dummy");
        Group dummyGroup2 = context.Groups.FirstOrDefault(g => g.Name == "Dummy2");


        //if (context.Groups.FirstOrDefault(g => g.Name == "Dummy2") == null)
        //{
        //    context.Groups.Add(
        //                                              new Group
        //                                              {
        //                                                  Name = "Dummy2",
        //                                                  Description = "DummyGroup2",
        //                                                  Categorie = group.CategorieList[1]
        //                                              });
        //    context.SaveChanges();


        //}

        // Dummys voor dummyRichting1 en dummyRichting2
        if (!context.Richtings.Any())
        {
            context.Richtings.AddRange(
                new Richting
                {
                    Name = "Dummy",
                    Description = "dummyRichting1",
                },
                new Richting
                {
                    Name = "Dummy2",
                    Description = "dummyRichting2",
                }
            );

            context.SaveChanges();
        }

        Richting dummyRichting1 = context.Richtings.FirstOrDefault(g => g.Name == "Dummy");
        Richting dummyRichting2 = context.Richtings.FirstOrDefault(g => g.Name == "Dummy2");

        // Dummys voor lessons
        Lesson lesson = new Lesson();
        if (!context.Lessons.Any())
        {
            if (dummyGroup != null && dummyRichting1 != null && dummyRichting2 != null)
            {
                context.Lessons.AddRange(
                    new Lesson
                    {
                        Name = "Dummy",
                        Description = "DummyLesson",
                        Type = lesson.TypeList[0],
                        GroupId = dummyGroup.Id,
                        RichtingId = dummyRichting1.Id,
                        RichtingName = dummyRichting1.Name,
                        LessonMakerId = dummyAdmin.Id,
                        LessonMaker = dummyAdmin
                    },
                    new Lesson
                    {
                        Name = "Dummy2",
                        Description = "DummyLesson2",
                        Type = lesson.TypeList[1],
                        GroupId = dummyGroup2.Id,
                        RichtingId = dummyRichting2.Id,
                        RichtingName = dummyRichting2.Name,
                        LessonMakerId = dummyUser.Id,
                        LessonMaker = dummyUser
                    },
                    new Lesson
                    {
                        Name = "Dummy3",
                        Description = "DummyLesson3",
                        Type = lesson.TypeList[0],
                        GroupId = dummyGroup2.Id,
                        RichtingId = dummyRichting1.Id,
                        RichtingName = dummyRichting1.Name,
                        LessonMakerId = dummyUser.Id,
                        LessonMaker = dummyUser
                    },
                    new Lesson
                    {
                        Name = "Dummy4",
                        Description = "DummyLesson4",
                        Type = lesson.TypeList[1],
                        GroupId = dummyGroup2.Id,
                        RichtingId = dummyRichting2.Id,
                        RichtingName = dummyRichting2.Name,
                        LessonMakerId = dummyAdmin.Id,
                        LessonMaker = dummyAdmin
                    }
                );

                context.SaveChanges();
            }
        }
        Lesson dummyLesson1 = context.Lessons.FirstOrDefault(g => g.Name == "Dummy");
        Lesson dummyLesson2 = context.Lessons.FirstOrDefault(g => g.Name == "Dummy2");
        Lesson dummyLesson3 = context.Lessons.FirstOrDefault(g => g.Name == "Dummy3");
        Lesson dummyLesson4 = context.Lessons.FirstOrDefault(g => g.Name == "Dummy4");



        if (!context.LessonRichtings.Any())
        {
            if (dummyLesson1 != null && dummyLesson2 != null && dummyRichting1 != null && dummyRichting2 != null)
            {
                context.LessonRichtings.AddRange(
                    new LessonRichting
                    {
                        LessonId = dummyLesson1.Id,
                        RichtingId = dummyRichting1.Id,
                        LessonName = dummyLesson1.Name,
                        RichtingName = dummyRichting1.Name
                    },
                    new LessonRichting
                    {
                        LessonId = dummyLesson2.Id,
                        RichtingId = dummyRichting2.Id,
                        LessonName = dummyLesson2.Name,
                        RichtingName = dummyRichting2.Name
                    },
                    new LessonRichting
                    {
                        LessonId = dummyLesson3.Id,
                        RichtingId = dummyRichting1.Id,
                        LessonName = dummyLesson3.Name,
                        RichtingName = dummyRichting1.Name
                    },
                    new LessonRichting
                    {
                        LessonId = dummyLesson4.Id,
                        RichtingId = dummyRichting2.Id,
                        LessonName = dummyLesson4.Name,
                        RichtingName = dummyRichting2.Name
                    }
                );

                context.SaveChanges();
            }
        }






        Clothes clothes = new Clothes();
        if (!context.Clothes.Any())
        {
            context.Clothes.Add(
                                   new Clothes
                                   {
                                       Name = "Dummy",
                                       Description = "DummyClothes",
                                       Ended = DateTime.Now,
                                       Size = clothes.SizeList[1]
                                   }

                                   );

            context.SaveChanges();
        }


        Clothes dummyClothes = context.Clothes.FirstOrDefault(g => g.Name == "Dummy");

        if (context.Clothes.FirstOrDefault(g => g.Name == "Dummy2") == null || context.Clothes.FirstOrDefault(g => g.Name == "Dummy3") == null
            || context.Clothes.FirstOrDefault(g => g.Name == "Dummy4") == null || context.Clothes.FirstOrDefault(g => g.Name == "Dummy5") == null)
        {

            context.Clothes.AddRange(
                               new Clothes
                               {
                                   Name = "Dummy2",
                                   Description = "DummyClothes2",
                                   Ended = DateTime.Now,
                                   Size = clothes.SizeList[2]
                               },
                                              new Clothes
                                              {
                                                  Name = "Dummy3",
                                                  Description = "DummyClothes3",
                                                  Ended = DateTime.Now,
                                                  Size = clothes.SizeList[3]
                                              },
                                                             new Clothes
                                                             {
                                                                 Name = "Dummy4",
                                                                 Description = "DummyClothes4",
                                                                 Ended = DateTime.Now,
                                                                 Size = clothes.SizeList[4]
                                                             },
                                                                            new Clothes
                                                                            {
                                                                                Name = "Dummy5",
                                                                                Description = "DummyClothes5",
                                                                                Ended = DateTime.Now,
                                                                                Size = clothes.SizeList[0]
                                                                            }
                                                                                           );

            context.SaveChanges();


        }

        if(context.Users.FirstOrDefault(u => u.UserName == "Teacher") == null)
        {

            MesDoigtsDeFeesUser teacher = new MesDoigtsDeFeesUser
            {
                Id = "Teacher",
                UserName = "Teacher",
                FirstName = "Teacher",
                LastName = "Teacher",
                Email = "teacher@teacher.com"
            };

            var result = await userManager.CreateAsync(teacher, "Abc!12345");



        }
        MesDoigtsDeFeesUser dummyTeacher = context.Users.FirstOrDefault(u => u.UserName == "Teacher");
        if (context.Roles.FirstOrDefault(r => r.Name == "Teacher") == null)
        context.Roles.AddRange(
            new IdentityRole
            {
                Id = "Teacher",
                Name = "Teacher",
                NormalizedName = "TEACHER"
            },
            new IdentityRole
            {
                Id = "Student",
                Name = "Student",
                NormalizedName = "STUDENT"
            });

        if (context.UserRoles.FirstOrDefault(u => u.UserId == dummyTeacher.Id) == null)
        { 
            context.UserRoles.AddRange(
                               new IdentityUserRole<string>
                               {
                    UserId = dummyTeacher.Id,
                    RoleId = "Teacher"
                });
            context.SaveChanges();
        }
        static void AddParameters(MyDBContext context, MesDoigtsDeFeesUser user)
        {
            if (!context.Parameter.Any())
            {
                context.Parameter.AddRange(
                    new Parameter { Name = "Version", Value = "0.1.0", Description = "Huidige versie van de parameterlijst", Destination = "System", UserId = user.Id },
                    new Parameter { Name = "Mail.Server", Value = "ergens.mesdoigtsdefees.be", Description = "Naam van de gebruikte pop-server", Destination = "Mail", UserId = user.Id },
                    new Parameter { Name = "Mail.Port", Value = "25", Description = "Poort van de smtp-server", Destination = "Mail", UserId = user.Id },
                    new Parameter { Name = "Mail.Account", Value = "SmtpServer", Description = "Acount-naam van de smtp-server", Destination = "Mail", UserId = user.Id },
                    new Parameter { Name = "Mail.Password", Value = "xxxyyy!2315", Description = "Wachtwoord van de smtp-server", Destination = "Mail", UserId = user.Id },
                    new Parameter { Name = "Mail.Security", Value = "true", Description = "Is SSL or TLS encryption used (true or false)", Destination = "Mail", UserId = user.Id },
                    new Parameter { Name = "Mail.SenderEmail", Value = "mesdoigtsdefees.groupspace.be", Description = "E-mail van de smtp-verzender", Destination = "Mail", UserId = user.Id },
                    new Parameter { Name = "Mail.SenderName", Value = "Administrator", Description = "Naam van de smtp-verzender", Destination = "Mail", UserId = user.Id }
                );
                context.SaveChanges();
            }

            Globals.Parameters = new Dictionary<string, Parameter>();
            foreach (Parameter parameter in context.Parameter)
            {
                Globals.Parameters[parameter.Name] = parameter;
            }
            Globals.ConfigureMail();
        }

    }




    public DbSet<MesDoigtsDeFees.Models.Group> Groups { get; set; } = default!;

    public DbSet<MesDoigtsDeFees.Models.Lesson> Lessons { get; set; } = default!;

    public DbSet<MesDoigtsDeFees.Models.Richting> Richtings { get; set; } = default!;

    public DbSet<MesDoigtsDeFees.Models.Clothes> Clothes { get; set; } = default!;

    public DbSet<MesDoigtsDeFees.Models.LessonRichting> LessonRichtings { get; set; } = default!;

    public DbSet<MesDoigtsDeFees.Models.Parameter> Parameter { get; set; } = default!;





    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<Lesson>()
    .HasOne(l => l.LessonMaker)
    .WithMany() // or WithOne() depending on your relationship
    .HasForeignKey(l => l.LessonMakerId)
    .IsRequired(false);

    }





 
}
