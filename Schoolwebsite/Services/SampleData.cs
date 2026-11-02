//using Schoolwebsite.Models;

//namespace Schoolwebsite.Services
//{
//    public static class SampleData
//    {

//        public static List<Teacher> Teachers { get; } = new()
//    {
//        new Teacher
//        {
//            Id = 1,
//            Name = "Mr. Kwame Owusu",
//            Role = "Headmaster",
//            Subject = "School Administration",
//            ImagePath = "/images/teachers/t-1.jpg",
//            About = "Mr. Owusu has led Bright Future SHS for over a decade, focused on academic excellence and student welfare.",
//            Achievements = "Ghana Education Service Award for School Leadership, 2021.",
//            Objective = "To build a school where every student is equipped with the knowledge and character to succeed."
//        },
//        new Teacher
//        {
//            Id = 2,
//            Name = "Mrs. Abena Mensah",
//            Role = "Assistant Headmistress",
//            Subject = "English Language",
//            ImagePath = "/images/teachers/t-2.jpg",
//            About = "Mrs. Mensah oversees academics and has taught English Language for over 15 years.",
//            Achievements = "Best Teacher Award, Ashanti Region, 2019.",
//            Objective = "To help every student read, write and speak with confidence."
//        },
//        new Teacher
//        {
//            Id = 3,
//            Name = "Mr. Yaw Boateng",
//            Role = "Head of Science Department",
//            Subject = "Physics & Chemistry",
//            ImagePath = "/images/teachers/t-3.jpg",
//            About = "Mr. Boateng runs the science labs and coordinates the school's annual science fair.",
//            Achievements = "Published contributor to the WAEC Chief Examiner's report, Physics.",
//            Objective = "To make science practical, hands-on and exciting for every student."
//        },
//        new Teacher
//        {
//            Id = 4,
//            Name = "Ms. Efua Asante",
//            Role = "Head of Mathematics Department",
//            Subject = "Core & Elective Mathematics",
//            ImagePath = "/images/teachers/t-4.jpg",
//            About = "Ms. Asante has guided many students to distinctions in WASSCE Mathematics.",
//            Achievements = "Regional Mathematics Quiz Coach of the Year, 2022.",
//            Objective = "To show students that mathematics is a skill anyone can master with practice."
//        }
//    };

//        public static List<Course> Courses { get; } = new()
//    {
//        new Course
//        {
//            Id = 1,
//            Title = "General Science",
//            Category = "Science Track",
//            Duration = "3 Years",
//            ImagePath = "/images/course/cu-1.jpg",
//            CoordinatorId = 3, // Mr. Yaw Boateng
//            Overview = new List<string>
//            {
//                "The General Science programme prepares students for careers in medicine, engineering, and the physical and biological sciences.",
//                "Students spend significant time in the laboratory, applying classroom theory through practical experiments in physics, chemistry and biology."
//            },
//            CoreSubjects = new List<string> { "Core Mathematics", "English Language", "Integrated Science", "Social Studies" },
//            ElectiveSubjects = new List<string> { "Physics", "Chemistry", "Biology", "Elective Mathematics" },
//            EntryRequirements = new List<string>
//            {
//                "Pass in Mathematics and Integrated Science at the JHS level (BECE).",
//                "A minimum aggregate as set by the school's admissions committee for the year of entry."
//            }
//        },
//        new Course
//        {
//            Id = 2,
//            Title = "General Arts",
//            Category = "Arts Track",
//            Duration = "3 Years",
//            ImagePath = "/images/course/cu-2.jpg",
//            CoordinatorId = 2, // Mrs. Abena Mensah
//            Overview = new List<string>
//            {
//                "The General Arts programme develops strong communication, critical thinking and analytical skills for students interested in law, journalism, education and the humanities.",
//                "Students explore literature, history, government and languages alongside core subjects."
//            },
//            CoreSubjects = new List<string> { "Core Mathematics", "English Language", "Integrated Science", "Social Studies" },
//            ElectiveSubjects = new List<string> { "Literature in English", "Government", "History", "Economics", "French" },
//            EntryRequirements = new List<string>
//            {
//                "Pass in English Language and Social Studies at the JHS level (BECE).",
//                "A minimum aggregate as set by the school's admissions committee for the year of entry."
//            }
//        },
//        new Course
//        {
//            Id = 3,
//            Title = "Business",
//            Category = "Business Track",
//            Duration = "3 Years",
//            ImagePath = "/images/course/cu-3.jpg",
//            CoordinatorId = 4, // Ms. Efua Asante
//            Overview = new List<string>
//            {
//                "The Business programme introduces students to accounting, management and economics, laying the foundation for careers in commerce, finance and entrepreneurship.",
//                "Students also take part in the school's annual student enterprise fair as part of practical coursework."
//            },
//            CoreSubjects = new List<string> { "Core Mathematics", "English Language", "Integrated Science", "Social Studies" },
//            ElectiveSubjects = new List<string> { "Financial Accounting", "Business Management", "Economics", "Elective Mathematics" },
//            EntryRequirements = new List<string>
//            {
//                "Pass in Mathematics and English Language at the JHS level (BECE).",
//                "A minimum aggregate as set by the school's admissions committee for the year of entry."
//            }
//        }
//    };

