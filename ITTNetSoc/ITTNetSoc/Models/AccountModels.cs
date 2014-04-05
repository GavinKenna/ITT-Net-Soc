using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace ITTNetSoc.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } //Like an about me

        [Required]
        [Display(Name = "DisplayName")]
        public string DisplayName { get; set; } //Like an about me

        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; } //Like an about me

        [Required]
        [Display(Name = "Picture")]
        public HttpPostedFileBase Picture { get; set; } //Like an about me

        [Required]
        [Display(Name = "Question")]
        public string Question { get; set; } //Like an about me

        [Required]
        [Display(Name = "Answer")]
        public string Answer { get; set; } //Like an about me

        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; } //Like an about me
    }

    public class EditAccountModel
    {
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } //Like an about me

        [Required]
        [Display(Name = "DisplayName")]
        public string DisplayName { get; set; } //Like an about me

        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; } //Like an about me

        [Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; } //Like an about me

        [Required]
        [Display(Name = "Year")]
        public string Year { get; set; } //Like an about me
    }

    public class ViewAccountModel
    {
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } //Like an about me

        [Required]
        [Display(Name = "DisplayName")]
        public string DisplayName { get; set; } //Like an about me

        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; } //Like an about me

        [Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; } //Like an about me

        [Required]
        [Display(Name = "Year")]
        public string Year { get; set; } //Like an about me
    }
}