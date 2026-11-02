using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schoolwebsite.Models;

namespace Schoolwebsite.Data;

// Runs once at startup. If the database is empty, fills it with the same
// sample content the site shipped with before the admin backend existed,
// so the site isn't blank on first run. Safe to run every startup — it
// only inserts when a table has zero rows.
public static class DbSeeder
{
    public static void Seed(ApplicationDbContext db)
    {
        // Applies any pending EF Core migrations. Requires migrations to
        // already exist — see the README's "First-time database setup".
        db.Database.Migrate();

        SeedAdminAccount(db);

        if (!db.Teachers.Any())
        {
            db.Teachers.AddRange(
                new Teacher
                {
                    Name = "Mr. Kwame Owusu",
                    Role = "Headmaster",
                    Subject = "School Administration",
                    ImagePath = "/images/teachers/t-1.jpg",
                    About = "Mr. Owusu has led Bright Future SHS for over a decade, focused on academic excellence and student welfare.",
                    Achievements = "Ghana Education Service Award for School Leadership, 2021.",
                    Objective = "To build a school where every student is equipped with the knowledge and character to succeed."
                },
                new Teacher
                {
                    Name = "Mrs. Abena Mensah",
                    Role = "Assistant Headmistress",
                    Subject = "English Language",
                    ImagePath = "/images/teachers/t-2.jpg",
                    About = "Mrs. Mensah oversees academics and has taught English Language for over 15 years.",
                    Achievements = "Best Teacher Award, Ashanti Region, 2019.",
                    Objective = "To help every student read, write and speak with confidence."
                },
                new Teacher
                {
                    Name = "Mr. Yaw Boateng",
                    Role = "Head of Science Department",
                    Subject = "Physics & Chemistry",
                    ImagePath = "/images/teachers/t-3.jpg",
                    About = "Mr. Boateng runs the science labs and coordinates the school's annual science fair.",
                    Achievements = "Published contributor to the WAEC Chief Examiner's report, Physics.",
                    Objective = "To make science practical, hands-on and exciting for every student."
                },
                new Teacher
                {
                    Name = "Ms. Efua Asante",
                    Role = "Head of Mathematics Department",
                    Subject = "Core & Elective Mathematics",
                    ImagePath = "/images/teachers/t-4.jpg",
                    About = "Ms. Asante has guided many students to distinctions in WASSCE Mathematics.",
                    Achievements = "Regional Mathematics Quiz Coach of the Year, 2022.",
                    Objective = "To show students that mathematics is a skill anyone can master with practice."
                }
            );
            db.SaveChanges();
        }

        if (!db.Courses.Any())
        {
            var boateng = db.Teachers.First(t => t.Name == "Mr. Yaw Boateng");
            var mensah = db.Teachers.First(t => t.Name == "Mrs. Abena Mensah");
            var asante = db.Teachers.First(t => t.Name == "Ms. Efua Asante");

            db.Courses.AddRange(
                new Course
                {
                    Title = "General Science",
                   // Category = "Science Track",
                    Duration = "3 Years",
                    ImagePath = "/images/course/cu-1.jpg",
                   // CoordinatorId = boateng.Id,
                    Overview =
                        "The General Science programme prepares students for careers in medicine, engineering, and the physical and biological sciences.\n" +
                        "Students spend significant time in the laboratory, applying classroom theory through practical experiments in physics, chemistry and biology.",
                    CoreSubjects = "Core Mathematics\nEnglish Language\nIntegrated Science\nSocial Studies",
                    ElectiveSubjects = "Physics\nChemistry\nBiology\nElective Mathematics",
                    EntryRequirements =
                        "Pass in Mathematics and Integrated Science at the JHS level (BECE).\n" +
                        "A minimum aggregate as set by the school's admissions committee for the year of entry."
                },
                new Course
                {
                    Title = "General Arts",
                   // Category = "Arts Track",
                    Duration = "3 Years",
                    ImagePath = "/images/course/cu-2.jpg",
                    //CoordinatorId = mensah.Id,
                    Overview =
                        "The General Arts programme develops strong communication, critical thinking and analytical skills for students interested in law, journalism, education and the humanities.\n" +
                        "Students explore literature, history, government and languages alongside core subjects.",
                    CoreSubjects = "Core Mathematics\nEnglish Language\nIntegrated Science\nSocial Studies",
                    ElectiveSubjects = "Literature in English\nGovernment\nHistory\nEconomics\nFrench",
                    EntryRequirements =
                        "Pass in English Language and Social Studies at the JHS level (BECE).\n" +
                        "A minimum aggregate as set by the school's admissions committee for the year of entry."
                },
                new Course
                {
                    Title = "Business",
                   // Category = "Business Track",
                    Duration = "3 Years",
                    ImagePath = "/images/course/cu-3.jpg",
                   // CoordinatorId = asante.Id,
                    Overview =
                        "The Business programme introduces students to accounting, management and economics, laying the foundation for careers in commerce, finance and entrepreneurship.\n" +
                        "Students also take part in the school's annual student enterprise fair as part of practical coursework.",
                    CoreSubjects = "Core Mathematics\nEnglish Language\nIntegrated Science\nSocial Studies",
                    ElectiveSubjects = "Financial Accounting\nBusiness Management\nEconomics\nElective Mathematics",
                    EntryRequirements =
                        "Pass in Mathematics and English Language at the JHS level (BECE).\n" +
                        "A minimum aggregate as set by the school's admissions committee for the year of entry."
                }
            );
            db.SaveChanges();
        }

        if (!db.Events.Any())
        {
            db.Events.AddRange(
                new SchoolEvent
                {
                    Title = "Annual Speech & Prize-Giving Day",
                    Date = new DateTime(2026, 11, 14),
                    StartTime = "9:00 AM",
                    EndTime = "1:00 PM",
                    Location = "School Auditorium",
                    ImagePath = "/images/event/se-1.jpg",
                    Summary = "The school celebrates the academic year with prizes for top-performing students and a keynote address from the guest speaker.",
                    Body =
                        "Parents, guardians and alumni are warmly invited to join staff and students for the school's biggest event of the year.\n" +
                        "Awards will be presented across all forms for academic excellence, sports, and outstanding conduct, followed by light refreshments."
                },
                new SchoolEvent
                {
                    Title = "Inter-House Sports Competition",
                    Date = new DateTime(2026, 9, 26),
                    StartTime = "8:00 AM",
                    EndTime = "4:00 PM",
                    Location = "School Sports Field",
                    ImagePath = "/images/event/se-2.jpg",
                    Summary = "Houses compete in track and field events as part of the school's annual sports festival.",
                    Body =
                        "All four houses will compete in track and field events throughout the day, with the winning house presented the Headmaster's Cup.\n" +
                        "Students are encouraged to come out and support their house, and parents are welcome to attend."
                },
                new SchoolEvent
                {
                    Title = "Career Guidance Day",
                    Date = new DateTime(2026, 10, 9),
                    StartTime = "10:00 AM",
                    EndTime = "3:00 PM",
                    Location = "School Auditorium",
                    ImagePath = "/images/event/se-3.jpg",
                    Summary = "Professionals from various fields visit to speak with SHS 2 and SHS 3 students about career and tertiary education options.",
                    Body =
                        "This year's Career Guidance Day features speakers from medicine, engineering, law, and business, organised by the guidance and counselling unit.\n" +
                        "Students are encouraged to prepare questions in advance about subject combinations, tertiary admission requirements, and career paths."
                }
            );
            db.SaveChanges();
        }

        if (!db.BlogPosts.Any())
        {
            db.BlogPosts.AddRange(
                new BlogPost
                {
                    Title = "Tips for Getting Better Results in Your Exams",
                    Author = "Mrs. Abena Mensah",
                    Date = new DateTime(2026, 3, 12),
                    Category = "Academics",
                    ImagePath = "/images/blog/b-1.jpg",
                    Summary = "A few practical study habits that help students prepare for WASSCE and end-of-term exams.",
                    Body =
                        "Good exam results start well before exam week. Students who spread their revision across the term, rather than cramming in the final days, consistently perform better.\n" +
                        "Past questions are one of the most useful study tools available. Working through previous WASSCE papers helps students get used to the structure and timing of the real exam.\n" +
                        "Finally, rest matters. A well-rested mind retains information far better than one running on late nights before an exam."
                },
                new BlogPost
                {
                    Title = "Bright Future SHS Wins Regional Science Fair",
                    Author = "Mr. Yaw Boateng",
                    Date = new DateTime(2026, 2, 20),
                    Category = "School News",
                    ImagePath = "/images/blog/b-2.jpg",
                    Summary = "Our SHS 2 science students took first place at this year's Ashanti Regional Science and Innovation Fair.",
                    Body =
                        "A team of five SHS 2 students represented the school at the Ashanti Regional Science and Innovation Fair, presenting a low-cost water filtration project.\n" +
                        "The judges praised the project for its practical relevance to rural communities and the clarity of the students' presentation.\n" +
                        "The team will now proceed to the national finals later this year. The school congratulates all students and staff involved."
                },
                new BlogPost
                {
                    Title = "Preparing for Career Day: What Students Should Know",
                    Author = "Mr. Kwame Owusu",
                    Date = new DateTime(2026, 1, 15),
                    Category = "Guidance & Counselling",
                    ImagePath = "/images/blog/b-1.jpg",
                    Summary = "Career Day is coming up. Here's how students can make the most of it.",
                    Body =
                        "Career Day gives students the chance to speak directly with professionals from many different fields, from engineering to nursing to law.\n" +
                        "Students are encouraged to prepare a few questions in advance and to bring a notebook to jot down what they learn.\n" +
                        "The guidance and counselling unit will also be on hand to help students think through subject combinations and tertiary options."
                }
            );
            db.SaveChanges();
        }
    }

