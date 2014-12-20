using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage="Please enter your name.")]
        public string Name { set; get; }

        [Required(ErrorMessage="Please enter your email address.")]
        [EmailAddress]
        public string Email { set; get; }

        [Required(ErrorMessage="Please enter your phone number.")]
        [PhoneAttribute]
        public string Phone { set; get; }

        [Required(ErrorMessage="Please specify whether you will attend.")]
        public bool? WillAttend { set; get; }
    }
}