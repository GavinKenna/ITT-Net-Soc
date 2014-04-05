using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;

namespace ITTNetSoc.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<CompSocEntities>
    {
        protected override void Seed(CompSocEntities context)
        {
            //News Items Start
            var newsItems = new List<NewsItem>
            {
                new NewsItem { Id = 1,
                    Author = "Admin",
                    AuthorID = 1,
                    Headline = "Database Is Go",
                    Summary = "DateTime causing trouble",
                    Body = "Fix in Database problem did not take DateTime formatted variable. Changed Date to string variable",
                    NewsArtUrl = "This is the Url"
                },

                new NewsItem { Id = 2,
                    Author = "Admin",
                    AuthorID = 1,
                    Headline = "Annual General Meeting - (AGM) ",
                    Summary = "Time & Location of AGM",
                    Body = "Held in room 116 at 3pm",
                    NewsArtUrl = "This is the Url"
                },

                new NewsItem { Id = 3,
                   Author = "Admin",
                    AuthorID = 1,
                    Headline = "Development Continues",
                    Summary = "Development progress so far.",
                    Body = "Now beginning to populate Gallery, News/NewsItems, Event/EventItems",
                    NewsArtUrl = "This is the Url"
                },

                  new NewsItem { Id = 4,
                   Author = "Admin",
                    AuthorID = 1,
                    Headline = "AGM Comittee Members",
                    Summary = "Name's/Positions of committee members",
                    Body = "Who became comittee members from the AGM meeting.",
                    NewsArtUrl = "This is the Url"
                },

                new NewsItem { Id = 5,
                    Author = "Admin",
                    AuthorID = 1,
                    Headline = "Development Continues",
                    Summary = "Development progress coontinues",
                    Body = "More news on the development of our website",
                    NewsArtUrl = "This is the Url"
                },

                 new NewsItem { Id = 6,
                    Author = "Admin",
                    AuthorID = 1,
                    Headline = "Page Listed",
                    Summary = "Got PagedList Working",
                    Body = "Finally got the Paged List working",
                    NewsArtUrl = "This is the Url"
                }
            };

            //News Items End

            var events = new List<Event>
            {
                new Event {
                    Id = 1,
                    Author = "Admin",
                    AuthorID = 1,
                    EventName = "Computer Society AGM",
                    Body = "The Computer Society AGM will be held in the college on 15/11/2012",
                    date = "15/11/2012",
                    time = "15:00",
                    mapLocation = "53.290758,-6.363757"
                },

                new Event {
                    Id = 2,
                    Author = "Sean Lynch",
                    AuthorID = 3,
                    EventName = "Committee Meeting",
                    Body = "The Computer Society will have a committee meeting to discuss our budget and plans for the following semester",
                    date = "29/11/2012",
                    time = "16:00",
                    mapLocation = "53.290758,-6.363757"
                },

                new Event {
                    Id = 3,
                    Author = "Admin",
                    AuthorID = 1,
                    EventName = "Server Construction",
                    Body = "We will soon begin building our servers so we can get our websites and applications online for the society to use",
                    date = "TBA",
                    time = "TBA",
                    mapLocation = "53.290758,-6.363757"
                }
            };

            var albums = new List<Album>
             {
                 new Album{
                    Id = 1,
                    AlbumName = "Pictures of IT Tallaght",
                    Description = "This is an album containing images of IT Tallaght",
                    time = "",
                    date = ""
                 },
                 new Album{
                    Id = 2,
                    AlbumName = "Students of IT Tallaght",
                    Description = "This is an album containing images of students from IT Tallaght",
                    time = "",
                    date = "",
                 },
                 new Album{
                    Id = 3,
                    AlbumName = "New Server at CompSoc",
                    Description = "This is an album containing images of our new servers.",
                    time = "",
                    date = "",
                 }
             };

            

            var pictures = new List<Picture>
             {
                 new Picture{
                    Id = 1,
                    Source = "/PICTURES/crecheweb.jpg",
                    AlbumId = 1
                 },
                 new Picture{
                    Id = 2,
                    Source = "/PICTURES/fountain-icicles.jpg",
                    AlbumId = 1,
                 },
                 new Picture{
                    Id = 3,
                    Source = "/PICTURES/IT_TALLAGHT_1_(600_x_450).jpg",
                    AlbumId = 1
                 },
                  new Picture{
                    Id = 4,
                    Source = "/PICTURES/Lecture Theatre Tip-up Seating Tallaght IT 3.jpg",
                    AlbumId = 1
                 }, new Picture{
                    Id = 5,
                    Source = "/PICTURES/pic5.jpg",
                    AlbumId = 1
                 },new Picture{
                    Id = 6,
                    Source = "/PICTURES/tallaght_itt.jpg",
                    AlbumId = 1
                 },new Picture{
                    Id = 7,
                    Source = "/PICTURES/accessoffice1.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 8,
                    Source = "/PICTURES/adademicserviceslowres5.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 9,
                    Source = "/PICTURES/creativedigitalmedia.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 10,
                    Source = "/PICTURES/engineering.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 11,
                    Source = "/PICTURES/full_time_intro.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 12,
                    Source = "/PICTURES/ITT_Media_19916_en.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 13,
                    Source = "/PICTURES/library1.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 14,
                    Source = "/PICTURES/registrarlowres2.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 15,
                    Source = "/PICTURES/Scienceresearcher1.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 16,
                    Source = "/PICTURES/sportslowres2.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 17,
                    Source = "/PICTURES/sportsrecreation2.jpg",
                    AlbumId = 2
                 },new Picture{
                    Id = 18,
                    Source = "/PICTURES/Server1.jpg",
                    AlbumId = 3
                 },new Picture{
                    Id = 19,
                    Source = "/PICTURES/Server2.png",
                    AlbumId = 3
                 },new Picture{
                    Id = 20,
                    Source = "/PICTURES/Server3.jpg",
                    AlbumId = 3
                 },new Picture{
                    Id = 21,
                    Source = "/PICTURES/Server4.jpeg",
                    AlbumId = 3
                 },new Picture{
                    Id = 22,
                    Source = "/PICTURES/Server5.jpeg",
                    AlbumId = 3
                 },new Picture{
                    Id = 23,
                    Source = "/PICTURES/Server6.jpeg",
                    AlbumId = 3
                 },

             };

            var users = new List<UserProfile>
            {
                new UserProfile{
                    AccountId = Membership.GetUser("Administrator").ProviderUserKey.ToString(),
                    Department = "Computing",
                    Description = "I'm the main administrator for this site. Please feel free to contact me with any issues",
                    DisplayName = "Admin",
                    Picture = "Unknown.jpg",
                    Year = 3
                },
                new UserProfile{
                    AccountId = Membership.GetUser("GavinK").ProviderUserKey.ToString(),
                    Department = "Computing",
                    Description = "I'm one of the programmers of this site.",
                    DisplayName = "Gavin",
                    Picture = "GavinK.jpg",
                    Year = 3
                },
                new UserProfile{
                    AccountId = Membership.GetUser("SeanL").ProviderUserKey.ToString(),
                    Department = "Computing",
                    Description = "I'm one of the programmers of this site.",
                    DisplayName = "Sean",
                    Picture = "sean.jpg",
                    Year = 3
                },
                new UserProfile{
                    AccountId = Membership.GetUser("RobT").ProviderUserKey.ToString(),
                    Department = "Computing",
                    Description = "I'm one of the programmers of this site.",
                    DisplayName = "Robert",
                    Picture = "rob.jpg",
                    Year = 3
                },
                new UserProfile{
                    AccountId = Membership.GetUser("SeanB").ProviderUserKey.ToString(),
                    Department = "Acting",
                    Description = "I'm Sean Bean. I die in every film I'm in. I'll probably die in this website too.",
                    DisplayName = "Sean Bean",
                    Picture = "bean.jpg",
                    Year = 9
                },
                new UserProfile{
                    AccountId = Membership.GetUser("DaveM").ProviderUserKey.ToString(),
                    Department = "Computing",
                    Description = "I'm the chairman of the CompSoc.",
                    DisplayName = "Dave Matthews",
                    Picture = "DaveM.jpg",
                    Year = 3
                },
                new UserProfile{
                    AccountId = Membership.GetUser("GLaDOS").ProviderUserKey.ToString(),
                    Department = "Science and Research",
                    Description = "I'm just a student, don't mind me, carry on. I'm not planning on destroying you or this website.",
                    DisplayName = "GLaDOS",
                    Picture = "Glados.png",
                    Year = 3
                },
                new UserProfile{
                    AccountId = Membership.GetUser("Koala").ProviderUserKey.ToString(),
                    Department = "Marketing",
                    Description = "I'm the brains behind this operation. Fear me human.",
                    DisplayName = "Koala",
                    Picture = "Koala.jpg",
                    Year = 3
                },
                 new UserProfile{
                    AccountId = Membership.GetUser("RobW").ProviderUserKey.ToString(),
                    Department = "Comedy",
                    Description = "I'm the presenter on Numberwang. That's Numberwang!",
                    DisplayName = "Robert Webb",
                    Picture = "RobW.jpg",
                    Year = 3
                },
                new UserProfile{
                    AccountId = Membership.GetUser("DavidM").ProviderUserKey.ToString(),
                    Department = "Comedy",
                    Description = "I'm the presenter on 'The Quiz Broadcast'. Remember, remain indoors!",
                    DisplayName = "David Mitchell",
                    Picture = "DavidM.jpg",
                    Year = 3
                },
                 new UserProfile{
                    AccountId = Membership.GetUser("ZooeyD").ProviderUserKey.ToString(),
                    Department = "Hollywood",
                    Description = "I'm Zooey Deschannel and I'm totally on this website and real and not fake.",
                    DisplayName = "Zooey Deschannel",
                    Picture = "Zooey.jpg",
                    Year = 3
                },
                new UserProfile{
                    AccountId = Membership.GetUser("Peach").ProviderUserKey.ToString(),
                    Department = "Getting Kidnapped",
                    Description = "I'm Princess Peach and I'm an independant princess and I don't need no Italian plumber saving me.",
                    DisplayName = "Princess Peach",
                    Picture = "Peach.jpg",
                    Year = 3
                },
                 new UserProfile{
                    AccountId = Membership.GetUser("StephenF").ProviderUserKey.ToString(),
                    Department = "Interesting Facts",
                    Description = "I'm Stephen Fry and I will narrate your life for a cup of tea.",
                    DisplayName = "Stephen Fry",
                    Picture = "Fry.jpg",
                    Year = 3
                }
            };

            albums.ForEach(a => context.Albums.Add(a));
            users.ForEach(u => context.UserProfiles.Add(u));
            context.SaveChanges();
            GenerateUserProfiles(context);
            pictures.ForEach(p => context.Pictures.Add(p));
            events.ForEach(e => context.Events.Add(e));
            newsItems.ForEach(s => context.NewsItems.Add(s));
            context.SaveChanges();
        }

        private void GenerateUserProfiles(CompSocEntities context)
        {
            //This method will go through each Membership Account in the ASPDB.mdf database
            //and create a UserProfile for each Member

            foreach (MembershipUser mem in Membership.GetAllUsers())
            {
                //Check to see if UserProfile doesn't already exist
                string accountID = mem.ProviderUserKey.ToString();
                var temp = context.UserProfiles.FirstOrDefault(u => u.AccountId.Equals(accountID));

                if (temp == null)
                {
                    UserProfile user = new UserProfile()
                                   {
                                       AccountId = mem.ProviderUserKey.ToString(),
                                       Question = mem.PasswordQuestion,
                                       Answer = "",
                                       Description = "Write a witty description of yourself here!",
                                       Department = "Department here",
                                       DisplayName = mem.UserName,
                                       Picture = "Unknown.jpg",
                                       Year = 0
                                   };
                    context.UserProfiles.Add(user);
                }
            }
        }
    }
}