//        public static List<SchoolEvent> Events { get; } = new()
//    {
//        new SchoolEvent
//        {
//            Id = 1,
//            Title = "Annual Speech & Prize-Giving Day",
//            Date = new DateTime(2026, 11, 14),
//            StartTime = "9:00 AM",
//            EndTime = "1:00 PM",
//            Location = "School Auditorium",
//            ImagePath = "/images/event/se-1.jpg",
//            Summary = "The school celebrates the academic year with prizes for top-performing students and a keynote address from the guest speaker.",
//            Body = new List<string>
//            {
//                "Parents, guardians and alumni are warmly invited to join staff and students for the school's biggest event of the year.",
//                "Awards will be presented across all forms for academic excellence, sports, and outstanding conduct, followed by light refreshments."
//            }
//        },
//        new SchoolEvent
//        {
//            Id = 2,
//            Title = "Inter-House Sports Competition",
//            Date = new DateTime(2026, 9, 26),
//            StartTime = "8:00 AM",
//            EndTime = "4:00 PM",
//            Location = "School Sports Field",
//            ImagePath = "/images/event/se-2.jpg",
//            Summary = "Houses compete in track and field events as part of the school's annual sports festival.",
//            Body = new List<string>
//            {
//                "All four houses will compete in track and field events throughout the day, with the winning house presented the Headmaster's Cup.",
//                "Students are encouraged to come out and support their house, and parents are welcome to attend."
//            }
//        },
//        new SchoolEvent
//        {
//            Id = 3,
//            Title = "Career Guidance Day",
//            Date = new DateTime(2026, 10, 9),
//            StartTime = "10:00 AM",
//            EndTime = "3:00 PM",
//            Location = "School Auditorium",
//            ImagePath = "/images/event/se-3.jpg",
//            Summary = "Professionals from various fields visit to speak with SHS 2 and SHS 3 students about career and tertiary education options.",
//            Body = new List<string>
//            {
//                "This year's Career Guidance Day features speakers from medicine, engineering, law, and business, organised by the guidance and counselling unit.",
//                "Students are encouraged to prepare questions in advance about subject combinations, tertiary admission requirements, and career paths."
//            }
//        }
//    };

//        public static List<BlogPost> BlogPosts { get; } = new()
//    {
//        new BlogPost
//        {
//            Id = 1,
//            Title = "Tips for Getting Better Results in Your Exams",
//            Author = "Mrs. Abena Mensah",
//            Date = new DateTime(2026, 3, 12),
//            Category = "Academics",
//            ImagePath = "/images/blog/b-1.jpg",
//            Summary = "A few practical study habits that help students prepare for WASSCE and end-of-term exams.",
//            Body = new List<string>
//            {
//                "Good exam results start well before exam week. Students who spread their revision across the term, rather than cramming in the final days, consistently perform better.",
//                "Past questions are one of the most useful study tools available. Working through previous WASSCE papers helps students get used to the structure and timing of the real exam.",
//                "Finally, rest matters. A well-rested mind retains information far better than one running on late nights before an exam."
//            }
//        },
//        new BlogPost
//        {
//            Id = 2,
//            Title = "Bright Future SHS Wins Regional Science Fair",
//            Author = "Mr. Yaw Boateng",
//            Date = new DateTime(2026, 2, 20),
//            Category = "School News",
//            ImagePath = "/images/blog/b-2.jpg",
//            Summary = "Our SHS 2 science students took first place at this year's Ashanti Regional Science and Innovation Fair.",
//            Body = new List<string>
//            {
//                "A team of five SHS 2 students represented the school at the Ashanti Regional Science and Innovation Fair, presenting a low-cost water filtration project.",
//                "The judges praised the project for its practical relevance to rural communities and the clarity of the students' presentation.",
//                "The team will now proceed to the national finals later this year. The school congratulates all students and staff involved."
//            }
//        },
//        new BlogPost
//        {
//            Id = 3,
//            Title = "Preparing for Career Day: What Students Should Know",
//            Author = "Mr. Kwame Owusu",
//            Date = new DateTime(2026, 1, 15),
//            Category = "Guidance & Counselling",
//            ImagePath = "/images/blog/b-1.jpg",
//            Summary = "Career Day is coming up. Here's how students can make the most of it.",
//            Body = new List<string>
//            {
//                "Career Day gives students the chance to speak directly with professionals from many different fields, from engineering to nursing to law.",
//                "Students are encouraged to prepare a few questions in advance and to bring a notebook to jot down what they learn.",
//                "The guidance and counselling unit will also be on hand to help students think through subject combinations and tertiary options."
//            }
//        }
//    };

//    }
//}