    // Seeds one "Admin" role and one admin user (username: admin,
    // password: Admin@123) using ASP.NET Core Identity's own PasswordHasher —
    // the same hasher UserManager/SignInManager use to verify logins, so
    // there's no risk of a hand-rolled hash mismatching a hand-rolled verify.
    // Change the password via the admin UI (or re-seed against an empty DB)
    // before this goes anywhere beyond your own machine.
    private static void SeedAdminAccount(ApplicationDbContext db)
    {
        const string adminRoleName = "Admin";
        const string adminUsername = "admin";
        const string adminDefaultPassword = "Admin@123";

        if (!db.Roles.Any(r => r.Name == adminRoleName))
        {
            db.Roles.Add(new IdentityRole(adminRoleName)
            {
                NormalizedName = adminRoleName.ToUpperInvariant()
            });
            db.SaveChanges();
        }

        if (!db.Users.Any(u => u.UserName == adminUsername))
        {
            var adminUser = new ApplicationUser
            {
                UserName = adminUsername,
                NormalizedUserName = adminUsername.ToUpperInvariant(),
                Email = "admin@school.local",
                NormalizedEmail = "ADMIN@SCHOOL.LOCAL",
                EmailConfirmed = true,
                DisplayName = "Administrator",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = hasher.HashPassword(adminUser, adminDefaultPassword);

            db.Users.Add(adminUser);
            db.SaveChanges();

            var adminRole = db.Roles.First(r => r.Name == adminRoleName);
            db.UserRoles.Add(new Microsoft.AspNetCore.Identity.IdentityUserRole<string>
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            });
            db.SaveChanges();
        }
    }
}