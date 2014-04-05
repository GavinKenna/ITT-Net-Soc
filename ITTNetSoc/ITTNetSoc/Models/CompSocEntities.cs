using System.Data.Entity;
using System.Web.Security;

namespace ITTNetSoc.Models
{
    public class CompSocEntities : DbContext
    {
        public DbSet<NewsItem> NewsItems { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public UserProfile GetUserFromMember(MembershipUser member)
        {
            foreach (UserProfile user in UserProfiles)
            {
                if (user.AccountId.Equals(member.ProviderUserKey.ToString()))
                {
                    return user;
                }
            }
            //If nothing returned
            return null;
        }

        public DbSet<Comments> comments { get; set; }
    }
}