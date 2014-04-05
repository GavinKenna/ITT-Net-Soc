using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Security;

namespace ITTNetSoc.Models
{
    public partial class UserProfile
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        public string AccountId
        {
            //get
            //{
            //    Guid userId = (Guid)Membership.GetUser().ProviderUserKey;
            //    return int.Parse(userId.ToString());
            //}
            //set
            //{
            //    Id = value ;
            //}
            get;
            set;
        }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } //Like an about me

        private string displayName = "empty";

        [Display(Name = "DisplayName")]
        public string DisplayName
        {
            get
            {
                if (this.displayName == null)
                {
                    Guid accountID = Guid.Parse(AccountId);
                    return Membership.GetUser(accountID).UserName;
                }
                else
                {
                    return this.displayName;
                }
            }
            set { this.displayName = value; }
        } //Like an about me

        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; } //Like an about me

        [Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; } //Like an about me

        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; } //Like an about me

        [Display(Name = "Question")]
        public string Question { get; set; } //Like an about me

        [Display(Name = "Answer")]
        public string Answer { get; set; } //Like an about me

        //    [Display(Name = "PictureUpload")
        [Display(Name = "PictureUpload")]
        [NotMapped]
        public HttpPostedFileBase PictureUpload
        {
            get;
            set;
        } // For when editing the user profile and you need to upload a new picture
    }
}